<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Delete_Leave_User.ascx.cs" Inherits="Layout_2._1.Delete_Leave_User" %>


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
    .selected-row{
        background-color:skyblue;
    }
</style>


<div class="modal" id="myModal8">
    <div class="modal-dialog">
        <div class="modal-content" style="height: 600px; width: 950px;">
            <div class="container ">
                <!-- Modal Header -->
                <div class="modal-header">
                     <h3 class="modal-title" style="margin-left:350px;">Delete Leave</h3>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <form>
                        <div class="row">
                           
                            <!--Gridview Container  -->
                            <div class="col-lg-10 offset-lg-1 mt-4 text-center">
                                <div class="gridview-container">
                                    <asp:GridView ID="DeleteLeaveGridView" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="DeleteLeaveGridView_RowDeleting" DataKeyNames="Id" OnRowDataBound="DeleteLeaveGridView_RowDataBound" OnSelectedIndexChanged="DeleteLeaveGridView_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Emp ID" />
                                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="Days" HeaderText="Total Days" />
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button CommandName="Delete" runat="server" CssClass="btn btn-danger" Text="Delete" ID="btnDelete" />
                                                    <%--OnClientClick='<%# "return showConfirmationAndAlert(\"" +  Eval("FirstName") + " " + Eval("LastName") + "\", \"" + Eval("StartDate") + "\", \"" + Eval("EndDate") + "\");" %>'--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" display="flex"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
            <!-- Modal footer -->

        </div>
    </div>
</div>
