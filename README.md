# Rammeverk og .net gruppeoppgave
 Rammeverk og .net gruppeoppgave. Brus og potetgull

# Fullstendig API dokumentasjon

Vi har benyttet docFX for � generere v�r fullstendig API dokumentasjon basert p� xml-kommentarene vi har skrevet.
Det er mulig � f� tilgang til denne p� to ulike m�ter.

Mulighet 1 - uten docFX

	�pne BrusDocs.pdf i root

Mulighet 2 - med docFX

For � installere docFX bruk f�lgende kommando som admin i terminal:

	dotnet tool update -g docfx

For � kj�rt nettsiden med API dokumentasjonen:
	g� til terminalen  -->  Fra root --> kj�r f�lgende kommando:

	docfx docFx\docfx.json --serve

G� deretter til http://localhost:8080/api/BrusOgPotetgull.AirportLiberary.html