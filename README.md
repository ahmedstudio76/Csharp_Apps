# Csharp Apps

A curated collection of modern C# applications — clean architecture, polished UI, production-minded defaults.

## Apps

| App | Stack | Description |
|-----|--------|-------------|
| **PulseDesk** | Blazor Web App (.NET 8) | Personal command center: tasks, focus timer, notes, and a live dashboard with a glassmorphism UI. |

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 17.8+, Rider, or VS Code + C# Dev Kit

## Run PulseDesk

```bash
cd src/PulseDesk.Web
dotnet restore
dotnet run
```

Open `https://localhost:5188`.

## Solution layout

```
Csharp_Apps/
  CsharpApps.sln
  Directory.Build.props
  src/
    PulseDesk.Web/          # Blazor interactive server UI
    PulseDesk.Core/         # Domain models & services
```

## Principles

- Nullable reference types on
- Small, focused services — no god classes
- UI first: spacing, type, motion, dark theme by default
- Each app is independently runnable

More apps land here as we ship them.
