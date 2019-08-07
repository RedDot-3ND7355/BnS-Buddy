using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BNSDat
{
    internal class BXML_CONTENT
    {
        public byte[] XOR_KEY;

        private bool Keep_XML_WhiteSpace = true;

        private byte[] Signature;

        private int Version;

        private int FileSize;

        private byte[] Padding;

        private bool Unknown;

        private int OriginalPathLength;

        private byte[] OriginalPath;

        private int AutoID;

        private XmlDocument Nodes = new XmlDocument();

        private XmlNode origName;

        private void Xor(byte[] buffer, int size)
        {
            for (int i = 0; i < size; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ XOR_KEY[i % XOR_KEY.Length]);
            }
        }

        public void Read(Stream iStream, BXML_TYPE iType)
        {
            if (iType == BXML_TYPE.BXML_PLAIN)
            {
                Signature = new byte[8]
                {
                    76,
                    77,
                    88,
                    66,
                    79,
                    83,
                    76,
                    66
                };
                Version = 3;
                FileSize = 85;
                Padding = new byte[64];
                Unknown = true;
                OriginalPathLength = 0;
                Nodes.PreserveWhitespace = Keep_XML_WhiteSpace;
                Nodes.Load(iStream);
                XmlNode xmlNode = Nodes.DocumentElement.ChildNodes.OfType<XmlComment>().First();
                origName = xmlNode;
                if (xmlNode != null && xmlNode.NodeType == XmlNodeType.Comment)
                {
                    string innerText = xmlNode.InnerText;
                    OriginalPathLength = innerText.Length;
                    OriginalPath = Encoding.Unicode.GetBytes(innerText);
                    Xor(OriginalPath, 2 * OriginalPathLength);
                    if (Nodes.PreserveWhitespace && xmlNode.NextSibling.NodeType == XmlNodeType.Whitespace)
                    {
                        Nodes.DocumentElement.RemoveChild(xmlNode.NextSibling);
                    }
                }
                else
                {
                    OriginalPath = new byte[2 * OriginalPathLength];
                }
            }
            if (iType == BXML_TYPE.BXML_BINARY)
            {
                Signature = new byte[8];
                BinaryReader binaryReader = new BinaryReader(iStream);
                binaryReader.BaseStream.Position = 0L;
                Signature = binaryReader.ReadBytes(8);
                Version = binaryReader.ReadInt32();
                FileSize = binaryReader.ReadInt32();
                Padding = binaryReader.ReadBytes(64);
                Unknown = (binaryReader.ReadByte() == 1);
                OriginalPathLength = binaryReader.ReadInt32();
                OriginalPath = binaryReader.ReadBytes(2 * OriginalPathLength);
                AutoID = 1;
                ReadNode(iStream);
                byte[] originalPath = OriginalPath;
                Xor(originalPath, 2 * OriginalPathLength);
                XmlComment newChild = Nodes.CreateComment(Encoding.Unicode.GetString(originalPath));
                Nodes.DocumentElement.PrependChild(newChild);
                XmlNode newChild2 = Nodes.CreateXmlDeclaration("1.0", "utf-8", null);
                Nodes.PrependChild(newChild2);
                if (FileSize != iStream.Position)
                {
                    throw new Exception($"Filesize Mismatch, expected size was {FileSize} while actual size was {iStream.Position}.");
                }
            }
        }

        public void Write(Stream oStream, BXML_TYPE oType)
        {
            if (oType == BXML_TYPE.BXML_PLAIN)
            {
                Nodes.Save(oStream);
            }
            if (oType == BXML_TYPE.BXML_BINARY)
            {
                BinaryWriter binaryWriter = new BinaryWriter(oStream);
                binaryWriter.Write(Signature);
                binaryWriter.Write(Version);
                binaryWriter.Write(FileSize);
                binaryWriter.Write(Padding);
                binaryWriter.Write(Unknown);
                binaryWriter.Write(OriginalPathLength);
                binaryWriter.Write(OriginalPath);
                AutoID = 1;
                WriteNode(oStream);
                FileSize = (int)oStream.Position;
                oStream.Position = 12L;
                binaryWriter.Write(FileSize);
            }
        }

        private void ReadNode(Stream iStream, XmlNode parent = null)
        {
            XmlNode xmlNode = null;
            BinaryReader binaryReader = new BinaryReader(iStream);
            int num = 1;
            if (parent != null)
            {
                num = binaryReader.ReadInt32();
            }
            if (num == 1)
            {
                xmlNode = Nodes.CreateElement("Text");
                int num2 = binaryReader.ReadInt32();
                for (int i = 0; i < num2; i++)
                {
                    int num3 = binaryReader.ReadInt32();
                    byte[] array = binaryReader.ReadBytes(2 * num3);
                    Xor(array, 2 * num3);
                    int num4 = binaryReader.ReadInt32();
                    byte[] array2 = binaryReader.ReadBytes(2 * num4);
                    Xor(array2, 2 * num4);
                    ((XmlElement)xmlNode).SetAttribute(Encoding.Unicode.GetString(array), Encoding.Unicode.GetString(array2));
                }
            }
            if (num == 2)
            {
                xmlNode = Nodes.CreateTextNode("");
                int num5 = binaryReader.ReadInt32();
                byte[] array3 = binaryReader.ReadBytes(num5 * 2);
                Xor(array3, 2 * num5);
                string temp = Encoding.Unicode.GetString(array3);
                if (temp.StartsWith("<!--"))
                {
                    xmlNode = Nodes.CreateComment("");
                    ((XmlComment)xmlNode).InnerText = temp.Substring(4, temp.Length - 7);
                }
                else
                    ((XmlText)xmlNode).InnerText = temp;
            }
            if (num > 2)
            {
                throw new Exception("Unknown XML Node Type");
            }
            binaryReader.ReadByte();
            int num6 = binaryReader.ReadInt32();
            byte[] array4 = binaryReader.ReadBytes(2 * num6);
            Xor(array4, 2 * num6);
            if (num == 1)
            {
                xmlNode = RenameNode(xmlNode, Encoding.Unicode.GetString(array4));
            }
            int num7 = binaryReader.ReadInt32();
            AutoID = binaryReader.ReadInt32();
            AutoID++;
            for (int j = 0; j < num7; j++)
            {
                ReadNode(iStream, xmlNode);
            }
            if (parent != null)
            {
                if (Keep_XML_WhiteSpace || num != 2 || !string.IsNullOrWhiteSpace(xmlNode.Value))
                {
                    parent.AppendChild(xmlNode);
                }
            }
            else
            {
                Nodes.AppendChild(xmlNode);
            }
        }

        public static XmlNode RenameNode(XmlNode node, string Name)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                XmlElement xmlElement = (XmlElement)node;
                XmlElement xmlElement2 = node.OwnerDocument.CreateElement(Name);
                while (xmlElement.HasAttributes)
                {
                    xmlElement2.SetAttributeNode(xmlElement.RemoveAttributeNode(xmlElement.Attributes[0]));
                }
                while (xmlElement.HasChildNodes)
                {
                    xmlElement2.AppendChild(xmlElement.FirstChild);
                }
                if (xmlElement.ParentNode != null)
                {
                    xmlElement.ParentNode.ReplaceChild(xmlElement2, xmlElement);
                }
                return xmlElement2;
            }
            return node;
        }

        private bool WriteNode(Stream oStream, XmlNode parent = null)
        {
            BinaryWriter binaryWriter = new BinaryWriter(oStream);
            XmlNode xmlNode = null;
            int num = 1;
            if (parent != null)
            {
                xmlNode = parent;
                if (xmlNode.NodeType == XmlNodeType.Element)
                {
                    num = 1;
                }
                if (xmlNode.NodeType == XmlNodeType.Text || xmlNode.NodeType == XmlNodeType.Whitespace)
                {
                    num = 2;
                }
                if (xmlNode.NodeType == XmlNodeType.Comment)
                {
                    if (xmlNode.InnerText == origName.InnerText)
                        return false;

                    num = -1;
                }
                if (num == -1)
                    binaryWriter.Write(2);
                else
                    binaryWriter.Write(num);
            }
            else
            {
                xmlNode = Nodes.DocumentElement;
            }
            if (num == 1)
            {
                int num2 = (int)oStream.Position;
                int num3 = 0;
                binaryWriter.Write(num3);
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    string name = attribute.Name;
                    int length = name.Length;
                    binaryWriter.Write(length);
                    byte[] bytes = Encoding.Unicode.GetBytes(name);
                    Xor(bytes, 2 * length);
                    binaryWriter.Write(bytes);
                    string value = attribute.Value;
                    int length2 = value.Length;
                    binaryWriter.Write(length2);
                    byte[] bytes2 = Encoding.Unicode.GetBytes(value);
                    Xor(bytes2, 2 * length2);
                    binaryWriter.Write(bytes2);
                    num3++;
                }
                int num4 = (int)oStream.Position;
                oStream.Position = num2;
                binaryWriter.Write(num3);
                oStream.Position = num4;
            }
            if (num == 2)
            {
                string value2 = xmlNode.Value;
                int length3 = value2.Length;
                binaryWriter.Write(length3);
                byte[] bytes3 = Encoding.Unicode.GetBytes(value2);
                Xor(bytes3, 2 * length3);
                binaryWriter.Write(bytes3);
            }
            if (num == -1)
            {
                string value2 = String.Format("<!--{0}-->", xmlNode.InnerText);
                int length3 = value2.Length;
                binaryWriter.Write(length3);
                byte[] bytes3 = Encoding.Unicode.GetBytes(value2);
                Xor(bytes3, 2 * length3);
                binaryWriter.Write(bytes3);
            }
            if (num > 2)
            {
                throw new Exception($"ERROR: XML NODE TYPE [{xmlNode.NodeType.ToString()}] UNKNOWN");
            }
            bool value3 = true;
            binaryWriter.Write(value3);
            string name2 = xmlNode.Name;
            int length4 = name2.Length;
            binaryWriter.Write(length4);
            byte[] bytes4 = Encoding.Unicode.GetBytes(name2);
            Xor(bytes4, 2 * length4);
            binaryWriter.Write(bytes4);
            int num5 = (int)oStream.Position;
            int num6 = 0;
            binaryWriter.Write(num6);
            binaryWriter.Write(AutoID);
            AutoID++;
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (WriteNode(oStream, childNode))
                {
                    num6++;
                }
            }
            int num7 = (int)oStream.Position;
            oStream.Position = num5;
            binaryWriter.Write(num6);
            oStream.Position = num7;
            return true;
        }
    }
}
