﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Tarifler.aspx.cs" Inherits="Yemek_Tarifleri_Sitem.Tarifler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">



        .auto-style6 {
            background-color: #C0C0C0;
        }
        .auto-style9 {
            width: 30px;
        }
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style10 {
            width: 29px;
        }
        .auto-style12 {
            text-align: right;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style6">
        <table class="auto-style4">
            <tr>
                <td class="auto-style9"><strong>
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style11" Height="30px"  Text="+" Width="30px" OnClick="Button1_Click"   />
                    </strong></td>
                <td class="auto-style10"><strong>
                    <asp:Button ID="Button2" runat="server" CssClass="auto-style11" Height="30px" Text="-" Width="30px" OnClick="Button2_Click"   />
                    </strong></td>
                <td><strong>ONAYSIZ TARİF LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="panel2">
        <asp:DataList ID="DataList1" runat="server" Width="450px">
            <ItemTemplate>
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style14">
                            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text='<%# Eval("TarifAd") %>'></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <a href="TarifOnerDetay.aspx?Tarifid=<%#Eval("Tarifid")%>">
                                <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="~/ikonlar/read.png" Width="30px" />
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
</asp:Panel>
    <asp:Panel ID="Panel3" runat="server" CssClass="auto-style6">
        <table class="auto-style4">
            <tr>
                <td class="auto-style9"><strong>
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style11" Height="30px"  Text="+" Width="30px" OnClick="Button3_Click"    />
                    </strong></td>
                <td class="auto-style10"><strong>
                    <asp:Button ID="Button4" runat="server" CssClass="auto-style11" Height="30px" Text="-" Width="30px" OnClick="Button4_Click"    />
                    </strong></td>
                <td><strong>ONAYLI TARİF LİSTESİ</strong></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="panel4">
        <asp:DataList ID="DataList2" runat="server" Width="450px">
            <ItemTemplate>
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style14">
                            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text='<%# Eval("TarifAd") %>'></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <a href="TarifOnerDetay.aspx?Tarifid=<%#Eval("Tarifid")%>">
                                <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="~/ikonlar/read.png" Width="30px" />
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
</asp:Panel>
</asp:Content>
