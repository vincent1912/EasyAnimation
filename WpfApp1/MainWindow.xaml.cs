using Prism.Commands;
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 
    }

    public class MainWindowViewModel : Prism.Mvvm.BindableBase
    {

        public MainWindowViewModel()
        {
            TestCommand = new DelegateCommand(() => 
            {
                IsFadeOut = true;
            });
            WindowAnimationCompletedCommand = new DelegateCommand(() => 
            {
                Application.Current.MainWindow.Close();
            });
            BorderAnimationCompletedCommand = new DelegateCommand(() =>
            {

            });
        }
        public DelegateCommand TestCommand { get; private set; }

        public DelegateCommand WindowAnimationCompletedCommand { get; private set; }
        public DelegateCommand BorderAnimationCompletedCommand { get; private set; }

        private bool _isFadeOut;

        public bool IsFadeOut
        {
            get { return _isFadeOut; }
            set { SetProperty(ref _isFadeOut, value); }
        }

    }
}
