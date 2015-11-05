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
                    <option value="Analysis,Analysis4">瞭解市場</option>
                    <option value="Topic,Set2">SET便條紙</option>
                </select>
                <label for="AllJump">
                    <input type="checkbox" id="AllJump" />全員跳頁
                </label>

            </span>
        </td>
    </tr>
</table>