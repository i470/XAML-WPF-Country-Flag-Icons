using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CountryFlags
{
    [TemplatePart(Name = "PART_COUNTRY_FLAG_IMAGE", Type = typeof(ImageBrush))]
    [TemplatePart(Name = "PART_ICON_PANEL", Type = typeof(Viewbox))]
    public class FlagIconPin : FlagControlBase
    {
        private const string ShapePartName = "PART_ICON_SHAPE";
        private const string PanelPartName = "PART_ICON_PANEL";
        private const string ImagePartName = "PART_COUNTRY_FLAG_IMAGE";

        public FlagIconPin()
        {

            this.DefaultStyleKey = typeof(FlagIconPin);

            this.ApplyTemplate();
        }

        static FlagIconPin()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlagIconPin), new FrameworkPropertyMetadata(typeof(FlagIconPin)));

        }

        private Viewbox _iconPanel;
        public Viewbox IconPanel
        {
            get => _iconPanel;
            set => _iconPanel = value;
        }

        private ImageBrush _iconImage;
        public ImageBrush IconImage
        {
            get => _iconImage;
            set => _iconImage = value;
        }

        public override void OnApplyTemplate()
        {
            IconImage = GetTemplateChild(ImagePartName) as ImageBrush;
            IconPanel = GetTemplateChild(PanelPartName) as Viewbox;

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



                if (IconImage != null)
                {

                    IconPanel.Width = (Double)Size;
                    IconPanel.Height = IconPanel.Width * 1.4;
                    

                    IconImage.ImageSource = CreateImageSource(Country);
                    UpdateLayout();
                }

            }
            else
            {
                this.Data = null;
            }
        }
    }
}
