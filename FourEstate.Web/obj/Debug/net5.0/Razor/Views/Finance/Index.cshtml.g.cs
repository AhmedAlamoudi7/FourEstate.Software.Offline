#pragma checksum "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Finance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "083bc1a69e80c71bf96a61dbff509e686f4961e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Finance_Index), @"mvc.1.0.view", @"/Views/Finance/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"083bc1a69e80c71bf96a61dbff509e686f4961e9", @"/Views/Finance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89bfb8dce0895456cad36eeb567be67376c5ceb0", @"/Views/_ViewImports.cshtml")]
    public class Views_Finance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Receipt/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light p-5 font-weight-bold mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/CatchReceipt/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\khatib\Desktop\Folders\FourEstate -النسخة الoffline\AhmedAlamoudi7\FourEstate.Software\FourEstate.Web\Views\Finance\Index.cshtml"
   ViewData["Title"] = "الصفحة المالية"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>



<!--begin::Card-->
<div class=""card card-custom"">
    <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
        <div class=""card-title"">
            <h1 class=""card-label"">
                الإدارة المالية
            </h1>
        </div>
    </div>


    <div class=""card-body"">
        <!-- Start Statices Setion -->
        <section class=""Statices text-center"">
                <div class=""container "">

                    <div class=""row"">

                        <div class=""media"" style=""padding:14px; margin:20px;"" height=""200"" width=""200"">
                            <a href=""Invoice/Index"" class=""btn btn-light p-5 font-weight-bold mr-2"">
                                <span class=""svg-icon svg-icon-success svg-icon-3x"">
                                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" ");
            WriteLiteral(@"version=""1.1"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <polygon points=""0 0 24 0 24 24 0 24"" />
                                            <path d=""M4.85714286,1 L11.7364114,1 C12.0910962,1 12.4343066,1.12568431 12.7051108,1.35473959 L17.4686994,5.3839416 C17.8056532,5.66894833 18,6.08787823 18,6.52920201 L18,19.0833333 C18,20.8738751 17.9795521,21 16.1428571,21 L4.85714286,21 C3.02044787,21 3,20.8738751 3,19.0833333 L3,2.91666667 C3,1.12612489 3.02044787,1 4.85714286,1 Z M8,12 C7.44771525,12 7,12.4477153 7,13 C7,13.5522847 7.44771525,14 8,14 L15,14 C15.5522847,14 16,13.5522847 16,13 C16,12.4477153 15.5522847,12 15,12 L8,12 Z M8,16 C7.44771525,16 7,16.4477153 7,17 C7,17.5522847 7.44771525,18 8,18 L11,18 C11.5522847,18 12,17.5522847 12,17 C12,16.4477153 11.5522847,16 11,16 L8,16 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                            <path d=""M6.85714286");
            WriteLiteral(@",3 L14.7364114,3 C15.0910962,3 15.4343066,3.12568431 15.7051108,3.35473959 L20.4686994,7.3839416 C20.8056532,7.66894833 21,8.08787823 21,8.52920201 L21,21.0833333 C21,22.8738751 20.9795521,23 19.1428571,23 L6.85714286,23 C5.02044787,23 5,22.8738751 5,21.0833333 L5,4.91666667 C5,3.12612489 5.02044787,3 6.85714286,3 Z M8,12 C7.44771525,12 7,12.4477153 7,13 C7,13.5522847 7.44771525,14 8,14 L15,14 C15.5522847,14 16,13.5522847 16,13 C16,12.4477153 15.5522847,12 15,12 L8,12 Z M8,16 C7.44771525,16 7,16.4477153 7,17 C7,17.5522847 7.44771525,18 8,18 L11,18 C11.5522847,18 12,17.5522847 12,17 C12,16.4477153 11.5522847,16 11,16 L8,16 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                                        </g>
                                    </svg>
                                </span>فاتورة
                            </a>
                        </div>
                        <div class=""media"" style=""padding:14px; margin:20px;"" height=""200"" width=""200"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "083bc1a69e80c71bf96a61dbff509e686f4961e98824", async() => {
                WriteLiteral(@"
                                <span class=""svg-icon svg-icon-success svg-icon-3x"">
                                    <!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2021-05-14-112058/theme/html/demo1/dist/../src/media/svg/icons/Files/Upload.svg--><svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                            <path d=""M2,13 C2,12.5 2.5,12 3,12 C3.5,12 4,12.5 4,13 C4,13.3333333 4,15 4,18 C4,19.1045695 4.8954305,20 6,20 L18,20 C19.1045695,20 20,19.1045695 20,18 L20,13 C20,12.4477153 20.4477153,12 21,12 C21.5522847,12 22,12.4477153 22,13 L22,18 C22,20.209139 20.209139,22 18,22 L6,22 C3.790861,22 2,20.209139 2,18 C2,15 2,13.3333333 2,13 Z"" fill=""#000000"" fill-r");
                WriteLiteral(@"ule=""nonzero"" opacity=""0.3"" />
                                            <rect fill=""#000000"" opacity=""0.3"" x=""11"" y=""2"" width=""2"" height=""14"" rx=""1"" />
                                            <path d=""M12.0362375,3.37797611 L7.70710678,7.70710678 C7.31658249,8.09763107 6.68341751,8.09763107 6.29289322,7.70710678 C5.90236893,7.31658249 5.90236893,6.68341751 6.29289322,6.29289322 L11.2928932,1.29289322 C11.6689749,0.916811528 12.2736364,0.900910387 12.6689647,1.25670585 L17.6689647,5.75670585 C18.0794748,6.12616487 18.1127532,6.75845471 17.7432941,7.16896473 C17.3738351,7.57947475 16.7415453,7.61275317 16.3310353,7.24329415 L12.0362375,3.37797611 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                                        </g>
                                    </svg><!--end::Svg Icon-->
                                </span> سند صرف
                            ");
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
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"media\" style=\"padding:14px; margin:20px;\" height=\"200\" width=\"200\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "083bc1a69e80c71bf96a61dbff509e686f4961e912163", async() => {
                WriteLiteral(@"
                                <span class=""svg-icon svg-icon-success svg-icon-3x"">
                                    <!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2021-05-14-112058/theme/html/demo1/dist/../src/media/svg/icons/Files/Download.svg-->
                                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                            <path d=""M2,13 C2,12.5 2.5,12 3,12 C3.5,12 4,12.5 4,13 C4,13.3333333 4,15 4,18 C4,19.1045695 4.8954305,20 6,20 L18,20 C19.1045695,20 20,19.1045695 20,18 L20,13 C20,12.4477153 20.4477153,12 21,12 C21.5522847,12 22,12.4477153 22,13 L22,18 C22,20.209139 20.209139,22 18,22 L6,22 C3.790861,22 2,20.209139 2,18 C2,15 2,");
                WriteLiteral(@"13.3333333 2,13 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                            <rect fill=""#000000"" opacity=""0.3"" transform=""translate(12.000000, 8.000000) rotate(-180.000000) translate(-12.000000, -8.000000) "" x=""11"" y=""1"" width=""2"" height=""14"" rx=""1"" />
                                            <path d=""M7.70710678,15.7071068 C7.31658249,16.0976311 6.68341751,16.0976311 6.29289322,15.7071068 C5.90236893,15.3165825 5.90236893,14.6834175 6.29289322,14.2928932 L11.2928932,9.29289322 C11.6689749,8.91681153 12.2736364,8.90091039 12.6689647,9.25670585 L17.6689647,13.7567059 C18.0794748,14.1261649 18.1127532,14.7584547 17.7432941,15.1689647 C17.3738351,15.5794748 16.7415453,15.6127532 16.3310353,15.2432941 L12.0362375,11.3779761 L7.70710678,15.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" transform=""translate(12.000004, 12.499999) rotate(-180.000000) translate(-12.000004, -12.499999) "" />
                                        </g>
                                    </sv");
                WriteLiteral("g><!--end::Svg Icon-->\r\n                                </span>سند قبض\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""media"" style=""padding:14px; margin:20px;"" height=""200"" width=""200"">

                            <a href=""#"" class=""btn btn-light p-5 font-weight-bold mr-2"">
                                <span class=""svg-icon svg-icon-success svg-icon-3x"">
                                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <polygon points=""0 0 24 0 24 24 0 24"" />
                                            <path d=""M4.85714286,1 L11.7364114,1 C12.0910962,1 12.4343066,1.12568431 12.7051108,1.35473959 L17.4686994,5.3839416 C17.8056532,5.66894833 18,6.08787823 18,6.52920201 L18,19.0833333 C18,20.8738751 17.9795521,21 16.1428571,21 L4.85714286,21 C3.02044787,21 3,20.8738751 3,19.0833333 L3,2.");
            WriteLiteral(@"91666667 C3,1.12612489 3.02044787,1 4.85714286,1 Z M8,12 C7.44771525,12 7,12.4477153 7,13 C7,13.5522847 7.44771525,14 8,14 L15,14 C15.5522847,14 16,13.5522847 16,13 C16,12.4477153 15.5522847,12 15,12 L8,12 Z M8,16 C7.44771525,16 7,16.4477153 7,17 C7,17.5522847 7.44771525,18 8,18 L11,18 C11.5522847,18 12,17.5522847 12,17 C12,16.4477153 11.5522847,16 11,16 L8,16 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                            <path d=""M6.85714286,3 L14.7364114,3 C15.0910962,3 15.4343066,3.12568431 15.7051108,3.35473959 L20.4686994,7.3839416 C20.8056532,7.66894833 21,8.08787823 21,8.52920201 L21,21.0833333 C21,22.8738751 20.9795521,23 19.1428571,23 L6.85714286,23 C5.02044787,23 5,22.8738751 5,21.0833333 L5,4.91666667 C5,3.12612489 5.02044787,3 6.85714286,3 Z M8,12 C7.44771525,12 7,12.4477153 7,13 C7,13.5522847 7.44771525,14 8,14 L15,14 C15.5522847,14 16,13.5522847 16,13 C16,12.4477153 15.5522847,12 15,12 L8,12 Z M8,16 C7.44771525,16 7,16.4477153 7,17 C7,17.5522847 7.44771525,18");
            WriteLiteral(@" 8,18 L11,18 C11.5522847,18 12,17.5522847 12,17 C12,16.4477153 11.5522847,16 11,16 L8,16 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                                        </g>
                                    </svg>
                                </span> شهادة خصم
                            </a>
                            </div>
                            <div class=""media"" style=""padding:14px; margin:20px;"" height=""200"" width=""200"">

                                <a href=""#"" class=""btn btn-light p-5 font-weight-bold mr-2"">
                                    <span class=""svg-icon svg-icon-success svg-icon-3x"">
                                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                <polygon points=""0 0 24 0 24 24 0 24"" />");
            WriteLiteral(@"
                                                <path d=""M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                                <rect fill=""#000000"" opacity=""0.3"" transform=""translate(8.984240, 12.127098) rotate(-45.000000) translate(-8.984240, -12.127098) "" x=""7.41281179"" y=""10.5556689"" width=""3.14285714"" height=""3.14285714"" rx=""0.75"" />
                                                <rect fill=""#000000"" opacity=""0.3"" transform=""translate(15.269955, 12.127098) rotate(-45.000000) translate(-15.269955, -12.127098) "" x=""13.6985261"" y=""10.5556689"" width=""3.14285714"" height=""3.14285714"" rx=""0.75"" />
                                                <rect fil");
            WriteLiteral(@"l=""#000000"" transform=""translate(12.127098, 15.269955) rotate(-45.000000) translate(-12.127098, -15.269955) "" x=""10.5556689"" y=""13.6985261"" width=""3.14285714"" height=""3.14285714"" rx=""0.75"" />
                                                <rect fill=""#000000"" transform=""translate(12.127098, 8.984240) rotate(-45.000000) translate(-12.127098, -8.984240) "" x=""10.5556689"" y=""7.41281179"" width=""3.14285714"" height=""3.14285714"" rx=""0.75"" />
                                            </g>
                                        </svg><!--end::Svg Icon-->
                                    </span> كشف حساب
                                </a>
                            </div>




                        </div>

                    </div>
                <!-- End container -->
            <!-- end Statices-back -->
        </section>
        <!-- End Statices Setion -->
    </div>
</div>

");
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
