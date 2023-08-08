<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Holidays.ascx.cs" Inherits="Layout_2._1.Holidays" %>
<style>
    .gridview th {
        text-align: center; /* Center align headers */
        border-bottom:solid 1px;
    }
    .gridview td:nth-child(1) {
        text-align: center; /* Right align cells in the second column (Date) */
        
    }
    .gridview td:nth-child(2) {
    padding-left: 125px; /* Right align cells in the second column (Date) */
    
    }
    .Container1 {
    align-items: center;
        justify-content: center;
        border: solid;
        border-width: 1px;
    }
    
</style>

<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
   
      <div class="modal-content" style="max-height:650px; width:600px; overflow-y:auto">
          <div class="Container1">
        <!-- Modal Header -->
            <div class="modal-header" style="padding:10px;">
                <h2 style="margin-left:130px; ">Upcoming Holidays</h2>
    <asp:ImageButton ID="close" CssClass="Close" ImageUrl="images/Close1.png" ImageAlign="AbsBottom"
	runat="server" OnClick="closeHoli_Click" />
           
               
            </div>

        <div class="modal-body">
         
  <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="97%"  BorderColor="White" BorderWidth="1px" CssClass="gridview" >
                           <Columns>
                <asp:BoundField DataField="Date" Headertext="Date" />                     
              
                               <asp:BoundField DataField="Holiday" Headertext="Holiday"/>
         
                           </Columns>      
            <EditRowStyle Height="50px" />
                        </asp:GridView>
             <asp:Label ID="InfoMsg" runat="server" Font-Bold="true" display="flex"></asp:Label>
        </div>

        
              </div>
      </div>
      
    </div>
  </div>	