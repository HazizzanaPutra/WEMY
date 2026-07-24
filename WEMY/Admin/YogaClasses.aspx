<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YogaClasses.aspx.cs" Inherits="WEMY.Admin.YogaClasses" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Manajemen Jadwal Yoga</h2>

    <p>
        Kelola seluruh jadwal kelas yoga.
    </p>

    <hr />

    <asp:Button
        ID="btnAdd"
        runat="server"
        Text="+ Tambah Jadwal"
        CssClass="btn btn-success mb-3"
        OnClick="btnAdd_Click" />

    <asp:GridView
        ID="gvYogaClass"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover">

        <Columns>

            <asp:BoundField
                DataField="ClassID"
                HeaderText="ID" />

            <asp:BoundField
                DataField="ClassTitle"
                HeaderText="Judul Kelas" />

            <asp:BoundField
                DataField="Theme"
                HeaderText="Tema" />

            <asp:BoundField
                DataField="Difficulty"
                HeaderText="Level" />

            <asp:BoundField
                DataField="ClassDate"
                HeaderText="Tanggal"
                DataFormatString="{0:dd MMM yyyy}" />

            <asp:BoundField
                DataField="Teacher"
                HeaderText="Instruktur" />

            <asp:BoundField
                DataField="MaxParticipant"
                HeaderText="Kuota" />

            <asp:TemplateField HeaderText="Aksi">

                <ItemTemplate>

                    <asp:Button
                        ID="btnEdit"
                        runat="server"
                        Text="Edit"
                        CssClass="btn btn-warning btn-sm"
                        CommandArgument='<%# Eval("ClassID") %>'
                        OnClick="btnEdit_Click" />

                    <asp:Button
                        ID="btnDelete"
                        runat="server"
                        Text="Hapus"
                        CssClass="btn btn-danger btn-sm"
                        CommandArgument='<%# Eval("ClassID") %>'
                        OnClick="btnDelete_Click"
                        OnClientClick="return confirm('Yakin ingin menghapus jadwal ini?');" />

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>
