using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileSearcher
{
	public static class Extensions
	{
		public static string NullWhitespaceToEmpty(this string source)
		{
			return string.IsNullOrWhiteSpace(source) ? "" : source;
		}
	}
}
