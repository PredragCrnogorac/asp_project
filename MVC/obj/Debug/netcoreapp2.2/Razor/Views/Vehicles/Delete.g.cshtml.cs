#pragma checksum "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a358f1743a187ebfbff71495e587f6d87457b081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicles_Delete), @"mvc.1.0.view", @"/Views/Vehicles/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vehicles/Delete.cshtml", typeof(AspNetCore.Views_Vehicles_Delete))]
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
#line 1 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
#line 2 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\_ViewImports.cshtml"
using MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a358f1743a187ebfbff71495e587f6d87457b081", @"/Views/Vehicles/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7a8f56340c239c091cff637a00cc2fdf252300", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicles_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DTO.ResponseDTO.VehicleResponseDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
  
	ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(96, 19, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n");
            EndContext();
#line 8 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
 if (TempData["error"] != null)
{

#line default
#line hidden
            BeginContext(151, 24, true);
            WriteLiteral("\t<p class=\"text-danger\">");
            EndContext();
            BeginContext(176, 17, false);
#line 10 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
                      Write(TempData["error"]);

#line default
#line hidden
            EndContext();
            BeginContext(193, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 11 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
}

#line default
#line hidden
            BeginContext(202, 82, true);
            WriteLiteral("<div>\r\n\t<h4>Vehicle</h4>\r\n\t<hr />\r\n\t<dl class=\"row\">\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(285, 38, false);
#line 17 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(323, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(364, 34, false);
#line 20 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(398, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(438, 41, false);
#line 23 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(479, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(520, 37, false);
#line 26 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Model));

#line default
#line hidden
            EndContext();
            BeginContext(557, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(597, 52, false);
#line 29 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FuelTankCapacity));

#line default
#line hidden
            EndContext();
            BeginContext(649, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(690, 48, false);
#line 32 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FuelTankCapacity));

#line default
#line hidden
            EndContext();
            BeginContext(738, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(778, 46, false);
#line 35 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CostPerDay));

#line default
#line hidden
            EndContext();
            BeginContext(824, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(865, 42, false);
#line 38 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CostPerDay));

#line default
#line hidden
            EndContext();
            BeginContext(907, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(947, 48, false);
#line 41 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VehicleBrand));

#line default
#line hidden
            EndContext();
            BeginContext(995, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(1036, 44, false);
#line 44 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VehicleBrand));

#line default
#line hidden
            EndContext();
            BeginContext(1080, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(1120, 47, false);
#line 47 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VehicleType));

#line default
#line hidden
            EndContext();
            BeginContext(1167, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(1208, 43, false);
#line 50 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VehicleType));

#line default
#line hidden
            EndContext();
            BeginContext(1251, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(1291, 45, false);
#line 53 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Automatic));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(1377, 41, false);
#line 56 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Automatic));

#line default
#line hidden
            EndContext();
            BeginContext(1418, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(1458, 42, false);
#line 59 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Rented));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(1541, 38, false);
#line 62 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Rented));

#line default
#line hidden
            EndContext();
            BeginContext(1579, 39, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
            EndContext();
            BeginContext(1619, 41, false);
#line 65 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
            EndContext();
            BeginContext(1660, 40, true);
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
            EndContext();
            BeginContext(1701, 37, false);
#line 68 "C:\Users\Shomy\Desktop\Bata ASP\AIFP\MVC\Views\Vehicles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Color));

#line default
#line hidden
            EndContext();
            BeginContext(1738, 22, true);
            WriteLiteral("\r\n\t\t</dd>\r\n\t</dl>\r\n\r\n\t");
            EndContext();
            BeginContext(1760, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a358f1743a187ebfbff71495e587f6d87457b08112420", async() => {
                BeginContext(1786, 71, true);
                WriteLiteral("\r\n\t\t<input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n\t\t");
                EndContext();
                BeginContext(1857, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a358f1743a187ebfbff71495e587f6d87457b08112886", async() => {
                    BeginContext(1879, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1895, 3, true);
                WriteLiteral("\r\n\t");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1905, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DTO.ResponseDTO.VehicleResponseDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591