<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteLeavePage.aspx.cs" Inherits="Layout_2._1.WebForm2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Leave</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Stylesheets/DeleteleavePageStyleSheet.css" />
 <style>
     .container {
         
         height: 570px;
         justify-content: center;
         padding: 10px 15px 10px 15px;
         margin-top: 10px;
         align-content: center !important;
         position: relative;
         background-color: white;
         width: 930px;
     }

     .header {
         display: flex;
         align-items: center;
         justify-content: space-between;
     }

     .header-text {
         flex: 1;
         text-align: center;
         margin-top:10px;
         
     }

     .close-button-container {
         padding-left: 10px;
     }

     .closeButton {
        
         cursor: pointer;
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
    .gridview-container {
    max-height: 450px !important;
    overflow-y: auto !important;
    width: 900px !important;
  
}
     </style>
</head>

<body>
    <form id="form1" runat="server">
      <%--******************************************************************** --%>
       
     
          <%--******************************************************************** --%>    
            
        <div class="container-fluid ">
            <div class="header">
                 <div class="header-text">
                <h2 class="text-center">Delete Leave</h2>
                     </div>
                <div class="close-button-container">
                <asp:Button runat="server" ID="btnClose" CssClass="closeButton" Text="Close" OnClick="btnClose_Click" />
                    </div>
            </div>      
            <hr/>
            <div class="row">
                <div class="col-lg-6 offset-lg-3">
                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Font-Size="15px" display="flex"></asp:Label>
                    <div class="input-group text-center">
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
            <div class="col-lg-10 offset-lg-2 mt-4 text-center">
                <div class="gridview-container ">
                    <asp:GridView ID="DeleteLeaveGridView" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDeleting="DeleteLeaveGridView_RowDeleting" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Emp ID" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                            <asp:BoundField DataField="StartDate" HeaderText="From" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="To" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Days" HeaderText="Total Days" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button CommandName="Delete" runat="server" CssClass="btn btn-danger" Text="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" display="flex"></asp:Label>
                </div>
            </div>

        </div>
    </form>
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>
</body>
</html>

