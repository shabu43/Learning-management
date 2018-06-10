<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailCourse.aspx.cs" Inherits="PL.DetailCourse" %>

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

.button4 {
    background-color: #4CAF50; /* Green */
    border: none;
    color: white;
    padding: 8px 52px;
    text-align: left;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 40px 12px;
    cursor: pointer;
    width:150px;
   -webkit-transition-duration: 0.4s; /* Safari */
    transition-duration: 0.4s;
    border-radius: 12px;
}
.button4:hover {
    background-color: #808080;
    color: red;
}
.button5 {
   background-color: #4CAF50; /* Green */
    border: none;
    color: white;
    padding: 8px 52px;
    text-align:center ;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 1px 12px;
     width:150px;
    cursor: pointer;
    -webkit-transition-duration: 0.4s; /* Safari */
    transition-duration: 0.4s;
    border-radius: 12px;
}
.button5:hover {
    background-color: #808080;
    color: red;
}

table {
    border-collapse: collapse;
    width: 100%;
}


td {
    text-align: left;
    padding: 8px;
}

tr:nth-child(even){background-color: #f2f2f2}

th {
    text-align:center;
    padding:16px;
    background-color: #4CAF50;
    color: white;
}
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
.button3 {
     background-color: #4CAF50; /* Green */
    border: none;
    color: white;
    padding: 6px 8px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    cursor: pointer;
    border-radius: 50%;}
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


    <form id="form1" runat="server">
        <div style="float:left;width: 20%;">
    <ul1>
        <li1><a class="active" href="#home">Nav</a></li1>

        
         <li1><a href=<%= ResolveUrl("CourseMaterialUpload.aspx") + "?id=" +Request.QueryString["id"] %>>Class Materials</a></li1>
       
        <% string pas = (string)(Session["pass"]); if ( pas != "123" && Session["pass"] !=null ) { %> 
        <li1><a href=<%= ResolveUrl("Quiz.aspx") + "?id=" +Request.QueryString["id"] %>>Quiz</a></li1>
        <li1><a href=<%= ResolveUrl("AssignmentUpload.aspx") + "?id=" +Request.QueryString["id"] %>>Send Assignment</a></li1>
        <% } %>
         <% string pass = (string)(Session["pass"]); if ( pass == "123" ) { %> 
        
         
        <li1><a href=<%= ResolveUrl("AssignmentUpload.aspx") + "?id=" +Request.QueryString["id"] %>>Show Assignment</a></li1>
        
        <li1><a href=<%= ResolveUrl("AddNewNotice.aspx") + "?id=" +Request.QueryString["id"] %>>Add Notice</a></li1>
        
                <li1><a href=<%= ResolveUrl("AddNewQuestion.aspx") + "?id=" +Request.QueryString["id"] %>>Add Question</a></li1>
        
              
        
              
         <% string setq = (string)(Session["setq"]); if ( setq != null ) { %> 
              <li1><a href=<%= ResolveUrl("EndQuiz.aspx") + "?id=" +Request.QueryString["id"] %>>Stop Quiz</a></li1>
         <% } else { %>
                    
                    <li1><a href=<%= ResolveUrl("QuizStudentList.aspx") + "?id=" +Request.QueryString["id"] %>>Show Quiz Ans. Scripts</a></li1>
                     <li1><a href=<%= ResolveUrl("StartQuiz.aspx") + "?id=" +Request.QueryString["id"] %>>Start Quiz</a></li1>
                    
        <% } %>
                
         <% } %>
         <li1><a href="UnderConstruction.aspx">Marks</a></li1>
        
        </ul1>

            
           
</div>
    <div style="float:left;width: 50%;">
       
        <table style="margin-top:20px;margin-left:75px ;width:auto; text-align:center;" >
             <tr> 
                 
            </tr>
            <tr>
            </tr>
            <tr>
                <asp: </asp:TextBox>
            </tr>

            <tr >

                <td class="auto-style3">Write Post :</td>
                <td>
                    <asp:TextBox ID="txtPost" runat="server" TextMode="MultiLine" Height="40px" Width="200px"  ></asp:TextBox>
                </td>
           
     
           
                
                <td>
                    <asp:Button class="button3" ID="btnPost" runat="server" OnClick="btnPost_Click" Text="Post" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridView2" runat="server" CellPadding="7" ForeColor="#333333" AutoGenerateColumns="False"
                AutoGenerateEditButton="False" 
                BorderColor="#EFF3FB"
                BorderStyle="None" BorderWidth="1px">
           
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <RowStyle BackColor="#EFF3FB" ForeColor="#2e5554" Font-Bold="True" Font-Size="X-Large" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" Font-Size="Larger" ForeColor="#333333" />
               
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField >
                       
                        <ItemTemplate>
                            <table style="width:auto">
                             <tr ""> <td >
                                    <asp:Label ID="Label1" runat="server"  Text='<%# Bind("name") %>' ></asp:Label>
                                  </td></tr>
                                 <tr style="margin-left:30px"> <td >
                                    <asp:Label ID="Label2" runat="server"  Text='<%# Bind("post") %>' ></asp:Label>
                              </td></tr>
                         </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    
                     
                   
                </Columns>
            </asp:GridView>


    </div>
    <div style="float:right;width: 30%;">

     <table style="margin-top:20px">
       <tr style="height:65px; background-color:white">
        <th >Notice</th>
    
         </tr>
         <tr>
   
                 <asp:GridView ID="GridView1" runat="server" CellPadding="7" ForeColor="#333333" AutoGenerateColumns="False"
                AutoGenerateEditButton="False" 
                BorderColor="#EFF3FB"
                BorderStyle="None" BorderWidth="1px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <RowStyle BackColor="#EFF3FB" ForeColor="#ff9900" Font-Bold="True" Font-Size="Large" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" Font-Size="Larger" ForeColor="#333333" />
               
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField >
                       
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("notice") %>' ></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("date") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    
                     
                   
                </Columns>
            </asp:GridView>
         </tr>
    </table>

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
