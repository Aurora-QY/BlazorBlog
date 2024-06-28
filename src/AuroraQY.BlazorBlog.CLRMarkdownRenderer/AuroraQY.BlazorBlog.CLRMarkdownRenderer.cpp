#include "pch.h"

#include "AuroraQY.BlazorBlog.CLRMarkdownRenderer.h"

#include "stdafx.h"
#include "md2html.hpp"
#include <msclr/marshal_cppstd.h>

using namespace System;

namespace MarkdownToHTML {
    public ref class MarkdownConverter {
    private:
        MarkdownTransform* transformer;

    public:
        MarkdownConverter(String^ markdown) {
            msclr::interop::marshal_context context;
            std::string stdMarkdown = context.marshal_as<std::string>(markdown);
            transformer = new MarkdownTransform(stdMarkdown);
        }

        ~MarkdownConverter() {
            delete transformer;
        }

        String^ Convert() {
            std::string result = transformer->getHTMLContent();
            return gcnew String(result.c_str());
        }
    };
}
