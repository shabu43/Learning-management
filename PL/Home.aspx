<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PL.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
}

li a, .dropbtn {
    display: inline-block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover, .dropdown:hover .dropbtn {
    background-color: red;
}

li.dropdown {
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}

.dropdown-content a:hover {background-color: #f1f1f1}

.dropdown:hover .dropdown-content {
    display: block;
}
.button {
    position: relative;
    background-color: #4CAF50;
    border: none;
    font-size: 13px;
    color: #FFFFFF;
    padding: 10px;
    width: 80px;
    text-align: center;
    -webkit-transition-duration: 0.4s; /* Safari */
    transition-duration: 0.4s;
    text-decoration: none;
    overflow: hidden;
    cursor: pointer;
}

.button:after {
    content: "";
    background: #90EE90;
    display: block;
    position: absolute;
    padding-top: 300%;
    padding-left: 350%;
    margin-left: -20px!important;
    margin-top: -120%;
    opacity: 0;
    transition: all 0.8s
}

.button:active:after {
    padding: 0;
    margin: 0;
    opacity: 1;
    transition: 0s
}

ul1 {
    list-style-type: none;
   
   
    background-color: #f1f1f1;
    border: 1px solid #555;
}

li1 a {
    display: block;
    color: #000;
    padding: 6px 10px;
    text-decoration: none;
}

li1 {
    text-align: center;
    border-bottom: 1px solid #555;
}

li1:last-child {
    border-bottom: none;
}

li1 a.active {
    background-color: #4CAF50;
    color: white;
}

li1 a:hover:not(.active) {
    background-color: #555;
    color: white;
}
.active1 {
    background-color: #4CAF50;
}

/*footer style */ 

.footer{
      
        min-height:16px;
        width:99%;
        
        overflow:hidden;
        background-color:#808080;
        bottom:0;
       position:fixed;
       text-align:center;
       text-decoration-color:white;
     }

.active1 {
    background-color: #4CAF50;
}
.active1 {
    background-color: #4CAF48;
}
</style>
</head>
<body>

    <form id="form1" runat="server">

   <ul style=" background-color: #808080;">
    <li><img src="image/logo.png" alt="Mountain View" style="width:84px;height:65px;"> </li>
  <li><h1 style="color:lightgray;">Online Learning Management</h1></li>
  
</ul>
    <ul>
  <li><a class="active" href="#"></a></li>
  <li><a class="active" href="Home.aspx">Home</a></li>
  <li><a href="#news">About</a></li>
        <% if (Session["user"] == null && Session["pass"] == null) { %>
  <li class="dropdown">
    <a href="#" class="dropbtn">Sign Up</a>
    <div class="dropdown-content">
      <a href="StudentSignup.aspx">Student Signup</a>
      <a href="TeacherSignup.aspx">Teacher Signup</a>
     
    </div>
  </li>

         
        <li   style="float:right"><a class="active1" href="Login.aspx">Login</a></li>
    <% } else { %>
        <li   style="float:right"><a class="active1" href="Logout.aspx">Logout</a></li>
      
        <li   style="float:right"><a class="active2" href="UpdateInfo.aspx">Update Info</a></li>
    <%} %>
         



</ul>
    
       
<div style="float:left;width: 20%;margin-top:12px"> 

     <ul1>
        <li1><a class="active" href="">My Course</a></li1>
          <% string pass = (string)(Session["pass"]); if ( pass == "123" ) { %> 
                <li1><a href="AddNewCourse.aspx">Create New Course</a></li1>
          <% } %> 
         
        
        </ul1>

 </div>    
       
 <div style="float:left;width: 45%;margin-left:15px;margin-top:32px"> 
   
         <asp:Label BorderStyle="Solid" BackColor="#e2cc96" ForeColor="#ff8040" Font-Size="X-Large" Font-Bold="true" ID="courseList" runat="server" Text="Course List"></asp:Label>     
        
             
       
            
    
            <asp:GridView ID="GridView1" runat="server" CellPadding="7" ForeColor="#333333" AutoGenerateColumns="False"
                AutoGenerateEditButton="False" 
                BorderColor="#EFF3FB"
                BorderStyle="None" BorderWidth="1px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <RowStyle BackColor="#EFF3FB" ForeColor="#ff9900" Font-Bold="True" Font-Size="X-Large" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" Font-Size="Larger" ForeColor="#333333" />
                <HeaderStyle  Font-Bold="True"  ForeColor="#333333" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Course Name">
                       
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("courseName") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Code">
                        
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("courseCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                   
                    <asp:HyperLinkField ControlStyle-BackColor="#6699ff" ControlStyle-ForeColor="WhiteSmoke" ControlStyle-Font-Underline="false" ControlStyle-Font-Size="Large" Text="select" DataNavigateUrlFields="courseID" DataNavigateUrlFormatString="~/Authontication.aspx?id={0}" />
                     
                </Columns>
            </asp:GridView>
          </div>       
       
         <div style="float:right;width: 30%;margin-top:41px"> 
        <asp:Label ID="lbl220" ForeColor="#ff9900" Font-Size="Large"  runat="server" Text="Calender"></asp:Label>
            
        <asp:Calendar ID="Calendar1" BorderColor="#ff9900" Font-Underline="false" NextPrevFormat="ShortMonth" TodayDayStyle-BackColor="#ff9900" TodayDayStyle-BorderColor="#ff9900" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
   </div>  
            
       
                   
   </form>
    <%-- footer --%>

    
 
 <div class="footer">
     © Shabu 2016
  </div>


    <%-- end --%>

   
</body>
</html>
