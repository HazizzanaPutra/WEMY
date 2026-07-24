<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WEMY.Admin.Dashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container mt-5">

    <h2>Dashboard Administrator</h2>

    <hr />

    <div class="card mt-4">
        <div class="card-body">

            <h4>Selamat Datang Administrator</h4>

            <p>
                Gunakan dashboard ini untuk
                memverifikasi pembayaran
                membership pengguna.
            </p>

            <asp:Button
                ID="btnPayments"
                runat="server"
                Text="Verifikasi Pembayaran"
                CssClass="btn btn-primary"
                OnClick="btnPayments_Click" />

        </div>
    </div>

</div>

</asp:Content>