<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="WEMY.Admin.MemberDetail" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container mt-4">

        <h2 class="mb-4">Detail Member
    </h2>

        <div class="card shadow-sm">

            <div class="card-body">

                <table class="table table-borderless">

                    <tr>
                        <th width="180">Nama</th>
                        <td>
                            <asp:Label ID="lblName"
                                runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <th>Email</th>
                        <td>
                            <asp:Label ID="lblEmail"
                                runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <th>Membership</th>
                        <td>
                            <asp:Label ID="lblPlan"
                                runat="server" />
                        </td>
                    </tr>

                    <asp:Label
                        ID="lblStatus"
                        runat="server"
                        EnableViewState="false" />

                    <tr>
                        <th>Join Date</th>
                        <td>
                            <asp:Label ID="lblJoinDate"
                                runat="server" />
                        </td>
                    </tr>

                </table>

            </div>

        </div>

        <div class="mt-3">

            <asp:Button
                ID="btnBack"
                runat="server"
                Text="← Kembali"
                CssClass="btn btn-secondary"
                PostBackUrl="~/Admin/ManageMembers.aspx" />

        </div>

    </div>

</asp:Content>
