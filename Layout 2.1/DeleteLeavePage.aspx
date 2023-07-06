<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteLeavePage.aspx.cs" Inherits="Layout_2._1.WebForm2" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Leave Page</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .container {
            border: solid;
            border-width: 1px;
            width: 900px;
            align-items: center;
            justify-content: center;
            padding: 10px;
            margin-top: 30px;
            align-content: center !important;
            position: relative;
        }
        
        #txtSearch{
            width:215px;
        }
     

        .DateCalendar {
            background-color: transparent;
            width: 30px;
            height: 28px;
            image-rendering: auto;
            z-index: 1;
            position: absolute;
        }
        .calendar-container{
            position: relative;
            z-index: 2;
        }
        .gridview-container {
            position: relative;
            z-index: 1;
        }

        .EmpNames {
            height: 30px;
            width: 350px;
            text-align: start;
            padding-left: 10px
        }

        .delete-button {
            position: absolute;
            bottom: 10px;
            right: 10px;
        }
        .EmptyRecordsMessage{
             
        }
        .Error {
            font-size: 15px;
            color: red;
        }
    </style>
    <script>
        document.addEventListener('click', function (event) {
            var calendar = document.getElementById('<%= Calendar1.ClientID %>');
       var target = event.target;
       var isCalendarClicked = calendar.contains(target);

       if (!isCalendarClicked) {
           calendar.style.display = 'none';

       }
    });
    document.addEventListener('click', function (event) {
        var calendar = document.getElementById('<%= Calendar2.ClientID %>');
        var target = event.target;
        var isCalendarClicked = calendar.contains(target);

        if (!isCalendarClicked) {
            calendar.style.display = 'none';

        }
    });

    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Delete Leave</h2>
            <hr />

            <div class="row">
                <div class="col-lg-5">
                 <asp:Label ID="MainLabel" runat="server" class="Error" ForeColor="Red" ></asp:Label>
                <asp:Label ID="EmpNameLabel" runat="server" class="Error" ForeColor="Red"></asp:Label>
                <asp:Label ID="StartDateLabel" runat="server" class="Error" ForeColor="Red"></asp:Label>
                 <asp:Label ID="EndDateLabel" runat="server" class="Error" ForeColor="Red"></asp:Label>
                
                </div>
                </div>

              <div class="row">
                <div class="col-lg-3  ">
                    <asp:Label ID="Employeename" runat="server" Text="Employee Name:"></asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>                 
                </div>

                <div class="col-lg-3">
                    <asp:Label ID="StartDate" runat="server" Text="Start Date:"></asp:Label><br />
                    <asp:TextBox ID="StartDateSearch" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="StartDateCalendar" CssClass="DateCalendar" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" OnClick="StartDateCalendar_Click" />
                    <div class="calendar-container">
                        <asp:Calendar ID="Calendar1" runat="server" DayNameFormat="FirstLetter" BackColor="white" CellPadding="4" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt"
                            Height="180px" ForeColor="Black" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender">
                            <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                            <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                            <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                            <DayHeaderStyle Font-Size="8pt" Font-Bold="false" BackColor="#CCCCCC"></DayHeaderStyle>
                            <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                            <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="white"></TitleStyle>
                            <WeekendDayStyle ForeColor="#FF3300"></WeekendDayStyle>
                            <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
                        </asp:Calendar>

                    </div>
                </div>

                <div class="col-lg-3">
                    <asp:Label ID="EndDate" runat="server" Text="End Date:"></asp:Label><br />
                    <asp:TextBox ID="EndDateSearch" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="EndDateCalendar" CssClass="DateCalendar" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" OnClick="EndDateCalendar_Click" />
                    <div class="calendar-container">
                        <asp:Calendar ID="Calendar2" runat="server" DayNameFormat="FirstLetter" BackColor="white" CellPadding="4" BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt"
                            Height="180px" ForeColor="Black" Width="200px" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender">
                            <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                            <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                            <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                            <DayHeaderStyle Font-Size="8pt" Font-Bold="false" BackColor="#CCCCCC"></DayHeaderStyle>
                            <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                            <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="white"></TitleStyle>
                            <WeekendDayStyle ForeColor="#FF3300"></WeekendDayStyle>
                            <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
                        </asp:Calendar>
                    </div>
                </div>

                <div class="col-lg-3">
                    <br />                  
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />              
                    </div>
                  </div>

              <div class="row">
                <div class="col-lg-6 offset-lg-1 mt-4">
                    <div class="gridview-container">
                    <asp:GridView ID="DeleteLeaveGridView" runat="server" Width="650px" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Days" HeaderText="Total Days" />
                        </Columns>
                    </asp:GridView>
                        
                        <asp:Label ID="lblmessage" runat="server" Font-Bold="true" display="flex" ></asp:Label>
                        </div>
                </div>

                <div class="delete-button">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                </div>

                </div>

           </div>
      
    </form>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" crossorigin="anonymous"></script>


</body>
</html>


