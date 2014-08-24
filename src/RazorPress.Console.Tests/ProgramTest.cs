﻿using System;
using System.IO;
using Xunit;

namespace RazorPress.Tests
{
    public sealed class ProgramTest : IDisposable
    {
        private string WorkingDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        public ProgramTest()
        {
            Directory.CreateDirectory(WorkingDirectory);
        }

        public void Dispose()
        {
            Directory.Delete(WorkingDirectory, true);
        }

        private string CreateTestFile(string extension)
        {
            string fileName = Path.GetRandomFileName();
            fileName = Path.ChangeExtension(fileName, extension);
            fileName = Path.Combine(WorkingDirectory, fileName);
            using (File.CreateText(fileName))
            {
            }

            return fileName;
        }

        [Fact]
        public void MainReturnsErrorCodeWhenNoArgumentsAreSpecified()
        {
            int exitCode = Program.Main(new string[0]);
            Assert.NotEqual(0, exitCode);
        }

        [Fact]
        public void RenderReturnsSuccessCodeWhenRenderArgumentsAreSpecifiedCorrectly()
        {
            string testFile = this.CreateTestFile(".cshtml");
            string[] args = new[] { "render", "/inputFile=" + testFile, "/outputFile=output.html" };
            Assert.Equal(0, Program.Main(args));
        }

        [Fact]
        public void RenderPerformsRazorTransformWhenInputFileExtensionStartsWithCs()
        {
            string inputFile = this.CreateTestFile(".cshtml");
            File.WriteAllText(inputFile, "@DateTime.Now.Year");
            string outputFile = Path.ChangeExtension(inputFile, ".html");

            string[] args = new[] { "render", "/i=" + inputFile, "/o=" + outputFile };

            Assert.Equal(0, Program.Main(args));
            Assert.Equal(DateTime.Now.Year.ToString(), File.ReadAllText(outputFile));
        }

        [Fact]
        public void RenderReturnsErrorCodeWhenInputFileIsNotSpecified()
        {
            string[] args = new[] { "render", "/outputFile=output.html" };
            Assert.NotEqual(0, Program.Main(args));
        }

        [Fact]
        public void RenderReturnsErrorCodeWhenInputFileDoesNotExist()
        {
            string[] args = new[] { "render", "/inputFile=nonexistent.cshtml", "/outputFile=output.html" };
            Assert.NotEqual(0, Program.Main(args));
        }
    }
}
