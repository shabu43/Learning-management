<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseMaterialUpload.aspx.cs" Inherits="PL.CourseMaterialUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

</style>
</head>

<body>
    
   <ul style=" background-color: #808080;">
    <li><img src="image/logo.png" alt="Mountain View" style="width:84px;height:65px;"> </li>
  <li><h1 style="color:lightgray;">Online Learning Management</h1></li>
  
</ul>
    <ul>
  <li><a class="active" href="#"></a></li>
  <li><a class="active" href="Home.aspx">Home</a></li>
  <li><a href="#news">About</a></li>
 <% if (Session["user"] == null && Session["pass"] == null) { %>  <li class="dropdown">
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
   
     <asp:Label ID="Label1" margin-left="10px" margin-top="8px" runat="server" BackColor="#ffcc99" Text="Course Material " ></asp:Label>
   <form id="frmDefault" enctype="multipart/form-data" runat="server">
       
<div style="width: 400px; margin-top :40px">
     <%  string pass = (string)(Session["pass"]); if ( pass == "123") { %>
    <div style="clear: both; width: 100%;margin-top:5px">
        <input type="file" name="fileInput" />
        <asp:Button ID="btnUpload" Text="Upload" runat="server" 
            onclick="btnUpload_Click" />
       
    </div>
      <%}  %>
    <div style="margin-top: 5px; clear: both">
        <asp:GridView ID="gvFiles" CssClass="GridViewStyle"
            AutoGenerateColumns="true" runat="server">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />    
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("ID", "CourseMaterialDownload.aspx?id={0}") %>'
                            Text="Download"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    
   
</div>
     
</form>
     
     <%-- footer --%>

    
 
 <div class="footer">
     © Shabu 2016
  </div>


    <%-- end --%>
</body>
</html>