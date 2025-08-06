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

        public MainWindow()
        {
            InitializeComponent();
            // 元のスタイルを保存（復元のため）
            _originalStyle = this.WindowStyle;
            _originalResizeMode = this.ResizeMode;
            _originalCursor = this.Cursor;
            _originalBorderBrush = this.BorderBrush;
            _originalThickness = this.BorderThickness;
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
        private void InsertCopiedStr(string mode)
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
                return;
            }
            if (int.TryParse(GroupComboBox.Text, out int group))
            {
                string copied = string.Format(formatDictionary[mode], group);
                Clipboard.SetText(copied);
                CopiedStringsListBox.Items.Insert(0, copied);
            }
            else
            {
                MessageBox.Show(nameof(GroupComboBox) + " ERROR");
            }
        }

        private void Copy180Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("180");
        }

        private void Copy120Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("120");
        }

        private void Copy60Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("60");
        }

        private void Copy30Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("30");
        }

        private void Copy15Button_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("15");
        }

        private void CopyInButton_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("in");
        }

        private void CopyPauseButton_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("pause");
        }

        private void CopyResumeButton_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("resume");
        }

        private void CopyDefeatButton_Click(object sender, RoutedEventArgs e)
        {
            InsertCopiedStr("defeat");
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