
//Før simulation
// Flygninger blir oppretter (ActiveAircraft, Datetime, Departure/Arrival Runway/Gate/Taxiway (som burde kunne endres))
// Objektene - Airport, Aircraft, Runway, Taxiway og Gate blir instansiert
// Flygninger legges til i incoming eller departuring listene


// SIMULATION
// Angir start og slutt tid for simulasjon
// Starter Simulering ved startTime, og kjører inntil tidspunktet for endtime er <= starttime

// Antall itereringer er basert på tidsenheten som blir lagt til for start tidspunktet nederst i loopen,
// og antall enheten som trengs for å nå ende tidspunktet.
// EKS: tidsenhet: start.addDays(1) start = 2024.05.07 end = 2024.05.08 ---> gir 2 iterasjoner fordi start <= end
    
    // IF
    //Hvis det finnes innkommende flygninger
        
        //Håndtere flygninger for landing

    // ELSE
    //Hvis det ikke finnes innkommende flygninger
        // Håndtere flygninger for avgang
