using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amh.LibraryMan.UI.Models;
using Amh.LibraryMan.UI.Services;

namespace Amh.LibraryMan.UI.UserControls
{
    public partial class UcBookDetail : UserControl
    {
        private AuthorService _authorService = new AuthorService();
        private PublisherService _publisherService = new PublisherService();
        private BookService _bookService = new BookService();
        private int _bookId = -1;

        public UcBookDetail()
        {
            InitializeComponent();
        }

        public UcBookDetail(int? bookId = null) : this()
        {
            if (bookId != null)
                _bookId = bookId.Value;
        }

        private void UcBookDetail_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (_bookId > 0)
            {
                var book = _bookService.GetBookById(_bookId);
                txtTitle.Text = book.Title;
                txtEdition.Text = book.Edition.ToString();
                txtPrice.Text = book.Price.ToString();
                txtPublishYear.Text = book.PublishDate.ToString();
                txtSerialNumber.Text = book.SerialNumber;
                cmbAuthor.SelectedValue = book.AuthorId;
                cmbPublisher.SelectedValue = book.PublisherId;
            }
        }

        private void LoadComboBoxes()
        {
            cmbAuthor.DataSource = _authorService.GetAuthors();
            cmbAuthor.DisplayMember = "LastName";
            cmbAuthor.ValueMember = "Id";
            cmbPublisher.DataSource = _publisherService.GetPublishers();
            cmbPublisher.DisplayMember = "Name";
            cmbPublisher.ValueMember = "Id";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Title = txtTitle.Text.Trim(),
                AuthorId = Convert.ToInt32(cmbAuthor.SelectedValue),
                PublisherId = Convert.ToInt32(cmbPublisher.SelectedValue),
                Price = Convert.ToInt32(txtPrice.Text.Trim()),
                Edition = Convert.ToInt32(txtEdition.Text.Trim()),
                PublishDate = Convert.ToInt32(txtPublishYear.Text.Trim()),
                SerialNumber = txtSerialNumber.Text.Trim()
            };
            if (_bookId > 0)
            {
                book.Id = _bookId;
                _bookService.EditBook(book);
            }
            else
            {
                _bookService.AddBook(book);
            }
            var btn = (Button)Application.OpenForms[0].Controls["pnlSideBar"].Controls["btnShowBooks"];
            btn.PerformClick();
        }
    }
}
