# Rammeverk og .net gruppeoppgave
 Rammeverk og .net gruppeoppgave. Brus og potetgull

# Fullstendig API dokumentasjon

Vi har benyttet docFX for å generere vår fullstendig API dokumentasjon basert på xml-kommentarene vi har skrevet.
Det er mulig å få tilgang til denne på to ulike måter.

Mulighet 1 - uten docFX

	Åpne BrusDocs.pdf i root

Mulighet 2 - med docFX

For å installere docFX bruk følgende kommando som admin i terminal:

	dotnet tool update -g docfx

For å kjørt nettsiden med API dokumentasjonen:
	gå til terminalen  -->  Fra root --> kjør følgende kommando:

	docfx docFx\docfx.json --serve

Gå deretter til http://localhost:8080/api/BrusOgPotetgull.AirportLiberary.html