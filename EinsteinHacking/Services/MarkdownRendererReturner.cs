using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinHacking.Services
{
    public class MarkdownRendererReturner
    {
        public string InputToMarkdown { get; set; }
        private void SetMarkdown(string inputToMarkdown)
        {
            InputToMarkdown = inputToMarkdown;
        }

        public MarkupString GetMarkdown(string inputToMarkdown)
        {
            SetMarkdown(inputToMarkdown);
            return ReturnMarkdown();
        }

        private MarkupString ReturnMarkdown()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var test = Markdown.Parse(InputToMarkdown, pipeline);
            string html = "";
            foreach (var t in test.Descendants())
            {
                if (t is AutolinkInline || t is LinkInline)
                {
                    t.GetAttributes().AddPropertyIfNotExist("target", "_blank");
                }
            }
            using (var writer = new StringWriter())
            {
                var renderer = new HtmlRenderer(writer);
                pipeline.Setup(renderer);
                renderer.Render(test);
                html = writer.ToString();
            }
            return new MarkupString(html);
            //var result = Markdig.Markdown.ToHtml(InputToMarkdown, pipeline);
            //var convertedToShowInHtml = new MarkupString(result);
            //return convertedToShowInHtml;
        }
    }
}
