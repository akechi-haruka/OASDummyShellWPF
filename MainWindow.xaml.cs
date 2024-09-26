using ManagedShell;
using ManagedShell.AppBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OASDummyShellWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private static ShellManager shell;
        private static AppBarWindow wm;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e) {
            shell = new ShellManager();

            wm = new AppBarWindow(shell.AppBarManager, shell.ExplorerHelper, shell.FullScreenHelper, AppBarScreen.FromPrimaryScreen(), AppBarEdge.Bottom, AppBarMode.None, 0);

            WindowState = WindowState.Minimized;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                string path = args[1];
                if (File.Exists(path)) {
                    Process.Start(path);
                }
            }
        }
    }
}
