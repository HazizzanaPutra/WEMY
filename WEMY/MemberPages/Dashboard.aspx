<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WEMY.MemberPages.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-5">

        <div class="dashboard-header mb-4">

            <h2>Selamat Datang,
           
                <asp:Label ID="lblFullName"
                    runat="server" />
                👋
        </h2>

            <p class="text-muted">
                Kelola membership yoga Anda di sini.
       
            </p>

        </div>

        <div class="row">

            <!-- Status Membership -->
            <div class="col-lg-4 mb-4">

                <div class="membership-card">

                    <div class="membership-header">

                        <span class="membership-icon">🟢

                        </span>

                        <div>

                            <h3 id="lblStatus"
                                runat="server"></h3>

                            <p id="lblDescription"
                                runat="server">
                            </p>

                        </div>

                    </div>

                    <hr />

                    <div class="membership-info">

                        <p>

                            <strong>Paket</strong>

                            <br />

                            <span
                                id="lblPlan"
                                runat="server"></span>

                        </p>

                        <p>

                            <strong>Bergabung</strong>

                            <br />

                            <span
                                id="lblJoinDate"
                                runat="server"></span>

                        </p>

                        <p>

                            <strong>Berakhir</strong>

                            <br />

                            <span
                                id="lblEndDate"
                                runat="server"></span>

                        </p>

                        <p>

                            <strong>Status</strong>

                            <br />

                            <span
                                id="lblMemberStatus"
                                runat="server"></span>

                        </p>

                        <p>

                            <strong>Sisa Membership</strong>

                            <br />

                            <span
                                id="lblRemaining"
                                runat="server"></span>

                        </p>

                    </div>

                    <asp:Button
                        ID="btnBuyMembership"
                        runat="server"
                        Text="Beli Membership"
                        CssClass="btn-membership"
                        PostBackUrl="~/Default.aspx#membership" />

                </div>

            </div>

            <!-- Riwayat -->
            <div class="col-lg-8 mb-4">

                <div class="dashboard-card">

                    <h4>Riwayat Pembelian</h4>

                    <asp:GridView
                        ID="gvHistory"
                        runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover"
                        GridLines="None"
                        OnRowDataBound="gvHistory_RowDataBound">

                        <Columns>

                            <asp:BoundField
                                HeaderText="Tanggal"
                                DataField="OrderDate"
                                DataFormatString="{0:dd MMM yyyy}" />

                            <asp:BoundField
                                HeaderText="Paket"
                                DataField="PlanName" />

                            <asp:BoundField
                                HeaderText="Total"
                                DataField="TotalPrice"
                                DataFormatString="Rp {0:N0}" />

                            <asp:TemplateField HeaderText="Status">

                                <ItemTemplate>

                                    <asp:Label
                                        ID="lblStatus"
                                        runat="server"
                                        Text='<%# Eval("Status") %>'>
                                    </asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>

    </div>
</asp:Content>
