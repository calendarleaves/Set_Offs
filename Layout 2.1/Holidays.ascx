<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Holidays.ascx.cs" Inherits="Layout_2._1.Holidays" %>

<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
   
      <div class="modal-content" style="max-height:650px; width:600px; overflow-y:auto">

        <div class="modal-header">
             <h4 class="modal-title" style="margin-left:180px;">Upcoming Holidays</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>

        <div class="modal-body">
         
  <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="97%"  BorderColor="White" BorderWidth="0px" >
                           <Columns>
                <asp:BoundField DataField="Date" Headertext="Date" />                     
               <asp:BoundField DataField="Holiday" Headertext="Holiday"/>
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