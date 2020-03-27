<%@ page import = "java.io.*,java.util.*,java.sql.*"%>
<%@ page import = "javax.servlet.http.*,javax.servlet.*" %>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Medtronic Feedback Application</title>

<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: center;
  padding: 8px;
  word-wrap: break-word;
  
}

tr:nth-child(even) {
  background-color: #dddddd;
}
#heading{
	font-family: sans-serif;
    color: #ffffff;
    background: #007cbd;
    padding: 5px 5px;
	font-size: 12px;
	align: center;
}
</style>
</head>
<body>
<h4  style="font-family:sans-serif;color: #004B87;">Medtronic FeedBack Extension</h4>
<table>
  <tr id="heading"  align="center">
      <th>Feedback Type</th>
 	 <th>IP Address</th>
    <th>URL</th>
    <th>Feedback</th>
    <th>Date & Time</th>
  </tr>
<%
Connection connection = null;

Class.forName("com.mysql.jdbc.Driver");
connection = DriverManager.getConnection("jdbc:mysql://10.10.248.157:3306/MEDTRONIC_BE","root","kpit123");
Statement stmt = null;
String username="";
PreparedStatement ps = connection.prepareStatement("Select * from feedback where user_id=? order by id desc");
if(request.getUserPrincipal()!=null)
{
	username=request.getUserPrincipal().getName();
	
		username=username.substring(username.toString().indexOf("\\")+1);	
	
}
ps.setString(1, username);
ResultSet rs = ps.executeQuery();

while(rs.next()){
	String type="";
	if(rs.getInt("result")==0)
	type="Smiley";
	else
	type="Frown";
	
%>
 <tr style="font-size: 12px;">
 <td><%=type%></td>
 <td><%=rs.getString("address")%></td>
 <td><%=rs.getString("urlpath")%></td>
 <td><%=rs.getString("feedback")%></td>
 <td><%=rs.getString("created_time")%></td>
 
 </tr>


<%}

%>
<label for="msg" id="yourFeedback" style="font-family:sans-serif;color: #004B87;" ><font size="2"><span><b>User Name:  <%= username%></b></span></font></label>


</table>
</body>
</html>