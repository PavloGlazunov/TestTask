using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Actions;
using Logic;
using FluentAssertions;

namespace UnitTests
{
	[TestClass]
	public class ConsoleTests
	{
		[TestMethod]
		public void ActionCppTest()
		{
			IHelper helper = new Helper();
			var list = new ActionFactory(helper).DoAction("cpp", @"f:\folder\", new List<string>
			{
				@"f:\folder\file.txt",
				@"f:\folder\file2.cpp",
				@"f:\folder\sub_folder\file3.cpp"
			});
			list.Count().Should().Be(3);
			list.All(f => f.EndsWith(" /")).Should().BeTrue();
		}

		[TestMethod]
		public void ActionAllTest()
		{
			IHelper helper = new Helper();
			var list = new ActionFactory(helper).DoAction("all", @"f:\folder\", new List<string>
			{
				@"f:\folder\file1.txt",
				@"f:\folder\file2.cpp",
				@"f:\folder\sub_folder\file3.cs",
				@"f:\folder\sub_foler\file1.txt"
			});
			list.Count().Should().Be(4);
			list.All(f => !f.Contains(@"f:\")).Should().BeTrue();
		}

		[TestMethod]
		public void ActionReversed1()
		{
			IHelper helper = new Helper();
			var list = new ActionFactory(helper).DoAction("reversed1", @"f:\bla\", new List<string>
			{
				@"f:\bla\ra\t.dat"
			});
			list.First().Should().Be(@"t.dat\ra");
		}

		[TestMethod]
		public void ActionReversed2()
		{
			IHelper helper = new Helper();
			var list = new ActionFactory(helper).DoAction("reversed2", @"f:\bla\", new List<string>
			{
				@"f:\bla\ra\t.dat"
			});
			list.First().Should().Be(@"tad.t\ar");
		}
	}
}
