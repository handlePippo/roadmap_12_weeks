🎯 Variance in C# – COSA DEVI RICORDARE
🔹 Contravarianza (in T)
Dove: sui parametri di input dei delegati/interfacce.

Permette: usare una funzione che accetta un tipo più generico.

Ricorda:
👉 Func<Dog, string> = Func<Animal, string> ✅
👉 Perché Dog è un Animal → input più specifico, metodo più generico = OK

🔹 Covarianza (out TResult)
Dove: sui tipi di ritorno.

Permette: usare una funzione che ritorna un tipo più specifico.

Ricorda:
👉 Func<Animal> = Func<Dog> ✅
👉 Perché Dog è un Animal → ritorno più preciso = OK

⚠️ Regola d’oro
La variance si applica SOLO tra tipi di delegati o interfacce generiche.
NON funziona quando assegni direttamente un metodo (MyMethod) con firma diversa.

🧠 Modello mentale
Contravarianza (in) = input più generico

Covarianza (out) = output più specifico

✅ Solo tra tipi, ❌ mai tra method group ↔ delegato con firma diversa