using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EncodingAlgorithms.Encodings.TextEncodings
{
    public abstract class TextEncoder : DataEncoder
    {
        #region PROPERTIES
        protected Encoding DecodingEncoding { get; set; }
        protected Encoding EncodingEncoding { get; set; }
        #endregion

        #region CONSTRUCTORS
        protected TextEncoder(Encoding decodingEncoding, Encoding encodingEncoding)
        {
            DecodingEncoding = decodingEncoding;
            EncodingEncoding = encodingEncoding;
        }
        #endregion

        #region METHODS
        public void Encode(string input, Encoding enc, Stream output)
        {
            this.Encode(enc.GetBytes(input), output);
        }
        public string Encode(string input, Encoding enc)
        {
            using (MemoryStream omem = new MemoryStream())
            {
                this.Encode(input, enc, omem);
                return EncodingEncoding.GetString(omem.ToArray());
            }
        }
        public void Decode(string input, Stream output)
        {
            this.Decode(DecodingEncoding.GetBytes(input), output);
        }
        public string Decode(string input)
        { 
            using (MemoryStream omem = new MemoryStream())
            {
                this.Decode(input, omem);
                return EncodingEncoding.GetString(omem.ToArray());
            }
        }
        #endregion
    }
}
