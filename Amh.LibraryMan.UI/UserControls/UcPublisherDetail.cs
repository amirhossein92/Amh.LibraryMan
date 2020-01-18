using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amh.LibraryMan.UI.Base;
using Amh.LibraryMan.UI.Models;
using Amh.LibraryMan.UI.Services;

namespace Amh.LibraryMan.UI.UserControls
{
    public partial class UcPublisherDetail : UcBase
    {
        private PublisherService _publisherService = new PublisherService();
        private int _publisherId = -1;

        public UcPublisherDetail() : base("Publisher Detail")
        {
            InitializeComponent();
        }

        public UcPublisherDetail(int? publisherId = null) : this()
        {
            if (publisherId != null)
                _publisherId = publisherId.Value;
        }

        private void UcPublisherDetail_Load(object sender, EventArgs e)
        {
            if (_publisherId > 0)
            {
                var publisher = _publisherService.GetPublisherByIndex(_publisherId);
                txtName.Text = publisher.Name;
                txtAddress.Text = publisher.Address;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var publisher = new Publisher
            {
                Name = txtName.Text,
                Address = txtAddress.Text
            };

            if (_publisherId > 0)
            {
                publisher.Id = _publisherId;
                _publisherService.EditPublihser(publisher);
            }
            else
            {
                _publisherService.AddPublihsher(publisher);
            }

            var btn = (Button)Application.OpenForms[0].Controls["pnlSideBar"].Controls["btnPublishers"];
            btn.PerformClick();
        }
    }
}
