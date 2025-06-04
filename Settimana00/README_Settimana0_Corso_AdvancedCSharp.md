# Settimana 0 – Corso Intensivo: Advanced C# Programming

## 🎯 Obiettivo della settimana

Completare il corso “[Advanced C# Programming by Gavin Lon](https://www.youtube.com/watch?v=YT8s-90oDC0)” eseguendo ogni parte con codice reale e comprensione approfondita.

## ⭐️ Struttura del corso e tracking

| Parte | Argomento                                 | Stato | Note |
| ----- | ----------------------------------------- | ----- | ---- |
| 1     | Introduzione e panoramica                 | ✅    | Avuto dubbi su delegato Action, ci ho perso tempo |
| 3     | .NET 5, .NET Core, .NET 6, .NET 7         | ✅/❌ |      |
| 4-8   | Delegates e Async Method Calls            | ✅/❌ |      |
| 9-12  | Events, Observer Pattern                  | ✅/❌ |      |
| 13-16 | Generics + Factory Design Pattern         | ✅/❌ |      |
| 17-20 | Async/Await + Best Practices              | ✅/❌ |      |
| 21-24 | LINQ: Introduzione, Queries, Operators    | ✅/❌ |      |
| 25    | C# Attributes                             | ✅/❌ |      |
| 26    | Reflection                                | ✅/❌ |      |
| 27-29 | .NET Framework, .NET Core, .NET 6, .NET 7 | ✅/❌ |      |

## 🛠️ Progetti creati

- Introduction project (HrDepartment Management) ✅
- Delegates examples
- Events + UWP or simulation handlers
- LINQ queries + custom operators
- Async/Await best practices demo
- Reflection tool
- Factory pattern generic demo

## 🧠 Annotazioni tecniche

- Concetti compresi meglio grazie al codice
- Errori/problemi affrontati
- Best practice da portare nella roadmap

# 1
- L'operatore as funziona solo con reference types e con value types nullable (es. int?, decimal?, float?, ecc.) perché può restituire null in caso di cast fallito, e solo questi tipi possono contenerlo. I value types non-nullable (come int, double, decimal) non sono compatibili con as.

ESEMPIO:

decimal? numberDecimal = 1; 
return numberDecimal as decimal?; ✅ valido

double numberDecimal = 123; 
return numberDecimal as int; ❌ errore di compilazione

- Utilizzare FactoryPattern quando possibile. Utilizzare i vincoli per specificare che TDestination può essere di tipo TSource (esempio: TSource = IEmployee e TDestination = Teacher; Teacher è IEmployee)

ESEMPIO:

    public static class FactoryPattern<TSource, TDestination> where TDestination : class, TSource, new() 
    {
        public static TSource GetInstance()
        {
            TSource obj = null;
            obj = new TDestination();
            return obj;
        }
    }

- Il delegato Action<TSource, out TDest> è un built-in .NET delegate che accetta un tipo TSource come parametro e accetta e restituisce TDest:
 
ESEMPIO:

    public TDest MyFunction(Action<TSource, TDest> action) 
    {   
        TDest dest = null; 
        return dest; 
    }


## 🧠 Riflessioni personali

# 1
04/06/2025: Stasera mi sono presentato anche se ero totalmente demoralizzato e paralizzato dalla paura di iniziare, di concretizzare, di fare. A volte sembra tutto inutile, ma a volte basta davvero soltanto iniziare.
E stasera ho iniziato, e 5 minuti sono diventati 1h30, dove non avrò realizzato il progetto della vita, ma ho posto delle solide ed ordinate basi per procedere a tutta dritta. Forza! Ce la farò.