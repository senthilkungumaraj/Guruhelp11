using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using SP2013Branding.Model;

namespace SP2013Branding.WebParts.HeroBanner
{
    [ToolboxItemAttribute(false)]
    public partial class HeroBanner : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public HeroBanner()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Model.HeroBanner banner = Controller.BannerController.GetBanners();

            container.InnerHtml = BuildHeroBannerStyleHTML() + BuildHeroBannerHTML(banner);
        }


        private string BuildHeroBannerHTML(Model.HeroBanner banner)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='outer-box-hero' style='background-image: url(\"");
            sb.Append(banner.HeroBannerImage);
            sb.Append("\")';><div class='inner-text-container-hero'><span>");
            sb.Append(banner.HeroBannerText);
            sb.Append("</span><span style='display: block;'Learn more</span></div></div>");

            return sb.ToString();
        }

        private string BuildHeroBannerStyleHTML()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<style>	.outer-box-hero {width: 700px;height: 400px;border: solid 5px;border-color: green;margin: 5px;border-width: 5px;position: absolute;display: inline;}	.inner-text-container-hero {	position: absolute;	left: 300px; top: 250px;}</style>");
            
            return sb.ToString();
        }
    }
}
