<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Abs.aspx.cs" Inherits="WebApplication1.WebForm1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
   <link rel="stylesheet" href="CreateAbsence.css"/>


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
<body onblur="closeCalendarPopup()" >
      
             
    <div class="col-md-3">
       
       
    </div>
  
     <div class="col-md-6 M">
          <form id="form1" runat="server"  >
   
    
  
       <div class="container">
             
             
       

                    <h1 class="h1">Create Absence</h1>
           

           
             <asp:Label class="leave" runat="server" Text="Leave Type :"></asp:Label> 
              <asp:Label ID="Label2" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />
            
             <asp:DropDownList  CssClass="drop" runat="server" ID="Drop" DataTextField="Drop" OnSelectedIndexChanged="Drop_SelectedIndexChanged" AutoPostBack="true" >
                 
              
                 <asp:ListItem>Full Day </asp:ListItem>  
                 <asp:ListItem>First Half </asp:ListItem>  
                <asp:ListItem>Second Half</asp:ListItem>  
                 <asp:ListItem>Work From  Home</asp:ListItem> 
                 
            
             </asp:DropDownList>
            
            <br />
            <asp:Label ID="LeaveLable" class="error" runat="server" Text="" ForeColor="Red"></asp:Label>
           
            <br /> 
             
       

            <asp:Label class="From" runat="server" Text="Start Date :"></asp:Label> 
              <asp:Label ID="lable2" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />


           <asp:TextBox ID="from" CssClass="text" runat="server"  ReadOnly="true" style=" max-width:320px; max-height:30px" OnGotFocus="focusforpass"></asp:TextBox>
              
       <!--       <asp:TextBox ID="from1" runat="server" type="text" placeholder="" class="form-control" style=" max-width:250px; max-height:30px" OnGotFocus="focusforpass"></asp:TextBox> -->
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" onclick="Calendar1_Click" /> <br />
           <asp:Label ID="calendar1lable" class="error" runat="server" Text="" ForeColor="#FF3300"></asp:Label>

            <asp:Calendar ID="Calendar1" CssClass="calendarView" DayNameFormat="FirstLetter"     runat="server" BackColor="white" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"  CellPadding="4" 
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
             
            <br />  
                
             <asp:Label  runat="server" class="TO" Text="End Date :"></asp:Label> 
              <asp:Label ID="Label1" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />

             <asp:TextBox ID="To" CssClass="text" runat="server" style=" max-width:320px; max-height:30px"  ReadOnly="true" ></asp:TextBox> 
         <!--   <asp:TextBox ID="To1" runat="server" type="text" placeholder="" class=" text2" style="max-width:320px; max-height:30px"  ReadOnly="true" OnGotFocus="focusforpass"></asp:TextBox> -->
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" onclick="Calendar2_Click" /><br/>
      <!--       <asp:Label ID="Calendar2Label" CssClass="error" runat="server" Text="" ForeColor="Red"></asp:Label> -->

            <asp:Calendar ID="Calendar2" runat="server" BackColor="white" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender"
                CssClass="calendarView" DayNameFormat="FirstLetter"      CellPadding="4" 
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
                  <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle></asp:Calendar>
                   <asp:Label ID="Calendar3Label" CssClass="error" runat="server" Text="" ForeColor="Red"></asp:Label><br/>
                  <asp:Label class="Total" ID="Total" runat="server" Text="Total Days : "></asp:Label><br/>

                  <asp:TextBox  ID="Total_Days" CssClass="text" runat="server" ReadOnly="true" ></asp:TextBox> <br />

                   <!--     <asp:TextBox ID="Total_Days1"  ReadOnly="true" runat="server" type="text" placeholder="" class="form-control text2"  OnGotFocus="focusforpass" style="max-height:30px" ></asp:TextBox>-->
            <br />

             <asp:Label class="comment" ID="Lable1" runat="server" Text="Comment :" ></asp:Label><br />
       <!--      <asp:TextBox ID="TextBox1" cssclass="text2" runat="server" TextMode="MultiLine"  Rows="4" Font-Size="Medium" class="form-control" style="max-width:300px; max-height:50px" OnGotFocus="focusforpass"></asp:TextBox>  <br /><br />-->
                 <asp:TextBox ID="CommentBox" runat="server" type="text" placeholder="text" class="form-control text2" TextMode="MultiLine"  Rows="4" Font-Size="Medium"  OnGotFocus="focusforpass"></asp:TextBox> <br />
           <asp:Label ID="FormError" runat="server" CssClass="error" Text="" ForeColor="#FF3300"></asp:Label><br />
            
             <asp:Button CssClass ="submit" runat="server"  Text="SUBMIT" OnClick="Submit_click"  />

          
            <asp:Button CssClass ="Cancel" runat="server"  Text="CANCEL" onclick="Cancel_Click" /> 
          
         
 
         

            </div> 
          
    
     </form>

    </div>
    

    <div class="col-md-3">
        
        
    </div>

          
</body>

</html>
