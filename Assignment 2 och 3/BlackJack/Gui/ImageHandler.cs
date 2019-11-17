using System;
using System.Windows.Media.Imaging;

namespace Gui
{
    // Creates a bit map image with a card
    public class ImageHandler
    {
        public BitmapImage GetCardImage(string cardName)
        {
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri
              ("pack://application:,,,/Gui;component/Resources/" + cardName + ".jpg");
            b.EndInit();

            return b;
        }
    }
}
