using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace AuroraQY.BlazorBlog.Infrastructure.ExternalServices
{
    public class MarkdownRenderer
    {
        public string RenderToHtml(string markdown)
        {
            return markdown;
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
