#pragma checksum "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45d0858f36bd37c8b5fa89bcd54cbf33483acba0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contract_GetLog), @"mvc.1.0.view", @"/Views/Contract/GetLog.cshtml")]
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
#line 1 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45d0858f36bd37c8b5fa89bcd54cbf33483acba0", @"/Views/Contract/GetLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89bfb8dce0895456cad36eeb567be67376c5ceb0", @"/Views/_ViewImports.cshtml")]
    public class Views_Contract_GetLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ContentChangeLogViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\r\n        <tr>\r\n            <th>الوقت</th>\r\n            <th>من</th>\r\n            <th>الى</th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
         foreach (var x in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th>");
#nullable restore
#line 20 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.ChangeAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 21 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.Old);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 22 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.New);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n");
#nullable restore
#line 24 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 26 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning\">\r\n        No Change Log Yet !!\r\n\r\n    </div>\r\n");
#nullable restore
#line 34 "C:\Users\khatib\Desktop\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("e>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ContentChangeLogViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
