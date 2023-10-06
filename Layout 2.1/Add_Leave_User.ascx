<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add_Leave_User.ascx.cs" Inherits="Layout_2._1.Add_Leave_User" %>

 
<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-KyZXEAgltcdPwqR5gKkxzWfod5oMh4PrpQmYfjELVYg=" crossorigin="anonymous"></script>
<link href="Stylesheets/AddLeaveForAdmin.css" rel="stylesheet" />
<!-- Place this script block after adding the jQuery library -->
<script>

    document.addEventListener('click', function (event) {
        var calendar = document.getElementById('<%= Calendar1.ClientID %>');
        var target = event.target;
        var isCalendarClicked = calendar.contains(target);

        if (!isCalendarClicked) {

            calendar.style.visibility = 'hidden';

            //   calendar.style.visibility = 'none';

        }
    });
    document.addEventListener('click', function (event) {

        var calendar = document.getElementById('<%= Calendar2.ClientID %>');
        var target = event.target;
        var isCalendarClicked = calendar.contains(target);

        if (!isCalendarClicked) {
            calendar.style.visibility= 'hidden';
           // calendar.style.display = 'none';

        } 
    });

   <%-- $(document).ready(function () {

      
        // When the document is ready, attach a click event handler to the TextBox
        $('#<%= comment.ClientID %>').click(function () {
            // Empty the Label's text
            $('#<%= commentError.ClientID %>').text('');
        });


    });--%>

</script>

<div class="modal" id="myModal7">
    <div class="modal-dialog">
        <div class="modal-content" style="height:600px; width:600px; border:solid; border-color:#5d6e8a  ">
            <!-- Modal Header -->
            <div class="modal-header">
                <h2 class="modal-title" style="margin-left:180px; ">ADD LEAVE</h2>
                <asp:ImageButton ID="close" CssClass="Close" ImageUrl="images/Close1.png" ImageAlign="AbsBottom" runat="server" OnClick="close_Click" />
            </div>

            <!-- Modal body -->
            <div class="modal-body" style="margin-left:100px">
                


              <asp:Label ID="LeaveType" runat="server"  Text="LeaveType:"></asp:Label> 
                <asp:Label ID="Label3" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />                
             
             <asp:DropDownList  CssClass="drop" runat="server" ID="Drop" DataTextField="Drop" OnSelectedIndexChanged="Drop_SelectedIndexChanged" AutoPostBack="true" >
                 
                     <asp:ListItem Text="--Select Leave--" Value="" Disabled="true" Selected="true" />
                     <asp:ListItem>Full Day </asp:ListItem>  
                     <asp:ListItem>First Half </asp:ListItem>  
                     <asp:ListItem>Second Half</asp:ListItem>  
                     <asp:ListItem>Work From  Home</asp:ListItem> 
                 
              </asp:DropDownList> <br />


            <asp:Label ID="LeaveLable" class="error" runat="server" Text="" ForeColor="Red"></asp:Label><br /> 
             
       

            <asp:Label class="From" runat="server" Text="Start Date :"></asp:Label> 
              <asp:Label ID="lable2" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />


           <asp:TextBox ID="from" CssClass="text" runat="server"  ReadOnly="true" style=" max-width:320px; max-height:30px" OnGotFocus="focusforpass"></asp:TextBox>
              
   
           <asp:ImageButton ID="ca1" CssClass="button1" runat="server" ImageUrl="images/cal1.jpg" ImageAlign="AbsBottom" onclick="Calendar1_Click" /> <br />
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
             <asp:ImageButton CssClass="button1" ID="Cal1" runat="server" ImageUrl="images/cal1.jpg" ImageAlign="AbsBottom"   onclick="Calendar2_Click" /><br/>
      <!--       <asp:Label ID="Calendar2Label" CssClass="error" runat="server" Text="" ForeColor="Red"></asp:Label> -->

            <asp:Calendar ID="Calendar2" runat="server" BackColor="white" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender"  AutoPostBack="true"
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

             <asp:Label class="comment" ID="Lable1" runat="server" Text="Reason :" ></asp:Label>
                 <asp:Label ID="Label2" runat="server" class=" form-label"  Text="Label" ForeColor="#FF3300">*</asp:Label><br />

       <!--      <asp:TextBox ID="TextBox1" cssclass="text2" runat="server" TextMode="MultiLine"  Rows="4" Font-Size="Medium" class="form-control" style="max-width:300px; max-height:50px" OnGotFocus="focusforpass"></asp:TextBox>  <br /><br />-->
                 <asp:TextBox ID="comment" runat="server" type="text" placeholder="Max 38 characters" class="form-control text2" TextMode="MultiLine"  Rows="4" Font-Size="Medium"  OnGotFocus="focusforpass" OnTextChanged="comment_TextChanged" MaxLength="38"></asp:TextBox> 
                 <asp:Label class="error" ID="commentError" runat="server" Text="" ></asp:Label><br />

             <asp:Button CssClass ="submit" runat="server"  Text="Submit" OnClick="Submit_click"  />
            <asp:Button CssClass ="Cancel" runat="server"  Text="Cancel" onclick="Cancel_Click" /> <br />
                 
         
        </div>
    </div>
</div>
    </div>


