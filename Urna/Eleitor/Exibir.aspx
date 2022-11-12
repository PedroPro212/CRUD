<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exibir.aspx.cs" Inherits="Urna.Eleitor.Exibir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    </style>

    <div class="container">
        <div class="text-center">
            <div class="row" style="margin-top:15px;">
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtNome" placeholder="Digite o nome:"></asp:TextBox>
                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                </div>
                <div class="col-sm-2"></div>
                <div class="col-sm-6">
                    <asp:Button runat="server" CssClass="btn btn-success" ID="btnCadastrarEleitor" Text="Cadastrar Eleitor" OnClick="btnCadastrarEleitor_Click" />
                </div>
                <div class="col-sm-1"><img runat="server" src="/imgs/bolso.png" width="80" /></div>
                <div class="col-sm-10" style="margin-top:30px;">
                    <asp:GridView runat="server" ID="grdEleitor" Width="80%" AutoGenerateColumns="false"
                    CssClass="table table-sm table-bordered table-condensed table-responsive-sm table-dark table-dark" OnRowCommand="grdEleitor_RowCommand"
                    AllowPaging="false">

                    <Columns>
                        <asp:BoundField DataField="nome" HeaderText="NOME" />
                        <asp:BoundField DataField="titulo" HeaderText="TÍTULO" />
                        <asp:BoundField DataField="zona" HeaderText="ZONA" />
                        <asp:BoundField DataField="secao" HeaderText="SEÇÃO" />
                        <asp:ButtonField ButtonType="Link" CommandName="editar" ControlStyle-CssClass="btn btn-warning" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                        <asp:ButtonField ButtonType="Link" CommandName="excluir" ControlStyle-CssClass="btn btn-danger" Text="Excluir" ItemStyle-HorizontalAlign="Center" />
                    </Columns>

                </asp:GridView>
                </div>
                <div class="col-sm-1"><img runat="server" src="/imgs/dedo.png" width="120" /></div>
            </div>
        </div>
    </div>
</asp:Content>
