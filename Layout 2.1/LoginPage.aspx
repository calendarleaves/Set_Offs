<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Layout_2._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="animatedLoginCSS1.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@500&display=swap" rel="stylesheet">
    
</head>
<body>
     
     <asp:Image ID="Image3" CssClass="backimg1" ImageUrl="flexur2.jpg"  runat="server" />
    <asp:Image ID="Image2" CssClass="backimg" ImageUrl="5259.jpg"  runat="server" />
   
    <div class="box">
    <form id="form1" runat="server">
        
        <asp:Image ID="Image1" class="Img" ImageUrl="undraw_pic_profile_re_7g2h.svg"  runat="server" Height="100" Width="100" ImageAlign="NotSet" />
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
        <br />
        <asp:Label ID="loginfail" CssClass="loginfail" runat="server" Text="" ForeColor="#FF3300"></asp:Label>

            
    </form>
    </div>
</body>
</html>

