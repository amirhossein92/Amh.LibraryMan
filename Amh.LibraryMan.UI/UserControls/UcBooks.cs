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
    public partial class UcBooks : UcBase
    {
        public UcBooks() : base("Books")
        {
            InitializeComponent();
        }

        private List<Book> books = new List<Book>();
        BookService _bookService = new BookService();
        PublisherService _publisherService = new PublisherService();

        private void UcBooks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //var publisherComboColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Publisher"];
            //publisherComboColumn.Items.AddRange(_publisherService.GetPublishers());
            //publisherComboColumn.DisplayMember = "Name";
            //publisherComboColumn.ValueMember = "Id";

            dataGridView1.AutoGenerateColumns = false;
            books = _bookService.GetBooks();
            dataGridView1.DataSource = books;
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            List<Book> filteredBooks = _bookService.GetBooks(txtTitle.Text, txtAuthor.Text, txtPublisher.Text);
            dataGridView1.DataSource = filteredBooks;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var bookId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["BookId"].Value);

            if (dataGridView.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                var frm = (MainForm)Application.OpenForms[0];
                frm.OpenBookDetail(bookId);
                LoadData();
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                if (MessageBox.Show("Are You Sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _bookService.DeleteBookByIndex(bookId);
                    LoadData();
                }
            }
        }
    }
}
