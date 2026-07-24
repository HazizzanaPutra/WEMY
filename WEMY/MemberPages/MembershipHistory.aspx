<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembershipHistory.aspx.cs" Inherits="WEMY.MemberPages.MembershipHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Riwayat Membership</h2>

    <p>
        Berikut adalah seluruh riwayat pembelian membership Anda.
    </p>

    <asp:GridView
        ID="gvHistory"
        runat="server"
        CssClass="table table-bordered table-hover"
        AutoGenerateColumns="False">

        <Columns>

            <asp:BoundField
                DataField="OrderDate"
                HeaderText="Tanggal"
                DataFormatString="{0:dd MMM yyyy}" />

            <asp:BoundField
                DataField="PlanName"
                HeaderText="Paket" />

            <asp:BoundField
                DataField="TotalPrice"
                HeaderText="Total"
                DataFormatString="Rp {0:N0}" />

            <asp:BoundField
                DataField="Status"
                HeaderText="Status" />

        </Columns>

    </asp:GridView>
</asp:Content>
