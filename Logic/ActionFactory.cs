using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Logic.Actions
{
	public class ActionFactory
	{
		private ActionBase Action;
		private IHelper ActionHelper;

		public ActionFactory(IHelper helper)
		{
			ActionHelper = helper;
		}

		public IEnumerable<string> DoAction(string command, string folderPath)
		{
			Action = Activator.CreateInstance(GetActionType(command), this.ActionHelper, folderPath, false) as ActionBase;
			return Action.GetFiles(folderPath);
		}

		public IEnumerable<string> DoAction(string command, string folderPath, IEnumerable<string> filesList)
		{
			Action = Activator.CreateInstance(GetActionType(command), this.ActionHelper, filesList) as ActionBase;
			return Action.GetFiles(folderPath);
		}

		public IEnumerable<string> DoActionAsync(string command, string folderPath)
		{
			Action = Activator.CreateInstance(GetActionType(command), this.ActionHelper) as ActionBase;
			return Action.GetFilesAsync(folderPath);
		}

		private Type GetActionType(string command)
		{
			Type actionType = typeof(ActionBase);
			Type attributeType = typeof(ActionAttribute);
			return Assembly.GetAssembly(actionType)
				.GetTypes()
				.Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(actionType) && (t.GetCustomAttribute(attributeType) as ActionAttribute).Command == command.ToLower())
				.FirstOrDefault();
		}
	}
}
