## Diacritical.Net

.net Standard library to replace Diacritic characters with ASCII equivalents.

<img src="https://raw.githubusercontent.com/anth12/diacritical-dotnet/master/assets/diacritical.png" alt="Diacritical logo" width="256px" align="right">

[![Build Status](https://anthonyhalliday.visualstudio.com/Diacritical/_apis/build/status/anth12.diacritical-dotnet?branchName=master)](https://anthonyhalliday.visualstudio.com/Diacritical/_build/latest?definitionId=1&branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Diacritical.Net)](https://www.nuget.org/packages/Diacritical.Net)


## Getting Started

Install the ([nuget][nuget]):

    PM> Install-Package Diacritical.Net

	> dotnet add package Diacritical.Net

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


[nuget]: https://www.nuget.org/packages/Diacritical.Net/
[diacritics database]: https://github.com/diacritics/database
[default provider]: https://github.com/anth12/diacritical-dotnet/blob/master/Diacritical/DefaultDiacriticProvider.cs
