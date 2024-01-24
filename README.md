## EFCoreSamples ## 
Dieses Repository enthält einige Beispiele für die Verwendung von Entity Framework Core (EF Core), einem beliebten Framework für die Datenzugriffsschicht in .NET-Anwendungen.

## Was ist EF Core? ## 
EF Core ist ein leichtgewichtiges, erweiterbares, quelloffenes und plattformübergreifendes Framework für die Modellierung, Abfrage und Aktualisierung von Daten in .NET. 
Es ermöglicht es Ihnen, mit Datenbanken zu arbeiten, indem Sie Objekte verwenden, die Ihre Datenbanktabellen und -spalten widerspiegeln, ohne dass Sie SQL schreiben müssen (Code First). 
EF Core unterstützt viele verschiedene Datenbankanbieter, wie z.B. SQL Server, SQLite, PostgreSQL, MySQL, Oracle usw.

## Was sind die Vorteile von EF Core? ## 
EF Core bietet viele Vorteile für die Entwicklung von Datenzugriffsschichten, wie z.B.:Produktivität: Sie können schnell und einfach Datenmodelle erstellen, indem Sie entweder Code First oder Database First-Ansätze (via Scaffolding) verwenden. 
EF Core generiert automatisch die notwendigen Datenbankobjekte für Sie, und Sie können sie mit Migrations verwalten und aktualisieren.
- Leistung: EF Core ist für hohe Leistung und Skalierbarkeit optimiert. Es verwendet effiziente Abfragegenerierung, Caching, Batch-Updates, asynchrone Operationen und vieles mehr, um die Datenzugriffsleistung zu verbessern.
- Flexibilität: EF Core ist sehr anpassbar und erweiterbar. Sie können Ihre eigenen Konventionen, Konfigurationen, Interceptors, Provider, Funktionen usw. definieren, um das Verhalten von EF Core zu ändern oder zu erweitern.
- Portabilität: EF Core ist plattformübergreifend und kann auf verschiedenen Betriebssystemen wie Windows, Linux, MacOS usw. ausgeführt werden. 
Sie können auch EF Core in verschiedenen Arten von .NET-Anwendungen verwenden, wie z.B. Konsolen-, Web-, Desktop-, Mobile-, Blazor-Anwendungen usw.

## Was sind die Inhalte dieses Repositories? ##
Dieses Repository zeigt, wie man verschiedene Funktionen von EF Core nutzt, wie z.B.:
Datenbankverbindungen und -transaktionenAbfragen und Aktualisieren von Daten
Verwenden von Migrations- und Seeding-Daten
Arbeiten mit komplexen Typen und Beziehungen
Anwenden von Konventionen und Konfigurationen
Implementieren von Repository- und Unit-of-Work-Mustern
Jedes Beispiel ist in einem separaten Ordner organisiert, der eine .NET Core-Konsolenanwendung enthält, die das EF Core-Szenario demonstriert. 


Sie können auch die Datenbanken für jedes Beispiel erstellen oder aktualisieren, indem Sie die folgenden Befehle ausführen.
Vorausgesetzt Sie haben eine Database-Provider lokal oder extern gehostet:

`dotnet ef migrations add InitialCreate --context [DbContextClassName] --verbose --project .\[ProjektName].csproj`

`dotnet ef database update --project .\[ProjektName].csproj --context [DbContextClassName]`
