# Settimana 01A — ASP.NET Core: Ciclo HTTP, Middleware, Hosting & DI

## 🎯 Obiettivi della settimana
- Comprendere la pipeline HTTP di ASP.NET Core
- Scrivere un middleware custom
- Configurare e avviare un'app ASP.NET da zero con `IHost` e `WebApplication`
- Registrare servizi con Dependency Injection
- Leggere configurazioni e loggare eventi a startup

## 📚 Risorse seguite
- [ ] Video: ASP.NET Core Middleware Pipeline – Nick Chapsas ✅/❌
- [ ] Video: Create Custom Middleware – Tim Corey ✅/❌
- [ ] Video: ASP.NET Core Startup Explained – Raw Coding ✅/❌
- [ ] Video: Dependency Injection in ASP.NET Core – IAmTimCorey ✅/❌
- [ ] Lettura: MS Docs Middleware ✅/❌
- [ ] Lettura: Docs WebApplicationBuilder & DI ✅/❌

## 🛠️ Esercizi svolti
| Esercizio                                | Stato | Note |
|------------------------------------------|--------|------|
| Ciclo HTTP disegnato                     | ✅     | Diagramma da browser a response |
| Middleware custom                        | ✅     | Logging + tempo esecuzione visibili in log |
| App ASP.NET senza template               | ✅     | Uso di `IHostBuilder` + `ConfigureServices` |
| DI, IConfiguration, Logging attivati     | ✅     | Lettura config da JSON, log strutturato |

## 🧩 Pattern e Concetti Applicati

- [ ] `Use`, `Run`, `Map` nella pipeline middleware
- [ ] `IServiceCollection` e `IConfiguration` nel Program.cs
- [ ] Comprensione chiara di `WebApplicationBuilder`, `Build`, `Run`
- [ ] Concetto di short-circuit middleware e chained execution

## 📈 KPI raggiunti
- [ ] Middleware attivo e tracciabile in console
- [ ] Servizi registrati correttamente e funzionanti
- [ ] Configurazioni lette e log di startup presenti
- [ ] App avviata senza usare `dotnet new`

## 🧠 Note tecniche
- Cosa mi ha fatto più fatica capire?
- Quale comportamento del ciclo HTTP ho dovuto testare più volte?
- Cosa ho scoperto sul logging che non conoscevo?
