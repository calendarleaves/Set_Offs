<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login_Page.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    <style>
        h1
        {
            text-align:center;
        }

        .div
        {
            margin:100px 600px;
            padding:20px;
            border: 1px double;
        }
        .txt
        
        {
            width:300px;
            height:30px;

        }
        .btn
        {
            height:40px;
            width:300px;
            margin-top:10px;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1> Login Page</h1>
        <hr />
        <div class="div">
            USERNAME:<br />
            <asp:TextBox CssClass="txt" ID="textuser" runat="server"/> <br />

            PASSWORD:<br />
             <asp:TextBox CssClass="txt" ID="textpass" runat="server"/> <br />

            <asp:Button CssClass="btn" ID="sbt" Text="Submit" runat="server" OnClick="sbt_Click" />

        </div>
    </form>
</body>
</html>
