using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Actions
{
	[ActionAttribute("reversed1")]
	public class ActionReversed1 : ActionBase
	{
		public ActionReversed1(IHelper helper, string folderPath, bool isAsync) : base(helper, folderPath, isAsync)
		{
		}

		public ActionReversed1(IHelper helper, IEnumerable<string> filesList) : base(helper, filesList)
		{
		}

		public override IEnumerable<string> GetFiles(string folderPath)
		{
			var files = this.FilesList.Select(f => this.ActionHelper.GetRelativePath(f, folderPath));
			var reversedPath = new List<string>();
			foreach (var file in files)
			{
				var pathParts = file.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				yield return string.Join(@"\", pathParts.Reverse());
			}
		}

		public override IEnumerable<string> GetFilesAsync(string folderPath)
		{
			return Task<IEnumerable<string>>.Run(() =>
			{
				return GetFiles(folderPath);
			}).GetAwaiter().GetResult();
		}
	}
}
