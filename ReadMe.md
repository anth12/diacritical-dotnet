# DotDiacritic

Replace Diacritic characters with ASCII equivalents.

## Getting Started

Install the [nuget](https://www.nuget.org/packages/DotDiacritic/):
    PM> Install-Package DotDiacritic
	> dotnet add package DotDiacritic


	"Buen día".RemoveDiacritics(); // Buen dia
    "Cześć".RemoveDiacritics(); // Czesc

	https://github.com/diacritics/database/blob/dist/v1/diacritics.json