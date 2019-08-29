# Diacritical dotnet

Replace Diacritic characters with ASCII equivalents.

## Getting Started

Install the [nuget](https://www.nuget.org/packages/Diacritical.Net/):

    PM> Install-Package Diacritical.Net

	> dotnet add package Diacritical.Net


	"Buen día".RemoveDiacritics(); // Buen dia
    "Cześć".RemoveDiacritics(); // Czesc

	https://github.com/diacritics/database/blob/dist/v1/diacritics.json