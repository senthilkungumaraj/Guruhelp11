using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using SP2013Branding.Model;
using SP2013Branding.Controller;

namespace SP2013Branding.WebParts.CallOuts3Column
{
    [ToolboxItemAttribute(false)]
    public partial class CallOuts3Column : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public CallOuts3Column()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<CallOut> callOuts = Controller.CallOutController.GetCallOut3Column();

            container.InnerHtml = BuildCallOutStyleHTML() + BuildCallOut3ColumnsHTML(callOuts);

        }

        
        private string BuildCallOut3ColumnsHTML(List<CallOut> callOuts)
        {
            StringBuilder sb = new StringBuilder();
            foreach(CallOut callOut in callOuts)
            {
                sb.Append("<div class='outer-box'><div class='inner-left-container'><img src='");
                sb.Append(callOut.CallOutImage);
                sb.Append("'/></div><div class='inner-right-container'><span class='inner-right-heading'>");
                sb.Append(callOut.CallOutName);
                sb.Append("</span><span class='inner-right-body'>");
                sb.Append(callOut.CallOutDescription);
                sb.Append("</span><div class='inner-right-footer'><a href='");
                sb.Append(callOut.CallOutLink);
                sb.Append("' ");
                if (callOut.OpenInNewWindow)
                {
                    sb.Append("target='_blank'");
                }
                sb.Append(">Learn more</a></div></div></div>");
            }
            return sb.ToString();
        }

        protected string BuildCallOutStyleHTML()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<style> .outer-box {width: 300px;height: 110px;border: solid 5px;	border-color: green;margin: 5px;border-width: 5px;position: relative;display: inline-block;}	.inner-left-container {display: block;position: absolute;}	.inner-right-container{display: block;position: absolute;width: 200px;left: 120px;} .inner-right-heading {font-weight: bold;display: block;margin: 5px;} .inner-right-body {margin: 5px;} .inner-right-footer {margin: 5px;font-weight: bold;} </style>");

            return sb.ToString();

        }
    }
}
