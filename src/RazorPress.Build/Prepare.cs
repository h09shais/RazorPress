﻿using System.Composition;
using MefBuild;

namespace RazorPress.Build
{
    /// <summary>
    /// Defines the preparation stage of the RazorPress build process.
    /// </summary>
    [Export]
    public class Prepare : SiteCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Prepare"/> command.
        /// </summary>
        [ImportingConstructor]
        public Prepare(ExecuteRazorPageHeaders executeRazorPageHeaders, GenerateSiteTags generateSiteTags)
            : base(new ICommand[] { executeRazorPageHeaders, generateSiteTags })
        {
        }

        /// <summary>
        /// Initializes a test instance of the <see cref="Prepare"/> command without any dependencies.
        /// </summary>
        protected Prepare()
        {
        }
    }
}
