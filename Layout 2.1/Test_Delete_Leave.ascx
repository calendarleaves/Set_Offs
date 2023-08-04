<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test_Delete_Leave.ascx.cs" Inherits="Layout_2._1.Test_Delete_Leave" %>
<link href="DeleteLeavePageStyleSheet.css" rel="stylesheet" />
<style>
    .container {
       border: 1px solid;
        align-items: center;
        height: 570px;
        justify-content: center;
        padding: 10px 15px 10px 15px;
        margin-top: 10px;
        align-content: center !important;
        position: relative;
        background-color: white;
        width:930px;
    }
    .modal-content {
        width: 90%;
        overflow-y: hidden;
        padding: 8px;
        background-color: white;
        border-radius: 4px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -2%);
    }
    .refreshButton {
        background-color: #e4e3e3;
        border: 1px solid #808080;
        height: 40px;
        width: 70px !important;
        margin-right: 50px;
    }
    .selected-row{
        background-color:skyblue;
    }
</style>

<div class="modal" id="DeleteLeaveModal">
    <div class="modal-dialog"  >
        <div class="modal-content" style="height:600px; width:950px;" >
           <div class="container" >
            <!-- Modal Header -->
            <div class="modal-header">
					<h4 class="modal-title text-center ">Delete Leave</h4>
					<button type="button" class="close" data-dismiss="modal">&times;</button>
				</div>

                <!-- Modal body -->
            <div class="modal-body">
                <form >
                    
                        <div class="row">
						<div class="col-lg-8 offset-lg-2">
							<asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Font-Size="15px" display="flex"/>
							<div class="input-group">
								<asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search employee name"/>
								<div class="input-group-append">
									<asp:Button runat="server" ID="btnSearch" class="btn btn-primary" Text="Search" />
									<div class="col-lg-12 text-right">
										<asp:Button runat="server" ID="btnRefresh" CssClass="refreshButton" Text="Refresh" />
									</div>
								</div>
							</div>
						</div>
					</div>
					<!--Gridview Container  -->
					<div class="col-lg-10 offset-lg-1 mt-3 text-center">
						<div class="gridview-container">
							<asp:GridView ID="DeleteLeaveGridView" runat="server" AutoGenerateColumns="false" CssClass="table">
								<Columns>
									<asp:BoundField DataField="Id" HeaderText="Emp ID"/>
									<asp:BoundField DataField="FirstName" HeaderText="First Name"/>
									<asp:BoundField DataField="LastName" HeaderText="Last Name"/>
									<asp:BoundField DataField="LeaveType" HeaderText="Leave Type"/>
									<asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}"/>
									<asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}"/>
									<asp:BoundField DataField="Days" HeaderText="Total Days"/>
									<asp:TemplateField HeaderText="Action">
										<ItemTemplate>
											<asp:Button CommandName="Delete" runat="server" CssClass="btn btn-danger" Text="Delete"/>
                                           
                                        </ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
							<asp:Label ID="lblmessage" runat="server" Font-Bold="true" display="flex"/>
						</div>
					</div>
				
					  </form>
				</div>

               </div>
                    </div>
                <!-- Modal footer -->
           </div>
        </div>