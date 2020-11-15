using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CountryFlags
{
    [TemplatePart(Name = "PART_COUNTRY_FLAG_IMAGE", Type = typeof(ImageBrush))]
    [TemplatePart(Name = "PART_ICON_SHAPE", Type = typeof(Path))]
    [TemplatePart(Name = "PART_ICON_PANEL", Type = typeof(Border))]
    public class FlagIconCircle : FlagControlBase
    {
        private const string ImagePartName = "PART_COUNTRY_FLAG_IMAGE";
        private const string ShapePartName = "PART_ICON_SHAPE";
        private const string PanelPartName = "PART_ICON_PANEL";

        public FlagIconCircle()
        {
          
            this.DefaultStyleKey = typeof(FlagIconCircle);
            Size = IconSize.s24;
            this.UpdateData();
        }

        static FlagIconCircle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlagIconCircle), new FrameworkPropertyMetadata(typeof(FlagIconCircle)));
            
        }

        private ImageBrush _iconImage;
        public ImageBrush IconImage
        {
            get => _iconImage;
            set => _iconImage = value;
        }

        private Path _iconShape;
        public Path IconShapePath
        {
            get => _iconShape;
            set => _iconShape = value;
        }


        private Border _iconPanel;
        public Border IconPanel
        {
            get => _iconPanel;
            set => _iconPanel = value;
        }

        public override void OnApplyTemplate()
        {
            IconImage = GetTemplateChild(ImagePartName) as ImageBrush;
            IconShapePath = GetTemplateChild(ShapePartName) as Path;
            IconPanel = GetTemplateChild(PanelPartName) as Border;

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
                    IconShapePath.Data = Geometry.Parse(IconShapeCollection[Shape.ToString()]);

                    if(Shape == IconShapes.Rect || Shape == IconShapes.RoundedRect)
                    {
                        IconPanel.Height = IconPanel.Width/1.3;
                    }
                    else
                    {
                        IconPanel.Height = IconPanel.Width;
                    }

                    


                    IconImage.ImageSource= CreateImageSource(Country);
                    UpdateLayout();
                }

            }
            else
            {
                this.Data = null;
            }
        }

        private Dictionary<string, string> IconShapeCollection= new Dictionary<string, string>
            {
                { "Circle", "M 190 103.21429 A 87.5 87.5 0 1 1  15,103.21429 A 87.5 87.5 0 1 1  190 103.21429 z" },
                { "Square", "M0.5,0.5 L49.5,0.5 L49.5,49.5 L0.5,49.5 z" },
                { "RoundedSquare","M0.5,3.5 C0.5,1.8431458 1.8431458,0.5 3.5,0.5 L12.5,0.5 C14.156854,0.5 15.5,1.8431458 15.5,3.5 L15.5,12.5 C15.5,14.156854 14.156854,15.5 12.5,15.5 L3.5,15.5 C1.8431458,15.5 0.5,14.156854 0.5,12.5 z" },
                {"Rect","M0.5,0.5 L99.5,0.5 L99.5,49.5 L0.5,49.5 z" },
                {"RoundedRect","M0.5,5.5 C0.5,2.7385763 2.7385763,0.5 5.5,0.5 L84.5,0.5 C87.261424,0.5 89.5,2.7385763 89.5,5.5 L89.5,47.5 C89.5,50.261424 87.261424,52.5 84.5,52.5 L5.5,52.5 C2.7385763,52.5 0.5,50.261424 0.5,47.5 z" }
            };


        protected static readonly DependencyProperty ShapeProperty
 = DependencyProperty.Register(nameof(Shape), typeof(IconShapes), typeof(FlagIconCircle), new PropertyMetadata(default(IconShapes), ShapeChangedCallback));

        private static void ShapeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                ((FlagIconCircle)d).UpdateData();
            }
        }


        public IconShapes Shape
        {
            get { return (IconShapes)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }


        public enum IconShapes
        {
            [Description("Circle")]Circle,
            [Description("Square")] Square,
            [Description("Rect")] Rect,
            [Description("RoundedSquare")] RoundedSquare,
            [Description("RoundedRect")] RoundedRect,
            [Description("Pin")] Pin,
            [Description("FancyPin")] FancyPin
        }
    }



}
