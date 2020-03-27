namespace Medtronic_IEAddOn
{
  public class Constants
  {
    public static string SuccessMessage = "Thank you for your feedback";
    public static string FailureMessage = "Unable to save feedback, please contact system administrator...";
    public static string ServletURL = "http://10.10.34.109:8090/BrowserFeedback/clientaddress";//"http://10.158.35.231:8090/BrowserFeedback/clientaddress";
    public static string MinimumCharMessage = "Note: Feedback should be alphanumeric characters only";
    public static string MaximumCharMessage = "Feedback should be maximum 500 characters";
    public static string LikeQuestion = "What did you like?";
    public static string DisLikeQuestion = "What did you not like? *";
    public static string RestrictionMessage = "Feedback can be given to Medtronic applications only";
  }

  enum SmileyType
  {
    Smile,
    Frown
  }

  public class ResultReference
  {
    public string success { get; set; }
    public string id { get; set; }
  }
}