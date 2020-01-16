using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amh.LibraryMan.UI.Base
{
    public partial class UcBase : UserControl
    {
        public UcBase()
        {
            InitializeComponent();
        }

        public UcBase(string formTitle) : this()
        {
            var lbl = (Label)Application.OpenForms[0].Controls["pnlHeader"].Controls["lblPageTitle"];
            lbl.Text = formTitle;
        }
    }
}
