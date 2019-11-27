namespace Revamped_BnS_Buddy.Functions
{
    class BNSXorEncryption
    {
        private byte[] encKey;

        private byte[] decKey;

        private int encCounter;

        private int decCounter;

        private int encSum;

        private int decSum;

        private byte[] key;

        public BNSXorEncryption(byte[] keyInt)
        {
            key = keyInt;
        }

        public byte[] Encrypt(byte[] src, int offset, int len)
        {
            if (encKey == null)
            {
                if (key == null)
                {
                    return null;
                }
                encKey = new byte[key.Length];
                key.CopyTo(encKey, 0);
                encCounter = 0;
            }
            return BlockEncrypt(src, encKey, ref encCounter, ref encSum);
        }

        public byte[] Decrypt(byte[] src, int offset, int len)
        {
            if (decKey == null)
            {
                if (key == null)
                {
                    return null;
                }
                decKey = new byte[key.Length];
                key.CopyTo(decKey, 0);
                decCounter = 0;
            }
            return BlockEncrypt(src, decKey, ref decCounter, ref decSum);
        }

        private byte[] BlockEncrypt(byte[] src, byte[] key, ref int counter, ref int sum)
        {
            for (int i = 0; i < src.Length; i++)
            {
                int num = counter = ((counter + 1) & 0xFF);
                int num2 = sum = ((sum + key[num]) & 0xFF);
                int num3 = key[num];
                key[num] = key[num2];
                key[num2] = (byte)num3;
                src[i] = (byte)(src[i] ^ key[(key[sum] + key[counter]) & 0xFF]);
            }
            return src;
        }
    }
}
