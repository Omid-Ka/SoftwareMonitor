#pragma checksum "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2c757aabae108c33c9811c71cb6ff981965ce27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminLayout), @"mvc.1.0.view", @"/Views/Shared/_AdminLayout.cshtml")]
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
#nullable restore
#line 1 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2c757aabae108c33c9811c71cb6ff981965ce27", @"/Views/Shared/_AdminLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438117d6a1056cfaf65713e7e7cf998840c12389", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("navbar-brand"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("theme-blue-Custom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2c757aabae108c33c9811c71cb6ff981965ce274942", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=Edge"">
    <meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"">
    <title>???????? ????????????</title>
    <!-- Favicon-->

    <title>");
#nullable restore
#line 11 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n\r\n    ");
#nullable restore
#line 13 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
Write(await Html.PartialAsync("_AdminLinks"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 14 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
Write(await Html.PartialAsync("_AdminScripts"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 16 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
Write(await RenderSectionAsync("Styles", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2c757aabae108c33c9811c71cb6ff981965ce277237", async() => {
                WriteLiteral(@"

    <!-- Page Loader -->
    <div class=""page-loader-wrapper"">
        <div class=""loader"">
            <div class=""preloader"" style=""direction: ltr !important"" >
                <div class=""spinner-layer pl-red"">
                    <div class=""circle-clipper left"">
                        <div class=""circle""></div>
                    </div>
                    <div class=""circle-clipper right"">
                        <div class=""circle""></div>
                    </div>
                </div>
            </div>
            <p>???????? ?????? ???????????? .....</p>
        </div>
    </div>
    <!-- #END# Page Loader -->
    <!-- Overlay For Sidebars -->
    <div class=""overlay""></div>
    <!-- #END# Overlay For Sidebars -->
    <!-- Search Bar -->
    <div class=""search-bar"">
        <div class=""close-search"">
            <i class=""material-icons"">close</i>
        </div>
        <input type=""text"" placeholder=""??????????..."">
        <div class=""search-icon"">
            <i class=""material-i");
                WriteLiteral(@"cons"">search</i>
        </div>
    </div>
    <!-- #END# Search Bar -->
    <!-- Top Bar -->
    <nav class=""navbar"">
        <div class=""container-fluid"">
            <div class=""navbar-header"">
                <a href=""javascript:void(0);"" class=""navbar-toggle collapsed"" data-toggle=""collapse"" data-target=""#navbar-collapse"" aria-expanded=""false""></a>
                <a href=""javascript:void(0);"" class=""bars""></a>
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2c757aabae108c33c9811c71cb6ff981965ce279052", async() => {
                    WriteLiteral("?????????? ???????? ???????? ???????????? ????");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <div class=\"collapse navbar-collapse\" id=\"navbar-collapse\">\r\n                <ul class=\"nav navbar-nav navbar-right\">\r\n\r\n");
                WriteLiteral("\r\n                    <!-- Call Search -->\r\n");
                WriteLiteral("                    <!-- #END# Call Search -->\r\n                    <!-- Notifications -->\r\n");
                WriteLiteral("                    ");
#nullable restore
#line 69 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
               Write(await Component.InvokeAsync("Notifications"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                    <!-- #END# Notifications -->\r\n                    <!-- Tasks -->\r\n\r\n                    ");
#nullable restore
#line 74 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
               Write(await Html.PartialAsync("_Tasks"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    <!-- #END# Tasks -->
                </ul>
            </div>
        </div>
    </nav>
    <!-- #Top Bar -->
    <section>
        <!-- Left Sidebar -->
        <aside id=""leftsidebar"" class=""sidebar"">
            <!-- User Info -->
            ");
#nullable restore
#line 85 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
       Write(await Html.PartialAsync("_UserInfo"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <!-- #User Info -->\r\n            <!-- Menu -->\r\n");
                WriteLiteral("            ");
#nullable restore
#line 89 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
       Write(await Component.InvokeAsync("SideBar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral("            <!-- #Menu -->\r\n        </aside>\r\n        <!-- #END# Left Sidebar -->\r\n        <!-- Right Sidebar -->\r\n");
                WriteLiteral("\r\n        <!-- #END# Right Sidebar -->\r\n    </section>\r\n\r\n    <section class=\"content\">\r\n        <div class=\"container-fluid\">\r\n\r\n            ");
#nullable restore
#line 108 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </div>\r\n    </section>\r\n\r\n");
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n    ");
#nullable restore
#line 122 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\Shared\_AdminLayout.cshtml"
Write(await RenderSectionAsync("Scripts", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
