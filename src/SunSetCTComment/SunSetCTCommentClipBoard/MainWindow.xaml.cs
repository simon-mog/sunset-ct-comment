using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SunSetCTCommentClipBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowStyle _originalStyle;
        private ResizeMode _originalResizeMode;
        private Cursor _originalCursor;
        private Brush _originalBorderBrush;
        private Thickness _originalThickness;
        private double _originalWindowWidth;
        private double _originalWindowHeight;

        private Brush _originalButtonBackground;

        public MainWindow()
        {
            InitializeComponent();
            // 元のスタイルを保存（復元のため）
            _originalStyle = this.WindowStyle;
            _originalResizeMode = this.ResizeMode;
            _originalCursor = this.Cursor;
            _originalBorderBrush = this.BorderBrush;
            _originalThickness = this.BorderThickness;
            _originalButtonBackground = this.CopyButton180.Background; //代表して180ボタン
        }

        /// <summary>
        /// グル1、180
        /// グル1、120
        /// グル1、60
        /// グル1、30
        /// グル1、15
        /// グル1、in
        /// グル1、in後待機
        /// グル1、再開
        /// グル1、撃破
        /// </summary>
        /// <param name="group"></param>
        private bool InsertCopiedStr(string mode)
        {
            var formatDictionary = new Dictionary<string, string>
            {
                {"180", "グル{0}、180"},
                {"120", "グル{0}、120"},
                {"60", "グル{0}、60"},
                {"30", "グル{0}、30"},
                {"15", "グル{0}、15"},
                {"in", "グル{0}、in"},
                {"pause", "グル{0}、in後待機"},
                {"resume", "グル{0}、再開"},
                {"defeat", "グル{0}、撃破"}
            };

            if (GroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("グループを選択してください");
                return false;
            }
            if (int.TryParse(GroupComboBox.Text, out int group))
            {
                string copied = string.Format(formatDictionary[mode], group);
                Clipboard.SetText(copied);
                CopiedStringsListBox.Items.Insert(0, copied);

                CopyButton180.Background = _originalButtonBackground;
                CopyButton120.Background = _originalButtonBackground;
                CopyButton60.Background = _originalButtonBackground;
                CopyButton30.Background = _originalButtonBackground;
                CopyButton15.Background = _originalButtonBackground;
                CopyButtonIn.Background = _originalButtonBackground;
                CopyButtonPause.Background = _originalButtonBackground;
                CopyButtonResume.Background = _originalButtonBackground;
                CopyButtonDefeat.Background = _originalButtonBackground;

                return true;
            }

            MessageBox.Show(nameof(GroupComboBox) + " ERROR");
            return false;
        }

        private void Copy180Button_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("180"))
            {
                CopyButton180.Background = Brushes.LightYellow;
            }
        }

        private void Copy120Button_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("120"))
            {
                CopyButton120.Background = Brushes.LightYellow;
            }
        }

        private void Copy60Button_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("60"))
            {
                CopyButton60.Background = Brushes.LightYellow;
            }
        }

        private void Copy30Button_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("30"))
            {
                CopyButton30.Background = Brushes.LightYellow;
            }
        }

        private void Copy15Button_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("15"))
            {
                CopyButton15.Background = Brushes.LightYellow;
            }
        }

        private void CopyInButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("in"))
            {
                CopyButtonIn.Background = Brushes.LightYellow;
            }
        }

        private void CopyPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("pause"))
            {
                CopyButtonPause.Background = Brushes.LightYellow;
            }
        }

        private void CopyResumeButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("resume"))
            {
                CopyButtonResume.Background = Brushes.LightYellow;
            }
        }

        private void CopyDefeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (InsertCopiedStr("defeat"))
            {
                CopyButtonDefeat.Background = Brushes.LightYellow;
            }
        }

        private void MyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Clear();
            }
        }

        private void SimpleModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this._originalWindowWidth = this.ActualWidth;
            this._originalWindowHeight = this.ActualHeight;

            this.WindowStyle = WindowStyle.None;
            this.Width = this.SimpleModeStackPanel.ActualWidth;
            this.Height = this.SimpleModeStackPanel.ActualHeight;
            this.ResizeMode = ResizeMode.NoResize;
            this.Cursor = Cursors.SizeAll;
            this.BorderBrush = Brushes.LightSalmon;
            this.BorderThickness = new Thickness(2);
            this.CopyCheckStackPanel.Visibility = Visibility.Collapsed;
        }
        private void SimpleModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            this.WindowStyle = _originalStyle;
            this.ResizeMode = _originalResizeMode;
            this.Cursor = _originalCursor;
            this.BorderBrush = _originalBorderBrush;
            this.BorderThickness = _originalThickness;
            
            this.Width = this._originalWindowWidth;
            this.Height = this._originalWindowHeight;

            this.CopyCheckStackPanel.Visibility = Visibility.Visible;
        }
        private void DragArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 左ボタン押下でウィンドウをドラッグ移動可能に
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}