# WPF XAML Country Flag Icons 197 Flags
Projects has 197 Country Flag Icons 

WPF .NET Core 3.1
Flag icons are generated from PNG Images size **204 x 120**,
demo size **51x30**

Country list populated in **CountryEnum.cs** 

![Image of WPF XAML Flag Icons](https://github.com/i470/WPF-Country-Flag-Icons/blob/master/wpf_country_icons.PNG)

![Image of WPF XAML Flag Icons with Pin , Square, Round, Circle Shapes](https://github.com/i470/WPF-Country-Flag-Icons/blob/master/wpf-xaml-world-country-flag-icons-square-rounded-rectangle-pin-fancy-pin.png)

## USAGE
WPF Flag icons and images located in **CountryFlags** Project.

Sample usage is in **CountryFlagsPreview** 
	
```xaml
<!-- add to namespace -->

<Window x:Class="CountryFlagsPreview.MainWindow"
        xmlns:cf="clr-namespace:CountryFlags;assembly=CountryFlags" >

<!-- FlagIcon object with country predefined in the list renders the flag -->

<cf:FlagIcon Country="Afghanistan" Size="s32" />
<cf:FlagIcon Country="Albania"  />
<cf:FlagIcon Country="Algeria"  />
<cf:FlagIcon Country="Andorra"  />
<cf:FlagIcon Country="Angola"  />


<cf:FlagIconCircle Country="Argentina" Size="s64"  Shape="RoundedSquare" />
<cf:FlagIconCircle Country="United_Kingdom" Size="s128" Shape="RoundedRect"  />

<cf:FlagIconPin Country="France" Size="s128" />
<cf:FlagIconPin2 Country="Canada" Size="s48" />

<!-- Default icon size is set to 16px , can be changed by setting property Size="s32" -->

<!-- Sizes : s16,s24,s32,s64,s128,s256,s512 -->

```
![Image of WPF XAML Flag Icons](https://github.com/i470/WPF-Country-Flag-Icons/blob/master/wpf-xaml-world-country-flags-sizes.png)

- [ ] replace png images with svg
- [x] add rounded corner style
- [x] add square style
- [x] add round style
- [ ] add Label Card (flag - text)
- [ ] render image for non centered flags diffrently, so that they look nice in square or circle shape
