using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileSearcher
{
	public abstract class FileChecker
	{
		const long buffsize = 2048;
		private static long Min(long a, long b)
		{
			return a < b ? a : b;
		}

		private static bool CheckByteArray(byte[] bytearr, string content)
		{
			string FileContent = Encoding.Default.GetString(bytearr);
			return FileContent.IndexOf(content) > -1;
		}
		public static bool CheckContent(FileInfo file, string content)
		{
			var fstream = file.OpenRead();
			long currentReaded = 0;

			Byte[] firstbuff = new Byte[2048];
			Byte[] secondbuff = new Byte[2048];
			Byte[] bothbuffs = new Byte[4096];
			Array.Clear(secondbuff, 0, 2048);

			fstream.Read(firstbuff, (int)currentReaded, (int)(Min(currentReaded + buffsize, fstream.Length) - currentReaded));
			currentReaded += buffsize;

			if (currentReaded >= fstream.Length && CheckByteArray(firstbuff, content))
			{
				return true;
			}

			while (currentReaded < fstream.Length)
			{
				int rest = (int)(Min(currentReaded + buffsize, fstream.Length) - currentReaded);
				fstream.Read(secondbuff, 0, rest);
				currentReaded += buffsize;
				bothbuffs = firstbuff.Concat(secondbuff).ToArray();
				if (CheckByteArray(bothbuffs, content))
				{
					return true;
				}
				firstbuff = secondbuff;
			}

			return false;
		}
		public static bool CheckName(string FileName, string Mask)
		{
			char[] strSource = new char[FileName.Length + 1];
			char[] strMask = new char[Mask.Length + 1];

			FileName.CopyTo(0, strSource, 0, FileName.Length);
			Mask.CopyTo(0, strMask, 0, Mask.Length);

			int SourceIndex = 0;
			int MaskIndex = 0;

			for (; SourceIndex < strSource.Length && strMask[MaskIndex] != '*'; MaskIndex++, SourceIndex++)
			{
				if (strMask[MaskIndex] != strSource[SourceIndex] && strMask[MaskIndex] != '?')
				{
					return false;
				}
			}

			int pSourceIndex = 0;
			int pMaskIndex = 0;

			for (; ; )
			{
				if (strSource[SourceIndex] == 0)
				{
					while (strMask[MaskIndex] == '*')
					{
						MaskIndex++;
					}

					return strMask[MaskIndex] == 0 ? true : false;
				}
				if (strMask[MaskIndex] == '*')
				{
					if (strMask[++MaskIndex] == 0)
					{
						return true;
					}

					pMaskIndex = MaskIndex;
					pSourceIndex = SourceIndex + 1;
					continue;
				}
				if (strMask[MaskIndex] == strSource[SourceIndex] || strMask[MaskIndex] == '?')
				{
					MaskIndex++;
					SourceIndex++;
					continue;
				}
				MaskIndex = pMaskIndex; SourceIndex = pSourceIndex++;
			}
		}
	}
}
