<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="PL.Quiz" %>

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
    <%-- ............................End CSS Menu...............................   --%>
</head>
<body>

<%-- ............................start menu...............................   --%>
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
    <form id="form1" runat="server">
    <div style="margin-left:40px;margin-top:20px">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                EditImageUrl="images/EditTableHS.png"
                AutoGenerateEditButton="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" BorderColor="Silver"
                BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged2">
                 
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF"/>
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                      
                   
                    <asp:TemplateField HeaderText="Quiz">
                       
                          <ItemTemplate>
                            <table style="width:800px">
                             <tr ""> <td >
                                 
                                      <%# Container.DataItemIndex + 1 %>
                                    <asp:Label ID="Label1" runat="server"  Text='<%# Bind("questionFor") %>' ></asp:Label>
                                 <asp:Label ID="Label8" runat="server"  Text='<%# Bind("QuestionType") %>' ></asp:Label>
                                  </td></tr>
                                <tr></tr>
                                 <tr> <td>
                                    <asp:Label ID="Label2" runat="server"  Text='<%# Bind("choiceA") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label3" runat="server"  Text='<%# Bind("choiceB") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label4" runat="server"  Text='<%# Bind("choiceC") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label5" runat="server"  Text='<%# Bind("choiceD") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label7" runat="server"  Text='<%# Bind("StudentAnsLabel") %>' ></asp:Label>
                                    <asp:Label ID="Label6" runat="server"  Text='<%# Bind("studentAns") %>' ></asp:Label>
                              </td></tr>
                         </table>
                        </ItemTemplate>
                        
                          
                      
                         <EditItemTemplate>
                             <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("QuestionID") %>'></asp:Label>
                               <tr ""> <td >
                                 
                                      <%# Container.DataItemIndex + 1 %>
                                    <asp:Label ID="Label1" runat="server"  Text='<%# Bind("questionFor") %>' ></asp:Label>
                                   
                                  </td></tr>
                                <tr></tr>
                                 <tr> <td>
                                    <asp:Label ID="Label2" runat="server"  Text='<%# Bind("choiceA") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label3" runat="server"  Text='<%# Bind("choiceB") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label4" runat="server"  Text='<%# Bind("choiceC") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label5" runat="server"  Text='<%# Bind("choiceD") %>' ></asp:Label>
                              </td></tr>
                                <tr> <td>
                                    <asp:Label ID="Label7" runat="server"  Text='<%# Bind("StudentAnsLabel") %>' ></asp:Label>
                                     <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("studentAns") %>' Width="100px"></asp:TextBox>
                                    <asp:Label ID="Label6" runat="server"  Text='<%# Bind("studentAns") %>' ></asp:Label>
                              </td></tr>


                        </EditItemTemplate>
                    </asp:TemplateField>
                   
                    
                  
                </Columns>
            </asp:GridView>
        <a href=<%= ResolveUrl("DetailCourse.aspx") + "?id=" +Request.QueryString["id"] %>>Back to Course</a>
    </div>
    </form>
      <%-- footer --%>

    
 
 <div class="footer">
     © Shabu 2016
  </div>


    <%-- end --%>
</body>
</html>
