# Inicijalne upute za prijavu projekta iz Programskog inženjerstva

Poštovane kolegice i kolege, 

čestitamo vam jer ste uspješno prijavili svoj projektni tim na kolegiju Programsko inženjerstvo, te je za vas automatski kreiran repozitorij koji ćete koristiti za verzioniranje vašega koda, ali i za pisanje dokumentacije.

Ovaj dokument (README.md) predstavlja **osobnu iskaznicu vašeg projekta**. Vaš prvi zadatak, ukoliko niste odabrali da želite raditi na projektu sa nastavnicima ili u sklopu WBL-a je **prijaviti vlastiti projektni prijedlog** na način da ćete prijavu vašeg projekta, sukladno uputama danim u ovom tekstu, napisati upravo u ovaj dokument, umjesto ovoga teksta.

Za upute o sintaksi koju možete koristiti u ovom dokumentu i kod pisanje vaše projektne dokumentacije pogledajte [ovaj link](https://guides.github.com/features/mastering-markdown/).
Sav programski kod potrebno je verzionirati u glavnoj **master** grani i **obvezno** smjestiti u mapu Software. Sve artefakte (npr. slike) koje ćete koristiti u vašoj dokumentaciju obvezno verzionirati u posebnoj grani koja je već kreirana i koja se naziva **master-docs** i smjestiti u mapu Documentation.

Nakon vaše prijave bit će vam dodijeljen mentor s kojim ćete tijekom semestra raditi na ovom projektu. A sada, vrijeme je da prijavite vaš projekt. Za prijavu vašeg projektnog prijedloga molimo vas koristite **predložak** koji je naveden u nastavku, a započnite tako da kliknete na *olovku* u desnom gornjem kutu ovoga dokumenta :) 

# Desktop app za  birtiji(gostionici)

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Ime i prezime | mvresk@foi.hr | 0016141883 | mvresk
Ime i prezime |mloncar1@foi.hr| 0016138129| Maicco12
Ime i prezime |kipsa@foi.hr| 0016145835| Bajastera
Ime i prezime |dkrhac@foi.hr| 0016139009| krhacd

## Opis domene
Naš projekt bavit će se izradom aplikacije koju će pokrivati sve osnovne funkcionalnosti koje treba imati aplikacija za gostionicu.Nabava i plaćanje pića,prijedlozi korisnika,obavijesti,pregled ponude , narudžbe pića...
## Specifikacija projekta


Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija| Za pristup aplikaciji potrebnba je autentikacija korisnika .Da bi se mogao prijaviti prvo mora izraditi korisnički račun . Registracija je nužna kako bi mogao pristupiti aplikaciji. | Marko Vresk
F02 | Login  | Nakon što se registrira korisnik se prijavljuje u aplikaciju korištenjem korisničkog imena i lozinke koju je definirao kod registracije. | Marko Vresk
F03 | Cjenik-pregled pića u ponudi |forma u kojoj imamo pregled svih pića u ponudi i nekih osnovnih informacija o tom piću , mogućnost ažuriranja cijena i opisa proizvoda. Zatim možemo pregledati narudžbe za određeni proizvod od strane kupaca i dobavljača. Neke od tih funkcionalnosti će biti ograničene ovisno o ulozi kojom se prijavimo. | Marko Vresk
F04 | Narudžbe |Prikaz svih narudžbi zaprimljenih od korisnika i prikaz svih narudžbi od dobavljača koje kafić mora obraditi. | David Krhač
F05 | Obavijesti | Prikaz i mogućnost kreiranja obavijesti| David Krhač
F06 | Recenzije i prijedlozi |Obavijesti i prijedlozi koje bi aplikacija primala od ljudi.| David Krhač
F07 | Raspored rada |Obavijesti i mogućnost kreiranja rasporeda rada.| Karlo Ipša
F08 | Statistika |Prikaz količine prodanih proizvoda .| Karlo Ipša
F09 | Odjava i Postavke |Odjava s aplikacije i podešavanje postavki(odabir pozadine , fonta i veličine slova)| Karlo Ipša
## Tehnologije i oprema
Microsoft Visual Studio za izradu same aplikacije i povezivanje s bazom podataka.
MySQL Workbench - za izradu potrebnih baza podataka
Draw.io -za izradu potrebnih dijagrama
Microsoft Word - za pisanje dokumentacije
