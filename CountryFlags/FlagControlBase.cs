using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

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