#pragma checksum "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7ccfa6752c8ce13e9b743cbbe6ad759bf87bb66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CheckOut), @"mvc.1.0.view", @"/Views/Order/CheckOut.cshtml")]
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
#line 1 "C:\Users\ADMIN\source\repos\FOODEE\Views\_ViewImports.cshtml"
using FOODEE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ADMIN\source\repos\FOODEE\Views\_ViewImports.cshtml"
using FOODEE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7ccfa6752c8ce13e9b743cbbe6ad759bf87bb66", @"/Views/Order/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fa9a633665020c60af809e285312805c91111e1", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FOODEE.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mx-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
  
    Layout = "_CustomerDashboardLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
  
    ViewBag.Title = "CheckOut";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card-header text-center tex-white \">\r\n    <h5 class=\"text-success \">CheckOut</h5>\r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-lg\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 279, "\"", 287, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size: 1px\">\r\n            <h2 style=\"color:black; font-size:20px; font-family:\'Times New Roman\'\"><em>UserName:</em></h2>\r\n            <h5 style=\"width: max-content\">");
#nullable restore
#line 16 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
                                      Write(ViewBag.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div>\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 517, "\"", 525, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size: 20px\">\r\n            <h2 style=\"color:black; font-size:20px; font-family:\'Times New Roman\'\"><em>Email</em></h2>\r\n            <h5 style=\"width: max-content\">");
#nullable restore
#line 20 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
                                      Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div><br />\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 755, "\"", 763, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size: 20px\">\r\n            <h2 style=\"color:black; font-size:20px; font-family:\'Times New Roman\'\"><em>PhoneNumber</em></h2>\r\n            <h5 style=\"width: max-content\">");
#nullable restore
#line 24 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
                                      Write(ViewBag.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <h2 style=\"color:black; font-size:20px; font-family:\'Times New Roman\'\"><em>Delivery Address</em></h2>\r\n            <h1 style=\"width: max-content\">");
#nullable restore
#line 28 "C:\Users\ADMIN\source\repos\FOODEE\Views\Order\CheckOut.cshtml"
                                      Write(ViewBag.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
        </div>
    </div>
    <br />
<div class=""col-lg"">
    <div class=""coler-25"">
        <div class=""container"">

            <div class=""notification text-success"">
                <h5>
                    FOODEE CART<i class=""fa fa-fw fa-shopping-cart""></i><span class=""badge"" id='newTotalQuantityLabel'></span>
                </h5>
            </div>
            <div class=""card-body "" id=""cart-menu"">
            </div>
        </div>
    </div>
</div>
</div>
<div class=""col"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7ccfa6752c8ce13e9b743cbbe6ad759bf87bb667361", async() => {
                WriteLiteral("Payment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FOODEE.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
