using System.Configuration;
using System.Data;
using System.Windows;

namespace ComboPDF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length >= 3)
            {
                string input1 = e.Args[0];
                string input2 = e.Args[1];
                string outputPath = e.Args[2];
                string outputName = e.Args[3];
                //if (string.IsNullOrEmpty(outputName)) outputName = "merged";
                MergePDF.MergePDFFiles(input1, input2, outputPath, outputName);
                Application.Current.Shutdown();
            }
            else
            {
                MainWindow wnd = new MainWindow();
                wnd.Show();
            }


        }

    }

}
