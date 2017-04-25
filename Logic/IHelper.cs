using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public interface IHelper
	{
		string GetRelativePath(string absoluteFilePath, string folderPath);
		IEnumerable<string> GetAllFilesFromFolder(string folderPath, string pattern);
		IEnumerable<string> GetAllFilesFromFolderAsync(string folderPath, string pattern);

	}
}
