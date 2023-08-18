<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PassChange.ascx.cs" Inherits="Layout_2._1.PassChange" %>

<style>
    .Changepass {
    padding: 5px;
    border-radius: 5px;
    border: 1px solid #000;
    background-color: #0555fb;
    color: white;
    font-weight: bold;
}




.Changepass:hover {
    background-color: #7499f1;
    color: black;
    border: 1px solid #000;
}
    .error {
   
    font-size: 15px;
    color: red;
}

.text2 {
    max-width: 350px;
    max-height: 50px;
    width: 350px;
    height: 50px;
    text-align: start;
    padding-left: 10px;
    padding-top: 10px;
}
.Close {
    height: 20px;
    width: 20px;
}
</style>
<div class="modal fade" id="myModal15" role="dialog">
    <div class="modal-dialog">    

<div class="modal-content">

        <div class="modal-header" style=" padding:10px">
             <asp:Label class="oldpass" ID="Label1" runat="server" Text="Password should be 8 to 20 characters " ></asp:Label><br />
             
            <asp:ImageButton ID="close" CssClass="Close" ImageUrl="images/Close1.png" ImageAlign="AbsBottom"
	runat="server" OnClick="closeChangepass"  />
          <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
       
        </div>

        <div class="modal-body">
         <%--<asp:GridView ID="details" runat="server" AutoGenerateColumns="false" CssClass="my-gridview" BorderColor="White" BorderWidth="0px">
                        <Columns>
                            <asp:TemplateField  > 
                                <ItemTemplate>
                                    <div class="grid-item">
                                        <asp:Label ID="detail" runat="server" Text='<%# Eval("Profile") %>'  CssClass="ml-3 mr-3"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                    <asp:Label class="oldpass" ID="oldpass" runat="server" Text="Old Password :" ></asp:Label>
                    <asp:Label  runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />           
                    <asp:TextBox ID="oldpassbox" runat="server"  placeholder="Enter old password " MinLength="8" MaxLength="20" class="form-control text2"   Rows="4" Font-Size="Medium"  OnGotFocus="focusforpass"></asp:TextBox> 
                    <asp:Label class="error" ID="oldpasserror" runat="server" Text="" ></asp:Label><br />
            
                  
                    <asp:Label class="oldpass" ID="newpass" runat="server" Text="New Password :" ></asp:Label>
                    <asp:Label  runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />
                    <asp:TextBox ID="newpassbox" runat="server" type="password" placeholder="Enter new password " MinLength="8" MaxLength="20" class="form-control text2"  Rows="4" Font-Size="Medium"  OnGotFocus="focusforpass"></asp:TextBox> 
                    <asp:Label class="error" ID="newpasserror" runat="server" Text="" ></asp:Label><br />

                    <asp:Label class="oldpass" ID="Label2" runat="server" Text="Confirm Password :" ></asp:Label>
                    <asp:Label  runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />
                    <asp:TextBox ID="confirmpassbox" runat="server" type="password" placeholder="Confirm password " MinLength="8" MaxLength="20" class="form-control text2"  Rows="4" Font-Size="Medium"  OnGotFocus="focusforpass"></asp:TextBox> 
                    <asp:Label class="error" ID="conformpasserror" runat="server" Text="" ></asp:Label><br />

            <asp:Button CssClass ="Changepass" runat="server" ID="Submit" Text="Change Password" style="margin-top:15px;" OnClick="ChangePass" />
        </div>

        <div class="modal-footer">
           <asp:Label ID="error" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
                                
        </div>
      </div>

           </div>
  </div>