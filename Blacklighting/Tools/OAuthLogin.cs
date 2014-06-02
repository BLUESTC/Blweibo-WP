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
        
        public async void getRequestToken()
        {
            string nonce = oauth.GenerateNonce();
            string timeStamp = oauth.GenerateTimeStamp();
            string normalizeUrl, normalizedRequestParameters, authHeader;

            //签名
            string sig = oauth.GenerateSignature(
                url, APP_KEY, APP_SECRET, string.Empty, string.Empty, "POST",
                timeStamp, nonce, out normalizeUrl,
                out normalizedRequestParameters, out authHeader);
            sig = WebUtility.UrlEncode(sig);

            //构造请求Request Token的url
            
            sb.AppendFormat("?oauth_callback=oob&");
            sb.AppendFormat("oauth_consumer_key={0}&", APP_KEY);
            sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
            sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
            sb.AppendFormat("oauth_nonce={0}&", nonce);
            sb.AppendFormat("oauth_version={0}&", "1.0");
            sb.AppendFormat("oauth_signature={0}", sig);

            //请求Request Token
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
                WebResponse response = await request.GetResponseAsync();
                StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseBody = stream.ReadToEnd();
                stream.Close();
                response.Close();
            }

            catch (Exception) { }

            //解析返回的 Request Token 和 Request Token Secret
            Dictionary<string, string> responseValues = parseResponse(responseBody);
            requestToken = responseValues["oauth_token"];
            requestTokenSecret = responseValues["oauth_token_secret"];
        }
    }
}