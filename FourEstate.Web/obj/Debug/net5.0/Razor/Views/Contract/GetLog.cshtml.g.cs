#pragma checksum "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4856e48ae2d5ad76de3f48618616acc18157e1be"
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
#line 1 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\_ViewImports.cshtml"
using FourEstate.Core.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4856e48ae2d5ad76de3f48618616acc18157e1be", @"/Views/Contract/GetLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89bfb8dce0895456cad36eeb567be67376c5ceb0", @"/Views/_ViewImports.cshtml")]
    public class Views_Contract_GetLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ContentChangeLogViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover\">\r\n        <tr>\r\n            <th>الوقت</th>\r\n            <th>من</th>\r\n            <th>الى</th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
         foreach (var x in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th>");
#nullable restore
#line 20 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.ChangeAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 21 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.Old);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 22 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
               Write(x.New);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n");
#nullable restore
#line 24 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
            WriteLiteral(@"    <div class=""accordion accordion-solid accordion-panel accordion-svg-toggle"" id=""accordionExample8"">
        <div class=""card"">
            <div class=""card-header"" id=""headingOne8"">
                <div class=""card-title"" data-toggle=""collapse"" data-target=""#collapseOne8"">
                    <div class=""card-label"">Product Inventory</div>
                    <span class=""svg-icon"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                <polygon points=""0 0 24 0 24 24 0 24""></polygon>
                                <path d=""M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.67");
            WriteLiteral(@"5721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                                <path d=""M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" transform=""translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) ""></path>
                            </g>
                        </svg>
                    </span>
                </div>
     ");
            WriteLiteral(@"       </div>
            <div id=""collapseOne8"" class=""collapse show"" data-parent=""#accordionExample8"">
                <div class=""card-body"">
                    ...
                </div>
            </div>
        </div>
        <div class=""card"">
            <div class=""card-header"" id=""headingTwo8"">
                <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseTwo8"">
                    <div class=""card-label"">Order Statistics</div>
                    <span class=""svg-icon"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                <polygon points=""0 0 24 0 24 24 0 24""></polygon>
                                <path d=""M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,");
            WriteLiteral(@"4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                                <path d=""M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" transform=""translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999");
            WriteLiteral(@") ""></path>
                            </g>
                        </svg>
                    </span>
                </div>
            </div>
            <div id=""collapseTwo8"" class=""collapse"" data-parent=""#accordionExample8"">
                <div class=""card-body"">
                    ...
                </div>
            </div>
        </div>
        <div class=""card"">
            <div class=""card-header"" id=""headingThree8"">
                <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseThree8"">
                    <div class=""card-label"">eCommerce Reports</div>
                    <span class=""svg-icon"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                <polygon points=""0 0 24 0 24 24 0 24""></polygon>
      ");
            WriteLiteral(@"                          <path d=""M12.2928955,6.70710318 C11.9023712,6.31657888 11.9023712,5.68341391 12.2928955,5.29288961 C12.6834198,4.90236532 13.3165848,4.90236532 13.7071091,5.29288961 L19.7071091,11.2928896 C20.085688,11.6714686 20.0989336,12.281055 19.7371564,12.675721 L14.2371564,18.675721 C13.863964,19.08284 13.2313966,19.1103429 12.8242777,18.7371505 C12.4171587,18.3639581 12.3896557,17.7313908 12.7628481,17.3242718 L17.6158645,12.0300721 L12.2928955,6.70710318 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                                <path d=""M3.70710678,15.7071068 C3.31658249,16.0976311 2.68341751,16.0976311 2.29289322,15.7071068 C1.90236893,15.3165825 1.90236893,14.6834175 2.29289322,14.2928932 L8.29289322,8.29289322 C8.67147216,7.91431428 9.28105859,7.90106866 9.67572463,8.26284586 L15.6757246,13.7628459 C16.0828436,14.1360383 16.1103465,14.7686056 15.7371541,15.1757246 C15.3639617,15.5828436 14.7313944,15.6103465 14.3242754,15.2371541 L9.03007575,10.3841378 L3.70710678,15.7071068 Z"" fill=");
            WriteLiteral(@"""#000000"" fill-rule=""nonzero"" opacity=""0.3"" transform=""translate(9.000003, 11.999999) rotate(-270.000000) translate(-9.000003, -11.999999) ""></path>
                            </g>
                        </svg>
                    </span>
                </div>
            </div>
            <div id=""collapseThree8"" class=""collapse"" data-parent=""#accordionExample8"">
                <div class=""card-body"">
                    ...
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 93 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"

}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning\">\r\n        No Change Log Yet !!!\r\n\r\n    </div>\r\n");
#nullable restore
#line 102 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Contract\GetLog.cshtml"
}

#line default
#line hidden
#nullable disable
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
