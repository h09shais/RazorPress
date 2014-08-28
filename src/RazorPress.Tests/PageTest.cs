﻿using System;
using System.IO;
using Xunit;

namespace RazorPress
{
    public class PageTest
    {
        public class Class : PageTest
        {
            [Fact]
            public void IsPublicForUsersToAccessItInTheirTemplates()
            {
                Assert.True(typeof(Page).IsPublic);
            }

            [Fact]
            public void ConstructorThrowsArgumentNullExceptionWhenSourceFileIsNullToPreventUsageErrors()
            {
                Assert.Throws<ArgumentNullException>(() => new Page(null));
            }
        }

        public class Content : PageTest
        {
            [Fact]
            public void IsEmptyStringByDefaultToPreventUsageErrors()
            {
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                Assert.Equal(0, page.Content.Length);
            }

            [Fact]
            public void CanBeSetByPageProcessors()
            {
                string content = "TestContent";
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                page.Content = content;
                Assert.Equal(content, page.Content);
            }

            [Fact]
            public void ThrowsArgumentNullExceptionToPreventUsageErrors()
            {
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                Assert.Throws<ArgumentNullException>(() => page.Content = null);
            }
        }

        public class Title : PageTest
        {
            [Fact]
            public void IsEmptyStringByDefaultToPreventUsageErrors()
            {
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                Assert.Equal(0, page.Title.Length);
            }

            [Fact]
            public void CanBeSetByUserToOverrideDefaultValueBasedOnFileName()
            {
                string title = "Hello, World";
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                page.Title = title;
                Assert.Equal(title, page.Title);
            }

            [Fact]
            public void ThrowsArgumentNullExceptionToPreventUsageErrors()
            {
                var page = new Page(new FileInfo(Path.GetRandomFileName()));
                Assert.Throws<ArgumentNullException>(() => page.Title = null);
            }
        }

        public class SourceFile : PageTest
        {
            [Fact]
            public void IsInitializedByConstructor()
            {
                var sourceFile = new FileInfo(Path.GetRandomFileName());
                var page = new Page(sourceFile);
                Assert.Same(sourceFile, page.SourceFile);
            }

            [Fact]
            public void IsReadOnlyBecauseItCannotBeChangedByUsers()
            {
                Assert.Null(typeof(Page).GetProperty("SourceFile").SetMethod);
            }
        }
    }
}
