document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("send").addEventListener("click", send)
		document.getElementById("smile").addEventListener("click", smile)
	chrome.tabs.query({active: true, currentWindow: true}, function (tabs) {
	 hostname = getHostname(tabs[0].url);
	 urlpath = tabs[0].url;
});
});

//document.addEventListener("DOMContentLoaded", function() {
//    document.getElementById("close").addEventListener("click", close)
	
//});


var hostname="";
var urlpath="";
var feedbackType="";
var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate()+':'+today.getHours()+':'+today.getMinutes()+':'+today.getSeconds();
function send(){

var feedback= document.getElementById("msg").value;
feedbackType = document.getElementById("resultId").value;
var saveSmiley=$("#saveSmiley").val();

feedback=feedback.trimRight();
feedback=feedback.trimLeft();
				$.ajax({
				type: "POST",
				//url: 'http://10.158.35.231:8090/BrowserFeedback/clientaddress',
				url: 'http://10.158.35.231:8090/BrowserFeedback/clientaddress',
				async: false,
				data: { 
				Hostname: hostname, 
				URLPath: urlpath, 
				Description: feedback,
				type:feedbackType,
				saveSmiley:saveSmiley,
				date:date
				},
				success: function(data) {
					//successpopup();
					//alert("Thank you for your feedback");
				},
				error: function(e) {
					alert("Unable to save feedback, please contact system administrator...");
				}
				});
		
		chrome.runtime.reload();	

}


$(document).ready(function(){
   $('#close').click(function(){
	   
     //$("#feedbackform").remove();
	 //$("#smileblock").remove();	 
	 $("#form").remove();
	 //$("#form").css("display","none");
	 window.close();
	 chrome.runtime.reload();
   }); 
});

function getHostname(url) {
	// Handle Chrome URLs
	if (/^chrome:\/\//.test(url)) { return; }
	try {
		var newUrl = new URL(url);
		return newUrl.hostname;
	} catch (err) {
		console.log(err);
	}
}

$(document).ready(function(){
   $('#smile').click(function(){
     saveSmileyClick();
   }); 
});

$(document).ready(function(){
   $('#smile1').click(function(){
     saveSmileyClick();
   }); 
});

function saveSmileyClick() {
	$("#feedbackform").show();
	//$("#feedbackform").css("align","centre");
	$("#smileblock").remove();

	$("#heading span").text("THANK YOU FOR YOUR FEEDBACK");
	$("#yourFeedback span").text("We really appreciate your comments");

	//$("#feedbackTitle span").text("What did you like?");
	// $('input[name=resultId]').val("0");
	document.getElementById("resultId").value = 0;
	//$("#valerror").text("Note: Feedback should be alphanumeric characters only");
	//$("#valerror").css("color", "#963403");
	//$("#valerror").css('font-size', "12px");  
	saveDefaultFeedback(0);
}

$(document).ready(function(){
   $('#frown').click(function(){
	 saveFrownClick()
   }); 
});

$(document).ready(function(){
   $('#frown1').click(function(){
	 saveFrownClick()
   }); 
});
function saveFrownClick() {
	$("#feedbackform").show();
	$("#smileblock").remove();
	$("#heading span").text("THANK YOU FOR YOUR FEEDBACK");
	$("#yourFeedback span").text("We really appreciate your comments");
	//$("#feedbackTitle span").append("What did you not like?<span id='star'> * </span>");  
	//$("#star").css("color", "#963403");
	//$("#valerror").text("Note: Feedback should be alphanumeric characters only");
	//$("#valerror").css("color", "#963403");
	//$("#valerror").css('font-size', "12px");  
	document.getElementById("resultId").value = 1;

	/*  $('#send').attr('disabled', true);
		 $('#msg').on('keyup',function() 
			 {
				 var msg = $("#msg").val();
				 if(msg.length >=10) {
					  $("#valerror").text("");
				 $('#send').attr('disabled', false);
			} 
		else {
				 $("#valerror").text("Note: Feedback should be minimum 10 characters");
				  $("#valerror").css("color", "#963403");
				   $("#valerror").css('font-size', "12px");        
				//$('#send').attr('disabled', true);
			}
    });*/
	saveDefaultFeedback(1)
}


function getUrlVars(href) {
    var vars = {};
    var parts = href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
        vars[key] = value;
    });
    return vars;
}

function successpopup()
   {
      var my_window = window.open("",
       "mywindow","status=1,width=350,height=150,top=200,left=1000");
		 my_window.document.close(); 
      my_window.document.write('<h2> <font color="green">Thank you for your feedback</font></h1>');
	  setTimeout(function () { my_window.close();}, 3000);
   }
   
   function failurepopup()
   {
      var my_window = window.open("","mywindow","status=1,width=350,height=100,top=200,left=1000");
	  my_window.document.close();   
      my_window.document.write('<h2> <font color="red">Unable to save feedback </font></h1>');
	  //$("#form").remove();
	  //chrome.runtime.reload();
	  setTimeout(function () { my_window.close();}, 3000);
	  my_window.onload = setTimeout();
   }

$(document).ready(function(){
   $("#msg").keypress(function(e) {
	var k= e.keyCode,$return = ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32  || (k >= 48 && k <= 57));
      if(!$return) {
		return false;
	}    
})
});





function saveDefaultFeedback(feedbackType ){
var feedback="";
var saveSmiley="0";
			$.ajax({
			type: "POST",
			//url: 'http://10.10.34.109:8090/BrowserFeedback/clientaddress',
			url: 'http://10.158.35.231:8090/BrowserFeedback/clientaddress',
			async: false,
			data: { 
			Hostname: hostname, 
			URLPath: urlpath, 
			Description: feedback,
			type:feedbackType,
			saveSmiley:saveSmiley,
			date:date
			},
			success: function(data) {
				var obj = jQuery.parseJSON(data);
				//successpopup();
			$("#saveSmiley").val(obj.id);
				
			},
			error: function(e) {
				//failurepopup();
				
			}
			});
}


$("#msg").ready(function() {
    var ctrlDown = false,
        ctrlKey = 17,
        cmdKey = 91,
        vKey = 86,
        cKey = 67;

    $("#msg").keydown(function(e) {
        if (e.keyCode == ctrlKey || e.keyCode == cmdKey) ctrlDown = true;
    }).keyup(function(e) {
        if (e.keyCode == ctrlKey || e.keyCode == cmdKey) ctrlDown = false;
    });

    $("#msg").keydown(function(e) {
        if (ctrlDown && (e.keyCode == vKey || e.keyCode == cKey)) return false;
    });
    
    // Document Ctrl + C/V 
    $("#msg").keydown(function(e) {
        if (ctrlDown && (e.keyCode == cKey)) console.log("Document catch Ctrl+C");
        if (ctrlDown && (e.keyCode == vKey)) console.log("Document catch Ctrl+V");
    });
});

