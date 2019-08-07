using System;
using System.IO;

namespace BNSDat
{
    internal class BXML
    {
        private BXML_CONTENT _content = new BXML_CONTENT();

        private byte[] XOR_KEY
        {
            get
            {
                return _content.XOR_KEY;
            }
            set
            {
                _content.XOR_KEY = value;
            }
        }

        public BXML(byte[] xor)
        {
            XOR_KEY = xor;
        }

        public void Load(Stream iStream, BXML_TYPE iType)
        {
            _content.Read(iStream, iType);
        }

        public void Save(Stream oStream, BXML_TYPE oType)
        {
            _content.Write(oStream, oType);
        }

        public BXML_TYPE DetectType(Stream iStream)
        {
            int num = (int)iStream.Position;
            iStream.Position = 0L;
            byte[] array = new byte[13];
            iStream.Read(array, 0, 13);
            iStream.Position = num;
            BXML_TYPE result = BXML_TYPE.BXML_UNKNOWN;
            if (BitConverter.ToString(array).Replace("-", "").Replace("00", "")
                .Contains(BitConverter.ToString(new byte[5]
                {
                    60,
                    63,
                    120,
                    109,
                    108
                }).Replace("-", "")))
            {
                result = BXML_TYPE.BXML_PLAIN;
            }
            if (array[7] == 66 && array[6] == 76 && array[5] == 83 && array[4] == 79 && array[3] == 66 && array[2] == 88 && array[1] == 77 && array[0] == 76)
            {
                result = BXML_TYPE.BXML_BINARY;
            }
            return result;
        }
    }
}
