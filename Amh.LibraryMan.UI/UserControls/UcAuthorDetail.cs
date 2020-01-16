using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amh.LibraryMan.UI.Base;
using Amh.LibraryMan.UI.Models;
using Amh.LibraryMan.UI.Services;

namespace Amh.LibraryMan.UI.UserControls
{
    public partial class UcAuthorDetail : UcBase
    {
        AuthorService _service = new AuthorService();
        private int _authorId = -1;

        public UcAuthorDetail() : base("Author Detail")
        {
            InitializeComponent();
        }

        public UcAuthorDetail(int? authorId) : this()
        {
            if (authorId != null)
                _authorId = authorId.Value;
        }

        private void UcAuthorDetail_Load(object sender, EventArgs e)
        {
            if (_authorId > 0)
            {
                var author = _service.GetAuthorById(_authorId);
                txtFirstName.Text = author.FirstName;
                txtLastName.Text = author.LastName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var author = new Author
            {
                Id = _authorId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim()
            };

            if (_authorId == -1)
            {
                _service.AddAuthor(author);
                var btn = (Button)Application.OpenForms[0].Controls["pnlSideBar"].Controls["btnAuthors"];
                btn.PerformClick();
            }
            else
            {
                _service.EditAuthor(author);
                var btn = (Button)Application.OpenForms[0].Controls["pnlSideBar"].Controls["btnAuthors"];
                btn.PerformClick();
            }

        }
    }
}
