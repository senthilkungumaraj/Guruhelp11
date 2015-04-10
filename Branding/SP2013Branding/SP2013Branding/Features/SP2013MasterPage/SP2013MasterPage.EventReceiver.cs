using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace SP2013Branding.Features.SP2013MasterPage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("fc5ced2e-5958-4f83-9c31-6b7ce8bb05f4")]
    public class SP2013MasterPageEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            using (SPSite CurrentSite = properties.Feature.Parent as SPSite)
            {
                using (SPWeb CurrentWeb = CurrentSite.RootWeb)
                {
                    CurrentWeb.CustomMasterUrl = CurrentWeb.Site.RootWeb.ServerRelativeUrl + "/_catalogs/masterpage/SP2013Master.master";

                    CurrentWeb.Update();
                }

            }

        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            using (SPSite CurrentSite = properties.Feature.Parent as SPSite)
            {
                using (SPWeb CurrentWeb = CurrentSite.RootWeb)
                {
                    CurrentWeb.CustomMasterUrl = CurrentWeb.Site.RootWeb.ServerRelativeUrl + "/_catalogs/masterpage/seattle.master";

                    CurrentWeb.Update();
                }

            }
        }

    }
}
