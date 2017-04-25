using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Logic
{
	public class Helper : IHelper
	{
		public string GetRelativePath(string absoluteFilePath, string folderPath)
		{
			return Uri.UnescapeDataString(new Uri(folderPath).MakeRelativeUri(new Uri(absoluteFilePath)).ToString());
		}

		public IEnumerable<string> GetAllFilesFromFolder(string folderPath, string pattern)
		{
			return Directory.EnumerateFiles(folderPath, pattern, SearchOption.AllDirectories);
		}

		public IEnumerable<string> GetAllFilesFromFolderAsync(string folderPath, string pattern)
		{
			return Task<IEnumerable<string>>.Run(() => 
				Directory.EnumerateFiles(folderPath, pattern, SearchOption.AllDirectories)
			)
			.GetAwaiter().GetResult();
		}

	}
}
