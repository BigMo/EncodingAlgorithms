using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EncodingAlgorithms.Encodings.TextEncodings
{
    public abstract class TextEncoder : DataEncoder
    {
     	#region METHODS
		/// <summary>
		/// Encodes the specified text using the given encoding to the output
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="enc">Enc.</param>
		/// <param name="output">Output.</param>
        public void Encode(string input, Encoding enc, Stream output)
        {
            this.Encode(enc.GetBytes(input), output);
        }
		/// <summary>
		/// Encode the specified input using the given encoding to string
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
		/// <param name="encIn">Enc.</param>
		/// <param name="encOut">Enc.</param>
		public string Encode(string input, Encoding encIn, Encoding encOut)
        {
            using (MemoryStream omem = new MemoryStream())
            {
                this.Encode(input, encIn, omem);
				return encOut.GetString(omem.ToArray());
            }
        }

		/// <summary>
		/// Decode the specified text
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="enc">Enc.</param>
		/// <param name="output">Output.</param>
        public void Decode(string input, Encoding enc, Stream output)
        {
            this.Decode(enc.GetBytes(input), output);
        }
		/// <summary>
		/// Decode the specified text
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
		/// <param name="enc">Enc.</param>
		public string Decode(string input, Encoding encIn, Encoding encOut)
        { 
            using (MemoryStream omem = new MemoryStream())
            {
                this.Decode(input, encIn, omem);
				return encOut.GetString(omem.ToArray());
            }
        }
        #endregion
    }
}
