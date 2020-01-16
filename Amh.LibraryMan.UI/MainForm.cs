using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amh.LibraryMan.UI.Services;
using Amh.LibraryMan.UI.UserControls;

namespace Amh.LibraryMan.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnAuthors_Click(object sender, EventArgs e)
        {
            OpenUserControl(new UcAuthors());
        }

        public void OpenAuthorDetail(int? authorId = null)
        {
            OpenUserControl(new UcAuthorDetail(authorId));
        }

        public void OpenBookDetail(int? bookId = null)
        {
            OpenUserControl(new UcBookDetail(bookId));
        }

        public void OpenPublisherDetail(int? publisherId = null)
        {
            OpenUserControl(new UcPublisherDetail(publisherId));
        }

        private void OpenUserControl(UserControl userControl)
        {
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(userControl);
        }

        private void BtnShowBooks_Click(object sender, EventArgs e)
        {
            OpenUserControl(new UcBooks());
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            OpenUserControl(new UcBookDetail());
        }

        private void BtnPublishers_Click(object sender, EventArgs e)
        {
            OpenUserControl(new UcPublishers());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblLoginDate.Text = DateTime.Now.ToLongDateString();
            lblPageTitle.Text = "Welcome";
            lblConnectionStatus.Text = "Connection Pending";
            timerConnection.Enabled = true;
            timerConnection.Interval = 10000;
        }

        private void TimerConnection_Tick(object sender, EventArgs e)
        {
            lblConnectionStatus.Text = DbService.GetConnectionStatus();
        }
    }
}
