#pragma checksum "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed8b3c6b074a9fd0a0c2d91105175fc5bb7bee47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\_ViewImports.cshtml"
using HotelBookingSystem.WebAppMVC;

#line default
#line hidden
#line 2 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\_ViewImports.cshtml"
using HotelBookingSystem.WebAppMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed8b3c6b074a9fd0a0c2d91105175fc5bb7bee47", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfb222d74d89d2bd843b5da6c80d1aa0c3710ee5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 398, true);
            WriteLiteral(@"<style>
    #login {
        width: 100px;
        height: 100px;
        margin: auto;
        position: absolute;
        left: 50%;
        top: 50%;
        margin-top: -50px;
        margin-left: -50px;
    }
</style>

<div id=""login"">
    <p class=""text-center""><b>Account Type:</b></p>
    <br />
    <input type=""button"" class=""btn-danger "" value=""          STAFF          """);
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 443, "\"", 499, 3);
            WriteAttributeValue("", 453, "location.href=\'", 453, 15, true);
#line 20 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 468, Url.Action("Login", "Staffs"), 468, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 498, "\'", 498, 1, true);
            EndWriteAttribute();
            BeginContext(500, 109, true);
            WriteLiteral(" />\r\n    <br /> <br /> <br />\r\n    <input type=\"button\" class=\"btn-success \" value=\"         CLIENT         \"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 609, "\"", 666, 3);
            WriteAttributeValue("", 619, "location.href=\'", 619, 15, true);
#line 22 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 634, Url.Action("Login", "Clients"), 634, 31, false);

#line default
#line hidden
            WriteAttributeValue("", 665, "\'", 665, 1, true);
            EndWriteAttribute();
            BeginContext(667, 111, true);
            WriteLiteral(" />\r\n\r\n    <br /> <br /> <br />\r\n    <input type=\"button\" class=\"btn-primary \" value=\"         SIGN UP        \"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 778, "\"", 836, 3);
            WriteAttributeValue("", 788, "location.href=\'", 788, 15, true);
#line 25 "C:\Users\Ezgi\source\repos\odev\HotelBookingSystem\HotelBookingSystem.WebAppMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 803, Url.Action("Create", "Clients"), 803, 32, false);

#line default
#line hidden
            WriteAttributeValue("", 835, "\'", 835, 1, true);
            EndWriteAttribute();
            BeginContext(837, 11, true);
            WriteLiteral(" />\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591