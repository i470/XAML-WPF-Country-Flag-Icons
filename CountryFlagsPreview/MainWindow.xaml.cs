using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace CountryFlagsPreview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SolidColorBrush CloseIconBrushActive= new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush CloseIconBrushInactive = new SolidColorBrush(Colors.WhiteSmoke);
        public MainWindow()
        {
            InitializeComponent();
            CloseIconBrushActive = WindowCloseIcon.Foreground as SolidColorBrush;
        }

        private void window_header_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
           
        }

        private void window_header_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void window_header_grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void WindowCloseIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.Close();
        }

        private void WindowCloseIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            WindowCloseIcon.Foreground = CloseIconBrushInactive;
        }

        private void WindowCloseIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            WindowCloseIcon.Foreground = CloseIconBrushActive;
        }
    }
}
