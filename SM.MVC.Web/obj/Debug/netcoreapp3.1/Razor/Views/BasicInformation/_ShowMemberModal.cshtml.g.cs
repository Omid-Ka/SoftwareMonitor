#pragma checksum "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "693af20e725ed3ca06c22400f28e75a0e98b3f96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BasicInformation__ShowMemberModal), @"mvc.1.0.view", @"/Views/BasicInformation/_ShowMemberModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"693af20e725ed3ca06c22400f28e75a0e98b3f96", @"/Views/BasicInformation/_ShowMemberModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438117d6a1056cfaf65713e7e7cf998840c12389", @"/Views/_ViewImports.cshtml")]
    public class Views_BasicInformation__ShowMemberModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Core.ViewModels.TeamDetailVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<style>
    .center {
        text-align: center !important;
        background-color: aliceblue !important;
        font-size: 24px !important;
    }

    .Header {
        font-size: 30px !important;
        text-align: center !important;
        background-color: aliceblue !important;
    }

    .tabStyle {
        padding-right: 0px !important;
        font-size: 24px;
    }

    .ItemsStyle {
        margin-bottom: 0px !important;
    }

    .ColStyle {
        margin-top: 6px;
        border: 2px solid;
        border-radius: 20px;
        height: 40px;
    }
</style>


<div class=""body"">
    <!-- Nav tabs -->
    <!-- Tab panes -->
    <div class=""tab-content"">
        <div role=""tabpanel"" class=""tab-pane fade in active"" id=""Profile"">
            <div id=""MemberModal"">

                <div class=""row clearfix center"">
");
#nullable restore
#line 43 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-sm-4 ColStyle\">\r\n                            <div class=\"form-group ItemsStyle\">\r\n                                ");
#nullable restore
#line 47 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
                           Write(item.Member);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-sm-6 ColStyle\">\r\n                            <div class=\"form-group ItemsStyle\">\r\n                                ");
#nullable restore
#line 52 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
                           Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-sm-2 \">\r\n                            <div class=\"form-group ItemsStyle\">\r\n                                <a class=\"btn bg-danger waves-effect\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1654, "\"", 1686, 3);
            WriteAttributeValue("", 1664, "DeleteMember(", 1664, 13, true);
#nullable restore
#line 57 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
WriteAttributeValue("", 1677, item.Id, 1677, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1685, ")", 1685, 1, true);
            EndWriteAttribute();
            WriteLiteral("> ?????? ?????? </a>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 60 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    function DeleteMember(id) {\r\n        $.ajax({\r\n            url: \"");
#nullable restore
#line 71 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\BasicInformation\_ShowMemberModal.cshtml"
             Write(Url.Action("DeleteMember", "BasicInformation"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?TeamDetailId=\" + id  ,\r\n            type: \"POST\",\r\n            success: function (result) {\r\n                $(\"#MemberModal\").html(result );\r\n\r\n            }\r\n        });\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Core.ViewModels.TeamDetailVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
