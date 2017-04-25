using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Actions
{
	[ActionAttribute("cpp")]
	public class ActionCpp : ActionBase
	{
		public ActionCpp(IHelper helper, string folderPath, bool isAsync) : base(helper, folderPath, isAsync)
		{
			ActionHelper = helper;
			if (isAsync)
			{
				FilesList = helper.GetAllFilesFromFolderAsync(folderPath, "*.cpp");
			}
			else
			{
				FilesList = helper.GetAllFilesFromFolder(folderPath, "*.cpp");
			}
		}

		public ActionCpp(IHelper helper, IEnumerable<string> filesList) : base(helper, filesList)
		{
		}

		public override IEnumerable<string> GetFiles(string folderPath)
		{
			return this.FilesList.Select(f => string.Format("{0} /", this.ActionHelper.GetRelativePath(f, folderPath))); ;
		}

		public override IEnumerable<string> GetFilesAsync(string folderPath)
		{
			return Task<IEnumerable<string>>.Run(() =>
			{
				return this.FilesList.Select(f => string.Format("{0} /", this.ActionHelper.GetRelativePath(f, folderPath)));
			}).GetAwaiter().GetResult();
		}
	}
}
