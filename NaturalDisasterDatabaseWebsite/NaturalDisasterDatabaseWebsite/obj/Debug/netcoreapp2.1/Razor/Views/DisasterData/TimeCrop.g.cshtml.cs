#pragma checksum "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c116fc3e9c7d57c7a8f83a1e4cc6cabd05f70bcf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DisasterData_TimeCrop), @"mvc.1.0.view", @"/Views/DisasterData/TimeCrop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DisasterData/TimeCrop.cshtml", typeof(AspNetCore.Views_DisasterData_TimeCrop))]
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
#line 1 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\_ViewImports.cshtml"
using NaturalDisasterDatabaseWebsite;

#line default
#line hidden
#line 2 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\_ViewImports.cshtml"
using NaturalDisasterDatabaseWebsite.Models;

#line default
#line hidden
#line 5 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\_ViewImports.cshtml"
using NaturalDisasterDatabaseWebsite.Controllers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c116fc3e9c7d57c7a8f83a1e4cc6cabd05f70bcf", @"/Views/DisasterData/TimeCrop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a6d8d6a67f7ada271b014efa1a910242944a815", @"/Views/_ViewImports.cshtml")]
    public class Views_DisasterData_TimeCrop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DisasterData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateCrop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCrop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteCrop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 143, true);
            WriteLiteral("<style>\r\n    span p a {\r\n        color: #337ab7;\r\n    }\r\n\r\n    span p a:hover {\r\n        color: #23527c;\r\n    }\r\n</style>\r\n<div style=\"\">\r\n    ");
            EndContext();
            BeginContext(143, 130, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ff87edb7b64a7892faced53c44d0b7", async() => {
                BeginContext(200, 69, true);
                WriteLiteral("<i class=\"glyphicon glyphicon-plus\"></i><span>添加时刻灾害数据：农作物生物灾害</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(273, 788, true);
            WriteLiteral(@"
    <button onclick=""downloadtimecrop();"" class=""btn btn-success"" style=""float:right; padding:3px 6px; border-radius:0px; font-size:14px;"">导出EXCEL</button>
</div>
<table class=""table"" id=""recorddatacrop"">
    <thead>
        <tr>
            <th style=""width:4%;"">序号</th>
            <th style=""width:8%;"">时间</th>
            <th style=""width:8%;"">经度(°)</th>
            <th style=""width:8%;"">维度(°)</th>
            <th style=""width:8%;"">损失(万元)</th>
            <th style=""width:8%;"">范围(公顷)</th>
            <th style=""width:13%;"">灾害类型</th>
            <th style=""width:13%;"">参考地点</th>
            <th style=""width:20%;"">详情</th>
            <th style=""width:6%;"">上报人</th>
            <th style=""width:4%;"" class=""noExl"">操作</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 31 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
          
            var i = 1;
            var count = 0;
            

#line default
#line hidden
#line 34 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
             foreach (var crop in ViewBag.croptime)
            {

#line default
#line hidden
            BeginContext(1193, 63, true);
            WriteLiteral("                <tr>\r\n                    <td class=\"t_center\">");
            EndContext();
            BeginContext(1257, 1, false);
#line 37 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                    Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1258, 58, true);
            WriteLiteral("</td>\r\n                    <td style=\"text-align:center;\">");
            EndContext();
            BeginContext(1317, 73, false);
#line 38 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                              Write(DateTime.Parse(@crop.croptime.ToString()).ToString("yyyy-MM-dd HH:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(1390, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(1408, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1440, 18, false);
#line 39 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                   Write(crop.croplongitude);

#line default
#line hidden
            EndContext();
            BeginContext(1458, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1490, 18, false);
#line 40 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                   Write(crop.cropdimension);

#line default
#line hidden
            EndContext();
            BeginContext(1508, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1540, 13, false);
#line 41 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                   Write(crop.croploss);

#line default
#line hidden
            EndContext();
            BeginContext(1553, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1585, 13, false);
#line 42 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                   Write(crop.croparea);

#line default
#line hidden
            EndContext();
            BeginContext(1598, 161, true);
            WriteLiteral("</td>\r\n                    <td class=\"newsInfo\" style=\"text-align:justify; text-align-last:left;\">\r\n                        <div class=\"newInfoTruncation boxId\">");
            EndContext();
            BeginContext(1760, 14, false);
#line 44 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                                        Write(crop.cropstyle);

#line default
#line hidden
            EndContext();
            BeginContext(1774, 38, true);
            WriteLiteral("</div>\r\n                        <span>");
            EndContext();
            BeginContext(1813, 14, false);
#line 45 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                         Write(crop.cropstyle);

#line default
#line hidden
            EndContext();
            BeginContext(1827, 190, true);
            WriteLiteral("</span>\r\n                    </td>\r\n                    <td class=\"newsInfo\" style=\"text-align:justify; text-align-last:left;\">\r\n                        <div class=\"newInfoTruncation boxId\">");
            EndContext();
            BeginContext(2018, 14, false);
#line 48 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                                        Write(crop.cropplace);

#line default
#line hidden
            EndContext();
            BeginContext(2032, 38, true);
            WriteLiteral("</div>\r\n                        <span>");
            EndContext();
            BeginContext(2071, 14, false);
#line 49 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                         Write(crop.cropplace);

#line default
#line hidden
            EndContext();
            BeginContext(2085, 220, true);
            WriteLiteral("</span>\r\n                    </td>\r\n                    <td class=\"newsInfo\" style=\"text-align:justify; text-align-last:left;\">\r\n                        <div class=\"newInfoTruncation newInfoTruncation3 boxId\" id=\"boxId\">");
            EndContext();
            BeginContext(2306, 60, false);
#line 52 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                                                                      Write(Html.Raw(System.Net.WebUtility.UrlDecode(@crop.cropdetails)));

#line default
#line hidden
            EndContext();
            BeginContext(2366, 38, true);
            WriteLiteral("</div>\r\n                        <span>");
            EndContext();
            BeginContext(2405, 60, false);
#line 53 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                         Write(Html.Raw(System.Net.WebUtility.UrlDecode(@crop.cropdetails)));

#line default
#line hidden
            EndContext();
            BeginContext(2465, 60, true);
            WriteLiteral("</span>\r\n                    </td>\r\n                    <td>");
            EndContext();
            BeginContext(2526, 13, false);
#line 55 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                   Write(crop.username);

#line default
#line hidden
            EndContext();
            BeginContext(2539, 71, true);
            WriteLiteral("</td>\r\n                    <td class=\"noExl\">\r\n                        ");
            EndContext();
            BeginContext(2610, 85, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aec42a307f05415a9a1e41303e43a32a", async() => {
                BeginContext(2689, 2, true);
                WriteLiteral("编辑");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 57 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                                                                 WriteLiteral(crop.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2695, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2776, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2800, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d2ffe4d46274968aa709eb5181ebfc7", async() => {
                BeginContext(2881, 2, true);
                WriteLiteral("删除");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                                                                                   WriteLiteral(crop.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2887, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 62 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\DisasterData\TimeCrop.cshtml"
                i++;
                count = i - 1;
            }

#line default
#line hidden
            BeginContext(3044, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(3081, 534, true);
            WriteLiteral(@"<script>
    function downloadtimecrop() {
        //console.log(1);
        $("".boxId"").html("""");
        $.noConflict(); //请务必加上这一句，否则无法下载excel，因为$符号与其他jq版本冲突了
        $(""#recorddatacrop"").table2excel({
            exclude: "".noExl"",
            name: new Date().getTime(),
            filename: new Date().getTime(),
            exclude_img: true,
            exclude_links: true,
            exclude_inputs: true
        });
        window.location.reload(); //强制刷新，因为 table2excel只执行一次，如果不刷新就不能再下载数据
    }
</script>");
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
