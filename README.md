# CatFactsApp

A simple .NET console application that retrieves random cat facts from the [Cat Fact API](https://catfact.ninja/fact) and saves them to a local text file.

## Features

* Retrieves a random cat fact from the Cat Fact API.
* Displays the received fact and its length in the console.
* Appends each retrieved fact to a local `.txt` file.
* Uses dependency injection to manage application services.
* Uses interfaces to separate abstractions from implementations.
* Uses `appsettings.json` for application configuration.

## Technologies

* .NET 10
* C#
* `HttpClient`
* `System.Text.Json`
* Microsoft.Extensions.DependencyInjection
* Microsoft.Extensions.Configuration

## Configuration

Application settings are stored in `appsettings.json`:

```json
{
  "CatFactApi": {
    "BaseUrl": "https://catfact.ninja/fact"
  },
  "File": {
    "Path": "catfacts.txt"
  }
}
```

The API URL and output file path can be changed without modifying the application code.

## Requirements

* .NET 10 SDK

## Running the application

Clone the repository and navigate to the project directory:

```bash
cd CatFactsApp
```

Run the application:

```bash
dotnet run
```

The application retrieves a cat fact, displays it in the console and appends it to the configured text file.

## Error Handling

If the application cannot retrieve a cat fact because of a network error or an unsuccessful API response, it displays an appropriate message instead of attempting to save an invalid result.

## Dependency Injection

The application uses `Microsoft.Extensions.DependencyInjection` to register and resolve its services.

`ICatFactService` and `IFileService` are registered as abstractions, while their concrete implementations are injected where needed.

## Version Control

The project is maintained using Git and hosted on GitHub.