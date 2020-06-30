# TwitStat
A Windows Forms application to help you keep track of your followers/unfollowers etc.

To use it, please visit http://dev.twitter.com/, register this app and enter the values received for consumer key, token etc. at the top of file \OAuth\OAuthMessageHandler.cs .

    public class OAuthMessageHandler : DelegatingHandler
    	{
    		// Obtain these values by creating a Twitter app at http://dev.twitter.com/
    		private static string _consumerKey = "your consumer key goes here";
    		private static string _consumerSecret = "your consumer secret goes here";
    		private static string _token = "your token goes here";
    		private static string _tokenSecret = "your token secret goes here";
    
    		private OAuthBase _oAuthBase = new OAuthBase();
        
 Keep your Twitter clean. :-)
