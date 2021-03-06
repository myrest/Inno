﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery-1.9.1.min.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery-ui-1.9.2.custom.min.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/TemplateJS.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/rabbit3.0.2.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/aes.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/base64-min.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/json2.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/Common.js") %>"></script>
<script type="text/javascript" src="<%= Url.CdnContent("/js/Main.js") %>"></script>