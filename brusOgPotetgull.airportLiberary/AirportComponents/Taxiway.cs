using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
		private int length;
        private Queue<Aircraft> taxiwayQueue = new Queue<Aircraft>();
        private int maxSpeed;

        public Taxiway(int length, int maxSpeed)
		{
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
		}
        public int Length { get; private set; }
        public int Id { get; private set; }
        public int MaxSpeed { get; private set; }

        public void printTaxiwayInformation()
		{
            Console.Write($"\nTaxiwayId: {Id}\nTaxiway lenght: {Length}\n");
        }
        public void addAircraftToQueue(Aircraft aircraft)
        {
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(aircraft);
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
                currentSpeed += aircraft.AccelerationOnGround;
                if (currentSpeed > aircraft.MaxSpeedOnGround)
                {
                    currentSpeed = MaxSpeed;
                }
                secondCounter++;
                Console.WriteLine(currentSpeed);
            }
        }
    }
}