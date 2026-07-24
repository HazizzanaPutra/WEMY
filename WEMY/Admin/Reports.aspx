<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="WEMY.Admin.Reports" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 class="mb-2">Laporan</h2>

    <p class="text-muted mb-4">
        Ringkasan statistik aplikasi WEMY Yoga.
    </p>

    <div class="row">

        <div class="col-md-3 mb-3">

            <div class="card shadow-sm border-0">

                <div class="card-body text-center">

                    <i class="fa-solid fa-users fa-2x text-primary mb-3"></i>

                    <h6>Member Aktif</h6>

                    <h2>
                        <asp:Label
                            ID="lblMember"
                            runat="server" />
                    </h2>

                </div>

            </div>

        </div>

        <div class="col-md-3 mb-3">

            <div class="card shadow-sm border-0">

                <div class="card-body text-center">

                    <i class="fa-solid fa-hourglass-half fa-2x text-warning mb-3"></i>

                    <h6>Menunggu Verifikasi</h6>

                    <h2>

                        <asp:Label
                            ID="lblWaiting"
                            runat="server" />

                    </h2>

                </div>

            </div>

        </div>

        <div class="col-md-3 mb-3">

            <div class="card shadow-sm border-0">

                <div class="card-body text-center">

                    <i class="fa-solid fa-money-bill-wave fa-2x text-success mb-3"></i>

                    <h6>Pendapatan</h6>

                    <h4>

                        <asp:Label
                            ID="lblRevenue"
                            runat="server" />

                    </h4>

                </div>

            </div>

        </div>

        <div class="col-md-3 mb-3">

            <div class="card shadow-sm border-0">

                <div class="card-body text-center">

                    <i class="fa-solid fa-calendar-days fa-2x text-info mb-3"></i>

                    <h6>Total Jadwal</h6>

                    <h2>

                        <asp:Label
                            ID="lblClass"
                            runat="server" />

                    </h2>

                </div>

            </div>

        </div>

    </div>

    <div class="card shadow-sm mt-4">

        <div class="card-header bg-dark text-white">

            <h5 class="mb-0">Riwayat Pembayaran

        </h5>

        </div>

        <div class="card-body">

            <asp:GridView
                ID="gvPayment"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-hover table-striped"
                GridLines="None"
                OnRowDataBound="gvPayment_RowDataBound">

                <Columns>

                    <asp:BoundField
                        DataField="PaymentID"
                        HeaderText="ID" />

                    <asp:BoundField
                        DataField="FullName"
                        HeaderText="Member" />

                    <asp:BoundField
                        DataField="PlanName"
                        HeaderText="Paket" />

                    <asp:BoundField
                        DataField="Amount"
                        HeaderText="Total"
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

                    <asp:BoundField
                        DataField="PaymentDate"
                        HeaderText="Tanggal"
                        DataFormatString="{0:dd MMM yyyy}" />

                </Columns>

            </asp:GridView>

        </div>

    </div>
</asp:Content>
