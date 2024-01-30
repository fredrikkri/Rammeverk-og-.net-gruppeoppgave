using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
        private Queue<Aircraft> taxiwayQueue = new Queue<Aircraft>();

        public Taxiway(int length, int maxSpeed, Airport locatedAtAirport)
        {
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
            this.LocatedAtAirport = locatedAtAirport;
        }
        public int Length { get; private set; }
        public int Id { get; private set; }
        public int MaxSpeed { get; private set; }
        public Airport LocatedAtAirport { get; private set; }

        public void printTaxiwayInformation()
		{
            Console.Write($"\nTaxiwayId: {Id}\n" +
                $"Taxiway lenght: {Length}\n");
        }
        public string getIdAndAirportNickname()
        {
            string returnString = (string)(Id + ", " + LocatedAtAirport.AirportNickname);
            return returnString;
        }
        public void addAircraftToQueue(Aircraft aircraft)
        {
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(aircraft);
        }
        public void peekToSeIfYourAircraftIsNext(Aircraft aircraft)
        {
            if (taxiwayQueue.Peek() == aircraft)
            {
                Console.Write($"\n{aircraft.Model} is first in queue\n");
                firstInQueueEnterTaxiway(aircraft);
            }
            else
            {
                while (taxiwayQueue.Peek() != aircraft)
                {
                    Console.Write("\nWaiting to be next in line to use taxiway...\n");
                }
            }

        }
        public void firstInQueueEnterTaxiway(Aircraft aircraft)
        {
            // (Nagel, 2022, s. 203)
            if (taxiwayQueue.Count >= 1)
            {
                var nextAircraftInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                simulateTaxiway(nextAircraftInQueue);
            }
        }
        public void simulateTaxiway(Aircraft aircraft)
        {
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

            while (remainingDistance > 0)
            {
                remainingDistance = remainingDistance - currentSpeed;
                if (currentSpeed == 0)
                {
                    currentSpeed += aircraft.AccelerationOnGround;
                }
                if (currentSpeed <= MaxSpeed & currentSpeed <= aircraft.MaxSpeedOnGround)
                {
                    currentSpeed += aircraft.AccelerationOnGround;
                }
                secondCounter++;
                Console.WriteLine(currentSpeed);
            }
        }
    }
}