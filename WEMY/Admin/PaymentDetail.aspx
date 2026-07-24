<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="WEMY.Admin.PaymentDetail" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Detail Pembayaran</h2>

    <hr />

    <table class="table table-bordered">

        <tr>
            <th>Nama</th>
            <td>
                <asp:Label
                    ID="lblName"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Email</th>
            <td>
                <asp:Label
                    ID="lblEmail"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Paket</th>
            <td>
                <asp:Label
                    ID="lblPlan"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Durasi</th>
            <td>
                <asp:Label
                    ID="lblDuration"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Total</th>
            <td>
                <asp:Label
                    ID="lblAmount"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Metode</th>
            <td>
                <asp:Label
                    ID="lblMethod"
                    runat="server" />
            </td>
        </tr>

        <tr>
            <th>Status</th>
            <td>
                <asp:Label
                    ID="lblStatus"
                    runat="server" />
            </td>
        </tr>

    </table>

    <h4>Bukti Pembayaran</h4>

    <asp:Image
        ID="imgProof"
        runat="server"
        Width="350" />

    <br />
    <br />

    <asp:Button
        ID="btnApprove"
        runat="server"
        Text="Approve"
        CssClass="btn btn-success"
        OnClick="btnApprove_Click"
        OnClientClick="return confirm('Apakah Anda yakin ingin menyetujui pembayaran ini?');" />

    <asp:Button
        ID="btnReject"
        runat="server"
        Text="Reject"
        CssClass="btn btn-danger"
        OnClick="btnReject_Click" />

</asp:Content>
