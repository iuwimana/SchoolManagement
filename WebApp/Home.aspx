<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<frameset cols="10%,*,10%">
  <frame src="onsides.aspx" frameborder=0>
  <frameset rows="30%,*,5%">
    <frame src="hedding.aspx" frameborder=0 noresize="noresize" scrolling=no>
    <frame src="Home1.aspx" name="mid_col" frameborder=0 noresize="noresize" scrolling=no>
    <frame src="onbotton.aspx" frameborder=0 noresize="noresize" scrolling=no>
  </frameset>
  <frame src="onsides.aspx" frameborder=0>
</frameset>
</html>