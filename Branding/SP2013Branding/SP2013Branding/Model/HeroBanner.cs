using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP2013Branding.Model
{
    public class HeroBanner
    {
        private string _text;
        private string _image;

        public string HeroBannerText
        {
            get { return _text; }
            set { _text = value; }
        }

        public string HeroBannerImage
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
