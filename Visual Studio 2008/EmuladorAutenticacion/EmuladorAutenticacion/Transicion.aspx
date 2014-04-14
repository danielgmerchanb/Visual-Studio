<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transicion.aspx.cs" Inherits="EmuladorAutenticacion.Transicion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina de Transición</title>
<%--    <meta http-equiv="Refresh" content="10;url=http://localhost:27805/pagamanet/web/MyPA/MyDirectory.aspx?ipa=*&idi=1&mpy=JustView&eml=N" />
--%></head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function pepito()
        {
        alert('Algo.');
        alert(document.getElementById("iFrameE").innerHTML.toString());
        }
    </script>
    <div>
        <iframe id="iFrameE" width="300" height="200" src="http://www.google.com" onload="pepito();">
        </iframe>
    </div>
    </form>
</body>
</html>
