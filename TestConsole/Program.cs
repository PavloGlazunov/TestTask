using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Actions;
using Logic;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string resultsFilePath = "results.txt";
			string command = "all";
			args = new string[] { @"D:\C#" };
			if (args.Length == 3)
			{
				resultsFilePath = args[2];
			}
			if (args.Length == 2)
			{
				command = args[1];
			}
			if (args.Length == 0)
			{
				Console.WriteLine("Invalid folder path");
			}
			else
			{
				string folderPath = args[0];
				if (Directory.Exists(Path.GetDirectoryName(folderPath)))
				{
					var list = new ActionFactory(new Helper()).DoAction(command, folderPath);
					File.WriteAllLines(resultsFilePath, list);
				}
				else
				{
					System.Console.WriteLine("Folder not found");
				}
			}
			Console.ReadKey();
		}
	}
}
