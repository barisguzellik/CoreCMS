#pragma checksum "C:\Users\baris\source\repos\CoreCMS\CoreCMS\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8494dbe5df787c56c8a62c2f294798566a506b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8494dbe5df787c56c8a62c2f294798566a506b4", @"/Pages/Index.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\baris\source\repos\CoreCMS\CoreCMS\Pages\Index.cshtml"
  
    ViewData["Title"] = "Admin";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">

    <div class=""row"">
        <div class=""col-lg-4"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""d-flex no-block"">
                        <div class=""m-r-20 align-self-center"">
                            <span class=""lstick m-r-20""></span>
                            <i class=""mdi mdi-star"" style=""font-size:40px;color:#398bf7;""></i>
                        </div>
                        <div class=""align-self-center"">
                            <h6 class=""text-muted m-t-10 m-b-0"">Service</h6>
                            <h2 class=""m-t-0"">");
#nullable restore
#line 21 "C:\Users\baris\source\repos\CoreCMS\CoreCMS\Pages\Index.cshtml"
                                         Write(Model.ServiceCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-lg-4"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""d-flex no-block"">
                        <div class=""m-r-20 align-self-center"">
                            <span class=""lstick m-r-20""></span>
                            <i class=""mdi mdi-tree"" style=""font-size:40px;color:#398bf7;""></i>
                        </div>
                        <div class=""align-self-center"">
                            <h6 class=""text-muted m-t-10 m-b-0"">Category</h6>
                            <h2 class=""m-t-0"">");
#nullable restore
#line 38 "C:\Users\baris\source\repos\CoreCMS\CoreCMS\Pages\Index.cshtml"
                                         Write(Model.CategoryCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-lg-4"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""d-flex no-block"">
                        <div class=""m-r-20 align-self-center"">
                            <span class=""lstick m-r-20""></span>
                            <i class=""mdi mdi-table"" style=""font-size:40px;color:#398bf7;""></i>
                        </div>
                        <div class=""align-self-center"">
                            <h6 class=""text-muted m-t-10 m-b-0"">Product</h6>
                            <h2 class=""m-t-0"">");
#nullable restore
#line 54 "C:\Users\baris\source\repos\CoreCMS\CoreCMS\Pages\Index.cshtml"
                                         Write(Model.ProductCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreCMS.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CoreCMS.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CoreCMS.IndexModel>)PageContext?.ViewData;
        public CoreCMS.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
