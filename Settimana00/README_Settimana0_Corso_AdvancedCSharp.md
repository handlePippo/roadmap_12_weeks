# Settimana 0 – Corso Intensivo: Advanced C# Programming

## 🎯 Obiettivo della settimana

Completare il corso “[Advanced C# Programming by Gavin Lon](https://www.youtube.com/watch?v=YT8s-90oDC0)” eseguendo ogni parte con codice reale e comprensione approfondita.

## ⭐️ Struttura del corso e tracking

| Parte | Argomento                                 | Stato | Note |
| ----- | ----------------------------------------- | ----- | ---- |
| 1     | Introduzione e panoramica                 | ✅ | Avuto dubbi su delegato Action, ci ho perso tempo |
| 3     | .NET 5, .NET Core, .NET 6, .NET 7         | ✅ |      |
| 4-8   | Delegates e Async Method Calls            | ✅ | Mi sono sentito piuttosto a mio agio     |
| 9-12  | Events, Observer Pattern                  | ✅/❌ |      |
| 13-16 | Generics + Factory Design Pattern         | ✅/❌ |      |
| 17-20 | Async/Await + Best Practices              | ✅/❌ |      |
| 21-24 | LINQ: Introduzione, Queries, Operators    | ✅/❌ |      |
| 25    | C# Attributes                             | ✅/❌ |      |
| 26    | Reflection                                | ✅/❌ |      |
| 27-29 | .NET Framework, .NET Core, .NET 6, .NET 7 | ✅/❌ |      |

## 🛠️ Progetti creati

- Introduction project (HrDepartment Management) ✅
- Delegates examples ✅
- Events + UWP or simulation handlers
- LINQ queries + custom operators
- Async/Await best practices demo
- Reflection tool
- Factory pattern generic demo

## 🧠 Annotazioni tecniche

- Concetti compresi meglio grazie al codice
- Errori/problemi affrontati
- Best practice da portare nella roadmap

### Introduzione e panoramica
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

### Delegates e Async Method Calls

E' possibile utilizzare multi cast delegates per assegnare ad un singolo delegate, due istanze di delegati dello stesso tipo.

ESEMPIO:

public class Program
{
    delegate void LogDel(string text);
    public static void Main(string[] args)
    {
        var f = new Factory();

        LogDel LogToConsoleDelegate, LogToFileDelegate;
        LogToConsoleDelegate = new LogDel(f.LogToConsole);
        LogToFileDelegate = new LogDel(f.LogToFile);

        LogDel multiCastDelegate = LogToConsoleDelegate + LogToFileDelegate;

        multiCastDelegate("some text");  // 2 in 1
    }
}

public class Factory
{
    public void LogToConsole(string text)
    {
        // something
    }

    public void LogToFile(string text)
    {
        // something
    }
}

## 🧠 Riflessioni personali
04/06/2025: Stasera mi sono presentato anche se ero totalmente demoralizzato e paralizzato dalla paura di iniziare, di concretizzare, di fare. A volte sembra tutto inutile, ma a volte basta davvero soltanto iniziare.
E stasera ho iniziato, e 5 minuti sono diventati 1h30, dove non avrò realizzato il progetto della vita, ma ho posto delle solide ed ordinate basi per procedere a tutta dritta. Forza! Ce la farò.

05/06/2025: Stasera non avevo voglia, ma non mi sentivo neanche così giu come ieri. Forse perchè ho iniziato, e sapevo di poter continuare. Mi è piaciuto rivedere la parte dei delegate e i multicast delegates.
Sento di aver fatto il mio.. non totalmente, ma di averlo fatto. Anche solo in parte. E già sono 2 sere di fila. Non voglio mollare!

06/06/2025: Oggi giornata piena. Ho lavorato fino alle 18.30, poi sono passato nel nuovo appartamento ad ordinare, poi palestra e subito dopo sono uscito. Sono rientrato a mezzanotte, e per coerenza ho svolto circa 15\20 minuti di corso. Non ho fatto molto, ma ho fatto il necessario, e sono rimasto coerente. Domani si macina! P.S: Tripletta! Good job!

07/06/2025: Oggi contavo di poter fare di piu, ma ho potuto iniziare dopo pranzo, intorno alle 14.30. Ho svolto circa 1h di corso, scrivendo codice in contemporanea col video del corso, e poi ho fatto 1h di lezione con Gades, portando avanti il gestore di spese mensili. Soddisfatto? Parzialmente. Potevo fare di piu', ma l'importante è che io sia stato costante e abbia mantenuto la coerenza e la catena.

08/06/2025: Stop

09/06/2025: Purtroppo ieri ho rotto la catena, è stata una domenica difficile, emotivamente intensa e che sto ancora lavorando. Chissà che effetto mi farà rileggere queste righe tra qualche settimana, quando magari avrò completato il corso.. Beh, a tutta dritta. Si riparte da qui. Stasera ho dedicato 1h30 abbondante al corso e ho cercato di aggiungere "un tocco personale" all'esercizio proposto dal corso sul ClubMembership, introducendo un DTO ed una logica per mappare da DTO a Entity. Voglio davvero fare la differenza! Forza, non si molla!

10/06/2025: Fatto. Anche stasera. Non sarò un fenomeno, ma non ho fatto vincere il loop nella mia testa che mi dice 'sei un coglione' quando semplicemente mi scontro con l'impossibilità di ottenere tutto e subito.

🔹 Kent Beck — creatore di eXtreme Programming, inventore di JUnit
“I’m not a great programmer. I'm just a good programmer with great habits.”

Tradotto: Non sono geniale. Ma sono sistematico.
👉 Ha dichiarato che per anni si sentiva lento, fragile, pieno di dubbi — finché non ha costruito metodo.

🔹 Dan Abramov — creatore di Redux (JavaScript)
Ha scritto pubblicamente:

“Most days I feel like I’m pretending to be a developer. I Google things all the time. I forget stuff constantly.”

👉 Uno dei più rispettati sviluppatori frontend dice di sentirsi un impostore anche oggi.

 Scott Hanselman — figura top di .NET e Microsoft
Ha parlato più volte di:

Avere sindrome dell’impostore

Sentirsi “indietro rispetto a tutti”

Aver dovuto reimparare tutto su async/await dopo anni di .NET

👉 Lo ha detto in podcast, blog e live pubblici.

Se ti presenti ogni giorno, il traguardo ti raggiunge.
Non devi pensarci. Non devi preoccupartene.
Devi solo fare la prossima unità di lavoro. E poi la prossima. E poi la prossima.

E a un certo punto, giri lo sguardo e ti accorgi che il traguardo l’hai già passato.