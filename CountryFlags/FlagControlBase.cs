using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CountryFlags
{
    
    public abstract class FlagControlBase : FlagBase
    {
     
        protected static readonly DependencyProperty DataProperty
         = DependencyProperty.Register(nameof(Data), typeof(string), typeof(FlagIcon), new PropertyMetadata(""));

        [TypeConverter(typeof(GeometryConverter))]
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            protected set { SetValue(DataProperty, value); }
        }


        protected virtual DrawingGroup GetDrawingGroup(object country, string path)
        {
            var baseUri = $"pack://application:,,,/CountryFlags;component/img/{path}";
            var imgUri = new Uri(baseUri, UriKind.Absolute);

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = imgUri;
            bitmap.DecodePixelWidth = 300;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();

            var decoder = new PngBitmapDecoder(imgUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            var img = new Image();
            img.BeginInit();
            img.Source = bitmapSource;



            var w = bitmap.PixelWidth;
            var h = bitmap.PixelHeight;

            var ImageDrawing = new ImageDrawing
            {
                Rect = new Rect(0, 0, w, h),
                ImageSource = bitmapSource
            };

            var drawingGroup = new DrawingGroup
            {
                Children = { ImageDrawing },

            };

            return drawingGroup;
        }

        protected ImageSource CreateImageSource(Enum country)
        {
            
            if (string.IsNullOrEmpty(Data))
            {
                return null;
            }

            var drawingImage = new DrawingImage(GetDrawingGroup(country, Data));
            drawingImage.Freeze();

            return drawingImage;
        }
    }


}