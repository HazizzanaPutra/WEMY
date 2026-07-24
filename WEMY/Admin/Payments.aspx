<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="WEMY.Admin.Payments" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container mt-5">

        <h2>Verifikasi Pembayaran</h2>

        <hr />

        <asp:GridView
            ID="gvPayments"
            runat="server"
            CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False">

            <Columns>

                <asp:BoundField
                    DataField="PaymentID"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="PlanName"
                    HeaderText="Paket" />

                <asp:BoundField
                    DataField="Amount"
                    HeaderText="Total" />

                <asp:BoundField
                    DataField="PaymentMethod"
                    HeaderText="Metode" />

                <asp:BoundField
                    DataField="PaymentDate"
                    HeaderText="Tanggal" />

                <asp:BoundField
                    DataField="Status"
                    HeaderText="Status" />

                <asp:TemplateField HeaderText="Aksi">
                    <ItemTemplate>
                        <asp:Button
                            ID="btnDetail"
                            runat="server"
                            Text="Detail"
                            CssClass="btn btn-primary btn-sm"
                            PostBackUrl='<%# "~/Admin/PaymentDetail.aspx?id=" + Eval("PaymentID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
