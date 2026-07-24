<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WEMY.MemberPages.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

    <div class="row justify-content-center">

        <div class="col-lg-7">

            <div class="card shadow border-0">

                <div class="card-body text-center">

                    <i class="fa-solid fa-circle-user fa-5x text-primary mb-3"></i>

                    <h3>
                        <asp:Label
                            ID="lblName"
                            runat="server" />
                    </h3>

                    <p class="text-muted">

                        <asp:Label
                            ID="lblRole"
                            runat="server" />

                        •

                        <asp:Label
                            ID="lblPlan"
                            runat="server" />

                    </p>

                    <hr />

                    <div class="text-start">

                        <p>

                            <i class="fa-solid fa-envelope text-primary"></i>

                            <strong>Email</strong>

                            <br />

                            <asp:Label
                                ID="lblEmail"
                                runat="server" />

                        </p>

                        <hr />

                        <p>

                            <i class="fa-solid fa-credit-card text-success"></i>

                            <strong>Membership</strong>

                            <br />

                            <asp:Label
                                ID="lblPlan2"
                                runat="server" />

                        </p>

                        <hr />

                        <p>

                            <i class="fa-solid fa-circle-check text-success"></i>

                            <strong>Status</strong>

                            <br />

                            <asp:Label
                                ID="lblStatus"
                                runat="server" />

                        </p>

                        <hr />

                        <p>

                            <i class="fa-solid fa-calendar-days text-warning"></i>

                            <strong>Join Date</strong>

                            <br />

                            <asp:Label
                                ID="lblJoin"
                                runat="server" />

                        </p>

                    </div>

                </div>

            </div>

        </div>

    </div>

</div>
</asp:Content>