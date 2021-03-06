#pragma checksum "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc60b995370cdcb4524915ba1822dde0808dafc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProjectInfo__StressAndLoadGrid), @"mvc.1.0.view", @"/Views/ProjectInfo/_StressAndLoadGrid.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc60b995370cdcb4524915ba1822dde0808dafc6", @"/Views/ProjectInfo/_StressAndLoadGrid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438117d6a1056cfaf65713e7e7cf998840c12389", @"/Views/_ViewImports.cshtml")]
    public class Views_ProjectInfo__StressAndLoadGrid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-bordered table-striped table-hover js-basic-example dataTable"">
    <thead>
        <tr>
            <th class=""align-right"">نوع تست</th>
            <th class=""align-right"">عنوان تست</th>
            <th class=""align-right"">تاریخ ثبت</th>
            <th class=""align-right"">نام پروژه</th>
            <th class=""align-right"">عملیات</th>
        </tr>
    </thead>
    <tfoot>
        <tr>
            <th class=""align-right"">نوع تست</th>
            <th class=""align-right"">عنوان تست</th>
            <th class=""align-right"">تاریخ ثبت</th>
            <th class=""align-right"">نام پروژه</th>
            <th class=""align-right"">عملیات</th>
        </tr>
    </tfoot>
    <tbody>
");
#nullable restore
#line 22 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th class=\"align-right\">");
#nullable restore
#line 25 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
                                   Write(item.TestType.ToDescription());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n                <th class=\"align-right\">");
#nullable restore
#line 26 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"align-right\">");
#nullable restore
#line 27 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
                                   Write(item.DateInserted.GetPrsianDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"align-right\">");
#nullable restore
#line 28 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
                                   Write(item.ProjectName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th class=\"align-right\">\r\n                    <a class=\"btn bg-amber waves-effect\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1174, "\"", 1204, 3);
            WriteAttributeValue("", 1184, "DeleteTest(", 1184, 11, true);
#nullable restore
#line 30 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
WriteAttributeValue("", 1195, item.Id, 1195, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1203, ")", 1203, 1, true);
            EndWriteAttribute();
            WriteLiteral("> حذف سند </a>\r\n                    <a class=\"btn bg-light-green waves-effect\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1283, "\"", 1311, 3);
            WriteAttributeValue("", 1293, "EditTest(", 1293, 9, true);
#nullable restore
#line 31 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
WriteAttributeValue("", 1302, item.Id, 1302, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1310, ")", 1310, 1, true);
            EndWriteAttribute();
            WriteLiteral("> ویرایش سند </a>\r\n                </th>\r\n            </tr>\r\n");
#nullable restore
#line 34 "D:\Omid\Project\SoftwareMonitor\SoftwareMonitor\SM.MVC.Web\Views\ProjectInfo\_StressAndLoadGrid.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
