#pragma checksum "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6171eb3f449378d1cdb48100910852bb01c4ce8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Index), @"mvc.1.0.view", @"/Views/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Index.cshtml", typeof(AspNetCore.Views_Index))]
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
#line 1 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6171eb3f449378d1cdb48100910852bb01c4ce8", @"/Views/Index.cshtml")]
    public class Views_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 49, true);
            WriteLiteral("\r\n<h2>Authentication with Identity</h2>\r\n<hr />\r\n");
            EndContext();
#line 5 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
            BeginContext(120, 13, true);
            WriteLiteral("    <p>Hello ");
            EndContext();
            BeginContext(134, 18, false);
#line 7 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
        Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(152, 7, true);
            WriteLiteral("!</p>\r\n");
            EndContext();
#line 8 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
     using (Html.BeginForm("LogOff", "Account"))
    {

#line default
#line hidden
            BeginContext(216, 73, true);
            WriteLiteral("        <input type=\"submit\" class=\"btn btn-default\" value=\"Log out\" />\r\n");
            EndContext();
#line 11 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
    }

#line default
#line hidden
#line 11 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
     
}
else
{

#line default
#line hidden
            BeginContext(308, 7, true);
            WriteLiteral("    <p>");
            EndContext();
            BeginContext(316, 39, false);
#line 15 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
  Write(Html.ActionLink("Register", "Register"));

#line default
#line hidden
            EndContext();
            BeginContext(355, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(369, 34, false);
#line 16 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
  Write(Html.ActionLink("Log in", "Login"));

#line default
#line hidden
            EndContext();
            BeginContext(403, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(417, 40, false);
#line 17 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
  Write(Html.ActionLink("Home", "Index", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(457, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 18 "C:\Users\NikhilBatta\Desktop\SweetSavory.Solution\SweetSavory\Views\Index.cshtml"
}

#line default
#line hidden
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
