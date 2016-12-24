using EncodingAlgorithms.Encodings.TextEncodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncodingAlgorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            Base64Encoder b = new Base64Encoder();

            string buffer = "";
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                    buffer = buffer.Substring(0, buffer.Length - 1);
                else
                    buffer += key.KeyChar;

				string buHex = string.Join("", Encoding.UTF8.GetBytes (buffer).Select (x=>x.ToString ("X2")));
				string encoded = b.Encode(buffer, Encoding.UTF8, Encoding.ASCII);
				string enHex = string.Join("", Encoding.UTF8.GetBytes (encoded).Select (x=>x.ToString ("X2")));
				string decoded = b.Decode(encoded, Encoding.ASCII, Encoding.UTF8);
				string deHex = string.Join("", Encoding.UTF8.GetBytes (decoded).Select (x=>x.ToString ("X2")));
				Console.WriteLine("Input: {0}\n -> Hex: {5}\n\nEncoded: {1}\n -> Hex: {3}\nDecoded: {2}\n -> Hex: {4}\n--> Success: {6}", 
					buffer, 
					encoded, 
					decoded, 
					enHex, 
					deHex, 
					buHex,
					buffer.Equals (decoded)
				);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
