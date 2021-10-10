using System;
using System.IO;
using System.Text.RegularExpressions;
using Main;
using NUnit.Framework;

namespace Tests
{
	public class Tests
	{
		[Test]
		public void IntegrateTest()
		{
			using (var sw = new StringWriter())
			{
				Console.SetOut(sw);

				EntryPoint.Main();
				var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "resources/output.txt");
				var expectedOutput = RemoveSpecialCharacters(File.ReadAllText(path));

				Assert.AreEqual(expectedOutput, RemoveSpecialCharacters(sw.ToString()));
			}
		}

		private static string RemoveSpecialCharacters(string str)
		{
			return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
		}
	}
}