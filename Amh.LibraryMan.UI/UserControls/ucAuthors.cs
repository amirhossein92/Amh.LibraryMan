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
using Amh.LibraryMan.UI.Services;

namespace Amh.LibraryMan.UI.UserControls
{
    public partial class UcAuthors : UcBase
    {
        AuthorService _service = new AuthorService();

        public UcAuthors() : base("Authors")
        {
            InitializeComponent();
        }

        private void UcAuthors_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _service.GetAuthors();
        }

        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            var frm = (MainForm)Application.OpenForms[0];
            frm.OpenAuthorDetail();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            var authorId = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["AuthorId"].Value);

            if (dataGrid.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var frm = (MainForm)Application.OpenForms[0];
                frm.OpenAuthorDetail(authorId);
            }
            else if (dataGrid.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                if (MessageBox.Show(
                        "Are You Sure?",
                        "Delete Author",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _service.DeleteAuthorById(authorId);
                    LoadData();
                }
            }
        }
    }
}
