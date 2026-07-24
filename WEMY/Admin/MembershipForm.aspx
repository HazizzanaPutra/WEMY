<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembershipForm.aspx.cs" Inherits="WEMY.Admin.MembershipForm" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 id="lblTitle"
        runat="server">Tambah Membership</h2>

    <hr />

    <div class="form-group">

        <label>Nama Paket</label>

        <asp:TextBox
            ID="txtPlanName"
            runat="server"
            CssClass="form-control" />

    </div>

    <div class="form-group mt-3">

        <label>Harga</label>

        <asp:TextBox
            ID="txtPrice"
            runat="server"
            CssClass="form-control" />

    </div>

    <div class="form-group mt-3">

        <label>Durasi (Bulan)</label>

        <asp:TextBox
            ID="txtDuration"
            runat="server"
            CssClass="form-control" />

    </div>

    <div class="form-group mt-3">

        <label>Deskripsi</label>

        <asp:TextBox
            ID="txtDescription"
            runat="server"
            TextMode="MultiLine"
            Rows="5"
            CssClass="form-control" />

    </div>

    <br />

    <asp:Button
        ID="btnSave"
        runat="server"
        Text="Simpan"
        CssClass="btn btn-success"
        OnClick="btnSave_Click" />

    <asp:Button
        ID="btnCancel"
        runat="server"
        Text="Batal"
        CssClass="btn btn-secondary"
        PostBackUrl="~/Admin/Memberships.aspx" />

</asp:Content>
