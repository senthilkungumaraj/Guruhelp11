using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP2013Branding.Model;
using Microsoft.SharePoint;

namespace SP2013Branding.Controller
{
    public static class CallOutController
    {
        public static List<CallOut> GetCallOut3Column()
        {
            return GetListItemsAsCallOuts("Call Outs 3 Column");
        }

        public static List<CallOut> GetCallOut4Column()
        {
            return GetListItemsAsCallOuts("Call Outs 4 Column");
        }

        private static List<CallOut> GetListItemsAsCallOuts(string contentTypeName)
        {
            List<CallOut> callOuts = new List<CallOut>();

            SPWeb web = SPContext.Current.Site.RootWeb;

            SPList list = web.Lists.TryGetList("Call Outs");

            if (list != null)
            {
                SPQuery query = new SPQuery();
                query.Query = string.Concat(
                                "<Where><Eq>",
                                    "<FieldRef Name='ContentType'/>",
                                    string.Format("<Value Type='Text'>{0}</Value>", contentTypeName),
                                "</Eq></Where>");
                query.RowLimit = 3;

                SPListItemCollection items = list.GetItems(query);

                foreach (SPListItem item in items)
                {
                    CallOut callOut = new CallOut();
                    
                    callOut.CallOutName =  item["Headline"] != null? item["Headline"].ToString() : "";
                    callOut.CallOutDescription = item["Call Out Body"] != null? item["Call Out Body"].ToString(): "";

                    if (item["Call Out Link"] != null)
                    {
                        SPFieldUrlValue callOutLinkFieldValue = new SPFieldUrlValue(item["Call Out Link"].ToString());
                        callOut.CallOutLink = callOutLinkFieldValue.Url;
                    }

                    if (item["Thumbnail Picture"] != null)
                    {
                        SPFieldUrlValue callOutImageFieldValue = new SPFieldUrlValue(item["Thumbnail Picture"].ToString());
                        callOut.CallOutImage = callOutImageFieldValue.Url;
                    }

                    if (item.Fields["Open In New Window?"] != null)
                    {
                        SPFieldBoolean boolField = item.Fields["Open In New Window?"] as SPFieldBoolean;
                        bool CheckBoxValue = (bool)boolField.GetFieldValue(item["Open In New Window?"].ToString());
                        callOut.OpenInNewWindow = CheckBoxValue;
                    }

                    callOuts.Add(callOut);
                }
            }

            return callOuts;
        }

    }
}
