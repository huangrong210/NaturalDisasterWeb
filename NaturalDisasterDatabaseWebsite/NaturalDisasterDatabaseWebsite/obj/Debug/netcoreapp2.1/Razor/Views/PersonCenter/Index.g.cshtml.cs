#pragma checksum "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "399908e1eb3a2a1b75141ead1e71faf8adb08872"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PersonCenter_Index), @"mvc.1.0.view", @"/Views/PersonCenter/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PersonCenter/Index.cshtml", typeof(AspNetCore.Views_PersonCenter_Index))]
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
#line 1 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
using System.Security.Claims;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"399908e1eb3a2a1b75141ead1e71faf8adb08872", @"/Views/PersonCenter/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a6d8d6a67f7ada271b014efa1a910242944a815", @"/Views/_ViewImports.cshtml")]
    public class Views_PersonCenter_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/PersonCenter.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
  
    ViewData["Title"] = "个人中心";

#line default
#line hidden
            BeginContext(98, 15953, true);
            WriteLiteral(@"<style>
    .rownavparent {
        margin-right: 0px;
        margin-left: 0px;
    }

    .rownavchild1 {
        border-bottom: 1px solid #ddd;
        padding: 0px;
    }

    .rownavchild2 {
        padding-top: 15px;
        padding-left: 24px;
        font-size: 16px;
        box-shadow: 1px -1px 1px rgba(123,0,0,0.1) inset;
    }

    #ul1 {
        height: auto;
        list-style: none;
        float: none;
        padding-left: 0px;
        margin: 0 auto;
    }

        #ul1 li {
            height: 35px;
            line-height: 35px;
            text-align: center;
            cursor: pointer;
            font-size: 15px;
        }

            #ul1 li:hover {
                background: #fde3e4;
                color: #ca0c16;
            }

    #content {
        min-height: 492px;
    }

    .tab {
        display: none;
    }

    .hover {
        background: #b20b13 !important;
        color: #fff !important;
    }

    h3.title {
       ");
            WriteLiteral(@" font-size: 20px;
        color: #3d3d3d;
        height: 50px;
        line-height: 36px;
        border-bottom: 1px solid #e0e0e0;
        margin-top: 0px;
        font-weight: 600;
    }

    .modify {
        font-size: 14px;
        color: #3399ea;
        margin-top: 8px;
        cursor: pointer;
        text-align: center;
    }

    .hide {
        display: none;
    }

    .c1 {
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background: rgba(0,0,0,.5);
        z-index: 2;
    }

    .c2 {
        background-color: white;
        position: fixed;
        width: 500px;
        height: 300px;
        top: 50%;
        left: 50%;
        z-index: 3;
        margin-top: -150px;
        margin-left: -280px;
        border-radius: 2px;
    }

    .maninfo {
        list-style: none;
        padding-left: 15px;
    }

        .maninfo li {
            height: 52px;
            line-height: 52px;
      ");
            WriteLiteral(@"      font-size: 16px;
            color: #4d4d4d;
        }

            .maninfo li span {
                display: inline-block;
                width: 11%;
                text-align: right;
                margin-right: 5px;
            }

    .head-img {
        border: 1px dashed rgba(0,0,0,.08);
        background-color: rgba(0,0,0,.03);
        margin-left: 24px;
        display: inline-block;
    }

    #imgupload {
        display: none;
    }

    .mandatarow {
        margin-left: 0px;
        margin-right: 0px;
    }

        .mandatarow .mandatarow1 {
            padding-left: 0px;
            padding-right: 0px;
            width: 11%;
        }

        .mandatarow .mandatarow11 {
            width: 89%;
            padding-right: 0px;
        }

        .mandatarow .mandatarow1 > img {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            margin: 5px auto 0;
        }

    #modal .modalspan1 {
        di");
            WriteLiteral(@"splay: inline-block;
        margin: 15px 0px 15px 15px;
        font-size: 16px;
        color: #3d3d3d;
        font-weight: 600;
        float: left;
    }

    #modal .modalspan2 {
        display: inline-block;
        color: #999;
        margin: 10px 15px 15px 0px;
        float: right;
        cursor: pointer;
    }

    #modal #form1 #my-img {
        cursor: pointer;
        text-align: center;
        width: 212px;
        height: 200px;
        line-height: 160px;
    }

        #modal #form1 #my-img > p {
            font-size: 14px;
            color: #666;
            line-height: 30px;
            margin: 0;
        }

    #modal table .preview {
        width: 212px;
        margin-right: 4px;
        height: 200px;
        text-align: center;
        line-height: 200px;
        color: #999;
        display: inline-block;
        position: relative;
    }

        #modal table .preview img {
            width: 212px;
            height: 200px;
    ");
            WriteLiteral(@"        position: absolute;
            left: -1px;
            top: -1px;
        }

    #modal .groupbtn {
        margin-top: 4px;
        width: 500px;
    }

        #modal .groupbtn .btndiv {
            margin: 0px auto;
            text-align: center;
            margin-top: 2px;
            width: 470px;
        }

        #modal .groupbtn .btnsave, #submitxgzl .obtn .btnsave {
            width: 100px;
            font-size: 14px;
            color: #fff;
            background: #ca0c16;
            border-radius: 4px;
            outline: none;
            margin-right: 80px;
            padding-left: 0px;
            padding-right: 0px;
        }

        #modal .groupbtn .btncancel, .obtn .btncancel {
            width: 100px;
            color: #3d3d3d;
            background: #e0e0e0;
            border-radius: 4px;
        }

    .xiugaiziliao {
        float: right;
        font-size: 14px;
        color: #3399ea;
        cursor: pointer;
    }

    ");
            WriteLiteral(@"    .xiugaiziliao:hover, .modify:hover {
            color: #157dcf;
        }

    #submitxgzl .control-label {
        display: inline-block;
        font-weight: normal;
    }

    #submitxgzl .form-control {
        width: 86%;
        display: inline-block;
    }

    #submitxgzl .form-group {
        margin-bottom: 17px;
    }

    #submitxgzl .obtn .btnsave, #submitxgzl .obtn .btncancel {
        width: 80px;
    }

    .mdpwd ul {
        list-style: none;
        width: 397px;
        margin: 0 auto;
    }

        .mdpwd ul li {
            margin-bottom: 18px;
            height: 36px;
            position: relative;
        }

    .mdpwd label {
        font-size: 15px;
        font-weight: normal;
    }

    .mdpwd li input {
        width: 252px;
        height: 32px;
        line-height: 30px;
        margin-left: 8px;
        border: 1px solid #ccc;
        border-radius: 4px;
        padding: 0 8px;
        font-size: 14px;
        color: #4d4d4");
            WriteLiteral(@"d;
    }

    .mdpwd .see-passwordold, .mdpwd .see-passwordnew, .mdpwd .see-passwordqr {
        position: absolute;
        right: 10px;
        top: 8px;
        font-size: 16px;
        color: #999;
        cursor: pointer;
    }

    .mdpwd .confirm_btn {
        width: 80px;
        height: 36px;
        line-height: 34px;
        border-radius: 4px;
        font-size: 14px;
        text-align: center;
    }

    .mdpwd .confirm_disable {
        background: #f5f5f5;
        border: 1px solid #f5f5f5;
        cursor: default;
        color: #999;
    }

    .mdpwd .confirm_primary {
        color: #fff;
        background: #ca0c16;
        border: 1px solid #ca0c16;
        cursor: pointer;
    }

    .navItem {
        display: flex;
        flex-wrap: wrap;
        padding-left: 0;
        margin-bottom: 0;
        list-style: none;
        font-weight: 600;
    }

    .main-nav-tabs {
        margin-top: 5px;
        border-bottom: 1px solid #e9e9e9;
    ");
            WriteLiteral(@"    display: flex;
        -webkit-box-align: center;
        align-items: center;
        height: 30px;
        /*padding-bottom: 8px;*/
        color: #2c3e50;
    }

    .navItem .nav-link {
        margin-right: 56px;
        font-size: 15px;
        color: #999;
        padding: 0;
        display: block;
        height: 30px;
        cursor: pointer;
    }

    .main-nav-tabs .navactive {
        color: #4d4d4d;
        border-bottom: 2px solid #ca0c16;
        background-color: transparent;
        border-radius: 0;
    }

    .main-nav-tabs .nav-link:hover {
        color: #ca0c16;
    }

    .article-list-item-mp, .article-list-item-mp .list-item-title {
        display: flex;
        -webkit-box-direction: normal;
    }

    .article-list-item-mp {
        -webkit-box-orient: vertical;
        flex-direction: column;
        border-bottom: 1px dotted #ddd;
        padding: 1.2rem 0 1rem 0;
        color: #999;
        font-size: 14px;
    }

    .list-item-");
            WriteLiteral(@"title {
        -webkit-box-orient: horizontal;
        flex-direction: row;
        -webkit-box-pack: start;
        justify-content: flex-start;
    }

        .list-item-title .article-list-item-tag {
            font-size: 12px;
            padding: 0 8px;
            height: 24px;
            line-height: 24px;
            margin-right: 12px;
            white-space: nowrap;
            border: 1px solid #e9e9e9;
            flex-shrink: 0;
        }

        .list-item-title .article-list-item-txt {
            font-size: 18px;
            color: #4d4d4d;
            margin-bottom: 0;
            -webkit-box-flex: 1;
            flex-grow: 1;
            display: flex;
        }

            .list-item-title .article-list-item-txt a {
                text-decoration: none;
                color: #4d4d4d;
            }

    .article-list-item-info {
        margin-top: 10px;
        display: flex;
        -webkit-box-orient: horizontal;
        -webkit-box-direction: n");
            WriteLiteral(@"ormal;
        flex-direction: row;
        -webkit-box-align: center;
        align-items: center;
        -webkit-box-pack: justify;
        justify-content: space-between;
    }

        .article-list-item-info .item-info-left > span {
            margin-right: 1.5rem;
        }

        .article-list-item-info .article-list-item-readComment img {
            width: 14px;
            height: 12px;
            vertical-align: -2px;
            margin-right: 3px;
        }

        .article-list-item-info .item-info-oper a {
            text-decoration: none;
            color: #349edf;
        }

        .article-list-item-info .item-info-oper .del {
            color: #ca0c16;
            cursor: pointer;
        }

    .form_search {
        float: right;
    }

    .el-input__inner {
        padding-left: 6px;
        width: 180px;
        -webkit-appearance: none;
        background-color: #fff;
        background-image: none;
        border-radius: 4px;
        b");
            WriteLiteral(@"order: 1px solid #dcdfe6;
        box-sizing: border-box;
        color: #606266;
        display: inline-block;
        height: 30px;
        line-height: 30px;
        outline: none;
        padding: 0 10px;
        transition: border-color .2s cubic-bezier(.645,.045,.355,1);
    }

        .el-input__inner:focus {
            border-color: #ca0c16;
        }

    .el-button {
        padding: 1px 10px;
        background-color: #ca0c16;
        border-color: #ca0c16;
        font-size: 15px;
        color: #fff;
        transition: background-color .3s ease-in,border-color .3s ease-in;
        line-height: 26px;
        outline: none;
        border: none;
        display: inline-block;
        white-space: nowrap;
        cursor: pointer;
        border: 1px solid #dcdfe6;
        text-align: center;
        box-sizing: border-box;
        outline: none;
        font-weight: 500;
        border-radius: 4px;
    }

        .el-button:hover {
            background-color");
            WriteLiteral(@": #b50a13;
            border-color: #b50a13;
        }

    .ismanager:focus {
        color: #fff;
    }

    .comment-nav-tabs {
        display: -webkit-box;
        display: -ms-flexbox;
        display: flex;
        border-bottom: 1px solid #e9e9e9;
        -webkit-box-align: center;
        -ms-flex-align: center;
        align-items: center;
        height: 38px;
        line-height: 38px;
    }

    .comment-nav-item {
        margin-right: 36px;
        cursor: pointer;
        font-size: 15px;
        color: #999;
        padding: 0;
        border-bottom: 2px solid transparent;
    }

        .comment-nav-item:hover, .comment-nav-tabs .activecomment:hover {
            color: #ca0c16;
        }

    .comment-nav-tabs .activecomment {
        color: #4d4d4d;
        border-bottom-color: #ca0c16;
        background-color: transparent;
        border-radius: 0;
    }

    .comment-list-box {
        display: flex;
        height: 83px;
        color: #4f4f4");
            WriteLiteral(@"f;
        padding: 7px 0 12px;
        font-size: 15px;
        line-height: 22px;
        border-bottom: 1px dashed #ddd;
        margin-top: 2px;
    }

        .comment-list-box .img-avatar-box {
            width: 32px;
            height: 32px;
        }

            .comment-list-box .img-avatar-box img {
                width: 32px;
                height: 32px;
                border-radius: 50%;
            }

        .comment-list-box .comment-item-content {
            -webkit-box-flex: 1;
            -ms-flex: 1;
            flex: 1;
            margin-left: 10px;
        }

            .comment-list-box .comment-item-content .comment-item-title {
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
                font-weight: 400;
                margin-top: 5px;
                margin-bottom: 12px;
                min-height: 22px;
                color: #999;
            }

            .comment-list-box");
            WriteLiteral(@" .comment-item-content .comment-item-box .icon {
                height: 16px;
                fill: #d4d4d4;
            }

            .comment-list-box .comment-item-content .comment-item-title .item-title-left {
                -webkit-box-flex: 1;
                -ms-flex: 1;
                flex: 1;
                display: -webkit-box;
                display: -ms-flexbox;
                display: flex;
            }

            .comment-list-box .comment-item-content .comment-item-title span {
                margin-right: 12px;
            }

            .comment-list-box .comment-item-content .comment-item-title .article-title {
                max-width: 530px;
                overflow: hidden;
                white-space: nowrap;
                text-overflow: ellipsis;
                color: #349edf;
                text-decoration: none;
                cursor: pointer;
            }

            .comment-list-box .comment-item-content .comment-item-box {
          ");
            WriteLiteral(@"      position: relative;
            }

                .comment-list-box .comment-item-content .comment-item-box .zuo-icon {
                    position: absolute;
                    left: 0;
                    top: 3px;
                }

                .comment-list-box .comment-item-content .comment-item-box span {
                    max-width: 930px;
                    display: block;
                    word-wrap: break-word;
                    padding: 0 32px;
                }

                .comment-list-box .comment-item-content .comment-item-box .you-icon {
                    position: absolute;
                    right: 0;
                    top: 3px;
                }

                .comment-list-box .comment-item-content .comment-item-box .comment-ue p {
                    margin: 0px;
                    padding-top: 1px;
                }

                .comment-list-box .comment-item-content .comment-item-box .nop p {
                    padding-t");
            WriteLiteral(@"op: 0px;
                }

                .comment-list-box .comment-item-content .comment-item-box .comment-ue p img {
                    width: 25px;
                    height: 20px;
                }
</style>
<style>
    .timeli {
        list-style: none;
    }

    .timeli li {
        height:35px;
        line-height:35px;
        cursor: pointer;
    }
    .timeli li a{
        color:#3d3d3d;
    }
    .timeli li a:hover{
        color: #337ab7;
    }
</style>
<hr style=""border: 7px solid #f1f1f1; margin:0px 0px"" />
<input id=""IDNumber"" type=""hidden""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 16051, "\"", 16085, 1);
#line 659 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
WriteAttributeValue("", 16059, User.FindFirstValue("ID"), 16059, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(16086, 210, true);
            WriteLiteral(" />\r\n\r\n<div class=\"row rownavparent\">\r\n    <div id=\"colmd2\" class=\"col-md-2 rownavchild1\">\r\n        <ul id=\"ul1\">\r\n            <li class=\"hover\">个人资料</li>\r\n            <li>我的文章</li>\r\n            <li>我的评论</li>\r\n");
            EndContext();
            BeginContext(16327, 27, true);
            WriteLiteral("            <li>修改密码</li>\r\n");
            EndContext();
#line 669 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
             if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
            {

#line default
#line hidden
            BeginContext(16460, 60, true);
            WriteLiteral("                <li style=\"position:relative;\">拾取坐标系统</li>\r\n");
            EndContext();
#line 672 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(16535, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 673 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
             if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "普通用户")
            {

#line default
#line hidden
            BeginContext(16642, 34, true);
            WriteLiteral("                <li>申请成为管理员</li>\r\n");
            EndContext();
#line 676 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(16691, 204, true);
            WriteLiteral("            <li>上报时刻灾害数据</li>\r\n        </ul>\r\n    </div>\r\n    <div id=\"content\" class=\"col-md-10 rownavchild2\">\r\n        <div class=\"tab\" style=\"display:block;\">\r\n            <h3 class=\"title\">个人资料</h3>\r\n");
            EndContext();
#line 683 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
              
                await Html.RenderPartialAsync("MyData");
            

#line default
#line hidden
            BeginContext(16984, 43, true);
            WriteLiteral("        </div>\r\n        <div class=\"tab\">\r\n");
            EndContext();
#line 688 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
              
                await Html.RenderPartialAsync("MyEssays");
            

#line default
#line hidden
            BeginContext(17118, 43, true);
            WriteLiteral("        </div>\r\n        <div class=\"tab\">\r\n");
            EndContext();
#line 694 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
              
                await Html.RenderPartialAsync("MyComment");
            

#line default
#line hidden
            BeginContext(17312, 84, true);
            WriteLiteral("        </div>\r\n        <div class=\"tab\">\r\n            <h3 class=\"title\">修改密码</h3>\r\n");
            EndContext();
#line 700 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
              
                await Html.RenderPartialAsync("MyModifyPassword");
            

#line default
#line hidden
            BeginContext(17495, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(17585, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 706 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
         if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
        {

#line default
#line hidden
            BeginContext(17701, 31, true);
            WriteLiteral("            <div class=\"tab\">\r\n");
            EndContext();
            BeginContext(17783, 706, true);
            WriteLiteral(@"                <iframe id=""pickupZuobiao"" name=""pickupZuobiao"" scrolling=""no"" style=""width:100%; min-height:500px;"" allowfullscreen=""true"" frameborder=""0"" src=""https://api.map.baidu.com/lbsapi/getpoint/index.html"" onload=""frameauto()""></iframe>
                <script>
                    function frameauto() {
                        window.onerror = function () { return true; }
                        $(function () {
                            headerH = 0;
                            var h = $(window).height();
                            $(""#pickupZuobiao"").height((h - headerH) + ""px"");
                        });
                    }
                </script>
            </div>
");
            EndContext();
#line 722 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(18500, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 723 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
         if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "普通用户")
        {

#line default
#line hidden
            BeginContext(18599, 865, true);
            WriteLiteral(@"            <div class=""tab"">
                <h3 class=""title"">申请成为管理员</h3>
                请在下方发送邮件给BOSS并表述自身可以成为网站管理员的优势或条件……
                <iframe id=""pickupZuobiao"" name=""pickupZuobiao"" scrolling=""no"" style=""width:100%; min-height:500px;"" allowfullscreen=""true"" frameborder=""0"" src=""https://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=alhbWlJbWFldWl4qGxtECQUH"" onload=""frameauto()""></iframe>
                <script>
                    function frameauto() {
                        window.onerror = function () { return true; }
                        $(function () {
                            headerH = 0;
                            var h = $(window).height();
                            $(""#pickupZuobiao"").height((h - headerH) + ""px"");
                        });
                    }
                </script>
            </div>
");
            EndContext();
#line 740 "D:\bishe\NaturalDisasterDatabaseWebsite\NaturalDisasterDatabaseWebsite\Views\PersonCenter\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(19475, 2015, true);
            WriteLiteral(@"        <div class=""tab"">
            <h3 class=""title"">上报时刻灾害数据</h3>
            <ul class=""timeli"">
                <li><a href=""/DisasterData/CreateCrop"">农作物生物灾害</a></li>
                <li><a href=""/DisasterData/CreateForest"">森林生物灾害</a></li>
                <li><a href=""/DisasterData/CreateGeology"">地质灾害</a></li>
                <li><a href=""/DisasterData/CreateFire"">森林火灾</a></li>
                <li><a href=""/DisasterData/CreateFlood"">洪水灾害</a></li>
                <li><a href=""/DisasterData/CreateMeteorology"">气象灾害</a></li>
                <li><a href=""/DisasterData/CreateMarine"">海洋灾害</a></li>
                <li><a href=""/DisasterData/CreateQuake"">地震灾害</a></li>
            </ul>
        </div>
    </div>
</div>
<i id=""hidemenu"" class=""glyphicon glyphicon-menu-left"" style=""position:absolute; color:#b20b13; background:#fff; border:1px solid #999; border-top:none; font-size:13px; top:7.8%; left:7.8%;""><i class=""glyphicon glyphicon-menu-left"" style=""position:absolute; color:#b20b13; background");
            WriteLiteral(@":#fff; border:1px solid #999; border-top:none; font-size:13px; top:1%; border-left: none; left:73.8%;""></i></i>
<script>
    $(""#hidemenu"").click(function () {
        if ($('#hidemenu').hasClass('glyphicon-menu-left') && $('#hidemenu i').hasClass('glyphicon-menu-left')) {
            $(""#hidemenu"").attr(""class"", ""glyphicon glyphicon-menu-right"");
            $(""#hidemenu i"").attr(""class"", ""glyphicon glyphicon-menu-right"");
            $(""#colmd2"").hide();
            $(""#content"").attr(""class"", ""col-md-12 rownavchild2"");
            $("".rownavchild2"").css('box-shadow', 'none');
        } else {
            $(""#hidemenu"").attr(""class"", ""glyphicon glyphicon-menu-left"");
            $(""#hidemenu i"").attr(""class"", ""glyphicon glyphicon-menu-left"");
            $(""#colmd2"").show();
            $(""#content"").attr(""class"", ""col-md-10 rownavchild2"");
            $("".rownavchild2"").css('box-shadow', '1px -1px 1px rgba(123,0,0,0.1) inset');
        }
    });
</script>
");
            EndContext();
            BeginContext(21490, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "756b03f50dea4f1585f462a693c18645", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(21534, 4, true);
            WriteLiteral("\r\n\r\n");
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
