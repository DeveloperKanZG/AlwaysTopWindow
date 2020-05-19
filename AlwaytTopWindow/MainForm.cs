using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlwaysTopWindow
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.RefreshProcessList();
        }

        /// <summary>
        /// ウィンドウ表示スタイル
        /// </summary>
        enum ShowWindowStyle : int
        {
            HWND_NOTOPMOST = -2,
            HWND_TOPMOST = -1,
            SW_SHOW = 1,
            SW_SHOWMINNOACTIVE = 7,
            SW_RESTORE = 9,
            GWL_STYLE = -16,
            SWP_FRAMECHANGED = 0x0020,
            SWP_SHOWWINDOW = 0x40,
        };

        /// <summary>
        /// ウィンドウスタイル
        /// </summary>
        enum WindowStyle : uint
        {
            WS_POPUP = 0x80000000,
            WS_OVERLAPPEDWINDOW = 0x00CF0000,
        };

        /// <summary>
        /// プロセス一覧
        /// </summary>
        readonly List<System.Diagnostics.Process> processList = new List<System.Diagnostics.Process>();

        /// <summary>
        /// ウィンドウ表示
        /// </summary>
        [DllImport("user32.dll")]
        static extern private int ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// ウィンドウの属性変更
        /// </summary>
        [DllImport("user32.dll")]
        static extern private long SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        /// <summary>
        /// ウィンドウの属性取得
        /// </summary>
        [DllImport("user32.dll")]
        static extern private long GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// ウィンドウの位置設定
        /// </summary>
        [DllImport("user32.dll")]
        static extern private int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int width, int height, int uFlags);

        /// <summary>
        /// ウィンドウのサイズ取得
        /// </summary>
        [DllImport("user32.dll")]
        static extern private int GetWindowRect(IntPtr hwnd, out RECT rc);

        /// <summary>
        /// ウィンドウ矩形情報
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public int Width => Math.Abs(this.Right - this.Left);
            public int Height => Math.Abs(this.Bottom - this.Top);
        }

        /// <summary>
        /// 最前面化解除ボタン
        /// </summary>
        private void releaseButton_Click(object sender, EventArgs e)
        {
            this.ReleaseBorderless();
        }

        /// <summary>
        /// 再検索
        /// </summary>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.RefreshProcessList();
        }

        /// <summary>
        /// プロセス一覧を取得します
        /// </summary>
        private void RefreshProcessList()
        {
            //ローカルコンピュータ上で実行されているすべてのプロセスを取得
            var processList = System.Diagnostics.Process.GetProcesses();

            this.processComboBox.Items.Clear();
            this.processList.Clear();

            //配列から1つずつ取り出す
            foreach (var process in processList.OrderByDescending(s => s.Id))
            {
                try
                {
                    if (process.MainWindowHandle == IntPtr.Zero) continue;

                    //プロセス名を取得・表示
                    this.processComboBox.Items.Add($"[{process.Id:D5}] | {process.ProcessName} : {process.MainWindowTitle}");
                    this.processList.Add(process);
                }
                catch (Exception)
                {
                    this.processComboBox.Items.Add("プロセス情報取得失敗");
                }
            }

            this.processComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 最前面化開始
        /// </summary>
        private void applyButton_Click(object sender, EventArgs e)
        {
            this.ApplyTopMost();
        }

        /// <summary>
        /// 指定されたプロセスを最前面化します
        /// </summary>
        private void ApplyTopMost()
        {
            if (this.processList[this.processComboBox.SelectedIndex].MainWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("HWNDがNULLです");
                return;
            }

            var process = this.processList[this.processComboBox.SelectedIndex];


            // 現在のウィンドウサイズ退避
            GetWindowRect(process.MainWindowHandle, out RECT rc);

            SetWindowPos(process.MainWindowHandle, (int)ShowWindowStyle.HWND_TOPMOST, rc.Left, rc.Top, rc.Width, rc.Height, (int)ShowWindowStyle.SWP_SHOWWINDOW);

            // ウィンドウアクティブ化
            ShowWindow(process.MainWindowHandle, (int)ShowWindowStyle.SW_SHOW);
        }

        /// <summary>
        /// 指定されたプロセスのボーダーレスを解除します
        /// </summary>
        private void ReleaseBorderless()
        {
            if (this.processList[this.processComboBox.SelectedIndex].MainWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("HWNDがNULLです");
                return;
            }

            var process = this.processList[this.processComboBox.SelectedIndex];

            // 現在のウィンドウサイズ退避
            GetWindowRect(process.MainWindowHandle, out RECT rc);

            SetWindowPos(process.MainWindowHandle, (int)ShowWindowStyle.HWND_NOTOPMOST, rc.Left, rc.Top, rc.Width, rc.Height, (int)ShowWindowStyle.SWP_SHOWWINDOW);

            // ウィンドウアクティブ化
            ShowWindow(process.MainWindowHandle, (int)ShowWindowStyle.SW_SHOW);
        }
    }
}
