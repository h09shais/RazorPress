﻿using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace RazorPress.Build
{
    /// <summary>
    /// Serves as a base class for page commands that require Razor templating services.
    /// </summary>
    public abstract class RazorPageCommand : PageCommand
    {
        private readonly TemplateService templateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RazorPageCommand"/> class.
        /// </summary>
        protected RazorPageCommand()
        {
            var configuration = new TemplateServiceConfiguration();
            configuration.BaseTemplateType = typeof(RazorTemplate);
            this.templateService = new TemplateService(configuration);
        }

        /// <summary>
        /// Returns output of the specified <paramref name="template"/> transformed by the Razor engine.
        /// </summary>
        protected string Transform(string template)
        {
            var model = new RazorTemplateModel(this.Site, this.Page);
            return this.templateService.Parse(template, model, null, null);
        }
    }
}