# WPF Country Flag Icons
Projects has 197 Country Flag Icons 

WPF .NET Core 3.1
Flag icons are generated from PNG Images size **204px x 120px**. 
Country list populated in **CountryEnum.cs** and 

![Image of WPF Flag Icons](https://github.com/i470/WPF-Country-Flag-Icons/blob/master/wpf_country_icons.PNG)

## USAGE
WPF Flag icons and images located in **CountryFlags** Project.

Sample usage is in **CountryFlagsPreview** 
	
```xaml
<!-- add to namespace -->

<Window x:Class="CountryFlagsPreview.MainWindow"
        xmlns:cf="clr-namespace:CountryFlags;assembly=CountryFlags" >

<!-- FlagIcon object with country predefined in the list renders the flag -->

<cf:FlagIcon Country="Afghanistan"  />
<cf:FlagIcon Country="Albania"  />
<cf:FlagIcon Country="Algeria"  />
<cf:FlagIcon Country="Andorra"  />
<cf:FlagIcon Country="Angola"  />

<!-- to change icon size go to FlagIcon control style located in the  CountryFlags\Themes\FlagIcon.xaml -->
<!-- it is enough to change only width or height -->

<Style x:Key="CountryFlags.Styles.CountryFlag" TargetType="{x:Type local:FlagIcon}">
          <Setter Property="Width" Value="51" />
   <!--<Setter Property="Height" Value="30" />-->
```

- [ ] replace png images with svg
- [ ] add rounded corner style
- [ ] add square style
- [ ] add round style
- [ ] add Label Card (flag - text)
