<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Leave_Records.ascx.cs" Inherits="Layout_2._1.Leave_Records" %>

<style>
    .RecordGrid th {
         /* Center align headers */
        border-bottom:solid 1px;
    }
    
    </style>

<div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
   
      <div class="modal-content" style="max-height:650px; width:600px; overflow-y:auto" >

       <!-- Modal Header -->
            <div class="modal-header" style="padding:10px;">
                <h2 style="margin-left:180px; ">Leave Records</h2>
    <asp:ImageButton ID="close" CssClass="Close" ImageUrl="images/Close1.png" ImageAlign="AbsBottom"
	runat="server" OnClick="closeLRec_Click" />
           
               
            </div>

         <div class="modal-body">
         
  <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" Width="97%"  BorderColor="White" BorderWidth="0px" cssClass="RecordGrid" >
                           <Columns>
                <asp:BoundField DataField="Name" Headertext="Name" />                     
                                <asp:BoundField DataField="StartDate" Headertext="From"/>
                                <asp:BoundField DataField="EndDate" Headertext="To"/>
            <asp:BoundField DataField="Comments" Headertext="Reason" />  
                           </Columns>      
            <EditRowStyle Height="50px" />
                        </asp:GridView>
             <asp:Label ID="lblMsg" runat="server" Font-Bold="true" display="flex"></asp:Label>
        </div>

        
      </div>
      
    </div>
  </div>