using System.Windows.Controls;

namespace CountryFlags
{

    public abstract class FlagBase : Control
    {
        protected internal abstract void SetSize<IconSize>(IconSize size);
        protected internal abstract void SetCountry<TCountry>(TCountry country);
        protected abstract void UpdateData();
    }
}
