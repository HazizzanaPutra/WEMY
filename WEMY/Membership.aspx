<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membership.aspx.cs" Inherits="WEMY.Membership" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <link href="Assets/css/membership.css" rel="stylesheet" />
    <div class="membership-detail">

        <div class="container">

            <a href="Default.aspx#membership"
                class="back-link">

                <i class="fa-solid fa-arrow-left"></i>
                Kembali
            </a>

            <div class="detail-card">

                <div class="detail-header">

                    <div class="detail-icon">

                        <i class="fa-solid fa-spa"></i>

                    </div>

                    <h1 id="lblPlanName" runat="server"></h1>

                    <h2 id="lblPrice" runat="server"></h2>

                    <span id="lblDuration"
                        runat="server"
                        class="duration-badge"></span>

                </div>

                <hr />

                <h4>Tentang Paket</h4>

                <p id="lblDescription"
                    runat="server">
                </p>

                <hr />

                <h4>Benefit Membership</h4>

                <ul class="benefit-list">

                    <li>
                        <i class="fa-solid fa-check"></i>

                        Akses kelas sesuai paket
                </li>

                    <li>
                        <i class="fa-solid fa-check"></i>

                        Jadwal latihan yoga
                </li>

                    <li>
                        <i class="fa-solid fa-check"></i>

                        Konsultasi instruktur
                </li>

                    <li>
                        <i class="fa-solid fa-check"></i>

                        Sertifikat digital
                </li>

                </ul>

                <asp:Button
                    ID="btnOrder"
                    runat="server"
                    Text="Pesan Membership"
                    CssClass="btn-order"
                    OnClick="btnOrder_Click" />
            </div>

        </div>

    </div>

</asp:Content>
