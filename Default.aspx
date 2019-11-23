<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsLabelTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <script src="Scripts/acsis.js"></script> 
    <script type="text/javascript">

 

    </script>

    <div class="jumbotron">
        <h2>Client Integration Testing</h2>

        <table >
            <tr>
                <td style="text-align:right">
                    <label style="margin-right:7px" >AssetId:</label></td>
                <td>
                    <input id="AssetId" type="text" style="border-radius: 5px"></td>
            </tr>
            <tr><td colspan="2" style="padding-top: 7px"></td></tr>
            <tr>
                <td style="text-align:right">
                    <label style="margin-right:7px" >AssetIdHdr:</label></td>
                <td>
                    <input id="AssetIdHdr" type="text" style="border-radius: 5px"></td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <%--<button type="button" onclick="printLocalLabel()" class="btn btn-primary" style="margin-left:-12px">Print Label</button>--%></td>
                    <button type="button" onclick="printLabel()" class="btn btn-primary" style="margin-left:-12px">Print Label</button></td>
                <td>
                    <select id="printerList" name="printerList" class ="selectCss" style="margin-left:3px; width:175px" >
                        <option selected="selected">Loading Printer List...</option>
                    </select></td>
            </tr>
        </table>
        <br />
        <br />
        <textarea id="ZplText" rows="8" cols="200"></textarea>
    </div>

</asp:Content>