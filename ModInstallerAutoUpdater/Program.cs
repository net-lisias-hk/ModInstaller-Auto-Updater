using System;
using System.Windows.Forms;

namespace ModInstallerAutoUpdater
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[]  arg)
        {
            EmbeddedAssemblies.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autoupdater(arg));
        }
    }
}
