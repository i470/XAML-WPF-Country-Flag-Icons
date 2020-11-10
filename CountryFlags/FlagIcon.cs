using System;
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
        
        public FlagIcon()
        {
           
            this.DefaultStyleKey = typeof(FlagIcon);
        }

        static FlagIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlagIcon), new FrameworkPropertyMetadata(typeof(FlagIcon)));
        }

        private const string FlagImagePartName = "PART_DISPLAY_COUNTRY_FLAG";

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
                CountryDataFactory.DataIndex.Value?.TryGetValue(Country, out data);
                this.Data = data;

               
                
                if(FlagImage!=null)
                {
                    FlagImage.Source = CreateImageSource(Country);
                   
                }
              
            }
            else
            {
                this.Data = null;
            }
        }

    }
}
