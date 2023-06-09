<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar 1.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Calendar Page </title>
    <link rel="stylesheet" type="text/css" href="CalendarStylesheet2.css" />
   


				 						   		
</head>
<body>
    <form id="form1" runat="server">
       
      <div class="Box0">         
 <asp:Image ID="Image1"  ImageUrl="flexur2.jpg" runat="server" CssClass="Image2" />

        <h1>Set Offs</h1>   </div>            
 
        <div class="Box1">
            
       
            <asp:Calendar ID="Calendar1" runat="server" Height="100%" Width="100%" CssClass="CalendarCss" OnSelectionChanged="Calendar1_SelectionChanged" CellSpacing="2" Font-Bold="False" Font-Size="Large" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" NextMonthText="Next &gt;" PrevMonthText="&lt; Previous" BorderColor="White" FirstDayOfWeek="Monday">
            <DayHeaderStyle BackColor="#bfdcfa" CssClass="" BorderColor="White" />
            <DayStyle ForeColor="Black" HorizontalAlign="Center" CssClass="CalendarDay" BorderColor="#FFFFCC" BorderWidth="0px" />
            <NextPrevStyle BackColor="White" ForeColor="Black" Font-Bold="True" Font-Overline="False" Font-Size="1em" Font-Underline="False" />
            <OtherMonthDayStyle ForeColor="Silver" />
            <SelectedDayStyle  CssClass="CalendarSelector" ForeColor="Black" BackColor="White" />
              <SelectorStyle  CssClass="CalendarSelector"/> 
            <TitleStyle BackColor="White"  BorderStyle="none" BorderWidth="0px" Font-Bold="True" />
            <TodayDayStyle BackColor="#99CCFF" BorderColor="Black" CssClass="TodaySelect" />
            <WeekendDayStyle ForeColor="#FF3300" />
        </asp:Calendar>
             </div>
       
  <div class="Box2">
      <asp:GridView ID="GridView1" runat="server"   CssClass="GridViewStyle" RowStyle-CssClass="CustomRowStyle"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Width="97%" BorderColor="White" BorderWidth="0px">
            <Columns>
                <asp:BoundField DataField="FirstName" Headertext="On Leave" />                     
               <asp:BoundField DataField="LeaveType" Headertext="Leave Type"/>
            </Columns>      
            <EditRowStyle Height="50px" />
        </asp:GridView>
      <asp:Label ID="lblMessage" runat="server"></asp:Label>
      <asp:GridView ID="GridView2" runat="server"></asp:GridView>

        </div>
     <br />
    <div class="Box4">
        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Create Absence"  OnClick="Button1_Click"/>
    </div>

			
       
    </form>
</body>
</html>
