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

        //获取Request Token
        string responseBody;
        static Uri url = new Uri(API.OAUTH_REQUEST_TOKEN_API);
        StringBuilder sb = new StringBuilder(url.ToString());
        StringBuilder oauthHeader = new StringBuilder();

        public async void  getRequestToken()
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
            oauthHeader.Append("oauth_signature=\"" + sig+"\"");
            //构造请求Request Token的url



            //sb.AppendFormat("?oauth_callback=oob&");
            //sb.AppendFormat("oauth_consumer_key={0}&", APP_KEY);
            //sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
            //sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
            //sb.AppendFormat("oauth_nonce={0}&", nonce);
            //sb.AppendFormat("oauth_version={0}&", "1.0");
            //sb.AppendFormat("oauth_signature={0}", sig);

            //请求Request Token

            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url.ToString()+"?oauth_callback=oob");
                request.Method = "POST";
                request.Headers["Authorization"] = oauthHeader.ToString();

                //request.BeginGetRequestStream(new AsyncCallback(GetResponseCallback), request);
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
                //response = await request.GetResponseAsync();
                //StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //responseBody = stream.ReadToEnd();
                //stream.Close();
                //response.Close();
            }

            catch (Exception e)
            {
                String error = e.ToString();

            }

            ////解析返回的 Request Token 和 Request Token Secret
            //Dictionary<string, string> responseValues = parseResponse(responseBody);
            //requestToken = responseValues["oauth_token"];
            //requestTokenSecret = responseValues["oauth_token_secret"];
        }

        public void GetRequestStreamCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            //Stream postStream = request.EndGetRequestStream(asyncResult);

            //StringBuilder postData = new StringBuilder();
            //postData.Append("oauth_callback=oob");
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());
            //postStream.Write(byteArray, 0, postData.Length);
            
            
            //postStream.Close();

            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }


        void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest webRequest = null;
            HttpWebResponse response = null;

            try
            {
                webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                //response = await webRequest.GetResponseAsync();
                // End the get response operation 
                response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                String Response = streamReader.ReadToEnd();
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
                String responseBody = stream.ReadToEnd();
                Console.WriteLine(responseBody);
            }
        }
    }
}