
//F�r simulation
// Flygninger blir oppretter (ActiveAircraft, Datetime, Departure/Arrival Runway/Gate/Taxiway (som burde kunne endres))
// Objektene - Airport, Aircraft, Runway, Taxiway og Gate blir instansiert
// Flygninger legges til i incoming eller departuring listene


// SIMULATION
// Angir start og slutt tid for simulasjon
// Starter Simulering ved startTime, og kj�rer inntil tidspunktet for endtime er <= starttime

// Antall itereringer er basert p� tidsenheten som blir lagt til for start tidspunktet nederst i loopen,
// og antall enheten som trengs for � n� ende tidspunktet.
// EKS: tidsenhet: start.addDays(1) start = 2024.05.07 end = 2024.05.08 ---> gir 2 iterasjoner fordi start <= end
    
    // IF
    //Hvis det finnes innkommende flygninger
        
        //H�ndtere flygninger for landing

    // ELSE
    //Hvis det ikke finnes innkommende flygninger
        // H�ndtere flygninger for avgang
