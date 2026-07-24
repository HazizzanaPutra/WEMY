<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YogaClassForm.aspx.cs" Inherits="WEMY.Admin.YogaClassForm" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 id="lblTitle"
        runat="server">Tambah Jadwal Yoga

</h2>

    <hr />

    <div class="form-group">

        <label>Judul Kelas</label>

        <asp:TextBox
            ID="txtClassTitle"
            runat="server"
            CssClass="form-control" />

    </div>

    <div class="form-group mt-3">

        <label>Tema</label>

        <asp:DropDownList
            ID="ddlTheme"
            runat="server"
            CssClass="form-control">

            <asp:ListItem>Relaxation</asp:ListItem>
            <asp:ListItem>Balance</asp:ListItem>
            <asp:ListItem>Flexibility</asp:ListItem>
            <asp:ListItem>Strength</asp:ListItem>
            <asp:ListItem>Meditation</asp:ListItem>

        </asp:DropDownList>

    </div>

    <div class="form-group mt-3">

        <label>Level</label>

        <asp:DropDownList
            ID="ddlDifficulty"
            runat="server"
            CssClass="form-control">

            <asp:ListItem>All Level</asp:ListItem>
            <asp:ListItem>Beginner</asp:ListItem>
            <asp:ListItem>Intermediate</asp:ListItem>
            <asp:ListItem>Advanced</asp:ListItem>

        </asp:DropDownList>

    </div>

    <div class="form-group mt-3">

        <label>Tanggal</label>

        <asp:TextBox
            ID="txtDate"
            runat="server"
            CssClass="form-control"
            TextMode="Date" />

    </div>

    <div class="form-group mt-3">

        <label>Jam Mulai</label>

        <asp:TextBox
            ID="txtStartTime"
            runat="server"
            CssClass="form-control"
            TextMode="Time" />

    </div>

    <div class="form-group mt-3">

        <label>Jam Selesai</label>

        <asp:TextBox
            ID="txtEndTime"
            runat="server"
            CssClass="form-control"
            TextMode="Time" />

    </div>

    <div class="form-group mt-3">

        <label>Instruktur</label>

        <asp:TextBox
            ID="txtTeacher"
            runat="server"
            CssClass="form-control" />

    </div>

    <div class="form-group mt-3">

        <label>Kuota Peserta</label>

        <asp:TextBox
            ID="txtMaxParticipant"
            runat="server"
            CssClass="form-control"
            TextMode="Number" />

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
        PostBackUrl="~/Admin/YogaClasses.aspx" />
</asp:Content>
