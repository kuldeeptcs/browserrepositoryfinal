using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Medtronic_IEAddOn
{
  public partial class SmileyPopup : Form
  {
    public string URLPath = string.Empty;
    public string RecordID = "0";
    public SmileyPopup()
    {
      InitializeComponent();
    }

    public SmileyPopup(string urlpath)
    {
      InitializeComponent();

      this.URLPath = urlpath;
    }

    private void Center_Text()
    {
      Graphics g = this.CreateGraphics();
      Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
      Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
      String tmp = " ";
      Double tmpWidth = 0;
      while ((tmpWidth + widthOfASpace) < startingPoint)
      {
        tmp += " ";
        tmpWidth += widthOfASpace;
      }
      this.Text = tmp + this.Text.Trim();
    }

    private void SmileRoutine()
    {
      CallServletAndInsertDataToDatabaseOnSmileyClick("0");
      FeedbackForm feedbackForm = new FeedbackForm(SmileyType.Smile.ToString(), URLPath, RecordID);
      this.Close();
      feedbackForm.Show();
    }

    private void pictureBoxSmile_Click(object sender, EventArgs e)
    {
      SmileRoutine();
    }

    private void FrownRoutine()
    {
      CallServletAndInsertDataToDatabaseOnSmileyClick("1");
      FeedbackForm feedbackForm = new FeedbackForm(SmileyType.Frown.ToString(), URLPath, RecordID);
      this.Close();
      feedbackForm.Show();
    }

    private void pictureBoxFrown_Click(object sender, EventArgs e)
    {
      FrownRoutine();
    }

    private void SmileyPopup_Load(object sender, EventArgs e)
    {
      //Center_Text();
    }

    private void CallServletAndInsertDataToDatabaseOnSmileyClick(string smiletype)
    {
      try
      {
        string redirectionUrl = string.Empty;
        var urlParameters = new Dictionary<string, string>();
        urlParameters.Add("Hostname", string.Empty);
        urlParameters.Add("URLPath", URLPath);
        urlParameters.Add("Description", string.Empty);
        urlParameters.Add("type", smiletype);
        urlParameters.Add("saveSmiley", "0");//in case of smiley click, default 0 should go
        urlParameters.Add("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        redirectionUrl = Constants.ServletURL.ToUrl(urlParameters);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redirectionUrl);
        request.Method = "POST";
        request.KeepAlive = true;
        request.ContentType = "appication/json";

        request.UseDefaultCredentials = true;
        request.PreAuthenticate = true;
        request.Credentials = CredentialCache.DefaultCredentials;

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        string myResponse = "";
        using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
        {
          myResponse = sr.ReadToEnd();

          var servletResponse = JsonConvert.DeserializeObject<ResultReference>(myResponse);

          if (servletResponse.id != "" && servletResponse.id != null)
            RecordID = servletResponse.id;
          else
            MessageBox.Show(Constants.FailureMessage);

          this.Close();
        }
      }
      catch (Exception ex)
      {
        ex.ToString();
      }
    }

    private void pictureBoxSmile_MouseHover(object sender, EventArgs e)
    {
      ToolTip tooltipsmile = new ToolTip();
      tooltipsmile.SetToolTip(this.pictureBoxSmile, "Send smile");
    }

    private void pictureBoxFrown_MouseHover(object sender, EventArgs e)
    {
      ToolTip tooltipsmile = new ToolTip();
      tooltipsmile.SetToolTip(this.pictureBoxFrown, "Send frown");
    }

    private void lblSmile_Click(object sender, EventArgs e)
    {
      SmileRoutine();
    }

    private void lblFrown_Click(object sender, EventArgs e)
    {
      FrownRoutine();
    }
  }
}