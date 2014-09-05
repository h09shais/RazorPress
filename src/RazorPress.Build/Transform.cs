﻿namespace RazorPress.Build
{
    /// <summary>
    /// Defines transformation stage of the RazorPress build process.
    /// </summary>
    public class Transform : CompositeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> command.
        /// </summary>
        public Transform(TransformMarkdownPages transformMarkdownPages, TransformRazorPages transformRazorPages)
            : base(new Command[] { transformMarkdownPages, transformRazorPages })
        {
        }

        /// <summary>
        /// Initializes a test instance of the <see cref="Transform"/> command without any dependencies.
        /// </summary>
        protected Transform()
        {
        }
    }
}
