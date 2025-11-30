# BeFit – aplikacja Blazor do śledzenia treningów

Aplikacja webowa napisana w **Blazor Web App (.NET 8)**, służąca do rejestrowania sesji treningowych, ćwiczeń oraz podglądu prostych statystyk użytkownika.  
Projekt zaliczeniowy z zakresu **ASP.NET / Entity Framework / Identity**.

## Funkcjonalności

### Użytkownicy i logowanie

- Rejestracja i logowanie oparte o **ASP.NET Core Identity** (`ApplicationUser`).
- Autoryzacja przez atrybuty `[Authorize]` oraz komponenty `AuthorizeView`.
- Każdy użytkownik widzi **tylko swoje dane** (sesje, ćwiczenia, statystyki).

### Typy ćwiczeń (`ExerciseType`)

- Model z polami: `Id`, `Name`, `Description` + walidacja (`[Required]`, `[MaxLength]`, `[Display]`).
- Strona **/exercise-types**:
  - lista wszystkich typów ćwiczeń,
  - **CRUD** (dodawanie, edycja, usuwanie) z użyciem `EditForm` i walidacji danych.
- Docelowo: operacje modyfikujące ograniczone do roli **Admin**.

### Sesje treningowe (`TrainingSession`)

- Model: `Id`, `UserId`, `StartTime`, `EndTime` + walidacja i etykiety po polsku.
- Strona **/training-sessions**:
  - wyświetla **tylko sesje zalogowanego użytkownika**,
  - możliwość dodawania / edycji / usuwania sesji,
  - `UserId` przypisywane **automatycznie** na podstawie aktualnie zalogowanego użytkownika (nie ma pola w formularzu),
  - pełna kontrola dostępu – użytkownik nie może edytować/usunąć cudzej sesji.

### Wpisy ćwiczeń w sesji (`ExerciseEntry`)

- Model: `Id`, `UserId`, `ExerciseTypeId`, `TrainingSessionId`, `Load`, `Sets`, `Reps` + walidacja (`[Range]`, `[Required]`, `[Display]`).
- Strona **/exercise-entries**:
  - lista wpisów bieżącego użytkownika,
  - wybór **sesji treningowej** oraz **typu ćwiczenia** z list rozwijanych (wyświetlane nazwy, nie id),
  - CRUD wpisów ćwiczeń z pilnowaniem `UserId` i dostępu tylko do własnych danych.

### Statystyki

- Strona **/stats** (docelowo):
  - statystyki z **ostatnich 4 tygodni**:
    - liczba wykonanych sesji,
    - łączna liczba powtórzeń,
    - maksymalne i średnie obciążenie,
  - dane filtrowane względem aktualnie zalogowanego użytkownika,
  - osobny model DTO na potrzeby wyświetlania (np. `Stat`).

### Role i panel administratora

- Konfiguracja ról w **Identity** (`AddRoles<IdentityRole>()`).
- Możliwość nadania roli **Admin** wybranemu użytkownikowi (np. strona `/add-admin`).
- Docelowo:
  - tylko **Admin** może tworzyć/edytować/usuwać **typy ćwiczeń**,
  - zwykli użytkownicy mają dostęp tylko do swoich danych treningowych.

---

## Technologie

- **.NET 8** / **ASP.NET Core**
- **Blazor Web App** (rendering: `InteractiveServer`)
- **Entity Framework Core** + **SQLite**
- **ASP.NET Core Identity** (logowanie, role)
- Bootstrap (stylowanie, layout)

---

## Uruchomienie lokalne

### 1. Wymagania

- Zainstalowany **.NET 8 SDK**
- (Opcjonalnie) narzędzia EF Core CLI:

```bash
dotnet tool install --global dotnet-ef
