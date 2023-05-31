<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login_Page.WebForm1" %>

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
</html>--%>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LoginAnimated.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<link href="animatedLoginCSS2.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500&display=swap" rel="stylesheet">
    
</head>
<body>
     
     <asp:Image ID="Image3" CssClass="backimg1" ImageUrl="flexur2.jpg"  runat="server" />
    <asp:Image ID="Image2" CssClass="backimg" ImageUrl="5259.jpg"  runat="server" />
   
    <div class="box">
    <form id="form1" runat="server">
        
        <asp:Image ID="Image1" class="Img" ImageUrl="img/undraw_pic_profile_re_7g2h.svg"  runat="server" Height="100" Width="100" ImageAlign="NotSet" />
          <br />
          <h2>Sign in</h2>
        <div class="inputBox">
            
             <asp:Label ID="Username" class="textbox" runat="server" Text="Username" ForeColor="Black" ></asp:Label><br />
             <asp:TextBox ID="UsernameTextBox" class="A" runat="server" Width="300" Height="25"></asp:TextBox>
            <asp:Label ID="user" runat="server" Text="" ForeColor="Red" Font-Size="10px"></asp:Label>
        </div> <br />


        <div class="inputBox">
            <br />
            <asp:Label ID="Password" runat="server" class="textbox" Text="Password" ForeColor="Black"></asp:Label> <br />
            <asp:TextBox ID="PasswordTextBox" class="A" runat="server" Height="25" Width="300" ></asp:TextBox>
            <asp:Label ID="pass" runat="server" Text="" ForeColor="Red" Font-Size="10px"></asp:Label>
        </div>
        <asp:Button ID="Submit" CssClass="Submit" runat="server" Text="Login" onclick="Submit_Click" BackColor="#CCCCCC" />
        

            
    </form>
    </div>
</body>
</html>