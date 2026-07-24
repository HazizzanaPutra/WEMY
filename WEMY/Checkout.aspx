<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WEMY.Checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container py-5">

        <div class="checkout-card">

            <h2>Checkout Membership</h2>

            <hr />

            <div class="checkout-item">

                <label>Paket Membership</label>

                <h4 id="lblPackage"
                    runat="server"></h4>

            </div>

            <div class="checkout-item">

                <label>Total Pembayaran</label>

                <h3 id="lblPrice"
                    runat="server"></h3>

            </div>

            <div class="checkout-item">

                <label>Metode Pembayaran</label>

                <asp:DropDownList
                    ID="ddlPaymentMethod"
                    runat="server"
                    CssClass="form-select">

                    <asp:ListItem>BCA</asp:ListItem>

                    <asp:ListItem>Mandiri</asp:ListItem>

                    <asp:ListItem>BNI</asp:ListItem>

                    <asp:ListItem>BRI</asp:ListItem>

                </asp:DropDownList>

            </div>

            <div class="checkout-item">

                <label>Upload Bukti Pembayaran</label>

                <asp:FileUpload
                    ID="fuPayment"
                    runat="server"
                    CssClass="form-control" />

            </div>

            <asp:Button
                ID="btnPayment"
                runat="server"
                Text="Konfirmasi Pembayaran"
                CssClass="btn-payment"
                OnClick="btnPayment_Click" />

        </div>

    </div>
</asp:Content>