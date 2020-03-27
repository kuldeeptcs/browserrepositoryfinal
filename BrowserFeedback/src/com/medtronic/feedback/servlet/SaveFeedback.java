package com.medtronic.feedback.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Properties;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.log4j.Logger;
import org.json.JSONException;
import org.json.JSONObject;

import com.medtronic.feedback.util.FileUtility;

/**
 * This class is responsible to store the user feedback into database.
 * @author jitendra
 *
 */
public class SaveFeedback extends HttpServlet {

	final static Logger logger = Logger.getLogger(SaveFeedback.class);
	private static final long serialVersionUID = 8224637305218506292L;
	private static final String database_driver = "database.driver";
	private static final String database_connectionUrl= "database.connectionurl";
	private static final String database_username = "database.username";
	private static final String database_password = "database.password";

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws IOException {


		PrintWriter out = res.getWriter();
		res.setContentType("text/plain");
		res.setHeader("Access-Control-Allow-Origin", "*");

		/*res.setHeader("Access-Control-Allow-Headers", "Authorization");
	        res.setHeader("Access-Control-Allow-Methods", "GET, POST");
	        res.setHeader("Access-Control-Allow-Origin","*");
	        res.setHeader("Access-Control-Expose-Headers", "WWW-Authenticate");*/

		// client's IP address
		logger.info("get client info");

		/*InetAddress inetAddress = InetAddress.getLocalHost();*/
		/*String ip=inetAddress.toString();*/
		/*String ip= inetAddress.toString().substring(inetAddress.toString().indexOf("/")+1);*/

		/*Get window user login name*/
		String username ="";
		if(req.getUserPrincipal()!=null)
		{
			username=req.getUserPrincipal().getName();
			if(username!=null){
				username=username.substring(username.toString().indexOf("\\")+1);	
			}
			
		}


		String remoteAddr = req.getRemoteAddr();
		/*String remoteHost = req.getRemoteHost();*/
		String host = req.getParameter("Hostname");
		String url = req.getParameter("URLPath");
		String description = req.getParameter("Description");
		String result = req.getParameter("type");
		String clientDate = req.getParameter("date");
		int saveSmiley =Integer.parseInt(req.getParameter("saveSmiley"));
		if(description==null){
			description="";
		}
			
		/*System.out.println("Clien Details:remoteAddr="+remoteAddr+" "+"remoteHost ="+remoteHost);
		System.out.println("host="+host);
		System.out.println("url="+url);
		System.out.println("description="+description);	 
		System.out.println("username="+username);*/

		JSONObject json = new JSONObject();
		try {
			logger.debug("Save feedback into database");
			int id=saveFeedback(remoteAddr,url,host,description,result,username,saveSmiley,clientDate);
			logger.debug("feedback saved successfully..");
			json.put("success", "success");
			json.put("id",id);
			
		} catch (Exception e) {
			logger.error(e);
			try {
				json.put("fail", "fail");
			} catch (JSONException e1) {
				logger.error(e);
			}
			e.printStackTrace();
		}finally{
			/*finally output the json string*/
			out.print(json.toString());
			out.close();	
		}
	}

	/**
	 * This method is responsible to save feedback in database.
	 * @param address
	 * @param urlpath
	 * @param host
	 * @param feedback
	 * @param result
	 * @throws Exception 
	 */
	private int saveFeedback(String address, String urlpath, String host,String feedback, String result ,String userName ,int saveSmiley,String clientDate) throws Exception {
		Connection connection = null;
		Properties prop = null;
		int incrId=0;
		try{
			prop = FileUtility.readPropertyFile();
			Class.forName(prop.getProperty(database_driver));
			connection = DriverManager.getConnection(prop.getProperty(database_connectionUrl),prop.getProperty(database_username),prop.getProperty(database_password));
			
			
			if(saveSmiley!=0){
				PreparedStatement pst = connection.prepareStatement("update feedback set feedback = ? where id=?");
				pst.setString(1,feedback);
				pst.setInt(2,saveSmiley); 
				int i = pst.executeUpdate();
			}else{
				PreparedStatement pst = connection.prepareStatement("insert into feedback (address, urlpath,feedback,result,created_time,user_id,server_time) values(?,?,?,?,?,?,?)",Statement.RETURN_GENERATED_KEYS);
				pst.setString(1,address);
				pst.setString(2,urlpath);
				pst.setString(3,feedback);
				pst.setInt(4,new Integer(result).intValue());
				pst.setString(5,clientDate);
				pst.setString(6,userName);
				pst.setTimestamp(7,getCurrentDate());
				int i = pst.executeUpdate();
				ResultSet rs = pst.getGeneratedKeys();

				if(rs.next()) {
					incrId = rs.getInt(1);
				}
			}
		}/*catch(SQLException ex){
				logger.error("Error while inserting the data", ex);
			} catch (ClassNotFoundException e) {
				logger.error("Error while inserting the data", e);
			}*/ finally {
				try {
					if (connection != null && !connection.isClosed()) {
						connection.close();
					}
				} catch (SQLException ex) {
					logger.error("Error while closing database connection", ex);
				}
			}
		//throw new Exception();
		return incrId;

	}
	private static java.sql.Timestamp getCurrentDate() {
		java.util.Date today = new java.util.Date();
		return new java.sql.Timestamp(today.getTime());
	}

}
