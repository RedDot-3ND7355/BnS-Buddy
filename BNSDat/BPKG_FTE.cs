namespace BNSDat
{
	internal class BPKG_FTE
	{
		public int FilePathLength;

		public string FilePath;

		public byte Unknown_001;

		public bool IsCompressed;

		public bool IsEncrypted;

		public byte Unknown_002;

		public int FileDataSizeUnpacked;

		public int FileDataSizeSheared;

		public int FileDataSizeStored;

		public int FileDataOffset;

		public byte[] Padding;
	}
}
