﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>

<link href="<%= Url.CdnContent("/Plugins/jquery-ui-1.9.2.custom.min.css") %>" rel="stylesheet" type="text/css" />
<link href="<%= Url.CdnContent("/CSS/Common.css") %>" rel="stylesheet" type="text/css" />