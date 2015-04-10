using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP2013Branding.Model;
using Microsoft.SharePoint;

namespace SP2013Branding.Controller
{
    public static class BannerController
    {
        public static HeroBanner GetBanners()
        {
            return GetListItemsAsBanners("Hero Banner");
        }

        private static HeroBanner GetListItemsAsBanners(string contentTypeName)
        {
            HeroBanner banners = new HeroBanner();

            SPWeb web = SPContext.Current.Site.RootWeb;

            SPList list = web.Lists.TryGetList("Hero Banners");

            if (list != null)
            {
                SPQuery query = new SPQuery();
                query.Query = string.Concat(
                                "<Where><Eq>",
                                    "<FieldRef Name='ContentType'/>",
                                    string.Format("<Value Type='Text'>{0}</Value>", contentTypeName),
                                "</Eq></Where>");
                query.RowLimit = 1;

                SPListItemCollection items = list.GetItems(query);

                foreach (SPListItem item in items)
                {
                    HeroBanner banner = new HeroBanner();
                    banner.HeroBannerText = item["Banner Text"] != null ? item["Banner Text"].ToString() : "";

                    if (item["Banner Image"] != null)
                    {
                        SPFieldUrlValue bannerImageFieldValue = new SPFieldUrlValue(item["Banner Image"].ToString());
                        banner.HeroBannerImage = bannerImageFieldValue.Url;
                    }

                    banners = banner;
                    break;
                }
            }

            return banners;
        }
    }
}
