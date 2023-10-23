##README##

Vanwege een aantal complicaties ben ik helemaal opnieuw moeten beginnen op woensdag week 6.
Samen met een erg drukke vakantie betekende dat ik erg weinig tijd had en er dus voor gekozen heb op een aantal punten het zo te laten aangezien ik naar mijn mening heb aangetoont dat ik er mee kan werken het het belangrijker is dat ik alle aspecten laat zien.

Wat momenteel werkt:
- CRUD van Klant, Items
- Layout/Indexing.

Wat niet werkt:
- CRUD van Order(Ordereitem)
    - Ik heb problemen bij het koppelen van items aan orders. In de database heb ik hiervoor een koppel tabel gemaakt waardoor ik een veel op veel relatie krijg.
      Echter heb ik een stuk of 4 oplossingen geprobeerd om of hieromhene te werken of omiets aan te passen.
      Momenteel geeft hij een error aan dat hij geen primary key heeft (de orderitem) en omdat entityframework een primary key nodig heeft loopt die vast.
      Ik heb geprobeerd deze key toetevoegen in de DB,Klasses,DBcontext dit is ook gelukt en er kwam geen fout meldingen totdat ik het programma draaide en hij met dezelfde error terug kwam.
      Toen heb ik besloten het weg te halen en te laten zoals het is dan werkt het voor een klein deel maar.
      (Het gaat fout op het moment dat je op het + of - klikt bij een Item card.)
- Een aantal aspecten zoals het opnieuw bestellen of het rekening houden met verschillende soorten gebruikers(Admin,klant) ben ik nog niet aan toegekomen. de Auth plugin heb ik bewust vermijd aangezien ik alleen maar mensen zag met problemen en auth niet nodig was.
  In de code zul je dus zien dat die dingen niet/amper verwerkt zjn.
- De API was op een redelijk niveau en de shell werkte ook zoals behoren. Echter nadat ik een referentie aanmaakte naar het MVC project en een koppeling legde met de DB via _context kreeg ik bij opstarten een error die mij niet duidelijk is. In het project zelf krijg ik ook geen errors.

Indien gewenst kan ik laten zien doormiddel van prive projecten dat ik wel ervaring heb met Git/CSSHTML dan dat zichtbaar is in dit project.
