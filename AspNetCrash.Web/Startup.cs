﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetCrash.Web.Startup))]
namespace AspNetCrash.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
