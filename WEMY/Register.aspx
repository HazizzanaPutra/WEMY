<%@ Page Title="Register " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WEMY.Register" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <link href="Assets/css/register.css" rel="stylesheet" />

    <section class="register-page">

        <div class="container">

            <div class="row justify-content-center">

                <div class="col-lg-6">

                    <div class="register-card">

                        <h2>Buat Akun Baru</h2>

                        <p class="register-text">
                            Daftar untuk mulai menikmati
                        seluruh kelas yoga premium.

                   
                        </p>

                        <div class="mb-3">

                            <label>Nama Lengkap</label>

                            <asp:TextBox
                                ID="txtNama"
                                runat="server"
                                CssClass="form-control form-register"
                                placeholder="Masukkan nama lengkap">
                            </asp:TextBox>

                        </div>

                        <div class="mb-3">

                            <label>Email</label>

                            <asp:TextBox
                                ID="txtEmail"
                                runat="server"
                                TextMode="Email"
                                CssClass="form-control form-register"
                                placeholder="Masukkan email">
                            </asp:TextBox>

                        </div>

                        <div class="mb-3">

                            <label>Password</label>

                            <asp:TextBox
                                ID="txtPassword"
                                runat="server"
                                TextMode="Password"
                                CssClass="form-control form-register"
                                placeholder="Password">
                            </asp:TextBox>

                        </div>

                        <div class="mb-4">

                            <label>Konfirmasi Password</label>

                            <asp:TextBox
                                ID="txtConfirm"
                                runat="server"
                                TextMode="Password"
                                CssClass="form-control form-register"
                                placeholder="Konfirmasi Password">
                            </asp:TextBox>

                        </div>

                        <asp:Button
                            ID="btnRegister"
                            runat="server"
                            Text="Daftar Sekarang"
                            CssClass="btn-register"
                            OnClick="btnRegister_Click" />

                    </div>

                </div>

            </div>

        </div>

    </section>

</asp:Content>
