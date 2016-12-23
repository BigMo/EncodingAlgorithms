using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EncodingAlgorithms.Encodings.TextEncodings
{
    public class Base64Encoder : TextEncoder
    {
        #region CONSTANTS
        private const string LIB = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        private static byte[] decodeLIB;
        #endregion

        public Base64Encoder() : base(Encoding.ASCII, Encoding.ASCII)
        {
            if(decodeLIB == null)
            {
                decodeLIB = new byte[byte.MaxValue];
                for (byte i = 0; i < LIB.Length; i++)
                    decodeLIB[LIB[i]] = i;
            }
        }

        public override void Decode(Stream input, Stream output)
        {
            byte[] idata = new byte[4];
            byte[] odata = new byte[3];
            int[] masks = { 0xFF << 16, 0xFF << 8, 0xFF };

            while (input.Position < input.Length)
            {
                byte toRead = (input.Length - input.Position) >= 4 ? (byte)4 : (byte)((input.Length - input.Position) % 4);
                idata[0] = idata[1] = idata[2] = idata[3] = 0;
                input.Read(idata, 0, toRead);

                idata[0] = decodeLIB[idata[0]];
                idata[1] = decodeLIB[idata[1]];
                idata[2] = decodeLIB[idata[2]];
                idata[3] = decodeLIB[idata[3]];
                int inValues = (idata[0] << 18) | (idata[1] << 12) | (idata[2] << 6) | idata[3];
                odata[0] = (byte)((inValues & masks[0]) >> 16);
                odata[1] = (byte)((inValues & masks[1]) >> 8);
                odata[2] = (byte)(inValues & masks[2]);
                output.Write(odata, 0, 3);
            }
        }

        public override void Encode(Stream input, Stream output)
        {
            byte[] idata = new byte[3];
            byte[] odata = new byte[4];
            int[] masks = { 0x3F << 18, 0x3F << 12, 0x3F << 6, 0x3F };

            while (input.Position < input.Length)
            {
                byte toRead = (input.Length - input.Position) >= 3 ? (byte)3 : (byte)((input.Length - input.Position) % 3);
                idata[0] = idata[1] = idata[2] = 0;
                input.Read(idata, 0, toRead);

                int inValues = (idata[0] << 16) | (idata[1] << 8) | idata[2];
                odata[0] = (byte)LIB[(byte)((inValues & masks[0]) >> 18)];
                odata[1] = (byte)LIB[(byte)((inValues & masks[1]) >> 12)];
                odata[2] = (byte)LIB[(byte)((inValues & masks[2]) >> 6)];
                odata[3] = (byte)LIB[(byte)(inValues & masks[3])];
                if (toRead < 3)
                {
                    odata[3] = (byte)'=';
                    if (toRead < 2)
                        odata[2] = (byte)'=';
                }
                output.Write(odata, 0, 4);
            }
        }
    }
}
