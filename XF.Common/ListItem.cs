using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF.Common
{
    public class ListItem : System.Object
    {
        private string _Value = string.Empty;
        private string _Text = string.Empty;

        public ListItem(string value, string text)
        {
            this._Value = value;
            this._Text = text;
        }

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public override string ToString()
        {
            return _Text;
        }
        
    }
}
