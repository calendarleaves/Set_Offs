<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar 1.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Calendar Page </title>
     <%--<link rel="stylesheet" type="text/css" href="CalendarStylesheet2.css" />--%>
    	 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>	
    <style>
    
        .profile-circle {
        width: 4vw;
        height: 8vh;
        
        background-color: white;
        overflow: hidden;
        position: relative;
        cursor: pointer;
        justify-content: right;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            
            <!-- Logo or Image on the Left -->
            
                 <asp:Image ID="Image2"  ImageUrl="flexur2.jpg" runat="server" CssClass="Image2" />

        <div class="navbar-header ">
            <!-- Title in the Middle -->
            <h1 class="navbar-item " style="margin-left: 110px;">SetOFFS</h1>
        </div>
             
            <!-- Dropdown on the Right -->
            <ul class="navbar-nav flex-row    justify-content-end">
            <li class="nav-item dropdown">
                
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  
              <asp:Label ID="EmpName_profile" runat="server" Text="Profile" CssClass="mb-0 h5"></asp:Label>
              
                       <asp:Image ID="Image1" runat="server" ImageUrl="profile.png" CssClass="profile-circle img-fluid" />
                    
                </a>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass="my-gridview" BorderColor="White" BorderWidth="0px">
                        <Columns>
                            <asp:TemplateField  > 
                                <ItemTemplate>
                                    <div class="grid-item">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Profile") %>'  CssClass="ml-3 mr-3"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label2" runat="server"   CssClass="ml-3 "></asp:Label>
                    <div class="dropdown-divider"></div>
                    <div class="text-right pr-2">
                        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" CssClass="btn btn-primary" />
                    </div>
                </div>
            </li>
        </ul>
            
        </div>
    </nav>
        <div class="Box1">
            
       
            <asp:Calendar ID="Calendar1" runat="server" Height="100%" Width="100%" CssClass="CalendarCss" OnSelectionChanged="Calendar1_SelectionChanged" CellSpacing="2" Font-Bold="False" Font-Size="Large" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" NextMonthText="Next &gt;" PrevMonthText="&lt; Previous" BorderColor="White" FirstDayOfWeek="Monday">
            <DayHeaderStyle BackColor="#bfdcfa" CssClass="" BorderColor="White" />
            <DayStyle ForeColor="Black" HorizontalAlign="Center" CssClass="CalendarDay" BorderColor="#FFFFCC" BorderWidth="0px" />
            <NextPrevStyle BackColor="White" ForeColor="Black" Font-Bold="True" Font-Overline="False"  Font-Underline="False" />
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
       <asp:Label ID="lblMessage" runat="server" ></asp:Label>
      <asp:GridView ID="GridView2" runat="server"></asp:GridView>

        </div>
     <br />
    <div class="Box4">
        <asp:Button ID="Button1" CssClass="button" runat="server" Text="Create Absence"  OnClick="Button1_Click"/>
    </div>

			
       
    </form>
    
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>
