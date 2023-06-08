<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Abs.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
   <link rel="stylesheet" href="AbsencePageCSS1.css">
</head>
<body>
  
    <div class="box">
      
    <form id="form1" runat="server"  >
      
                    <h1 class="h1">Create Absence</h1>
           

            <br />
             
         <div class="A">
             <asp:Label class="leave" runat="server" Text="Leave Type :"></asp:Label> </br>
            
             <asp:DropDownList  CssClass="drop" runat="server" ID="Drop" DataTextField="Drop" OnSelectedIndexChanged="Drop_SelectedIndexChanged" AutoPostBack="true" >
                 
                 <asp:ListItem Value=""> </asp:ListItem>  
                 <asp:ListItem>Privilege leave </asp:ListItem>  
                <asp:ListItem>Sick Leave</asp:ListItem>  
                 <asp:ListItem>Half Leave</asp:ListItem> 
                 
            
             </asp:DropDownList>
            <br />
            <asp:Label ID="LeaveLable" class="error" runat="server" Text="" ForeColor="Red"></asp:Label>
           
            <br /> 
             
       

            <asp:Label class="From" runat="server" Text="Start Date :"></asp:Label> <br />
            <asp:TextBox ID="from" CssClass="text" runat="server" ReadOnly="true"></asp:TextBox>
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" onclick="Calendar1_Click" /><br />
            <asp:Label ID="calendar1lable" class="error" runat="server" Text="" ForeColor="#FF3300"></asp:Label>

            <asp:Calendar ID="Calendar1" CssClass="calendarView" runat="server" BackColor="#9999FF" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" ></asp:Calendar> 
            <br />  
                
             <asp:Label  runat="server" class="TO" Text="End Date :"></asp:Label> </br>

             <asp:TextBox ID="To" CssClass="text" runat="server" ReadOnly="true" ></asp:TextBox>
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="cal1.jpg" ImageAlign="AbsBottom" onclick="Calendar2_Click" /><br />
             <asp:Label ID="Calendar2Label" CssClass="error" runat="server" Text="" ForeColor="Red"></asp:Label>

            <asp:Calendar ID="Calendar2" runat="server"  BackColor="#9999FF" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender" ></asp:Calendar> <br />

            <asp:Label class="Total" ID="Total" runat="server" Text="Total Days : "></asp:Label></br>

            <asp:TextBox  ID="Total_Days" CssClass="text" runat="server" ReadOnly="true" ></asp:TextBox>
            
            <br /><br />

             <asp:Label class="comment" ID="Lable1" runat="server" Text="Comment :" ></asp:Label><br />
             <asp:TextBox ID="TextBox1" cssclass="text2" runat="server" TextMode="MultiLine"  Rows="4" Font-Size="Medium"></asp:TextBox>  <br /><br />
               
               </div>

              <div class="button">
             <asp:Button CssClass ="submit" runat="server"  Text="Submit" OnClick="Submit_click"  />

          
            <asp:Button CssClass ="Cancel" runat="server"  Text="Cancel"  OnClick="Cancel_Click" /> 

           </div>
          
    
    </form>

    </div>
        

</body>

</html>

