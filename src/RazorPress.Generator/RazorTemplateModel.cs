﻿namespace RazorPress.Generator
{
    /// <summary>
    /// Serves as a model for <see cref="RazorPress.Template"/>.
    /// </summary>
    public class RazorTemplateModel
    {
        private readonly Page page;

        /// <summary>
        /// Initializes a new instance of the <see cref="RazorTemplateModel"/> class.
        /// </summary>
        public RazorTemplateModel(Page page)
        {
            this.page = page;
        }

        /// <summary>
        /// Gets a <see cref="Page"/> object that represents the web page generated by the current <see cref="RazorTemplate"/>.
        /// </summary>
        public Page Page 
        { 
            get { return this.page; } 
        }
    }
}