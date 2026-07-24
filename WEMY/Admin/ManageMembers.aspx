<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="WEMY.Admin.ManageMembers" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container-fluid">

        <h2 class="mb-2">Manajemen Member

    </h2>

        <p class="text-muted mb-4">
            Kelola seluruh data member WEMY Yoga.
        </p>

        <div class="card shadow-sm">

            <div class="card-body">

                <div class="row mb-3">

                    <div class="col-md-4">

                        <asp:TextBox
                            ID="txtSearch"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Cari nama atau email..." />

                    </div>

                    <div class="col-md-2">

                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Cari"
                            CssClass="btn btn-primary"
                            OnClick="btnSearch_Click" />

                    </div>

                </div>

                <div class="row mb-4">

                    <div class="col-md-3">

                        <div class="card shadow-sm border-0">

                            <div class="card-body text-center">

                                <h6 class="text-muted">Total Member</h6>

                                <h2 class="fw-bold text-primary">

                                    <asp:Label
                                        ID="lblTotalMember"
                                        runat="server"
                                        Text="0" />

                                </h2>

                            </div>

                        </div>

                    </div>

                </div>
                <asp:GridView
                    ID="gvMember"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-hover table-striped">

                    <Columns>

                        <asp:BoundField
                            DataField="FullName"
                            HeaderText="Nama" />

                        <asp:BoundField
                            DataField="Email"
                            HeaderText="Email" />

                        <asp:BoundField
                            DataField="PlanName"
                            HeaderText="Paket" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>

                                <span class='<%# Eval("Status").ToString() == "Active" ? "badge bg-success"  : "badge bg-danger" %>'> <%# Eval("Status") %> </span>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField
                            DataField="JoinDate"
                            HeaderText="Join Date"
                            DataFormatString="{0:dd MMM yyyy}" />

                        <asp:HyperLinkField
                            HeaderText="Aksi"
                            Text="Detail"
                            DataNavigateUrlFields="MemberID"
                            DataNavigateUrlFormatString="MemberDetail.aspx?id={0}" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>
