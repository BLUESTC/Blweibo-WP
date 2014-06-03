using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using Blacklighting.Tools;

namespace Blacklighting.Tools
{
    public class OAuthLogin
    {
        OAuthBase oauth = new OAuthBase();

        public const string APP_KEY = API.CONSUMER_KEY;
        public const string APP_SECRET = API.CONSUMER_SECRET;
        string requestToken, requestTokenSecret,
               accessToken, accessTokenSecret;

        private Dictionary<string, string> parseResponse(string parameters)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(parameters))
            {
                string[] p = parameters.Split('&');
                foreach (string s in p)
                    if (!string.IsNullOrEmpty(s))
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(temp[0], temp[1]);
                        }
                        else result.Add(s, string.Empty);
            }

            return result;
        }
       
        String responseBody;
        static Uri url = new Uri(API.OAUTH_REQUEST_TOKEN_API);
        StringBuilder oauthHeader = new StringBuilder();
        //获取Request Token
        public void getRequestToken()
        {
            string nonce = oauth.GenerateNonce();
            string timeStamp = oauth.GenerateTimeStamp();
            string normalizeUrl, normalizedRequestParameters, authHeader;

            //签名
            string sig = oauth.GenerateSignature(
                url, APP_KEY, APP_SECRET, string.Empty, string.Empty, "POST",
                timeStamp, nonce, "oob", out normalizeUrl,
                out normalizedRequestParameters, out authHeader);
            sig = WebUtility.UrlEncode(sig);

            oauthHeader.Append("OAuth ");
            oauthHeader.Append("oauth_callback=\"oob\",");
            oauthHeader.Append("oauth_consumer_key=\"" + APP_KEY + "\",");
            oauthHeader.Append("oauth_signature_method=\"" + "HMAC-SHA1\",");
            oauthHeader.Append("oauth_timestamp=\"" + timeStamp + "\",");
            oauthHeader.Append("oauth_nonce=\"" + nonce + "\",");
            oauthHeader.Append("oauth_version=\"" + "1.0\",");
            oauthHeader.Append("oauth_signature=\""  + sig+"\"");
        
            //请求Request Token
            HttpWebRequest request = null;
            try
            {
                //构造请求Request Token的url
                request = (HttpWebRequest)WebRequest.Create(url.ToString()+"?oauth_callback=oob");
                request.Method = "POST";
                request.Headers["Authorization"] = oauthHeader.ToString();

                //request.BeginGetRequestStream(new AsyncCallback(GetResponseCallback), request);
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            }

            catch (Exception e)
            {
                String error = e.ToString();
            }

        }

        public void GetRequestStreamCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }
        
        public void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest webRequest = null;
            HttpWebResponse response = null;

            try
            {
                webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the get response operation 
                response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                responseBody = streamReader.ReadToEnd();
                //outputbox.Text = Response.ToString(); 
                streamResponse.Close();
                streamReader.Close();
                response.Close();

            }
            catch (WebException e)
            {             
                // Error treatment 
                Stream postStream = e.Response.GetResponseStream();
                StreamReader stream = new StreamReader(postStream, Encoding.UTF8);
                responseBody = stream.ReadToEnd();
                Console.WriteLine(responseBody);
            }
        }

        //解析返回的 Request Token 和 Request Token Secret
        
    }
}