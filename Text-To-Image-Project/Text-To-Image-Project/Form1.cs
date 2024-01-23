using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALLE_WinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        private const string BaseUrl = "https://api.openai.com/v1/images/generations";
        private Image generatedImage;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private async void GenerateImageButton_Click(object sender, EventArgs e)
        {
            var prompt = InputTextBox.Text;
            try
            {
                var base64Image = await GenerateImage(prompt);

                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    generatedImage = Image.FromStream(ms, true);
                    pictureBox1.Image = generatedImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task<string> GenerateImage(string prompt)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

            // Set the authorization header with your API key
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            // Set the content of the request
            var content = new
            {
                model = "dall-e-3",
                prompt,
                n = 1,
                size = "1024x1024",
                response_format = "b64_json"
            };

            var jsonContent = JsonConvert.SerializeObject(content);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Send the request and get the response
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API request failed with status code {response.StatusCode}, {errorContent}");
            }

            // Read the content of the response
            var responseContent = await response.Content.ReadAsStringAsync();

            // Extract the image data from the response
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

            // Check if the 'response_format' was 'b64_json'
            if (content.response_format == "b64_json")
            {
                // The image data is in the "b64_json" property of the first item in the "data" array
                string base64Image = responseObject.data[0]?.b64_json;

                if (string.IsNullOrEmpty(base64Image))
                {
                    throw new Exception("API response does not contain image data");
                }

                // Print out the revised prompt
                string revisedPrompt = responseObject.data[0]?.revised_prompt;
                Console.WriteLine($"Revised prompt: {revisedPrompt}");

                return base64Image;
            }
            else // 'response_format' was 'url' or not specified
            {
                // The URL of the image is in the "url" property of the first item in the "data" array
                string imageUrl = responseObject.data[0]?.url;

                if (string.IsNullOrEmpty(imageUrl))
                {
                    throw new Exception("API response does not contain image URL");
                }

                // Download the image from the URL
                var imageResponse = await _httpClient.GetAsync(imageUrl);
                var imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();

                return Convert.ToBase64String(imageBytes);
            }
        }

        private void DownloadImageButton_Click(object sender, EventArgs e)
        {
            if (generatedImage != null)
            {
                saveFileDialog1.Filter = "JPEG Image|*.jpg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    generatedImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                MessageBox.Show("Please generate an image first.");
            }
        }
    }
}
