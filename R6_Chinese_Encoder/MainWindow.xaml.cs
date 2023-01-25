using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace R6_Chinese_Encoder
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Icon.MouseDown += (s, e) =>
            {
                System.Diagnostics.Process.Start("https://github.com/a36176381/R6_Chinese_Encoder/");

            };
            textBox1.PreviewTextInput += (s, e) =>
            {
                e.Handled = new Regex("[^\u4e00-\u9fa5]").IsMatch(e.Text);
            };
            btn1.Click += (s, e) =>
            {
                textBox2.Text = "";
                var big5 = Encoding.GetEncoding("big5");
                foreach (var item in textBox1.Text)
                {
                    string f = "";
                    foreach (var b in big5.GetBytes(item.ToString()))
                    {
                        f += b.ToString("X2");
                    }
                    textBox2.Text += $"{Convert.ToInt32(f, 16)}\n";
                }
            };
        }
    }
}
