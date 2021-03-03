using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace api_confirm.tools
{
    public class JwtTools
    {
        /// <summary>
        /// 金鑰
        /// </summary>
        public static string key = "my-test";
         /// <summary>
         /// 加密
         /// </summary>
        public static string Encode(Dictionary<string,object> payload , string key)
        {
            var secret = key;
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serizlizer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serizlizer, urlEncoder);
            //產生token
            return   encoder.Encode(payload, secret);
        }
        /// <summary>
        /// 解密
        /// </summary>
        public static string Decode(string token, string key)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                var algorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = decoder.Decode(token, key, verify: true);
                return json;
            }
            catch (TokenExpiredException)
            {
                throw new Exception ("超過期限");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("驗證不符，可能被竄改");
            }
        }






        /// <summary>
        /// 驗證是否有登入過
        /// </summary>
        public static string ValideLogined(HttpRequestHeaders headers)
        {
            if (headers.GetValues("token").First() == null)  throw new Exception("請登入");
            return Decode(headers.GetValues("token").First(), key);
        }
    }
}