using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book_Store.Startup))]
namespace Book_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
