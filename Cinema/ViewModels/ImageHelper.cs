using System;
using System.IO;
using System.Net;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class ImageHelper : ViewModelBase
    {
        private string _fileName;
        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set {
                this.RaiseAndSetIfChanged(ref _imageUrl, value);
                DownloadImage(ImageUrl);
                System.Diagnostics.Debug.WriteLine(ImageUrl);
            }
        }

        private Bitmap _image = null;
        public Bitmap Image
        {
            get => _image;
            set => this.RaiseAndSetIfChanged(ref _image, value);
        }

        public ImageHelper(string fileName, string imageUrl)
        {
            ImageUrl = imageUrl;
            _fileName = fileName;
            
            DownloadImage(ImageUrl);
        }

        private void DownloadImage(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadDataAsync(new Uri(url));
                client.DownloadDataCompleted += DownloadComplete;
            }
        }

        private void DownloadComplete(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                byte[] bytes = e.Result;

                Stream memoryStream = new MemoryStream(bytes);

                //сохранить на диск:
                using (FileStream file = new FileStream(_fileName, FileMode.Create, System.IO.FileAccess.Write))
                {
                    memoryStream.CopyTo(file);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                Image = null; // Could not download...
            }
        }
    }
}