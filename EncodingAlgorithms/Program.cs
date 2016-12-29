using EncodingAlgorithms.Encodings.TextEncodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncodingAlgorithms.Encodings.BinaryEncodings;
using EncodingAlgorithms.Encodings;

namespace EncodingAlgorithms
{
    class Program
    {
		private static void RunAlgorithm(DataEncoder b) {
			string buffer = "";
			ConsoleKeyInfo key = new ConsoleKeyInfo();
			Console.WriteLine ("Begin typing!");
			bool mode = true;
			do
			{
				Console.WriteLine("Mode: {0}", mode ? "encode" : "decode");
				key = Console.ReadKey();
				Console.Clear();
				if (key.Key == ConsoleKey.PageUp){
					mode = !mode;
					continue;
				}
				if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
					buffer = buffer.Substring(0, buffer.Length - 1);
				else
					buffer += key.KeyChar;

				string buHex = string.Join("", Encoding.UTF8.GetBytes (buffer).Select (x=>x.ToString ("X2")));

				if (mode) {
					var encBytes = b.Encode(Encoding.UTF8.GetBytes(buffer));
					string encoded = Encoding.ASCII.GetString(encBytes);
					string enHex = string.Join("", encBytes.Select (x=>x.ToString ("X2")));

					var decBytes = b.Decode(encBytes);
					string decoded = Encoding.UTF8.GetString(decBytes);
					string deHex = string.Join("", decBytes.Select (x=>x.ToString ("X2")));
					Console.WriteLine("Algorithm: {7}\nInput: {0}\n -> Hex: {5}\n\nEncoded: {1}\n -> Hex: {3}\nDecoded: {2}\n -> Hex: {4}\n\n--> Success: {6}", 
						buffer, 
						encoded, 
						decoded, 
						enHex, 
						deHex, 
						buHex,
						buffer.Equals (decoded),
						b.GetType ().Name
					);
				} else {
					var buBytes = Encoding.ASCII.GetBytes(buffer);
					var decBytes = b.Decode(buBytes);
					string decoded = Encoding.UTF8.GetString(decBytes);
					string deHex = string.Join("", decBytes.Select (x=>x.ToString ("X2")));

					var encBytes = b.Encode(decBytes);
					string encoded = Encoding.ASCII.GetString(encBytes);
					string enHex = string.Join("", encBytes.Select (x=>x.ToString ("X2")));
					Console.WriteLine("Algorithm: {7}\nInput: {0}\n -> Hex: {5}\n\nDecoded: {2}\n -> Hex: {4}\nEncoded: {1}\n -> Hex: {3}\n\n--> Success: {6}", 
						buffer, 
						encoded, 
						decoded, 
						enHex, 
						deHex, 
						buHex,
						buffer.Equals (decoded),
						b.GetType ().Name
					);
				}
			} while (key.Key != ConsoleKey.Escape);
		}

        public static void Main(string[] args)
        {
			//RunAlgorithm (new Base64Encoder());
			RunAlgorithm (new UuEncoder());
        }
    }
}
