#pragma checksum "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6652b3d44ce0b60db0393febf24f2662b2b3c80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comment_Comments), @"mvc.1.0.view", @"/Views/Comment/Comments.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\_ViewImports.cshtml"
using SM.MVC.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\_ViewImports.cshtml"
using SM.MVC.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6652b3d44ce0b60db0393febf24f2662b2b3c80", @"/Views/Comment/Comments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438117d6a1056cfaf65713e7e7cf998840c12389", @"/Views/_ViewImports.cshtml")]
    public class Views_Comment_Comments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Core.ViewModels.ProjectVersionDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Commentbody.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("profile-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/ProjectIcon.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("online"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
  
    ViewData["Title"] = "نظرات";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6652b3d44ce0b60db0393febf24f2662b2b3c805657", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            WriteLiteral("<!------ Include the above in your HEAD tag ---------->\r\n");
            WriteLiteral("<!------ Include the above in your HEAD tag ---------->\r\n");
            WriteLiteral("\r\n\r\n<div id=\"frame\" class=\"FrameClass\">\r\n    <div id=\"sidepanel\">\r\n        <div id=\"profile\">\r\n            <div class=\"wrap\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6652b3d44ce0b60db0393febf24f2662b2b3c807277", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <p>");
#nullable restore
#line 44 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
              Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
        </div>
        <div id=""search"">
            <input id=""searchComment"" type=""text"" placeholder=""جستجو"" />
            <a onclick=""SearchComment()"" style=""float: left;padding: 10px 0 6px 0px;""><i class=""material-icons"">search</i></a>
        </div>
        <div id=""contacts"">
            <ul>
");
#nullable restore
#line 53 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"contact\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3178, "\"", 3238, 5);
            WriteAttributeValue("", 3188, "ShowConversation(", 3188, 17, true);
#nullable restore
#line 55 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
WriteAttributeValue("", 3205, Model[i].ProjectId, 3205, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3224, ",", 3224, 1, true);
#nullable restore
#line 55 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
WriteAttributeValue("", 3225, Model[i].Id, 3225, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3237, ")", 3237, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"wrap\">\r\n                            <span class=\"contact-status online\"></span>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6652b3d44ce0b60db0393febf24f2662b2b3c8010470", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"meta\">\r\n                                <p class=\"name\">");
#nullable restore
#line 60 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                                           Write(Model[i].ProjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"preview\">نسخه : ");
#nullable restore
#line 61 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                                                     Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </li>\r\n");
#nullable restore
#line 65 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("            </ul>\r\n        </div>\r\n");
            WriteLiteral("    </div>\r\n    <div id=\"ProjectConversation\" class=\"content\">\r\n        <div class=\"contact-profile\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6652b3d44ce0b60db0393febf24f2662b2b3c8012866", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <p>");
#nullable restore
#line 87 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral(@"        </div>
        <div class=""messages"">
        </div>
        <div class=""message-input"">
            <div class=""wrap"">
                <input id=""CommentTxt"" type=""text"" placeholder=""پیام ...."" />
                <button class=""submit""><i class=""material-icons"">send</i></button>
            </div>
        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n\r\n        function SearchComment() {\r\n            var Comment = $(\"#searchComment\").val();\r\n\r\n                $.ajax({\r\n                    url: \"");
#nullable restore
#line 115 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                     Write(Url.Action("SearchComment", "Comment"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?Comment="" + Comment ,
                    type: ""POST"",
                    success: function (result) {
                        $(""#contacts"").html(result);
                    }
                });


        }

        function ShowConversation(id, versionid ) {
            $.ajax({
                url: """);
#nullable restore
#line 127 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Comment\Comments.cshtml"
                 Write(Url.Action("ShowConversation", "Comment"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?ProjectId=\" + id + \"&VersionId=\" + versionid ,\r\n                type: \"POST\",\r\n                success: function (result) {\r\n                    $(\"#ProjectConversation\").html(result);\r\n                }\r\n            });\r\n        }\r\n\r\n\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Core.ViewModels.ProjectVersionDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591