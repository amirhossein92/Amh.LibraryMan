using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amh.LibraryMan.UI.Services;

namespace Amh.LibraryMan.UI.UserControls
{
    public partial class UcPublishers : UserControl
    {
        private PublisherService _publisherService = new PublisherService();

        public UcPublishers()
        {
            InitializeComponent();
        }

        private void UcPublishers_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _publisherService.GetPublishers();
        }

        private void LoadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _publisherService.GetPublishers();
        }

        private void BtnAddPublisher_Click(object sender, EventArgs e)
        {
            var frm = (MainForm)Application.OpenForms[0];
            frm.OpenPublisherDetail();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var publisherId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PublisherId"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var frm = (MainForm)Application.OpenForms[0];
                frm.OpenPublisherDetail(publisherId);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    _publisherService.DeleteByIndex(publisherId);
                LoadData();
            }
        }
    }
}
