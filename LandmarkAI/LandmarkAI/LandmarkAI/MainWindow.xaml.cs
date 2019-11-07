using LandmarkAI.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        private async void MakePredictionAsync(string fileName)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/54a2b3b0-9de8-4aec-a6cc-cffad8b3c589/classify/iterations/Iteration1/image";
            string predictionKey = "9b2f63af4ead44c7917914ab375bbb03";
            string contentType = "application/octet-stream";
            
            // reads the file at the path into an array of bytes
            var file = File.ReadAllBytes(fileName);

            // using statement so client closes as soon as execution leaves this code block
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);

                using (var content = new ByteArrayContent(file))
                {
                    // Tell what type of content is in the request
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    var response = await client.PostAsync(url, content);

                    // PostAsync sends a post request and requests info 
                    
                    // JSON string
                    // jsonutils.com, gives a nice little summary of the classes etc. needed for managing
                    // JSON info, very useful for much more complex JSON replies

                    var responseString = await response.Content.ReadAsStringAsync();

                    // generic Deserialize, deserialize JSON response to a CustomVision object,
                    // access its list of predictions

                    List<Prediction> predictions = (JsonConvert.DeserializeObject<CustomVision>(responseString)).Predictions;
                }

            }
        }

    }
}
