<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TrabajoPractico6.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <br />
                        <br />
&nbsp;<br />
                        <strong><span class="auto-style2">Grupo Nº 3 </span></strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:HyperLink ID="HlbtnEjercicio1" runat="server" NavigateUrl="~/Ejercicio1.aspx">Ejercicio 1</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:HyperLink ID="hlbtnEjercicio2" runat="server">Ejercicio 2</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
