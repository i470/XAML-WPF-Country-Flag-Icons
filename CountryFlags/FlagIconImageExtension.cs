using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CountryFlags
{
    [MarkupExtensionReturnType(typeof(ImageSource))]
    public class FlagIconImageExtension: BaseImageExtension
    {
        public FlagIconImageExtension()
        {
        }

        public FlagIconImageExtension(Enum country)
        {
            this.Country = country;
        }

        [ConstructorArgument("country")]
        public Enum Country { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CreateImageSource(this.Country);
        }

        protected override string GetPathData(Enum country)
        {
            string data = null;
            CountryDataFactory.DataIndex.Value?.TryGetValue(country, out data);
            return data;
        }
    }

    [MarkupExtensionReturnType(typeof(ImageSource))]
    public abstract class BaseImageExtension : MarkupExtension
    {
        protected abstract string GetPathData(Enum country);

        protected virtual DrawingGroup GetDrawingGroup(object country,  string path)
        {
            var baseUri = $"pack://application:,,,/CountryFlags;component/img/{path}";

            var ImageDrawing = new ImageDrawing
            {
                Rect = new Rect(0, 0, 102, 60),
                ImageSource = new BitmapImage(new Uri(baseUri, UriKind.Absolute))
            };

            var drawingGroup = new DrawingGroup
            {
                Children = { ImageDrawing },
               
            };

            return drawingGroup;
        }

        protected ImageSource CreateImageSource(Enum country)
        {
            string path = this.GetPathData(country);

            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var drawingImage = new DrawingImage(GetDrawingGroup(country, path));
            drawingImage.Freeze();

            return drawingImage;
        }

    }
}

