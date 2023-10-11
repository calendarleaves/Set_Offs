<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="WebApplication1.WebForm11" %>
<%@ Register TagPrefix="uc" TagName="Holidays" Src="~/Holidays.ascx" %>


<%@ Register TagPrefix="uc" TagName="Leave_Records" Src="~/Leave_Records.ascx" %>
<%@ Register TagPrefix="uc" TagName="Add_Leave_User" Src="~/Add_Leave_User.ascx" %>

<%@ Register TagPrefix="uc" TagName="Delete_Leave" Src="~/Delete_Leave.ascx" %>
<%@ Register TagPrefix="uc" TagName="Add_Leave" Src="~/Add_Leave.ascx" %>
<%@ Register TagPrefix="uc" TagName="Delete_Leave_User" Src="~/Delete_Leave_User.ascx" %>
<%@ Register TagPrefix="uc" TagName="Test_Delete_Leave" Src="~/Test_Delete_Leave.ascx" %>
<%@ Register TagPrefix="uc" TagName="PasswordChange" Src="~/PasswordChange.ascx" %>

<%@ Register TagPrefix="uc" TagName="PassChange" Src="~/PassChange.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar Page </title>
    <%--<link rel="stylesheet" type="text/css" href="CalendarStylesheet2.css" />--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link href="LoginCSSboot.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link href="Stylesheets/CalendarStylesheet3.css" rel="stylesheet" />

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
     

     .popUpButtons2{
        
          margin-top: 20px;
            margin-right:15px;
            margin-bottom:10px;
    width: 125px;
    padding: 2px;
    height:40px;
    border-radius: 5px;
    border: 1px solid #000;
    background-color: #0555fb;
    color: white;
    font-weight:bold;
     }

     .popUpButtons2:hover {
                background-color: #7499f1;
                color:black;
                border:1px solid #000;
              
            }
     
.logout {
    margin-top: 20px;
    margin-left: 90px;
    width: 100px;
    padding: 5px;
    border-radius: 5px;
    border: 1px solid #000;
    background-color: #0555fb;
    color: white;
    font-weight:bold;
}


    .logout:hover {
        background-color: #7499f1;
        color: black;
        border: 1px solid #000;
    }
 .custom-link {
            color: #007bff; /* Blue color for link */
            text-decoration: none; /* Remove underline */
            cursor: pointer; /* Hand cursor on hover */
        }
        .custom-link:hover {
            color: #0056b3; /* Darker blue color for hover */
            text-decoration: ; /* Add underline on hover */
        }
            
        .image {
        opacity: 0.5; /* Lower opacity */
        filter: grayscale(100%); /* Apply a grayscale effect */
        pointer-events: none; /* Disable pointer events to make it non-interactable */
    }
.AbsButton:hover
{
    background-color: blue;
    color:white;
}     
     .divider {
    border: none;
    border-top: 1px solid #bebcbc !important;
    margin: 0px 0;
}
     .division-heading {
    margin-top: 0;
}

