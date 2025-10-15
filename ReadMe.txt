# IBAS Support WebApp udviklet af Alfred, ITAE24-A i faget Cloud Computing.

## Formål
Denne webapplikation er udviklet som en del af Cloud Computing-forløbet (M4.04).
Formålet er at demonstrere, hvordan en Blazor Server-app kan integreres med Azure CosmosDB
til håndtering af kundehenvendelser om IBAS cykler.

## Funktioner
- Opret nye supporthenvendelser via formular  
- Se liste over alle eksisterende henvendelser  
- Data gemmes og hentes fra Azure CosmosDB (NoSQL)  
- Simpel validering og brugergrænseflade  
 
## Teknologi
- ASP.NET Core / Blazor Server  
- Azure CosmosDB (NoSQL, SQL API)  
- C#, Razor, JSON  

## Opsætning af CosmosDB (Azure CLI)
```bash
# Opret resource group
az group create --name IBasSupportRG --location "uksouth"

# Opret CosmosDB konto
az cosmosdb create --name ibas-db-account --resource-group IBasSupportRG --enable-free-tier true --locations regionName=uksouth

# Opret database
az cosmosdb sql database crea

##Hvad nåede jeg?
Jeg nåede egentlig godt i mål med det meste. Næste skridt ville nok være at inddele henvendelserne i status, 
så man ville kunne trykke på 3 forskellige knapper øverst: åben, under behandling og lukket.
Derudover ville en slet funktion være fed at implementere.
