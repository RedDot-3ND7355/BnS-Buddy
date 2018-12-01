using BNSDat;
using Ionic.Zlib;
using Revamped_BnS_Buddy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BNSDat
{

    public class BNSDat
    {
        public string AES_KEY = "bns_obt_kr_2014#";

        public byte[] XOR_KEY = new byte[16]
        {
        164,
        159,
        216,
        179,
        246,
        142,
        57,
        194,
        45,
        224,
        97,
        117,
        92,
        75,
        26,
        7
        };

        private byte[] Decrypt(byte[] buffer, int size)
        {
            int length = AES_KEY.Length;
            int num = size + length;
            byte[] array = new byte[num];
            byte[] array2 = new byte[num];
            buffer.CopyTo(array2, 0);
            buffer = null;
            Rijndael rijndael = Rijndael.Create();
            rijndael.Mode = CipherMode.ECB;
            rijndael.CreateDecryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]).TransformBlock(array2, 0, num, array, 0);
            array2 = array;
            array = new byte[size];
            Array.Copy(array2, 0, array, 0, size);
            array2 = null;
            return array;
        }

        private byte[] Deflate(byte[] buffer, int sizeCompressed, int sizeDecompressed)
        {
            byte[] array = ZlibStream.UncompressBuffer(buffer);
            if (array.Length != sizeDecompressed)
            {
                byte[] array2 = new byte[sizeDecompressed];
                if (array.Length > sizeDecompressed)
                {
                    Array.Copy(array, 0, array2, 0, sizeDecompressed);
                }
                else
                {
                    Array.Copy(array, 0, array2, 0, array.Length);
                }
                array = array2;
                array2 = null;
            }
            return array;
        }

        private byte[] Unpack(byte[] buffer, int sizeStored, int sizeSheared, int sizeUnpacked, bool isEncrypted, bool isCompressed)
        {
            byte[] array = buffer;
            if (isEncrypted)
            {
                array = Decrypt(array, sizeStored);
            }
            if (isCompressed)
            {
                array = Deflate(array, sizeSheared, sizeUnpacked);
            }
            if (array == buffer)
            {
                array = new byte[sizeUnpacked];
                if (sizeSheared < sizeUnpacked)
                {
                    Array.Copy(buffer, 0, array, 0, sizeSheared);
                }
                else
                {
                    Array.Copy(buffer, 0, array, 0, sizeUnpacked);
                }
            }
            return array;
        }

        private byte[] Inflate(byte[] buffer, int sizeDecompressed, out int sizeCompressed, int compressionLevel)
        {
            MemoryStream memoryStream = new MemoryStream();
            ZlibStream zlibStream = new ZlibStream(memoryStream, CompressionMode.Compress, (CompressionLevel)compressionLevel, leaveOpen: true);
            zlibStream.Write(buffer, 0, sizeDecompressed);
            zlibStream.Flush();
            zlibStream.Close();
            sizeCompressed = (int)memoryStream.Length;
            return memoryStream.ToArray();
        }

        private byte[] Encrypt(byte[] buffer, int size, out int sizePadded)
        {
            int length = AES_KEY.Length;
            sizePadded = size + (length - size % length);
            byte[] array = new byte[sizePadded];
            byte[] array2 = new byte[sizePadded];
            Array.Copy(buffer, 0, array2, 0, buffer.Length);
            buffer = null;
            Rijndael rijndael = Rijndael.Create();
            rijndael.Mode = CipherMode.ECB;
            rijndael.CreateEncryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]).TransformBlock(array2, 0, sizePadded, array, 0);
            array2 = null;
            return array;
        }

        private byte[] Pack(byte[] buffer, int sizeUnpacked, out int sizeSheared, out int sizeStored, bool encrypt, bool compress, int compressionLevel)
        {
            byte[] array = buffer;
            buffer = null;
            sizeSheared = sizeUnpacked;
            sizeStored = sizeSheared;
            if (compress)
            {
                byte[] array2 = Inflate(array, sizeUnpacked, out sizeSheared, compressionLevel);
                sizeStored = sizeSheared;
                array = array2;
            }
            if (encrypt)
            {
                array = Encrypt(array, sizeSheared, out sizeStored);
            }
            return array;
        }

        public void Extract(string FileName, bool is64 = false)
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            binaryReader.ReadBytes(8);
            binaryReader.ReadUInt32();
            binaryReader.ReadBytes(5);
            if (!is64)
            {
                binaryReader.ReadInt32();
            }
            else
            {
                binaryReader.ReadInt64();
            }
            int num = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            bool isCompressed = binaryReader.ReadByte() == 1;
            bool isEncrypted = binaryReader.ReadByte() == 1;
            binaryReader.ReadBytes(62);
            int num2 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            int sizeUnpacked = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            byte[] buffer = binaryReader.ReadBytes(num2);
            int num3 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            num3 = (int)binaryReader.BaseStream.Position;
            byte[] buffer2 = Unpack(buffer, num2, num2, sizeUnpacked, isEncrypted, isCompressed);
            buffer = null;
            MemoryStream memoryStream = new MemoryStream(buffer2);
            BinaryReader binaryReader2 = new BinaryReader(memoryStream);
            for (int i = 0; i < num; i++)
            {
                BPKG_FTE bPKG_FTE = new BPKG_FTE();
                bPKG_FTE.FilePathLength = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FilePath = Encoding.Unicode.GetString(binaryReader2.ReadBytes(bPKG_FTE.FilePathLength * 2));
                bPKG_FTE.Unknown_001 = binaryReader2.ReadByte();
                bPKG_FTE.IsCompressed = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.IsEncrypted = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.Unknown_002 = binaryReader2.ReadByte();
                bPKG_FTE.FileDataSizeUnpacked = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeSheared = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeStored = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataOffset = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32()) + num3;
                bPKG_FTE.Padding = binaryReader2.ReadBytes(60);
                string text = FileName + ".files\\" + bPKG_FTE.FilePath;
                if (!Directory.Exists(new FileInfo(text).DirectoryName))
                {
                    Directory.CreateDirectory(new FileInfo(text).DirectoryName);
                }
                binaryReader.BaseStream.Position = bPKG_FTE.FileDataOffset;
                buffer = binaryReader.ReadBytes(bPKG_FTE.FileDataSizeStored);
                byte[] array = Unpack(buffer, bPKG_FTE.FileDataSizeStored, bPKG_FTE.FileDataSizeSheared, bPKG_FTE.FileDataSizeUnpacked, bPKG_FTE.IsEncrypted, bPKG_FTE.IsCompressed);
                buffer = null;
                bPKG_FTE = null;
                if (text.EndsWith("xml") || text.EndsWith("x16"))
                {
                    MemoryStream memoryStream2 = new MemoryStream();
                    MemoryStream memoryStream3 = new MemoryStream(array);
                    BXML bXML = new BXML(XOR_KEY);
                    Convert(memoryStream3, bXML.DetectType(memoryStream3), memoryStream2, BXML_TYPE.BXML_PLAIN);
                    memoryStream3.Close();
                    File.WriteAllBytes(text, memoryStream2.ToArray());
                    memoryStream2.Close();
                    array = null;
                }
                else
                {
                    File.WriteAllBytes(text, array);
                    array = null;
                }
                string value = "Extracting: " + i.ToString() + "/" + num.ToString();
                Form1.CurrentForm.SortOutputHandler(value);
            }
            Form1.CurrentForm.SortOutputHandler("Done!");
            binaryReader2.Close();
            memoryStream.Close();
            binaryReader2 = null;
            memoryStream = null;
            binaryReader.Close();
            fileStream.Close();
            binaryReader = null;
            fileStream = null;
        }

        public Dictionary<string, byte[]> ExtractFile(string FileName, List<string> filesToExtract, bool is64 = false)
        {
            Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
            FileStream fileStream = new FileStream(FileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            binaryReader.ReadBytes(8);
            binaryReader.ReadUInt32();
            binaryReader.ReadBytes(5);
            if (!is64)
            {
                binaryReader.ReadInt32();
            }
            else
            {
                binaryReader.ReadInt64();
            }
            int num = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            bool isCompressed = binaryReader.ReadByte() == 1;
            bool isEncrypted = binaryReader.ReadByte() == 1;
            binaryReader.ReadBytes(62);
            int num2 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            int sizeUnpacked = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            byte[] buffer = binaryReader.ReadBytes(num2);
            int num3 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            num3 = (int)binaryReader.BaseStream.Position;
            byte[] buffer2 = Unpack(buffer, num2, num2, sizeUnpacked, isEncrypted, isCompressed);
            buffer = null;
            MemoryStream memoryStream = new MemoryStream(buffer2);
            BinaryReader binaryReader2 = new BinaryReader(memoryStream);
            int num4 = 0;
            for (int i = 0; i < num; i++)
            {
                if (num4 == filesToExtract.Count)
                {
                    break;
                }
                BPKG_FTE bPKG_FTE = new BPKG_FTE();
                bPKG_FTE.FilePathLength = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FilePath = Encoding.Unicode.GetString(binaryReader2.ReadBytes(bPKG_FTE.FilePathLength * 2));
                bPKG_FTE.Unknown_001 = binaryReader2.ReadByte();
                bPKG_FTE.IsCompressed = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.IsEncrypted = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.Unknown_002 = binaryReader2.ReadByte();
                bPKG_FTE.FileDataSizeUnpacked = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeSheared = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeStored = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataOffset = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32()) + num3;
                bPKG_FTE.Padding = binaryReader2.ReadBytes(60);
                if (bPKG_FTE.FilePath != null && filesToExtract.Contains(bPKG_FTE.FilePath.ToLower()))
                {
                    binaryReader.BaseStream.Position = bPKG_FTE.FileDataOffset;
                    buffer = binaryReader.ReadBytes(bPKG_FTE.FileDataSizeStored);
                    byte[] array = Unpack(buffer, bPKG_FTE.FileDataSizeStored, bPKG_FTE.FileDataSizeSheared, bPKG_FTE.FileDataSizeUnpacked, bPKG_FTE.IsEncrypted, bPKG_FTE.IsCompressed);
                    buffer = null;
                    if (bPKG_FTE.FilePath.ToLower().EndsWith("xml") || bPKG_FTE.FilePath.ToLower().EndsWith("x16"))
                    {
                        MemoryStream memoryStream2 = new MemoryStream();
                        MemoryStream memoryStream3 = new MemoryStream(array);
                        BXML bXML = new BXML(XOR_KEY);
                        Convert(memoryStream3, bXML.DetectType(memoryStream3), memoryStream2, BXML_TYPE.BXML_PLAIN);
                        memoryStream3.Close();
                        array = memoryStream2.ToArray();
                        memoryStream2.Close();
                    }
                    dictionary.Add(bPKG_FTE.FilePath, array);
                    num4++;
                    bPKG_FTE = null;
                    array = null;
                }
            }
            binaryReader2.Close();
            memoryStream.Close();
            binaryReader2 = null;
            memoryStream = null;
            binaryReader.Close();
            fileStream.Close();
            binaryReader = null;
            fileStream = null;
            return dictionary;
        }

        public void CompressFiles(string FileName, Dictionary<string, byte[]> filesToReplace, bool is64 = false, int compressionLevel = 1)
        {
            MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(FileName));
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            byte[] buffer = binaryReader.ReadBytes(8);
            uint value = binaryReader.ReadUInt32();
            byte[] buffer2 = binaryReader.ReadBytes(5);
            int num = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            int num2 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            bool flag = binaryReader.ReadByte() == 1;
            bool flag2 = binaryReader.ReadByte() == 1;
            byte[] buffer3 = binaryReader.ReadBytes(62);
            int num3 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            int sizeUnpacked = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            byte[] buffer4 = binaryReader.ReadBytes(num3);
            int num4 = (int)(is64 ? binaryReader.ReadInt64() : binaryReader.ReadInt32());
            num4 = (int)binaryReader.BaseStream.Position;
            byte[] buffer5 = Unpack(buffer4, num3, num3, sizeUnpacked, flag2, flag);
            buffer4 = null;
            MemoryStream memoryStream2 = new MemoryStream(buffer5);
            BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
            List<BPKG_FTE> list = new List<BPKG_FTE>();
            MemoryStream memoryStream3 = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream3);
            MemoryStream memoryStream4 = new MemoryStream();
            BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream4);
            byte[] buffer6;
            for (int i = 0; i < num2; i++)
            {
                BPKG_FTE bPKG_FTE = new BPKG_FTE();
                bPKG_FTE.FilePathLength = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FilePath = Encoding.Unicode.GetString(binaryReader2.ReadBytes(bPKG_FTE.FilePathLength * 2));
                bPKG_FTE.Unknown_001 = binaryReader2.ReadByte();
                bPKG_FTE.IsCompressed = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.IsEncrypted = (binaryReader2.ReadByte() == 1);
                bPKG_FTE.Unknown_002 = binaryReader2.ReadByte();
                bPKG_FTE.FileDataSizeUnpacked = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeSheared = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataSizeStored = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32());
                bPKG_FTE.FileDataOffset = (int)(is64 ? binaryReader2.ReadInt64() : binaryReader2.ReadInt32()) + num4;
                bPKG_FTE.Padding = binaryReader2.ReadBytes(60);
                if (bPKG_FTE.FilePath != null && filesToReplace.Keys.Contains(bPKG_FTE.FilePath.ToLower()))
                {
                    MemoryStream memoryStream5 = new MemoryStream(filesToReplace[bPKG_FTE.FilePath.ToLower()]);
                    MemoryStream memoryStream6 = new MemoryStream();
                    if (bPKG_FTE.FilePath.ToLower().EndsWith(".xml") || bPKG_FTE.FilePath.ToLower().EndsWith(".x16"))
                    {
                        BXML bXML = new BXML(XOR_KEY);
                        Convert(memoryStream5, bXML.DetectType(memoryStream5), memoryStream6, BXML_TYPE.BXML_BINARY);
                    }
                    else
                    {
                        memoryStream5.CopyTo(memoryStream6);
                    }
                    memoryStream5.Close();
                    memoryStream5 = null;
                    bPKG_FTE.FileDataOffset = (int)binaryWriter.BaseStream.Position;
                    bPKG_FTE.FileDataSizeUnpacked = (int)memoryStream6.Length;
                    buffer6 = memoryStream6.ToArray();
                    memoryStream6.Close();
                    memoryStream6 = null;
                    buffer4 = Pack(buffer6, bPKG_FTE.FileDataSizeUnpacked, out bPKG_FTE.FileDataSizeSheared, out bPKG_FTE.FileDataSizeStored, bPKG_FTE.IsEncrypted, bPKG_FTE.IsCompressed, compressionLevel);
                    buffer6 = null;
                    binaryWriter.Write(buffer4);
                    buffer4 = null;
                    list.Add(bPKG_FTE);
                }
                else
                {
                    binaryReader.BaseStream.Position = bPKG_FTE.FileDataOffset;
                    bPKG_FTE.FileDataOffset = (int)binaryWriter.BaseStream.Position;
                    list.Add(bPKG_FTE);
                    binaryWriter.Write(binaryReader.ReadBytes(bPKG_FTE.FileDataSizeStored));
                }
            }
            binaryReader2.Close();
            memoryStream2.Close();
            binaryReader2 = null;
            memoryStream2 = null;
            binaryReader.Close();
            memoryStream.Close();
            binaryReader = null;
            memoryStream = null;
            foreach (BPKG_FTE item in list)
            {
                if (is64)
                {
                    binaryWriter2.Write((long)item.FilePathLength);
                }
                else
                {
                    binaryWriter2.Write(item.FilePathLength);
                }
                binaryWriter2.Write(Encoding.Unicode.GetBytes(item.FilePath));
                binaryWriter2.Write(item.Unknown_001);
                binaryWriter2.Write(item.IsCompressed);
                binaryWriter2.Write(item.IsEncrypted);
                binaryWriter2.Write(item.Unknown_002);
                if (is64)
                {
                    binaryWriter2.Write((long)item.FileDataSizeUnpacked);
                }
                else
                {
                    binaryWriter2.Write(item.FileDataSizeUnpacked);
                }
                if (is64)
                {
                    binaryWriter2.Write((long)item.FileDataSizeSheared);
                }
                else
                {
                    binaryWriter2.Write(item.FileDataSizeSheared);
                }
                if (is64)
                {
                    binaryWriter2.Write((long)item.FileDataSizeStored);
                }
                else
                {
                    binaryWriter2.Write(item.FileDataSizeStored);
                }
                if (is64)
                {
                    binaryWriter2.Write((long)item.FileDataOffset);
                }
                else
                {
                    binaryWriter2.Write(item.FileDataOffset);
                }
                binaryWriter2.Write(item.Padding);
            }
            MemoryStream memoryStream7 = new MemoryStream();
            BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream7);
            binaryWriter3.Write(buffer);
            binaryWriter3.Write(value);
            binaryWriter3.Write(buffer2);
            num = (int)binaryWriter.BaseStream.Length;
            if (is64)
            {
                binaryWriter3.Write((long)num);
                binaryWriter3.Write((long)num2);
            }
            else
            {
                binaryWriter3.Write(num);
                binaryWriter3.Write(num2);
            }
            binaryWriter3.Write(flag);
            binaryWriter3.Write(flag2);
            binaryWriter3.Write(buffer3);
            sizeUnpacked = (int)binaryWriter2.BaseStream.Length;
            int sizeSheared = sizeUnpacked;
            num3 = sizeUnpacked;
            buffer6 = memoryStream4.ToArray();
            binaryWriter2.Close();
            memoryStream4.Close();
            binaryWriter2 = null;
            memoryStream4 = null;
            buffer4 = Pack(buffer6, sizeUnpacked, out sizeSheared, out num3, flag2, flag, compressionLevel);
            buffer6 = null;
            if (is64)
            {
                binaryWriter3.Write((long)num3);
            }
            else
            {
                binaryWriter3.Write(num3);
            }
            if (is64)
            {
                binaryWriter3.Write((long)sizeUnpacked);
            }
            else
            {
                binaryWriter3.Write(sizeUnpacked);
            }
            binaryWriter3.Write(buffer4);
            buffer4 = null;
            num4 = (int)memoryStream7.Position + (is64 ? 8 : 4);
            if (is64)
            {
                binaryWriter3.Write((long)num4);
            }
            else
            {
                binaryWriter3.Write(num4);
            }
            buffer4 = memoryStream3.ToArray();
            binaryWriter.Close();
            memoryStream3.Close();
            binaryWriter = null;
            memoryStream3 = null;
            binaryWriter3.Write(buffer4);
            buffer4 = null;
            File.WriteAllBytes(FileName, memoryStream7.ToArray());
            binaryWriter3.Close();
            memoryStream7.Close();
            binaryWriter3 = null;
            memoryStream7 = null;
        }

        public void Compress(string Folder, bool is64 = false, int compression = 1)
        {
            string[] array = Directory.EnumerateFiles(Folder, "*", SearchOption.AllDirectories).ToArray();
            int num = array.Count();
            BPKG_FTE bPKG_FTE = new BPKG_FTE();
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            MemoryStream memoryStream2 = new MemoryStream();
            BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
            byte[] buffer;
            byte[] buffer2;
            for (int i = 0; i < num; i++)
            {
                string text = array[i].Replace(Folder, "").TrimStart('\\');
                bPKG_FTE.FilePathLength = text.Length;
                if (is64)
                {
                    binaryWriter.Write((long)bPKG_FTE.FilePathLength);
                }
                else
                {
                    binaryWriter.Write(bPKG_FTE.FilePathLength);
                }
                bPKG_FTE.FilePath = text;
                binaryWriter.Write(Encoding.Unicode.GetBytes(bPKG_FTE.FilePath));
                bPKG_FTE.Unknown_001 = 2;
                binaryWriter.Write(bPKG_FTE.Unknown_001);
                bPKG_FTE.IsCompressed = true;
                binaryWriter.Write(bPKG_FTE.IsCompressed);
                bPKG_FTE.IsEncrypted = true;
                binaryWriter.Write(bPKG_FTE.IsEncrypted);
                bPKG_FTE.Unknown_002 = 0;
                binaryWriter.Write(bPKG_FTE.Unknown_002);
                FileStream fileStream = new FileStream(array[i], FileMode.Open);
                MemoryStream memoryStream3 = new MemoryStream();
                if (text.EndsWith(".xml") || text.EndsWith(".x16"))
                {
                    BXML bXML = new BXML(XOR_KEY);
                    Convert(fileStream, bXML.DetectType(fileStream), memoryStream3, BXML_TYPE.BXML_BINARY);
                }
                else
                {
                    fileStream.CopyTo(memoryStream3);
                }
                fileStream.Close();
                fileStream = null;
                bPKG_FTE.FileDataOffset = (int)binaryWriter2.BaseStream.Position;
                bPKG_FTE.FileDataSizeUnpacked = (int)memoryStream3.Length;
                if (is64)
                {
                    binaryWriter.Write((long)bPKG_FTE.FileDataSizeUnpacked);
                }
                else
                {
                    binaryWriter.Write(bPKG_FTE.FileDataSizeUnpacked);
                }
                buffer = memoryStream3.ToArray();
                memoryStream3.Close();
                memoryStream3 = null;
                buffer2 = Pack(buffer, bPKG_FTE.FileDataSizeUnpacked, out bPKG_FTE.FileDataSizeSheared, out bPKG_FTE.FileDataSizeStored, bPKG_FTE.IsEncrypted, bPKG_FTE.IsCompressed, compression);
                buffer = null;
                binaryWriter2.Write(buffer2);
                buffer2 = null;
                if (is64)
                {
                    binaryWriter.Write((long)bPKG_FTE.FileDataSizeSheared);
                }
                else
                {
                    binaryWriter.Write(bPKG_FTE.FileDataSizeSheared);
                }
                if (is64)
                {
                    binaryWriter.Write((long)bPKG_FTE.FileDataSizeStored);
                }
                else
                {
                    binaryWriter.Write(bPKG_FTE.FileDataSizeStored);
                }
                if (is64)
                {
                    binaryWriter.Write((long)bPKG_FTE.FileDataOffset);
                }
                else
                {
                    binaryWriter.Write(bPKG_FTE.FileDataOffset);
                }
                bPKG_FTE.Padding = new byte[60];
                binaryWriter.Write(bPKG_FTE.Padding);
                string value = "Compiling: " + i.ToString() + "/" + num.ToString();
                Form1.CurrentForm.SortOutputHandler(value);
            }
            Form1.CurrentForm.SortOutputHandler("Packing!");
            MemoryStream memoryStream4 = new MemoryStream();
            BinaryWriter binaryWriter3 = new BinaryWriter(memoryStream4);
            byte[] buffer3 = new byte[8]
            {
            85,
            79,
            83,
            69,
            68,
            65,
            76,
            66
            };
            binaryWriter3.Write(buffer3);
            int value2 = 2;
            binaryWriter3.Write(value2);
            byte[] buffer4 = new byte[5];
            binaryWriter3.Write(buffer4);
            int num2 = (int)binaryWriter2.BaseStream.Length;
            if (is64)
            {
                binaryWriter3.Write((long)num2);
                binaryWriter3.Write((long)num);
            }
            else
            {
                binaryWriter3.Write(num2);
                binaryWriter3.Write(num);
            }
            bool flag = true;
            binaryWriter3.Write(flag);
            bool flag2 = true;
            binaryWriter3.Write(flag2);
            byte[] buffer5 = new byte[62];
            binaryWriter3.Write(buffer5);
            int num3 = (int)binaryWriter.BaseStream.Length;
            int sizeSheared = num3;
            int sizeStored = num3;
            buffer = memoryStream.ToArray();
            binaryWriter.Close();
            memoryStream.Close();
            binaryWriter = null;
            memoryStream = null;
            buffer2 = Pack(buffer, num3, out sizeSheared, out sizeStored, flag2, flag, compression);
            buffer = null;
            if (is64)
            {
                binaryWriter3.Write((long)sizeStored);
            }
            else
            {
                binaryWriter3.Write(sizeStored);
            }
            if (is64)
            {
                binaryWriter3.Write((long)num3);
            }
            else
            {
                binaryWriter3.Write(num3);
            }
            binaryWriter3.Write(buffer2);
            buffer2 = null;
            int num4 = (int)memoryStream4.Position + (is64 ? 8 : 4);
            if (is64)
            {
                binaryWriter3.Write((long)num4);
            }
            else
            {
                binaryWriter3.Write(num4);
            }
            buffer2 = memoryStream2.ToArray();
            binaryWriter2.Close();
            memoryStream2.Close();
            binaryWriter2 = null;
            memoryStream2 = null;
            binaryWriter3.Write(buffer2);
            buffer2 = null;
            File.WriteAllBytes(Folder.Replace(".files", ""), memoryStream4.ToArray());
            binaryWriter3.Close();
            memoryStream4.Close();
            binaryWriter3 = null;
            memoryStream4 = null;
            Form1.CurrentForm.SortOutputHandler("Done!");
        }

        private void Convert(Stream iStream, BXML_TYPE iType, Stream oStream, BXML_TYPE oType)
        {
            if ((iType == BXML_TYPE.BXML_PLAIN && oType == BXML_TYPE.BXML_BINARY) || (iType == BXML_TYPE.BXML_BINARY && oType == BXML_TYPE.BXML_PLAIN))
            {
                BXML bXML = new BXML(XOR_KEY);
                bXML.Load(iStream, iType);
                bXML.Save(oStream, oType);
            }
            else
            {
                iStream.CopyTo(oStream);
            }
        }
    }
}