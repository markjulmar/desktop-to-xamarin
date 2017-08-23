using Xamarin.Forms;

namespace MobileCLScraper
{
    public class BorderFrame : Frame
    {
        public BorderFrame()
        {
            if (Device.RuntimePlatform == Device.iOS)   
            {
                Margin = new Thickness(5, 10);
                Padding = new Thickness(10);
                HasShadow = false;
                OutlineColor = Color.LightGray;
                BackgroundColor = Color.White;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                Margin = new Thickness(5, 10);
                Padding = new Thickness(10);
                HasShadow = true;
                BackgroundColor = Color.White;
            }
        }

    }
}
