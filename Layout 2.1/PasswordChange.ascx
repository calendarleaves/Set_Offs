<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.ascx.cs" Inherits="Layout_2._1.Password_Change" %>

 <div class="modal fade" id="PasswordUpdate" role="dialog">
    <div class="modal-dialog">    

<div class="modal-content">

        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>

        <div class="modal-body">
         
    <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Width="97%" BorderColor="White" BorderWidth="0px">
            <Columns>
                <asp:BoundField DataField="Date" Headertext="On Leave" />                     
               <asp:BoundField DataField="Holiday" Headertext="Leave Type"/>
            </Columns>      
            <EditRowStyle Height="50px" />
        </asp:GridView>
        </div>

        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>

           </div>
  </div>