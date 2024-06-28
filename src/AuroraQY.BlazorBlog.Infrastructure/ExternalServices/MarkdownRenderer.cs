using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Markdig;

namespace AuroraQY.BlazorBlog.Infrastructure.ExternalServices
{
    public class MarkdownRenderer
    {
        // TODO: 替换为自定义的Markdown渲染器
        public string RenderToHtml(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var result = Markdown.ToHtml(markdown, pipeline);
            return result;
        }
        // [DllImport("MarkdownRendererLib.dll", CallingConvention = CallingConvention.Cdecl)]
        // private static extern IntPtr RenderMarkdown(string markdown);

        // [DllImport("MarkdownRendererLib.dll", CallingConvention = CallingConvention.Cdecl)]
        // private static extern void FreeRenderedMarkdown(IntPtr renderedMarkdown);

        // public string RenderToHtml(string markdown)
        // {
        //     IntPtr renderedPtr = RenderMarkdown(markdown);
        //     string result = Marshal.PtrToStringAnsi(renderedPtr);
        //     FreeRenderedMarkdown(renderedPtr);
        //     return result;
        // }
    }
}
