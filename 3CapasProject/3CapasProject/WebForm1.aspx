<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_3CapasProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style type="text/css">
          #form1 {
              height: 911px;
          }
          #Select1 {
              width: 129px;
          }
      </style>
      <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Formulario Nuevo Empleado</h1>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:HiddenField ID="hid" runat="server" />
            <asp:TextBox ID="txtNom"   PlaceHolder="Nombre"    runat  ="server" Width="139px" ToolTip="Nombre" Height="22px" style="margin-left: 489px; margin-bottom: 0px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblnom" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtApe"   PlaceHolder="Apellido"  runat="server" Width="139px" ToolTip="Apellido" style="margin-left: 488px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblapellido" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtEda"   PlaceHolder="Edad"      runat  ="server" TextMode="Number" ToolTip="Edad" Width="140px" Height="16px" style="margin-left: 489px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbledad" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <br/>
            <asp:TextBox ID="txtCargo" PlaceHolder="Cargo en la Empresa" runat="server" Width="140px" ToolTip="Cargo" style="margin-left: 490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCargo" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtsue" placeHolder="Sueldo" runat="server" TextMode="Number" Width="141px" ToolTip="Sueldo" style="margin-left: 490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblsueldo" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
         


            <asp:Button ID="Button2" runat="server" Text="Guardar" OnClick="Button2_Click" style="margin-left: 567px" /><br/>
         


            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Nuevo" OnClick="Button1_Click" Width="92px" style="margin-left: 116px" /><br />
         </div>



         
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="244px" ScrollBars="Both" style="margin-left: 111px" Width="956px">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="128px" Width="937px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-left: 8px; margin-top: 12px;">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField CommandName="Borrar" Text="Borrar" />
                        <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
        </asp:Panel>
        
    </form>
</body>
</html>
