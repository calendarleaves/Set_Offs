<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Abs.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style>
      

        .div
        {
            margin:50px 500px 50px 300px;
            padding:40px;
            border: 1px double;
            background-color:white;
        }
        .txt
        {
             
            width:400px;
            height:150px;
           
        }
        .button1
        {
            width:30px;
            height:30px;
        }
        .h1{
            margin:10px 100px;
            font-size:35px;
            font-style:italic;
        }
        .drop
        {
            width:150px;
            height:30px;
        }
        .leave,.From,.TO,.Total,.comment
        {
            margin:50px ;
            font-size:25px;

        }
        .submit
        {
               margin:10px 80px;
             width:80px;
            height:40px;
               
        }
        .Cancel
        {
            width:80px;
            height:40px;
        }
        .fixed-size-textbox
        {
            width: 200px; 
           height: 50px;
        }    
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div class="div" >

             <h1 class="h1">Create Absence</h1>

            <br /><br />

             <asp:Label class="leave" runat="server" Text="Leave type : "></asp:Label> 

             <asp:DropDownList  CssClass="drop" runat="server" ID="Drop" DataTextField="Drop" >
                 
                 <asp:ListItem Value="">Please Select</asp:ListItem>  
                 <asp:ListItem>Full day </asp:ListItem>  
                <asp:ListItem>First Half</asp:ListItem>  
                 <asp:ListItem>Second Half</asp:ListItem>  
            
             </asp:DropDownList>
             

            <br /> <br />


            <asp:Label class="From" runat="server" Text="Start Date :"></asp:Label> 
            <asp:TextBox ID="from" CssClass="text" runat="server" ReadOnly="true"></asp:TextBox>
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="~/cal.jpg" ImageAlign="AbsBottom" onclick="Calendar1_Click" /><br />


            <asp:Calendar ID="Calendar1" runat="server" BackColor="#9999FF" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" ></asp:Calendar> 
            <br />  
                
             <asp:Label  runat="server" class="TO" Text="End Date :"></asp:Label> 
             <asp:TextBox ID="To" CssClass="text" runat="server" ReadOnly="true" ></asp:TextBox>
             <asp:ImageButton CssClass="button1" runat="server" ImageUrl="~/cal.jpg" ImageAlign="AbsBottom" onclick="Unnamed_Click1"/><br />


            <asp:Calendar ID="Calendar2" runat="server" BackColor="#9999FF" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender" ></asp:Calendar> <br />

            <asp:Label class="Total" ID="Total" runat="server" Text="Total Days : "></asp:Label>
            <asp:TextBox  ID="Total_Days" runat="server" ReadOnly="true" ></asp:TextBox>

            <br /><br />

             <asp:Label class="comment" ID="Lable1" runat="server" Text="Comment" ></asp:Label>
             <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" CssClass= "fixed-size-textbox" Rows="4" Font-Size="Medium"></asp:TextBox>  <br /><br />

          
             <asp:Button CssClass ="submit" runat="server" BackColor="#00CC66" Text="Submit" OnClick="Unnamed_Click2" />

          
            <asp:Button CssClass ="Cancel" runat="server" BackColor="#FF3300" Text="Cancel"  /> <br />

            <asp:Label ID="ErrorLable" runat="server" Text="" ForeColor="#FF0066" Visible="false"></asp:Label>
          
        </div>
    </form>
</body>
</html>
