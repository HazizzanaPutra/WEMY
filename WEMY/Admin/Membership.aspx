<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="WEMY.Admin.Membership" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Manajemen Paket Membership</h2>

    <p>
        Kelola seluruh paket membership yang tersedia.
    </p>

    <hr />

    <asp:Button
        ID="btnAdd"
        runat="server"
        Text="+ Tambah Paket"
        CssClass="btn btn-success mb-3"
        OnClick="btnAdd_Click" />

    <asp:GridView
        ID="gvMembership"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover">

        <Columns>

            <asp:BoundField
                DataField="PlanID"
                HeaderText="ID" />

            <asp:BoundField
                DataField="PlanName"
                HeaderText="Nama Paket" />

            <asp:BoundField
                DataField="Price"
                HeaderText="Harga"
                DataFormatString="Rp {0:N0}" />

            <asp:BoundField
                DataField="DurationMonth"
                HeaderText="Durasi (Bulan)" />

            <asp:TemplateField HeaderText="Aksi">

                <ItemTemplate>

                    <asp:Button
                        ID="btnEdit"
                        runat="server"
                        Text="Edit"
                        CssClass="btn btn-warning btn-sm"
                        CommandArgument='<%# Eval("PlanID") %>'
                        OnClick="btnEdit_Click" />

                    <asp:Button
                        ID="btnDelete"
                        runat="server"
                        Text="Hapus"
                        CssClass="btn btn-danger btn-sm"
                        CommandArgument='<%# Eval("PlanID") %>'
                        OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Hapus paket ini?');" />

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>
