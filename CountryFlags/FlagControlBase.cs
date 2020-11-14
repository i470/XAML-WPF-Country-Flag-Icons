using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CountryFlags
{

    public abstract class FlagControlBase : FlagBase
    {

        protected static readonly DependencyProperty SizeProperty
      = DependencyProperty.Register(nameof(Size), typeof(IconSize), typeof(FlagIcon), new PropertyMetadata(default(IconSize), SizeChangedCallback));

        private static void SizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((FlagIcon)d).UpdateData();
            }
        }


        public IconSize Size
        {
            get { return (IconSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }




        protected static readonly DependencyProperty DataProperty
         = DependencyProperty.Register(nameof(Data), typeof(string), typeof(FlagIcon), new PropertyMetadata(""));

        [TypeConverter(typeof(GeometryConverter))]
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            protected set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty CountryProperty
            = DependencyProperty.Register(nameof(Country), typeof(CountryEnum), typeof(FlagIcon), new PropertyMetadata(default(CountryEnum), CountryPropertyChangedCallback));

        private static void CountryPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((FlagIcon)dependencyObject).UpdateData();
            }
        }

        public CountryEnum Country
        {
            get { return (CountryEnum)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }



        protected internal override void SetCountry<TCountry>(TCountry country)
        {
            BindingOperations.SetBinding(this, CountryProperty, new Binding() { Source = country, Mode = BindingMode.OneTime });
        }

        protected virtual DrawingGroup GetDrawingGroup(object country, string path)
        {
            var baseUri = $"pack://application:,,,/CountryFlags;component/img/{path}";
            var imgUri = new Uri(baseUri, UriKind.Absolute);

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = imgUri;
            bitmap.DecodePixelWidth = (Int16)Size;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();

            var w = bitmap.PixelWidth;
            var h = bitmap.PixelHeight;

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

        protected internal override void SetSize<IconSize>(IconSize size)
        {
            BindingOperations.SetBinding(this, SizeProperty, new Binding() { Source = size, Mode = BindingMode.OneTime });
        }
    }

    
}

public enum IconSize
{    
    s16 = 16,
    s24=24,
    s32=32,
    s64=64,
    s128=128,
    s256=256,
    s512=512
}