using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class ActionBase
    {
		protected IHelper ActionHelper;
		protected IEnumerable<string> FilesList;
		public readonly string FileExtension;

		public ActionBase(IHelper helper, string folderPath, bool isAsync = false)
		{
			FileExtension = "*";
			ActionHelper = helper;
			if (isAsync)
			{
				FilesList = helper.GetAllFilesFromFolderAsync(folderPath, FileExtension);
			}
			else
			{
				FilesList = helper.GetAllFilesFromFolder(folderPath, FileExtension);
			}
		}

		public ActionBase(IHelper helper, IEnumerable<string> filesList)
		{
			ActionHelper = helper;
			FilesList = filesList;
		}

		public abstract IEnumerable<string> GetFiles(string folderPath);

		public abstract IEnumerable<string> GetFilesAsync(string folderPath);
    }
}
