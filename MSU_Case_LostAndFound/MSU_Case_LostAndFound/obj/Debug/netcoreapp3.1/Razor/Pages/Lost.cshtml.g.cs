#pragma checksum "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db03824b0bb6afc65f562347781e5d21d01c0e04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MSU_Case_LostAndFound.Pages.Pages_Lost), @"mvc.1.0.razor-page", @"/Pages/Lost.cshtml")]
namespace MSU_Case_LostAndFound.Pages
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
#line 1 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\_ViewImports.cshtml"
using MSU_Case_LostAndFound;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db03824b0bb6afc65f562347781e5d21d01c0e04", @"/Pages/Lost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c885ef89a50eac290e471ae55d9e33d905e3c00d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Lost : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
  
    ViewData["Title"] = "Dyr som er savnet";


    int totalItems = Model.AnimalLst.Count();
    int itemsPerRow = 3;

    int counter = -1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"w-100 d-flex flex-row\">\r\n    <div class=\"w-50\">\r\n        <h1>");
#nullable restore
#line 15 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div class=\"w-50 d-flex justify-content-end align-content-end\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db03824b0bb6afc65f562347781e5d21d01c0e044688", async() => {
                WriteLiteral("\r\n            <div class=\"btn btn-primary\">Ny annonse</div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"w-100 d-flex flex-row justify-content-between\">\r\n");
#nullable restore
#line 25 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
     foreach (var item in Model.AnimalLst)
    {
        Console.WriteLine(item.Name);
        counter++;

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
         if (counter % 3 == 0)
        {
            Console.WriteLine("Line swap");

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("</div><div class=\"w-100 d-flex flex-row justify-content-between\">\r\n");
#nullable restore
#line 34 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"w-25 border p-2 mb-2 d-flex flex-row\">\r\n            <div class=\"w-50 mr-1\">\r\n                <p>picture</p>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1002, "\"", 1022, 1);
#nullable restore
#line 39 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
WriteAttributeValue("", 1008, item.ImageUrl, 1008, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"animal-picture\" class=\"img-fluid ar-1-1\" />\r\n            </div>\r\n            <div class=\"w-50 d-flex flex-column\">\r\n                <div>\r\n                    ");
#nullable restore
#line 43 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
#nullable restore
#line 46 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
               Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db03824b0bb6afc65f562347781e5d21d01c0e048635", async() => {
                WriteLiteral("\r\n                        <div class=\"btn btn-primary\">Se mer</div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 55 "C:\Users\patrick.grove\Desktop\Github\MSU_CASE_LostAndFound\MSU_Case_LostAndFound\MSU_Case_LostAndFound\Pages\Lost.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LostModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LostModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LostModel>)PageContext?.ViewData;
        public LostModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
