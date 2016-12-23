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

                string encoded = b.Encode(buffer, Encoding.ASCII);
                string decoded = b.Decode(encoded);
                Console.WriteLine("Input: {0}\nEncoded: {1}\nDecoded: {2}", buffer, encoded, decoded);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
