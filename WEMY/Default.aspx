<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEMY._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero">
        <div class="container">

            <div class="row align-items-center">

                <div class="col-lg-6">

                    <h1>Temukan Keseimbangan Tubuh dan Pikiran
                    </h1>

                    <p>
                        Nikmati berbagai pilihan paket membership, kelas yoga profesional,
                        <br />
                        dan pengalaman berlatih yang nyaman untuk membantu Anda menjalani<br />
                        gaya hidup yang lebih sehat.
                    </p>

                    <input type="email"
                        class="email-box"
                        placeholder="Enter your email address" />

                    <br />

                    <button class="hero-button">
                        Start 7 Day Free Trial
                    </button>

                </div>

                <div class="col-lg-6 text-center">

                    <img src="Assets/img/yoga.png"
                        class="hero-image img-fluid" />

                </div>

            </div>

        </div>
    </section>


    <!-- section Paket Membership. -->
    <section id="membership" class="membership-section">

        <div class="container">

            <div class="section-title">

                <h2>Paket Membership</h2>

                <p>
                    Pilih paket membership yang sesuai dengan kebutuhan latihan Anda.
           
                </p>

            </div>

            <div class="membership-grid">
                <asp:Repeater ID="rptMembership"
                    runat="server">

                    <ItemTemplate>

                        <div class="membership-card">

                            <div class="membership-icon">

                                <i class="fa-solid fa-calendar-check"></i>

                            </div>

                            <h3><%# Eval("PlanName") %></h3>

                            <h2>Rp <%# String.Format("{0:N0}", Eval("Price")) %></h2>

                            <p>
                                Durasi
                       
                            <%# Eval("DurationMonth") %>
                        Bulan

                   
                            </p>

                            <p>

                                <%# Eval("Description") %>
                            </p>

                            <a href='Membership.aspx?id=<%# Eval("PlanID") %>'
                                class="btn-detail">Lihat Detail
                            </a>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>
            </div>
        </div>

    </section>

    <!-- section Jadwal Yoga. -->
    <section id="schedule" class="schedule-section">

    <div class="container">

        <div class="section-title">

            <h2>Jadwal Yoga</h2>

            <p>
                Temukan jadwal kelas yoga yang sesuai dengan waktu dan tingkat kemampuan Anda.
            </p>

        </div>

        <div class="row">

            <asp:Repeater
                ID="rptYoga"
                runat="server">

                <ItemTemplate>

                    <div class="col-lg-4 mb-4">

                        <div class="card shadow-sm h-100">

                            <div class="card-body">

                                <h4>

                                    <%# Eval("ClassTitle") %>

                                </h4>

                                <hr />

                                <p>

                                    <strong>Tema</strong>

                                    <br />

                                    <%# Eval("Theme") %>

                                </p>

                                <p>

                                    <strong>Level</strong>

                                    <br />

                                    <%# Eval("Difficulty") %>

                                </p>

                                <p>

                                    <strong>Tanggal</strong>

                                    <br />

                                    <%# Eval("ClassDate","{0:dd MMM yyyy}") %>

                                </p>

                                <p>

                                    <strong>Jam</strong>

                                    <br />

                                    <%# Eval("StartTime") %>

                                    -

                                    <%# Eval("EndTime") %>

                                </p>

                                <p>

                                    <strong>Instruktur</strong>

                                    <br />

                                    <%# Eval("Teacher") %>

                                </p>

                                <p>

                                    <strong>Kuota</strong>

                                    <br />

                                    <%# Eval("MaxParticipant") %>

                                    Orang

                                </p>

                            </div>

                        </div>

                    </div>

                </ItemTemplate>

            </asp:Repeater>

        </div>

    </div>

</section>

</asp:Content>
