using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace CountryFlags
{
    [MarkupExtensionReturnType(typeof(FlagBase))]
    public class FlagExtension : BaseFlagExtension
    {
        public FlagExtension(Enum country)
        {
            this.Country = country;
        }

        public Enum Country { get; set; }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Country is CountryEnum)
            {
                return this.GetFlagIcon<FlagIcon, CountryEnum>((CountryEnum)this.Country);
            }

            return null;
        }


    }

    public static class FlagIconExtensionHelper
    {
        public static FlagControlBase GetFlagIcon<TStyle, TCountry>(this FlagExtension flagExtension, TCountry country) where TStyle : FlagControlBase, new()
        {
            var flagIcon = new TStyle();
            flagIcon.SetCountry(country);

            if (flagExtension.IsFieldChanged(BaseFlagExtension.ChangedFieldFlags.Width))
            {
                flagIcon.Width = flagExtension.Width;
            }

            if (flagExtension.IsFieldChanged(BaseFlagExtension.ChangedFieldFlags.Height))
            {
                flagIcon.Height = flagExtension.Height;
            }

            return flagIcon;
        }

    }


    public abstract class BaseFlagExtension : MarkupExtension
    {
        private double _width = 51d;
        public double Width
        {
            get => _width;
            set
            {
                if (Equals(_width, value))
                {
                    return;
                }

                _width = value;
                WriteFieldChangedFlag(ChangedFieldFlags.Width, true);
            }
        }

        private double _height = 30d;
        public double Height
        {
            get => _height;
            set
            {
                if (Equals(_height, value))
                {
                    return;
                }

                _height = value;
                WriteFieldChangedFlag(ChangedFieldFlags.Height, true);
            }
        }

        internal ChangedFieldFlags changedField; // Cache changed field bits

        internal bool IsFieldChanged(ChangedFieldFlags reqFlag)
        {
            return (changedField & reqFlag) != 0;
        }

        internal void WriteFieldChangedFlag(ChangedFieldFlags reqFlag, bool set)
        {
            if (set)
            {
                changedField |= reqFlag;
            }
            else
            {
                changedField &= (~reqFlag);
            }
        }

        [Flags]
        internal enum ChangedFieldFlags : ushort
        {
            Width = 0x0001,
            Height = 0x0002,
            Normal = 0x0004,
            Square = 0x0008,
            Circle = 0x0010,
            Pin = 0x0020
        }
    }

}
