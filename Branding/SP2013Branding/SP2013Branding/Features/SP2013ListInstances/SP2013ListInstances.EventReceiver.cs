using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace SP2013Branding.Features.SP2013ListInstances
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("e9bf87f1-5ae7-4613-ba29-e234c1fd10ac")]
    public class SP2013ListInstancesEventReceiver : SPFeatureReceiver
    {
       
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists.TryGetList("Call Outs");

            if (list != null)
            {
                SPField thumbnailPicture = (SPField)web.Fields.GetField("Thumbnail Picture");
                list.Fields.Add(thumbnailPicture);
                //list.DefaultView.ViewFields.Add(thumbnailPicture);

                SPField thumbnailText = (SPField)web.Fields.GetField("Thumbnail Text");
                list.Fields.Add(thumbnailText);
                //list.DefaultView.ViewFields.Add(thumbnailText);

                SPField headline = (SPField)web.Fields.GetField("Headline");
                list.Fields.Add(headline);
                //list.DefaultView.ViewFields.Add(headline);

                SPField body = (SPField)web.Fields.GetField("Body");
                list.Fields.Add(body);
                //list.DefaultView.ViewFields.Add(body);

                SPField openInNewWindow = (SPField)web.Fields.GetField("Open In New Window?");
                list.Fields.Add(openInNewWindow);
                //list.DefaultView.ViewFields.Add(openInNewWindow);

                SPField miniThumbnail = (SPField)web.Fields.GetField("Mini Thumbnail");
                list.Fields.Add(miniThumbnail);
                //list.DefaultView.ViewFields.Add(miniThumbnail);

                SPField miniThumbnailAltText = (SPField)web.Fields.GetField("Mini Thumbnail Alt Text");
                list.Fields.Add(miniThumbnailAltText);
                //list.DefaultView.ViewFields.Add(miniThumbnailAltText);

                SPField backgroundStyle = (SPField)web.Fields.GetField("Background Style");
                list.Fields.Add(backgroundStyle);
                //list.DefaultView.ViewFields.Add(backgroundStyle);

                list.Update();
            }

            SPList list2 = web.Lists.TryGetList("Hero Banners");

            if (list2 != null)
            {
                SPField callOutName = (SPField)web.Fields.GetField("Banner Text");
                list2.Fields.Add(callOutName);
                //list2.DefaultView.ViewFields.Add(callOutName);

                SPField callOutDesc = (SPField)web.Fields.GetField("Banner Image");
                list2.Fields.Add(callOutDesc);
                //list2.DefaultView.ViewFields.Add(callOutDesc);

                list2.Update();
            }


        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
