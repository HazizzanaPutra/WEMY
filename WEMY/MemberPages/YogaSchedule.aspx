<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YogaSchedule.aspx.cs" Inherits="WEMY.MemberPages.YogaSchedule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Jadwal Yoga

</h2>

    <p>
        Jadwal kelas yang dapat Anda ikuti sesuai paket membership.

    </p>

    <div class="alert alert-success mt-3">

        <strong>Paket Aktif :

    </strong>

        <asp:Label
            ID="lblPlan"
            runat="server" />

    </div>

    <hr />

    <asp:Repeater
        ID="rptYoga"
        runat="server">

        <ItemTemplate>

            <div class="card shadow-sm mb-4">

                <div class="card-body">

                    <h4 class="mb-3">🧘 <%# Eval("ClassTitle") %>  </h4>

                    <span class="badge bg-success">

                        <%# Eval("Theme") %>

                    </span>

                    <span class="badge bg-primary">

                        <%# Eval("Difficulty") %>

                    </span>

                    <hr />

                    <p>

                        <i class="fa-solid fa-calendar-days"></i>

                        <strong>Tanggal</strong>

                        <br />

                        <%# Eval("ClassDate","{0:dd MMM yyyy}") %>
                    </p>

                    <p>

                        <i class="fa-solid fa-clock"></i>

                        <strong>Jam</strong>

                        <br />

                        <%# Eval("StartTime") %>

                -

               

                        <%# Eval("EndTime") %>
                    </p>

                    <p>

                        <i class="fa-solid fa-user"></i>

                        <strong>Instruktur</strong>

                        <br />

                        <%# Eval("Teacher") %>
                    </p>

                    <p>

                        <i class="fa-solid fa-users"></i>

                        <strong>Kuota</strong>

                        <br />

                        <%# Eval("MaxParticipant") %>

                Orang

           
                    </p>

                    <hr />

                    <div class="text-center">

                        <span class="badge bg-success">✔ Tersedia untuk Paket
                   
                            <asp:Label
                                ID="lblPlanCard"
                                runat="server"
                                Text='<%# ((System.Web.UI.Page)Page).FindControl("lblPlan") != null ? ((Label)((System.Web.UI.Page)Page).FindControl("lblPlan")).Text : "" %>' />

                        </span>

                    </div>

                </div>

            </div>

        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
