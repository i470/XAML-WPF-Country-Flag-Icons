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

            var bitmap = new BitmapImage(new Uri(baseUri, UriKind.Absolute));
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.Freeze();

            BmpBitmapDecoder decoder2 = new BmpBitmapDecoder(baseUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            var w = bitmap.Width;
            var h = bitmap.Height;

            var ImageDrawing = new ImageDrawing
            {
                Rect = new Rect(0, 0, w, h),
                ImageSource = bitmap
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