using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ModInstallerAutoUpdater;

namespace ModInstallerAutoUpdater
{
    public partial class Autoupdater : Form
    {
        public Autoupdater(string[] path)
        {
            InitializeComponent(path[0]);
            this.path = path[0];
            link = new Uri (path[1]);
        }

        private void Autoupdater_Load(object sender, System.EventArgs e)
        {
            DoUpdate();
        }

        private void DoUpdate()
        {
            DownloadHelper download = new DownloadHelper(link, path + @"/lol.exe");
            download.Closed += Download_Closed;
            download.ShowDialog();
        }

        private void Download_Closed(object sender, EventArgs e)
        {
            File.Copy(path + @"/lol.exe", path + @"/ModInstaller.exe", true);
            Process.Start(path + @"/ModInstaller.exe");
            Application.Exit();
        }

        private string path;
        private Uri link;
    }
}
