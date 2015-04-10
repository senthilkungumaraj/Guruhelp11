using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP2013Branding.Model
{
    public class CallOut
    {
        private string _name;
        private string _description;
        private string _link;
        private string _image;
        private bool _openInNewWindow;

        public string CallOutName {
            get { return _name; }
            set { _name = value; }
        }

        public string CallOutDescription {
            get { return _description; }
            set { _description = value; }
        }

        public string CallOutLink {
            get { return _link; }
            set { _link = value; }
        }

        public string CallOutImage {
            get { return _image; }
            set { _image = value; }
        }

        public bool OpenInNewWindow {
            get { return _openInNewWindow; }
            set { _openInNewWindow = value; }
        }
    }
}
