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
        public byte[] Encode(byte[] input)
        {
            using (MemoryStream imem = new MemoryStream(input))
                return Encode(imem);
        }
        public byte[] Encode(Stream input)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Encode(input, output);
                return output.ToArray();
            }
        }
        public void Encode(byte[] input, Stream output)
        {
            using (MemoryStream imem = new MemoryStream(input))
                Encode(imem, output);
        }
        public abstract void Encode(Stream input, Stream output);

        public byte[] Decode(byte[] input)
        {
            using (MemoryStream imem = new MemoryStream(input))
                return Decode(imem);
        }
        public byte[] Decode(Stream input)
        {
            using (MemoryStream output = new MemoryStream())
            {
                Decode(input, output);
                return output.ToArray();
            }
        }
        public void Decode(byte[] input, Stream output)
        {
            using (MemoryStream imem = new MemoryStream(input))
                Decode(imem, output);
        }
        public abstract void Decode(Stream input, Stream output);
        #endregion
    }
}
