using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PropertyChecker.Views;
namespace PropertyChecker
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.StartupUri = new Uri("Views\\MainWindow.xaml", UriKind.Relative);
            base.OnStartup(e);
        }
    }
}
