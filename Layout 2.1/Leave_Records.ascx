<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Leave_Records.ascx.cs" Inherits="Layout_2._1.Leave_Records" %>

<div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
   
      <div class="modal-content">

        <div class="modal-header">
             <h4 class="modal-title">Leave Reocrds</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>

         <div class="modal-body">
         
  <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="97%"  BorderColor="White" BorderWidth="0px" >
                           <Columns>
                <asp:BoundField DataField="Name" Headertext="Name" />                     
                                <asp:BoundField DataField="StartDate" Headertext="StartDate"/>
                                <asp:BoundField DataField="EndDate" Headertext="EndDate"/>
            <asp:BoundField DataField="Comments" Headertext="Comments" />  
                           </Columns>      
            <EditRowStyle Height="50px" />
                        </asp:GridView>
             <asp:Label ID="lblMsg" runat="server" Font-Bold="true" display="flex"></asp:Label>
        </div>

        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>