<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsLabelTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/acsis.js"></script>
    <div class="jumbotron">
        <h2>Client Integration Testing</h2>
        <table>
            <tr>
                <td><button type="button" onclick="AcsisPrintLabel()" class="btn btn-primary" style="margin-left: 7px">Print Label</button></td>
                <td><button type="button" onclick="Test()" class="btn btn-primary" style="margin-left: 7px">Test</button></td>
                <td>
                    <select id="printerList" name="printerList" clientidmode="Static" runat="server" class="selectCss" style="margin-left: 3px; width: 175px">
                        <option selected="selected">Loading Printer List...</option>
                    </select>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <textarea id="ZplText" rows="8" cols="200"></textarea>

        <%--Field where label data is stored and accessed by the AcsisPrintLabel() javascript function--%>
        <asp:HiddenField ID="AcsisLabelData" runat="server" ClientIDMode="Static" />

    </div>
</asp:Content>
