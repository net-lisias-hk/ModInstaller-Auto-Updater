using System;
using System.IO;
using System.Windows.Forms;

namespace ModInstallerAutoUpdater
{
    public partial class Autoupdater : Form
    {
        public Autoupdater(string[] args)
        {
            InitializeComponent(args[0]);
            this.path = args[0];
            link = new Uri (args[1]);
            exec = args[2];
        }

        private void Autoupdater_Load(object sender, System.EventArgs e)
        {
            DoUpdate();
        }

        private void DoUpdate()
        {
            DownloadHelper download = new DownloadHelper(link, Path.Combine(this.path, "package.zip"));
            download.Closed += Download_Closed;
            download.ShowDialog();
        }

        private void Download_Closed(object sender, EventArgs e)
        {
            Util.Unzip(Path.Combine(this.path,"package.zip"), path);
            Util.Execute(path, exec);
            Application.Exit();
        }

        private readonly string exec;
        private readonly string path;
        private readonly Uri link;
    }
}
