<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmuladorAutenticacion._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Autenticación</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            width: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" class="style3">
            <tr>
                <td style="border-style: outset; padding: 0px">
                    <table class="style1">
                        <tr>
                            <td colspan="2">
                                <h1>
                                    Autenticación</h1>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <h2>
                                    Nombre:</h2>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <h2>
                                    Contraseña:</h2>
                            </td>
                            <td>
                                <asp:TextBox ID="tbxContrasena" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <hr />
                                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
