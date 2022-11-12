<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarEleitor.aspx.cs" Inherits="Urna.Eleitor.CadastrarEleitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <h5>Insira o nome:</h5>
                <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                <h5>Insira o título do eleitor:</h5>
                <asp:TextBox runat="server" ID="txtTitulo"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <h5>Insira a seção:</h5>
                <asp:TextBox runat="server" ID="txtSecao"></asp:TextBox>
                <h5>Insira a zona:</h5>
                <asp:TextBox runat="server" ID="txtZona"></asp:TextBox>
            </div>
            <div class="col-sm-12 text-center" style="margin-top:15px;">
                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" CssClass=" btn-success" OnClick="btnCadastrar_Click" />
            </div>

        </div>
    </div>

</asp:Content>
