using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CountryFlags
{

    [TemplatePart(Name = "PART_DISPLAY_COUNTRY_FLAG", Type = typeof(Image))]
    public class FlagIcon : FlagControlBase
    {
        private const string FlagImagePartName = "PART_DISPLAY_COUNTRY_FLAG";

        public FlagIcon()
        {
           
            this.DefaultStyleKey = typeof(FlagIcon);
            Size = IconSize.s24;
        }

        static FlagIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlagIcon), new FrameworkPropertyMetadata(typeof(FlagIcon)));
           
        }

        

        private Image _flagImage;
        public Image FlagImage
        {
            get => _flagImage;
            set => _flagImage = value;
        }

        public override void OnApplyTemplate()
        {
            FlagImage = GetTemplateChild(FlagImagePartName) as Image;
            base.OnApplyTemplate();
            this.UpdateData();
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

        protected override void UpdateData()
        {
            if (Country != default(CountryEnum))
            {
                string data = null;
                CountryDataFactory.CountryIndex.Value?.TryGetValue(Country, out data);
                this.Data = data;

               
                
                if(FlagImage!=null)
                {
                    FlagImage.Source = CreateImageSource(Country);
                    FlagImage.Width = (Int16)Size;
                }
              
            }
            else
            {
                this.Data = null;
            }
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
