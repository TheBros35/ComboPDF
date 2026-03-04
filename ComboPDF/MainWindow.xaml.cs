using Microsoft.Win32;
using System.Windows;


namespace ComboPDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MergeBtn_Click(object sender, RoutedEventArgs e)
        {
            string input1 = file1TextBox.Text;
            string input2 = file2TextBox.Text;
            string outputPath = outputPathTextBox.Text;
            string outputName = outputNameTextBox.Text;
            if (MergePDF.MergePDFFiles(input1, input2, outputPath, outputName))
            {
                MessageBox.Show("PDF files merged successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to merge PDF files. Please check the file paths and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void browseFile1Btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == true)
            {
                file1TextBox.Text = dialog.FileName;
            }
        }

        private void browseFile2Btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == true)
            {
                file2TextBox.Text = dialog.FileName;
            }
        }

        private void browseOutputPathBtn_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFolderDialog
            {
                // Set options here
            };

            if (folderDialog.ShowDialog() == true)
            {
                var folderName = folderDialog.FolderName;
                outputPathTextBox.Text = folderName;
                // Do something with the result
            }
        }

    }
}