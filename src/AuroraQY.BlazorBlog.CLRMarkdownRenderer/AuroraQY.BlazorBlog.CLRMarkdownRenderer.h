// MarkdownRender.h
#pragma once

using namespace System;

#include <msclr/marshal_cppstd.h>
#include "md2html.hpp"

namespace MarkdownRender {
    public ref class ManagedMarkdownRenderer
    {
    private:
        MarkdownTransform* transformer;

    public:
        ManagedMarkdownRenderer(String^ filename) {
            // 将System::String^ 转换为 std::string
            msclr::interop::marshal_context context;
            std::string stdFilename = context.marshal_as<std::string>(filename);
            transformer = new MarkdownTransform(stdFilename);
        }

        ~ManagedMarkdownRenderer() {
            delete transformer;
        }

        String^ RenderMarkdown(String^ markdownText, String^ filePath) {
            std::string mdText = msclr::interop::marshal_as<std::string>(markdownText);

            MarkdownTransform renderer(mdText);
            std::string htmlContent = renderer.getContents();

            return msclr::interop::marshal_as<String^>(htmlContent);
        }

    };
}
