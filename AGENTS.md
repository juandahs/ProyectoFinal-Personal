# Repository Guidelines

## Project Structure & Module Organization
`ProyectoFinal.sln` groups four .NET 8 projects. `ProyectoFinal.VetSite.MVC/` contains the ASP.NET Core MVC app: controllers, Razor views, view models, static assets in `wwwroot/`, and SQL/bootstrap files in `AppData/`. `ProyectoFinal.Servidor/` holds application services, `ProyectoFinal.Repositorio/` contains EF Core data access plus `Migrations/`, and `ProyectoFinal.Entidades/` defines shared domain entities. Supporting documents live in `docs/`.

## Build, Test, and Development Commands
Run commands from the repository root.

- `dotnet restore ProyectoFinal.sln` restores NuGet packages.
- `dotnet build ProyectoFinal.sln` builds all projects and validates references.
- `dotnet run --project ProyectoFinal.VetSite.MVC` starts the web app locally on the launch profile ports in `Properties/launchSettings.json` (`http://localhost:5224`, `https://localhost:7006`).
- `dotnet ef database update --project ProyectoFinal.Repositorio --startup-project ProyectoFinal.VetSite.MVC` applies EF Core migrations using the MVC app as startup.

## Coding Style & Naming Conventions
Use 4-space indentation and standard C#/.NET naming: `PascalCase` for types, public members, controllers, and services; `camelCase` for locals and parameters. Keep one class per file, matching the filename, for example `PacienteServicio.cs`. Razor partials use a leading underscore, such as `Views/Pacientes/_Formulario.cshtml`. Prefer nullable-aware code and avoid hard-coded configuration values outside `appsettings*.json`.

## Testing Guidelines
There is currently no dedicated test project in this repository. Before merging data or UI changes, at minimum run `dotnet build` and smoke-test the affected flows in the MVC app. When adding tests, create a sibling test project under the solution, use clear names like `PacienteServicioTests`, and name test methods after behavior, for example `CrearPaciente_DeberiaGuardarDatosValidos`.

## Commit & Pull Request Guidelines
Recent history uses short Spanish summaries such as `Limpieza de código` and `Se agregan diagramas al proyecto`. Follow that pattern: one imperative, focused subject line describing the change. Keep commits scoped to a single concern. Pull requests should include a short description, impacted modules, manual verification steps, linked issue or task when available, and screenshots for Razor/CSS changes.

## Security & Configuration Tips
Do not commit real credentials or mail passwords in `README.md`, `appsettings*.json`, or SQL scripts. Keep local secrets in user secrets or environment variables, and treat `AppData/*.sql` as seed/setup assets that must be reviewed before execution.
