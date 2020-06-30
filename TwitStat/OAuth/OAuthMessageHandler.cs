using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MyLocalTwitterStats.OAuth
{
	public class OAuthMessageHandler : DelegatingHandler
	{
		// Obtain these values by creating a Twitter app at http://dev.twitter.com/
		private static string _consumerKey = "your consumer key goes here";
		private static string _consumerSecret = "your consumer secret goes here";
		private static string _token = "your token goes here";
		private static string _tokenSecret = "your token secret goes here";


		private OAuthBase _oAuthBase = new OAuthBase();

		public OAuthMessageHandler(HttpMessageHandler innerHandler)
			: base(innerHandler)
		{
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// Compute OAuth header 
			string normalizedUri;
			string normalizedParameters;
			string authHeader;


			string signature = _oAuthBase.GenerateSignature(
				request.RequestUri,
				_consumerKey,
				_consumerSecret,
				_token,
				_tokenSecret,
				request.Method.Method,
				_oAuthBase.GenerateTimeStamp(),
				_oAuthBase.GenerateNonce(),
				out normalizedUri,
				out normalizedParameters,
				out authHeader);

			request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
			
			return base.SendAsync(request, cancellationToken);
		}

		
	}
}
