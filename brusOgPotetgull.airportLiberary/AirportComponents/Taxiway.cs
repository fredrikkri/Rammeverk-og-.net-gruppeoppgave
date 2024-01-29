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
        public void useTaxiway(Aircraft aircraft)
        {
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

            // (Nagel, 2022, s. 203)
            if (taxiwayQueue.Count >= 1)
            {
                var firstInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                while (remainingDistance > 0)
                {
                    remainingDistance = (remainingDistance - currentSpeed);
                    currentSpeed += aircraft.Acceleration;
                    if (currentSpeed > aircraft.MaxSpeed)
                    {
                        currentSpeed = MaxSpeed;
                    }
                    secondCounter++;
                    Console.WriteLine(currentSpeed);
                }
            }
        }
    }
}