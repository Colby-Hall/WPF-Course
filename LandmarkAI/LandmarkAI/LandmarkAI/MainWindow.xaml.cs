using Microsoft.Win32;
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

namespace LandmarkAI
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
        // selecting an image file
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Filter happens in the file explorer through the text after the vertical bar 
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png; *(jpg)|*.png;*.jpg;*jpeg|All files (*.*)|*.*";
            // Setting the initial directory
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);


            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }

            
        }

        private void MakePredictionAsync(string fileName)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/54a2b3b0-9de8-4aec-a6cc-cffad8b3c589/classify/iterations/Iteration1/image";
            string predictionKey = "9b2f63af4ead44c7917914ab375bbb03";
            string contentType = "application/octet-stream";
        }

    }
}
