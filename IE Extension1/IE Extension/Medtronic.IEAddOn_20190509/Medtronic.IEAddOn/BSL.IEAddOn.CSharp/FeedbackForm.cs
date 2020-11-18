using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Medtronic_IEAddOn
{
  public partial class FeedbackForm : Form
  {
    public string smileType = string.Empty;
    public string URLPath = string.Empty;
    public string RecordID = "0";

    private void FeedbackForm_Load(object sender, EventArgs e)
    {
      txtFeedbackBox.ContextMenu = new ContextMenu();
      //txtFeedbackBox.Text = "Type Message...";
    }

    public FeedbackForm()
    {
      InitializeComponent();
    }

    public FeedbackForm(string smileyType, string urlpath, string recordid)
    {
      InitializeComponent();

      if (smileyType == SmileyType.Smile.ToString())
      {
        smileType = "0";
        URLPath = urlpath;
        RecordID = recordid;
      }
      else if (smileyType == SmileyType.Frown.ToString())
      {
        smileType = "1";
        URLPath = urlpath;
        RecordID = recordid;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      lblValidationMessage.Hide();

            /* call database insertion in case of any text found only */
            if (txtFeedbackBox.Text.Length > 0)// || txtFeedbackBox.Text != "Type Message...")
                CallServletAndInsertDataToDatabaseOnSend();
            else
            {
                MessageBox.Show(Constants.SuccessMessage);
            }
            this.Close();
        }

    private void CallServletAndInsertDataToDatabaseOnSend()
    {
      try
      {
        string redirectionUrl = string.Empty;
        var urlParameters = new Dictionary<string, string>();
        urlParameters.Add("Hostname", string.Empty);
        urlParameters.Add("URLPath", URLPath);
        urlParameters.Add("Description", txtFeedbackBox.Text.Trim());
        urlParameters.Add("type", smileType);
        urlParameters.Add("saveSmiley", RecordID);
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

          if (servletResponse.success != "success")
         //   MessageBox.Show(Constants.SuccessMessage);
         // else
            MessageBox.Show(Constants.FailureMessage);

          this.Close();
        }
      }
      catch (Exception ex)
      {
        ex.ToString();
      }
    }

    private void txtFeedbackBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      //if (Char.IsLetterOrDigit(e.KeyChar) // Allowing only any letter OR Digit
      //|| e.KeyChar == '\b' || e.KeyChar == 8 || e.KeyChar == 32)  // Allowing BackSpace, space and enter character
      //{
      //  e.Handled = false;
      //}
      //else
      //{
      //  e.Handled = true;
      //}
    }

    private void txtFeedbackBox_TextChanged(object sender, EventArgs e)
    {
      //TODO : TODO check for special characters
    }

        private void lblHeadline_Click(object sender, EventArgs e)
        {

        }
    }
}