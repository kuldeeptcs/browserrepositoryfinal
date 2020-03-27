package com.medtronic.feedback.util;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class FileUtility {

	public static Properties readPropertyFile(){
		Properties prop = new Properties();
		InputStream input = null;
		try {
			input = FileUtility.class.getClassLoader().getResourceAsStream("db.properties");

			// load a properties file
			prop.load(input);		

		} catch (IOException ex) {
			ex.printStackTrace();
		} finally {
			if (input != null) {
				try {
					input.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
		return prop;
		
	}
}
