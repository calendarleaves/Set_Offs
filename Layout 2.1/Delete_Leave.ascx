<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Delete_Leave.ascx.cs" Inherits="Layout_2._1.Delete_Leave" %>

<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-KyZXEAgltcdPwqR5gKkxzWfod5oMh4PrpQmYfjELVYg=" crossorigin="anonymous"></script>

<link href="DeleteLeavePageStyleSheet.css" rel="stylesheet" />



<div class="modal" id="myModal4">
    <div class="modal-dialog">
        <div class="modal-content" style="height: 650px; width: 1000px;">
            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title text-center ">Delete Leave</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">

                <div class="container ">
                    
                    <div class="row">
                        <div class="col-lg-8 offset-lg-2">
                            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Font-Size="15px" display="flex"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search employee name"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button runat="server" ID="btnSearch" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />

                                    <div class="col-lg-12 text-right">

                                        <asp:Button runat="server" ID="btnRefresh" CssClass="refreshButton" Text="Refresh" OnClick="btnRefresh_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
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
                                            <asp:Button CommandName="Delete" runat="server" CssClass="btn btn-danger" Text="Delete" />
                                            <%--OnClientClick='<%# "return showConfirmationAndAlert(\"" +  Eval("FirstName") + " " + Eval("LastName") + "\", \"" + Eval("StartDate") + "\", \"" + Eval("EndDate") + "\");" %>'--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblmessage" runat="server" Font-Bold="true" display="flex"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>

            <!-- Modal footer -->
            <%--<div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>--%>

        </div>
    </div>
</div>
