﻿using System;
using System.IO;

namespace RazorPress
{
    /// <summary>
    /// Represents a web page.
    /// </summary>
    public class Page
    {
        private string content = string.Empty;
        private string[] tags = new string[0];
        private string title = string.Empty;

        /// <summary>
        /// Gets or sets the page content.
        /// </summary>
        public string Content 
        {
            get { return this.content; }
            set { SetProperty(ref this.content, value); }
        }

        /// <summary>
        /// Gets or sets the tags of this page.
        /// </summary>
        public string[] Tags
        {
            get { return this.tags; }
            set { SetProperty(ref this.tags, value); }
        }

        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        /// <remarks>
        /// Default page is automatically derived from the template file name. It can also be changed in template code.
        /// </remarks>
        public string Title 
        {
            get { return this.title; }
            set { SetProperty(ref this.title, value); }
        }

        private static void SetProperty<T>(ref T field, T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            field = value;
        }
    }
}
