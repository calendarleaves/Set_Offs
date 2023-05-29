<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar 1.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Calendar Page </title>
     <style>
        * {
        margin:0;
        padding:0;
        }
        .Box0 {
        height:40px;
        background-color:burlywood;
        text-align:center;
       padding:50px;
        }
        .Box1 {
            background-color:aliceblue;
          float:left;
          width:69%;
          height:500px;
            
        }
        .Box2{
         background-color:aqua;
         float:right;
         width:30%;
          height:500px;
        }
         #Button1 {
         margin-left:400px;
         margin-top:10px;
         min-height:15px;
         }
       


    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="Box0">
          
            <header>
                <h1>Set Offs</h1>
              
            </header>
             
        </div>
        <div class="Box1">
            
       
          <asp:Calendar ID="Calendar1" runat="server" Height="466px" Width="620px" OnSelectionChanged="Calendar1_SelectionChanged" CellSpacing="2" Font-Bold="True" Font-Size="Large" SelectedDate="05/05/2023 12:14:16" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
            <DayHeaderStyle BackColor="#99CCFF" />
            <DayStyle ForeColor="Black" HorizontalAlign="Center" />
            <NextPrevStyle BackColor="White" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="Silver" />
            <SelectedDayStyle BackColor="White" BorderColor="#6666FF" BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            <TodayDayStyle BackColor="#99CCFF" BorderColor="Black" />
            <WeekendDayStyle ForeColor="#FF3300" />
        </asp:Calendar>
             </div>
       
  <div class="Box2">
      <asp:GridView ID="GridView1" runat="server"  
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" CellPadding="5"  >
            <Columns>
                <asp:BoundField DataField="FirstName" Headertext="On Leave"/>                     
               <asp:BoundField DataField="LeaveType" Headertext="Leave Type"/>
            </Columns>
         <EmptyDataTemplate>No Records!!</EmptyDataTemplate>
        </asp:GridView>
       <asp:Label ID="lblMessage" runat="server"></asp:Label>
             </div>
        <asp:Button ID="Button1" runat="server" Text="Create Absence" onclick="Button1_Click" />
        
       
    </form>
</body>
</html>
