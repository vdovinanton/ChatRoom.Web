using System.Web.Http;
using ChatRoom.App_Start;

namespace ChatRoom
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DefaultData.Initializer();
            MessageListener.Instance().Start();
        }

        protected void Application_End()
        {
            MessageListener.Instance().Stop();
        }
    }
}
