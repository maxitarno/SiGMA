using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Tweetinvi;

namespace Herramientas
{
    public class GestorTwitter
    {
        public void PublicarTweetConFoto(byte[] file, string mensaje)
        {
            var credentials = TwitterCredentials.CreateCredentials("2821489066-0z7L9YNPsL4ykZvy0trXUPvrJIPybXc1m74CbQz", "zL7m27cUyjTLJWnAMwvlF23Be13jcLGTKawFpwHcyZNiW",
                "Y13DKMi1QnHKVgbZwGgORSouG", "UfreNU1mYQyz6KAJZfRkQqVMVoXuPqSHfDJeJ8ShaXGAP3WNRs");
            TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
            {
                var tweet = Tweetinvi.Tweet.PublishTweetWithMedia(mensaje, file);
            });
        }

        public void PublicarTweetSoloTexto(string mensaje)
        {
            var credentials = TwitterCredentials.CreateCredentials("2821489066-0z7L9YNPsL4ykZvy0trXUPvrJIPybXc1m74CbQz", "zL7m27cUyjTLJWnAMwvlF23Be13jcLGTKawFpwHcyZNiW",
                "Y13DKMi1QnHKVgbZwGgORSouG", "UfreNU1mYQyz6KAJZfRkQqVMVoXuPqSHfDJeJ8ShaXGAP3WNRs");
            TwitterCredentials.ExecuteOperationWithCredentials(credentials, () =>
            {
                var tweet = Tweetinvi.Tweet.PublishTweet(mensaje);
            });
        }
    }
}
