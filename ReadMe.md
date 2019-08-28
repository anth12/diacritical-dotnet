# Diacritical.Net

.net Standard library to replace Diacritic characters with ASCII equivalents.

![Diacritical logo][logo]

## Getting Started

Install the ([nuget][nuget]):

    PM> Install-Package DotDiacritic
	> dotnet add package DotDiacritic

Usage

```c#
"Buen día".RemoveDiacritics();      // Buen dia
"Witaj świecie".RemoveDiacritics(); // Witaj swiecie

"Olá Mundo".HasDiacritics();   // true
"Hello World".HasDiacritics(); // false
```

Sample mappings
- Á,Ă,Ắ,Ặ,Ằ,Ẳ,Ẵ,Ǎ,Â... -> **A**
- á,ă,ắ,ặ,ằ,ẳ,ẵ,ǎ,â... -> **a**
- Æ,Ǽ,Ǣ -> **AE**
- é,ĕ,ě,ȩ,ḝ,ê,ế,ệ,ề... -> **e**
- Ó,Ŏ,Ǒ,Ô,Ố,Ộ,Ồ,Ổ,Ỗ... -> **O**
- Ś,Ṥ,Š,Ṧ,Ş,Ŝ,Ș,Ṡ,Ṣ... -> **S**
- ...

A full list of supported mappings can be found [here][default provider].

Custom mappings can easily be added with a custom `IDiacriticProvider` implementation and registered with:

```c#
DiacriticMap.AddProvider(new MyCustomDiacriticProvider());
```

## Credits
- Logo eraser icon by Terrence Kevin Oleary (noun project)
- Diacritic mappings from [diacritics/database][diacritics database]


[logo]: https://raw.githubusercontent.com/anth12/diacritical-dotnet/master/assets/diacritical.png

[nuget]: https://www.nuget.org/packages/DotDiacritic/
[diacritics database]: https://github.com/diacritics/database
[default provider]: https://github.com/anth12/diacritical-dotnet/blob/master/DotDiacritic/DefaultDiacriticProvider.cs