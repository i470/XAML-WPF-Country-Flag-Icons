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

    }


}