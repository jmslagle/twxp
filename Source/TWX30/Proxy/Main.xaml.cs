using System;
using System.Collections.Generic;
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
using TWXP;

namespace TWX3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        System.Windows.Forms.NotifyIcon notifyicon;
        Window popup = new Popup();

        private Proxy proxy;
        public Proxy Proxy { get => proxy; set => proxy = value; }

        public Main()
        {
            // Hide the main window.
            Hide();

            InitializeComponent();
            Initialize();

            Window welcome = new Welcome();
            //welcome.ShowDialog();

            Proxy = new Proxy();
            proxy.StartAsync();
            //proxy.Scripts.Load(@"scripts\login.cts");

        }

        void Initialize()
        {
            // Create the notification icon and losd from resources.
            notifyicon = new System.Windows.Forms.NotifyIcon();
            using (Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/TWX3;component/Images/proxy.ico")).Stream)
            {
                notifyicon.Icon = new System.Drawing.Icon(iconStream, new System.Drawing.Size(16, 16));
            }

            // Setup callbacks for mouse clicks.
            notifyicon.MouseClick += MouseClick;
            notifyicon.DoubleClick += DoubleClick;

            // Show the notification icon.
            notifyicon.Visible = true;

            // Set the deactivate callback for the popup window.
            popup.Deactivated += PopupLostFocus;
        }


        private void MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }
            else
            {
                // TODO: Get the position of the current window instead of primary.
                popup.Top = System.Windows.SystemParameters.PrimaryScreenHeight - popup.Height - 32;
                popup.Left = System.Windows.SystemParameters.PrimaryScreenWidth - popup.Width - 10;

                // TODO: Get correct position when magnification is on.
                int pos = System.Windows.Forms.Cursor.Position.X;
                if (pos < popup.Left + 20)
                {
                    popup.Left = pos - 20;
                }

                popup.ShowInTaskbar = false;
                popup.Show();
                popup.Activate();
                popup.Focus();
            }

        }

        private void PopupLostFocus(object sender, EventArgs e)
        {
            popup.Hide();
        }

        private void DoubleClick(object sender, EventArgs e)
        {

        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            //List<string> ts = new List<string>();
            //input.Text = "setVar meow 7\nadd meow 3\necho \"7 plus 3 equals\" meow *\n" +
            //    "setvar MyVar1 True\n" +
            //    "setvar MyVar2 True\n" +
            //    "and MyVar1 MyVar2\n" +
            //    "echo \":\" MyVar1 \":\" MyVar2 \n" +
            //    "setvar $Var1 1\n" +
            //    "setvar $Var2 1\n" +
            //    "and $Var1 $Var2\n" +
            //    "echo \":\" $Var1 \":\" $Var1 \n"


            //    ;

            //proxy.Scripts.Load(@"scripts\zed-bot.cts");
            //proxy.Scripts.Compile(input.Text);

        }

        private void ApplicationClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Hide the notification icon.
            notifyicon.Visible = false;
        }

    }
}
