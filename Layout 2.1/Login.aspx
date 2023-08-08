<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Layout_2._1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
   
   <link href="LoginCSSboot1.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous"/>
    
</head>
<body>
     <div class="container-fluid ">

        <div class="row">

             


             <div class="col-md-8">
                    <div class="Images">
                       
                      
                        <div class="Flx">
                        <asp:Image ID="Image1" src="images/flexur2.jpg" class=" img-fluid Flexur" runat="server" />
                           
                         <asp:Label class="H1" runat="server" Text="Leave Portal" ></asp:Label>

                        </div>
                          


                       <asp:Image ID="Image2" src="images/holiday.jpg" class=" img-fluid holiday" runat="server" />

                </div>


                 </div>






                <div class="col-md-4  " style="float:right">
                    <div class="box " style="max-width:350px; max-height:420px">
                        <form id="form2" runat="server" >



                                <div class="login img-fluid" style="max-width:400px; min-width:400px">

                                   
                                    <asp:Image ID="Image4" class="A rounded-circle respnsive loginlogo img-fluid" src="undraw_pic_profile_re_7g2h.svg" runat="server" /><br />
                                    <asp:Label ID="Label6" class="h1 form-label" runat="server" Text="Label">Sign in</asp:Label>
                                 
                                    <br />
                                   
                                    <asp:Label ID="Label7"  class="B form-label" runat="server" Text="Label" ForeColor="Black">Username</asp:Label>
                                    <asp:Label ID="user" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label>
                                    
                                    <asp:TextBox ID="UsernameTextBox" runat="server" type="email" placeholder="Email" class="form-control" style="max-width:300px; max-height:50px"></asp:TextBox>

                                   

                                    <br />
                                    

                                    <asp:Label ID="Label9"  class="B form-label" runat="server" Text="Label">Password</asp:Label>
                                    <asp:Label ID="pass" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label>
                                    <asp:TextBox ID="PasswordTextBox" runat="server" type="password" placeholder="Password" class="form-control" style="max-width:300px; max-height:50px" OnGotFocus="focusforpass"></asp:TextBox>

                                    <asp:Button ID="Submit" class="submit" runat="server" Text="LOGIN" OnClick="Login_Click"/>
                                    <br />
                                    <asp:Label ID="error" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
                                </div>
                            </form>

                       
                    </div>



                </div>


            </div>
         </div>
       
</body>
</html>