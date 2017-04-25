using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Actions
{
	[ActionAttribute("reversed2")]
	public class ActionReversed2 : ActionBase
	{
		public ActionReversed2(IHelper helper, string folderPath, bool isAsync) : base(helper, folderPath, isAsync)
		{
		}

		public ActionReversed2(IHelper helper, IEnumerable<string> filesList) : base(helper, filesList)
		{
		}

		public override IEnumerable<string> GetFiles(string folderPath)
		{
			return this.FilesList.Select(f => this.ReverseString(this.ActionHelper.GetRelativePath(f, folderPath).Replace(@"/", @"\")));
		}

		public override IEnumerable<string> GetFilesAsync(string folderPath)
		{
			return Task<IEnumerable<string>>.Run(() =>
			{
				return this.FilesList.Select(f => this.ReverseString(this.ActionHelper.GetRelativePath(f, folderPath).Replace(@"/", @"\")));
			}).GetAwaiter().GetResult();
		}

		private string ReverseString(string inputString)
		{
			char[] charArray = inputString.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
