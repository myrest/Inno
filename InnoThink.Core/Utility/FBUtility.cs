using Facebook;
using InnoThink.Core.Model;
using Rest.Core.Utility;
using System;

namespace InnoThink.Core.Utility
{
    public class FBUtility
    {
        private static readonly SysLog log = SysLog.GetLogger(typeof(FBUtility));

        public static FacebookPersonAuth GetUserID(string token)
        {
            var client = new FacebookClient(token);
            //var meinfo = client.Get("me");
            try
            {
                dynamic meinfo = client.Get("me", new { fields = "name,id,picture,email" });
                dynamic picobj = new { data = "url" };
                picobj = meinfo.picture.data;
                return new FacebookPersonAuth()
                {
                    Email = meinfo.email,
                    Id = meinfo.id,
                    Name = meinfo.name,
                    Picture = picobj.url,
                    isLogined = true
                };
            }
            catch (FacebookOAuthException ex)
            {
                log.Debug("FaceBook login failed.");
                log.Exception(ex);
                return new FacebookPersonAuth();
            }
            catch (Exception ex)
            {
                log.Exception(ex);
                return new FacebookPersonAuth();
            }
        }
    }
}