using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EncodingAlgorithms.Encodings
{
    public abstract class DataEncoder
    {
        #region PROPERTIES
        #endregion

        #region CONSTRUCTORS
        #endregion

        #region METHODS
		/// <summary>
		/// Encode the specified input.
		/// </summary>
		/// <param name="input">Input.</param>
        public byte[] Encode(byte[] input)
        {
            using (MemoryStream imem = new MemoryStream(input))
                return Encode(imem);
        }
		/// <summary>
		/// Encode the specified input.
		/// </summary>
		/// <param name="input">Input.</param>
        public byte[] Encode(Stream input)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Encode(input, output);
                return output.ToArray();
            }
        }
		/// <summary>
		/// Encode the specified input to the specified output.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
        public void Encode(byte[] input, Stream output)
        {
            using (MemoryStream imem = new MemoryStream(input))
                Encode(imem, output);
        }
		/// <summary>
		/// Encode the specified input to the specified output.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
        public abstract void Encode(Stream input, Stream output);

		/// <summary>
		/// Decode the specified input.
		/// </summary>
		/// <param name="input">Input.</param>
        public byte[] Decode(byte[] input)
        {
            using (MemoryStream imem = new MemoryStream(input))
                return Decode(imem);
        }
		/// <summary>
		/// Decode the specified input.
		/// </summary>
		/// <param name="input">Input.</param>
        public byte[] Decode(Stream input)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Decode(input, output);
                return output.ToArray();
            }
        }
		/// <summary>
		/// Decode the specified input to the specified output.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
        public void Decode(byte[] input, Stream output)
        {
            using (MemoryStream imem = new MemoryStream(input))
                Decode(imem, output);
        }
		/// <summary>
		/// Decode the specified input to the specified output.
		/// </summary>
		/// <param name="input">Input.</param>
		/// <param name="output">Output.</param>
        public abstract void Decode(Stream input, Stream output);
        #endregion
    }
}
