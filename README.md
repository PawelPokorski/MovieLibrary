# MovieLibrary

Projekt MovieLibrary to aplikacja, która umożliwia zarządzanie kolekcją filmów. Użytkownicy mogą dodawać, edytować, usuwać i przeglądać informacje o filmach, takie jak tytuł, reżyser, rok wydania i gatunek. Dodatkowo, użytkownicy mogą oceniać i recenzować filmy, aktorów czy reżyserów.

**Projekt jest w trakcie tworzenia. Niektóre elementy aplikacji nie są jeszcze zaimplementowane lub zintegrowane.**

## Cel projektu

Ten projekt jest realizowany w celach edukacyjnych i stanowi świetną bazę do dalszego rozwoju. Możesz go wykorzystać do nauki technologii .NET Core, Entity Framework Core, AutoMapper, FluentValidation i MediatR. Zachęcamy do eksperymentowania, dodawania nowych funkcji i dostosowywania projektu do własnych potrzeb.

**Projekt jest tworzony w oparciu o architekturę Clean Architecture, co pozwala na utrzymanie wysokiej jakości kodu i łatwiejsze rozwijanie aplikacji w przyszłości.**

## Funkcje

* Dodawanie nowych filmów do biblioteki.
* Edycja istniejących informacji o filmach.
* Usuwanie filmów z biblioteki.
* Przeglądanie listy filmów.
* Filtrowanie filmów według różnych kryteriów (np. gatunek, rok wydania).
* Wyszukiwanie filmów po tytule lub reżyserze.
* Sortowanie filmów według różnych kryteriów (np. tytuł, rok wydania).
* Informacje o aktorach grających w filmach
* Oceny aktorów według ich ról
* Dodawanie ocen i recenzji do filmów i aktorów
* i wiele innych...

## Technologie

* .NET Core 9.0
* SQL Server

## Biblioteki

* EntityFrameworkCore
* AutoMapper
* FluentValidation
* MediatR

## Instalacja

1.  Sklonuj repozytorium:

    ```bash
    git clone [https://github.com/PawelPokorski/MovieLibrary.git](https://github.com/PawelPokorski/MovieLibrary.git)
    ```

2.  Upewnij się, że masz zainstalowany .NET Core 9.0 SDK.
3.  Skonfiguruj połączenie z bazą danych SQL Server w pliku `appsettings.json`.
4.  Zainstaluj zależności:

    ```bash
    dotnet restore
    ```

5.  Zaktualizuj bazę danych za pomocą Entity Framework Core Migrations:

    ```bash
    dotnet
    ```

## Aktualny branch

Aktualnie rozwijane funkcjonalności i testy znajdują się w branchu `[layers-expand]`.
