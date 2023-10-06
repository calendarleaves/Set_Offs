<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveApproval.ascx.cs" Inherits="Layout_2._1.LeaveApproval" %>



<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-KyZXEAgltcdPwqR5gKkxzWfod5oMh4PrpQmYfjELVYg=" crossorigin="anonymous"></script>
<link href="DeleteLeavePageStyleSheet.css" rel="stylesheet" />
<style>
    .container {
        border: solid;
        border-width: 1px;
        align-items: center;
        height: 600px;
        justify-content: center;
        padding: 10px 20px 10px 20px;
        margin-top: 20px;
        align-content: center !important;
        position: relative;
        background-color: white;
       
    }
    .modal-content {
        width: 80%;
        overflow-y: auto;
        padding: 10px;
        background-color: white;
        border-radius: 4px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -2%);
    }
   /* .selected-row{
        background-color:skyblue;
    }*/
    .gridview-container {
    max-height: 400px !important;
    overflow-y: auto !important;
    width:800px !important;
}
     .custom-header-gridview th {
        height: 50px; /* Adjust the height as needed */
      /*  background-color: #f2f2f2;  Background color for the header row */
        /* Add other styles as needed */

        background-color: lightsalmon;
    }

  
    .approved-rejected-row {
    background-color: lightgray;
    border-radius:5px;
    height:40px;

    
}

    .default-row
    {
        background-color: lightgoldenrodyellow;
    }

 
    
</style>

<div class="modal" id="myModal90">
    <div class="modal-dialog">
        <div class="modal-content" style="height: 600px; width: 950px;">
            <div class="container ">
                <!-- Modal Header -->
                <div class="modal-header">
                     <h3 class="modal-title" style="margin-left:350px;">Leave Request's</h3>
                    <button type="button" class="close" data-dismiss="modal" style="color:red">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <form>
                        <div class="row">
                           
                            <!--Gridview Container  -->
                            <div class="col-lg-10 offset-lg-1 mt-4 text-center">
                                <div class="gridview-container">
                                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand" CssClass="custom-header-gridview" OnRowDataBound="GridView1_RowDataBound"  >
                                  
         <Columns>
          
          <asp:BoundField DataField="EmpId" HeaderText="Emp Id" ItemStyle-Width="100px" />
          <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" ItemStyle-Width="100px"  />
          <asp:BoundField DataField="StartDate" HeaderText="From" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100px"  ItemStyle-height="60px" />
          <asp:BoundField DataField="EndDate" HeaderText="To" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100px"/>
          <asp:BoundField DataField="Days" HeaderText="Total Days" ItemStyle-Width="100px"/>
          <%-- <asp:BoundField DataField="Comments" HeaderText="Reason" ItemStyle-Width="100px"/>--%>
          <asp:BoundField DataField="ApprovalStatus" HeaderText="Status" ItemStyle-Width="100px"/>
                                           
                                           
         <asp:TemplateField HeaderText="Actions" ItemStyle-Width="200px">
            <ItemTemplate>
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Approve" CommandName="Approove" CommandArgument='<%# Container.DataItemIndex %>' />
                <asp:Button ID="btnUpdate2" runat="server" CssClass="btn btn-danger" Text="Reject" CommandName="Reject" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
         </asp:TemplateField>
            
         </Columns>
            </asp:GridView>         
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
           

        </div>
           </div>
         </div>
