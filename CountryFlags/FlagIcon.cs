using System;
using System.Windows;
using System.Windows.Controls;

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

    }
}
