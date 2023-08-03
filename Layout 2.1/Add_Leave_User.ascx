<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add_Leave_User.ascx.cs" Inherits="Layout_2._1.Add_Leave_User" %>

<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-KyZXEAgltcdPwqR5gKkxzWfod5oMh4PrpQmYfjELVYg=" crossorigin="anonymous"></script>

<!-- Place this script block after adding the jQuery library -->
<%--<script>
    $(document).ready(function () {
        // When a date is clicked in the calendar, prevent the default postback behavior
        $('#<%= Calendar2.ClientID %> td:not(.ajax__calendar_other)').on('click', function (e) {
            e.preventDefault();
            e.stopPropagation();
        });
    });
</script>--%>

<div class="modal" id="myModal7">
    <div class="modal-dialog">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Add leave Form</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">
                <!-- Your form content here -->
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
                <!-- Add other form elements here -->
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            </div>
            <asp:Calendar ID="Calendar2" CssClass="calendarView" DayNameFormat="FirstLetter"     runat="server" BackColor="white"   CellPadding="4" 
      BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" 
      Height="180px" ForeColor="Black" 
      Width="200px" >
      <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
      <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
      <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
      <DayHeaderStyle Font-Size="8pt"  Font-Bold="false" BackColor="#CCCCCC">
      </DayHeaderStyle>
      <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666">
      </SelectedDayStyle>
      <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="white">
      </TitleStyle>
      <WeekendDayStyle BackColor="white"></WeekendDayStyle>
      <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle> </asp:Calendar> 

            <!-- Modal footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <!-- You can add additional buttons if needed -->
            </div>
        </div>
    </div>
</div>