using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Actions
{
	[ActionAttribute("all")]
	public class ActionAll : ActionBase
	{
		public ActionAll(IHelper helper, string folderPath, bool isAsync) : base(helper, folderPath, isAsync)
		{
		}

		public ActionAll(IHelper helper, IEnumerable<string> filesList) : base(helper, filesList)
		{
		}

		public override IEnumerable<string> GetFiles(string folderPath)
		{
			return this.FilesList.Select(f => this.ActionHelper.GetRelativePath(f, folderPath).Replace(@"/", @"\"));
		}

		public override IEnumerable<string> GetFilesAsync(string folderPath)
		{
			return Task<IEnumerable<string>>.Run(() =>
			{
				return this.FilesList.Select(f => this.ActionHelper.GetRelativePath(f, folderPath));
			}).GetAwaiter().GetResult();
			
		}
	}
}
