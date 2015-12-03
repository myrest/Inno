<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<table width="100%" border="0" align="center" id="QuickNavBar">
    <%
        QuickControllBarViewModel QCBAR = (QuickControllBarViewModel)ViewData["QCBAR"];
        bool IsAdmin = (bool)ViewData["_isAdmin"];
        bool IsLeader = (bool)ViewData["IsLeader"];
        bool IsClose = (bool)ViewData["IsClose"];

        if (IsAdmin)
        {
            IsLeader = IsAdmin;
        }
        string HideForNotLeader = (!IsLeader || IsClose) ? "hidden" : string.Empty;
        if (QCBAR.isFirstStep && !IsClose)
        {
            //At first step, all the member can see the ALL member jump function.
            HideForNotLeader = string.Empty;
        }
    %>
    <tr>
        <td align="center" colspan="3">
            <script type="text/javascript">
                var CurrentPage = [ '<% =QCBAR.ControlMainTitle %>', '<% =QCBAR.ControlSubTitle %>' ];
            </script>
            <span class="align-right QuickJumpBlock">
                <!--select id="MainMenuDDL">
                </!--select>
                <select id="QuickJump">
                </select -->
                <select id="QuickJump">
                    <option value="Topic,Set2">01. SET便條紙</option>
                    <option value="Topic,Set4">02. KJ法</option>
                    <option value="Topic,Set5">03. Set重要性分析</option>
                    <option value="Topic,Set6">04. 尋找產品機會缺口</option>
                    <option value="Topic,Set6_1">05. 我的點子</option>
                    <option value="Analysis,Analysis4">06. 現有市場分析</option>
                    <option value="Scenario,Scenario2_1">07. 角色扮演設定</option>
                    <option value="Scenario,Scenario3_1">08. 我的情境故事</option>
                    <option value="Scenario,Scenario4_1">09. 有價值點分析</option>
                    <option value="Scenario,Scenario5">10. 情境故事重要性分析</option>
                    <option value="Topic,Result3">設計專案成果</option>
                    <option value="Topic,Result1">草稿設計</option>
                    <option value="Topic,Result2">裱版設計</option>
                </select>
                <label for="AllJump">
                    <input type="checkbox" id="AllJump" />全員跳頁
                </label>

            </span>
        </td>
    </tr>
</table>