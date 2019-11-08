using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XF.ExControls.Model
{
    public abstract class BaseRichFormat : IRichFormat
    {
        public abstract void SetFormat(RichTextBox rtbInfo);
    }
}
