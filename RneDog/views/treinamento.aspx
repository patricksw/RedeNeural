<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="treinamento.aspx.cs" Inherits="RneDog.views.treinamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Treinamento</legend>
        <asp:Label ID="lbTreinamento" runat="server" Text="Selecione o Arquivo Para o Treinamento" CssClass="label"></asp:Label><br />
        <asp:FileUpload ID="fileUpTreinamento" runat="server" CssClass="input" /><br />
        <br />
        <asp:Button ID="btnTreinar" runat="server" CssClass="button" Text="Treinar" OnClick="btnTreinar_Click" /><br />
        <asp:GridView ID="grvFuncao" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Parâmetros da Função">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Neuronio") %>' ID="Label1" CssClass="label-green"></asp:Label>
                        <asp:Label runat="server" Text='<%# "[" + Math.Abs(Convert.ToDouble(Eval("Limite"))) + "]" %>' ID="Label2" CssClass="label"></asp:Label>
                        <asp:Label runat="server" Text='<%#"[" + Math.Abs(Convert.ToDouble(Eval("Valor"))) + "]" %>' ID="Label3" CssClass="label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
    <fieldset>
        <legend>Identificar Raça</legend>
        <asp:Label ID="lbVida" runat="server" Text="Espectativa de Vida" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtVida" runat="server" CssClass="input"></asp:TextBox><br />
        <asp:Label ID="lbAltura" runat="server" Text="Altura do Cacnhorro (cm)" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtAltura" runat="server" CssClass="input"></asp:TextBox><br />
        <asp:Label ID="lbPeso" runat="server" Text="Peso do Cacnhorro (kg)" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtPeso" runat="server" CssClass="input"></asp:TextBox><br />
        <asp:Label ID="lbInteligencia" runat="server" Text="Fator de Inteligência" CssClass="label"></asp:Label><br />
        <asp:DropDownList ID="dpdInteligencia" runat="server" CssClass="input">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnDescobrir" runat="server" Text="Descobrir Raça" CssClass="button" OnClick="btnDescobrir_Click" />
    </fieldset>
    <fieldset style="width: 860px; min-height: 100px;">
        <legend>Resultado</legend>
        <div style="float: left; border: solid 1px;">
            <asp:Image ID="img_cao" runat="server" ImageUrl="~/image/dog.png" />
        </div>
        <div style="float: left; margin: 5px;">
            <asp:Label ID="lbNomeRaca" runat="server" Text="Raça: " CssClass="label-red"></asp:Label><br />
            <asp:Label ID="lbPorcentagem" runat="server" Text="Precisão: " CssClass="label-blue"></asp:Label>
        </div>
    </fieldset>
</asp:Content>
