﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar 1.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Calendar Page </title>
     <%--<link rel="stylesheet" type="text/css" href="CalendarStylesheet2.css" />--%>
    	 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>	
    <style>
    
        .profile-circle {
        width: 38px;
        height: 40px;
        
        background-color: white;
        overflow: hidden;
        position: relative;
        cursor: pointer;
        justify-content: right;
        }
        .footer {
    background-color: white;
    padding: 10px;
    text-align: left;
    width:100%;
}


.footer-text {
    margin-bottom: 0;
    font-size: 10px;
}
     .AbsButton {
	margin-top: 20px;
    margin-left: 80px;
    width: 130px;
    padding: 5px;
    border-radius: 5px;
    background-color: #7499f1;
}  

.AbsButton:hover
{
    background-color: blue;
    color:white;
}     
     .divider {
    border: none;
    border-top: 1px solid #000;
    margin: 0px 0;
}
     .division-heading {
    margin-top: 0;
}

.division-divider {
    margin-top: 5px;
    margin-bottom: 5px;
    border: 1px solid #000;
}
.GriedViewContainer {
    height: 500px;
}
.Griedview1Div, .Griedview2Div {
    max-height: 50%;
    min-height:50%;
    background-color: white;
    overflow-y: auto;
    padding: 10px;
}
.TodaySelect {
    background: linear-gradient(to bottom, #4e82eb, #b6c4db)!important;
}

.DayHeader {
    text-align: center;
    font-size: 18px;
    background-color: #a7c4f2 !important;
}

.CalendarSelector {
   
    background-color:#bebcbc !important;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            
            <!-- Logo or Image on the Left -->
            
                 <asp:Image ID="Image2"  ImageUrl="flexur2.jpg" runat="server" CssClass="Image2" />

        <div class="navbar-header d-md-flex ">
            <!-- Title in the Middle -->
            <h1 class="navbar-item " style="margin-left: 100px;">Set Offs</h1>
        </div>
             
            <!-- Dropdown on the Right -->
            <ul class="navbar-nav flex-row  d-none d-md-flex  justify-content-end">
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
                        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" CssClass="AbsButton" Width="80px" Style="margin-top: 2px;"/>
                    </div>
                </div>
            </li>
        </ul>
            
        </div>
    </nav>
            </div>
         <hr class="divider"/>
       	 <div class="container-fluid main">
            <div class="row">
            
        <div class="col-lg-8 col-md-12 calendar-container">
            <asp:Calendar ID="Calendar1" runat="server" Height="500px" Width="100%" CssClass="CalendarCss" OnSelectionChanged="Calendar1_SelectionChanged" CellSpacing="2" Font-Bold="True" Font-Size="Large" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" NextMonthText="Next &gt;" PrevMonthText="&lt; Previous" BorderColor="White" FirstDayOfWeek="Monday">
            <DayHeaderStyle BorderColor="White" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="DayHeader" />
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
       
   <div class="col-lg-4 col-md-12 GriedViewContainer">
                    <div class="Griedview1Div ">
                         <h4 class="division-heading">On Leave</h4>
                        <hr class="division-divider">
      <asp:GridView ID="GridView1" runat="server"   CssClass="GridViewStyle" RowStyle-CssClass="CustomRowStyle"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" Width="97%" BorderColor="White" BorderWidth="0px">
            <Columns>
                <asp:BoundField DataField="FirstName" Headertext="On Leave" />                     
               <asp:BoundField DataField="LeaveType" Headertext="Leave Type"/>
            </Columns>      
            <EditRowStyle Height="50px" />
        </asp:GridView>
       <asp:Label ID="lblMessage" runat="server" ></asp:Label>
                        </div>
      <!--GridView Section - Upcoming Holiday -->
                    <div class="Griedview2Div">
                        <h4 class="division-heading">Upcoming Holidays</h4>
                        <hr class="division-divider">
                        
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="97%" cssClass="Griedview2Style" BorderColor="White" BorderWidth="0px" >
                           <Columns>
                <asp:BoundField DataField="Date" Headertext="Date" />                     
               <asp:BoundField DataField="Holiday" Headertext="Holiday"/>
            </Columns>      
            <EditRowStyle Height="50px" />
                        </asp:GridView>
                    </div>
       
   </div> </div></div>

            </div></div>
       <hr class="divider">
    <div class="container-fluid" style="display: flex; justify-content: flex-end; margin-right: 20px;">
          <asp:Button ID="Button2" cssClass="AbsButton" runat="server" Text="Delete Leave"  onClick="Button2_Click" Height:25px Visible="false" Enabled="false"/>
        <asp:Button ID="Button1" CssClass="AbsButton" runat="server" Text="Create Absence"  OnClick="Button1_Click" Height:25px/>
      </div>
        <footer class="footer">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                       
                        <p class="footer-text">&copy; 2023 Flexur Systems. All rights reserved.</p>
                    </div>
                </div>
            </div>
        </footer>
			
       
    </form>
    
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>