.division-divider {
    margin-top: 5px;
    margin-bottom: 5px;
    border: 1px solid #bebcbc;
}
.GriedViewContainer {
    height: 500px;
}
.Griedview1Div {
    max-height: 50%;
    min-height:50%;
    background-color: white;
    overflow-y: auto;
    padding: 10px;
}
 .Griedview2Div {
    max-height: 40%;
    min-height:40%;
    background-color: white;
    overflow-y: auto;
    padding: 10px;
}
 .small-case {
    font-size: 14px;
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
.colorCode1 {
  
     border: 1px solid white !important;
    border-collapse: collapse !important;
    
}

    </style>
   
</head>
<body>
    <form id="form1" runat="server">

        <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-white">
        <div class="container-fluid ">
           <%-- <div class="alert alert-success" role="alert">
  This is a success alert with <a href="#" class="alert-link">an example link</a>. Give it a click if you like.
</div>--%>
            
            <!-- Logo or Image on the Left -->
            <div class="navbar-item col-lg-5 col-md-12">
             
                 <asp:Image ID="Image2"  ImageUrl="images/flexur2.jpg" runat="server" CssClass="" />
                 <asp:Image ID="Image5" ImageUrl="images/flexur2.jpg" runat="server" value="" CssClass="image" style="display: none;" />
                </div>
        <div class="navbar-header d-md-flex col-lg-3 col-md-12">
            <!-- Title in the Middle -->
            
             <h1 class="navbar-item" style="background-image: linear-gradient(to right, #553c9a 45%, #ee4b2b);
    color: transparent;-webkit-background-clip: text;">Leave </h1>
            <h1 class="navbar-item" style="margin-left: 8px;background-image: linear-gradient(to right, #553c9a 45%, #ee4b2b);
    color: transparent;-webkit-background-clip: text;">Portal</h1>
             </div>
            <!-- Dropdown on the Right -->
            <ul class="navbar-nav flex-row  justify-content-end col-lg-4 col-md-12">
                <li class=" d-none d-md-flex" style="margin-right: 20px;">
                    <a class="nav-link" runat="server" href="#" id="holi" role="button" data-toggle="modal" data-target="#myModal" aria-haspopup="true" aria-expanded="false">
                  
              
              
                       <asp:Image ID="Image3" runat="server" ImageUrl="images/HolidayIcon.svg" CssClass="profile-circle img-fluid" ToolTip="Upcoming Holidays" />
                    <uc:Holidays ID="Holidays" runat="server" />
                </a>
                    
                      
                </li >
                <li class=" d-none d-md-flex" style="margin-right: 20px;">
                    <a class="nav-link " runat="server" href="#" id="LeaveRecors" role="button" data-toggle="modal" data-target="#myModal2" aria-haspopup="true" aria-expanded="false">
                  
                      <asp:Image ID="Image4" runat="server" ImageUrl="images/LeaveRecordsIcon.svg" CssClass="profile-circle img-fluid" ToolTip="Leave Records" />
                       
                     <uc:Leave_Records ID="Leave_Records" runat="server" />
                </a>
                </li>
            <li class="nav-item dropdown d-none d-md-flex">
                
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  
              <asp:Label ID="EmpName_profile" runat="server" Text="Profile" CssClass="mb-0 h5"></asp:Label>
              
                       <asp:Image ID="Image1" runat="server" ImageUrl="images/Profile.png" CssClass="profile-circle img-fluid" ToolTip="Profile" />
                    
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
                    <asp:label ID="Changepass" runat="server"   CssClass="ml-3 mb-2 custom-link cursor-pointer" data-toggle="modal" data-target="#myModal15">Change password</asp:label>
                    <%--<a href="#" data-toggle="modal" data-target="#PasswordUpdate">Open Popup</a>--%>
                   <%-- <uc:PasswordChange id="PasswordChange1" runat="server" />--%>
                   
                     <%--<a href="#" class="ml-3" data-toggle="modal" data-target="#myModal15" >Open Popup 2</a>--%>
                    <asp:Label ID="Label2" runat="server"   CssClass="ml-3 "></asp:Label>
                    <div class="dropdown-divider"></div>
                   <div class="d-flex justify-content-end  align-items-center ml-3">
                     
                        <%--<a type="" class="btn btn-primary changepass mb-2" data-toggle="modal" data-target="#PasswordUpdate">Change_Pass</a>--%>
        
                        
                    
                        <asp:Button ID="Button3" runat="server" OnClick="logout" Text="Logout" CssClass="btn btn-primary logout mr-3" Width="80px" />
                    
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
            <TodayDayStyle BackColor="#60a4e8" BorderColor="Black" CssClass="TodaySelect" />
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
      <!--GridView Section - Upcoming Leaves -->
       <h4 class="division-heading">Upcoming Leaves<span class="small-case"> (upto next friday)</span></h4>
       <hr class="division-divider">
                    <div class="Griedview2Div" >
                        
                        
                        
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" Width="97%" cssClass="Griedview2Style" BorderColor="White" BorderWidth="0px" >
                           <Columns>
                               <%--<asp:BoundField DataField="FirstName" Headertext="FirstName"/>
                               <asp:BoundField DataField="LastName" Headertext="LastName"/>--%>
                                <asp:BoundField DataField="FullName" Headertext="Name">
                                      <ItemStyle Width="40%" />
                                    </asp:BoundField>
                                <asp:BoundField DataField="LeaveType" Headertext="Leave Type"/>
                                <asp:BoundField DataField="StartDate" Headertext="From" /> 
                               <asp:BoundField DataField="EndDate" Headertext="To" /> 
               
            </Columns>      
            <EditRowStyle Height="50px" />
                        </asp:GridView>
                        <asp:Label ID="Label3" runat="server" Font-Bold="false" display="flex"></asp:Label>
                                
                    </div>
       
   </div> </div></div>

           
       <!--<hr class="divider">
    <div class="container-fluid" style="display: flex; justify-content: flex-end; margin-right: 20px;">
          <asp:Button ID="Button2" cssClass="popUpButtons" runat="server" Text="Delete Leave"  onClick="Button2_Click" Height:25px Visible="true" Enabled="true"/>
        <asp:Button ID="Button1" CssClass="popUpButtons" runat="server" Text="Create Absence"  OnClick="Button1_Click" Height:25px/>
      </div>-->
        <hr class="divider">
            <div class="container-fluid" style="display: flex; justify-content: flex-end; margin-right: 20px;">
            <!--code for color squares and info-->
                        <div style="display:flex; flex-direction:column;justify-content:flex-start; margin-right:700px">
                 <div style="display: flex; justify-content: flex-start;">
    <!-- First Column -->
    <div style="display: flex; flex-direction: column; justify-content: flex-start; align-items: flex-start; margin-right: 20px;">
        <span style="display: flex; align-items: center; margin-bottom: 5px; margin-top:15px;">
            <div style="width: 10px; height: 10px; background-color: orange; margin-right: 5px;"></div>
            Absent
        </span>
    </div>

    <!-- Second Column -->
    <div style="display: flex; flex-direction: column; justify-content: flex-start; align-items: flex-start; margin-right: 20px;">
        <span style="display: flex; align-items: center; margin-top:15px;">
            <div style="width: 10px; height: 10px; background-color: green; margin-right: 5px;"></div>
            Present
        </span>
    </div>

                      <!-- Third Column (replicated from the Second Column) -->
   
    <div style="display: flex; flex-direction: column; justify-content: flex-start; align-items: flex-start; margin-right: 20px;">
        <span style="display: flex; align-items: center; margin-top: 15px;">
            <div style="width: 10px; height: 10px; background-color: red; margin-right: 5px;"></div>
            Holiday
        </span>
    </div>
                      </div>
   <div style="display: flex; justify-content: flex-start; margin-top: 10px;">
    <span style="font-size: 10px; color: #888;">LeavePortal v1.2</span>
</div>
                     
</div>


                <asp:HiddenField ID="hiddenField" runat="server" Value="" />
           <button type="button" id="AddAdmnBtn" class="btn btn-primary  popUpButtons2" data-toggle="modal" data-target="#myModal3" style="display:none">Add Leave</button>     
      <uc:Add_Leave ID="Add_Leave" runat="server" />
               
                          <button runat="server" type="button" id="AddUsrBtn" class="btn btn-primary  popUpButtons2" data-toggle="modal" data-target="#myModal7">Apply Leave</button>     
      <uc:Add_Leave_User ID="Add_Leave_User" runat="server" />

            
                
                <button runat="server" type="button" id="DltUsrBtn" class="btn btn-primary  popUpButtons2" style="display:none; text-align:center; justify-content:center;"  data-toggle="modal" data-target="#myModal8">Delete Leave</button>     
	 <uc:Delete_Leave_User ID="Delete_Leave_User" runat="server" />

                <button type="button" id="DltAdmnBtn" class="btn btn-primary  popUpButtons2" data-toggle="modal" data-target="#myModal4" style="display:none">Delete Leave pop up</button>     
	 <uc:Delete_Leave ID="Delete_Leave" runat="server" />

                <uc:PassChange ID="PassChange" runat="server" />
                <asp:Button ID="DltAdmnBtn2" cssClass="popUpButtons2" runat="server" Text="Delete Leave"  onClick="Button2_Click" Height:25px Visible="false" Enabled="false"/>
     
                
               <%-- <%--<button type="button" id="DeleteLeaveBtn" class="btn btn-primary popUpButtons" data-toggle="modal" data-target="DeleteLeaveModal">Test Delete Popup</button>
                <uc:Test_Delete_Leave ID="Test_Delete_Leave" runat="server"></uc:Test_Delete_Leave>--%>
            
            </div>
       
       <!-- <footer class="footer">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                       
                        <p class="footer-text">&copy; 2023 Flexur Systems. All rights reserved.</p>
                    </div>
                </div>
            </div>
        </footer> -->
			
       
    </form>
    


</body>
</html>