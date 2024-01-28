using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
		private int length;
        private Queue<Aircraft> taxiwayQueue = new Queue<Aircraft>();
        private int minutesOfUse;
        private int speedWhenUsed;

        public Taxiway(int length, int minutesOfUse, int speedWhenUsed)
		{
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Length = length;
            this.MinutesOfUse = minutesOfUse;
            this.SpeedWhenUsed = speedWhenUsed;
		}
        public int Length { get; private set; }
        public int Id { get; private set; }
        public int MinutesOfUse { get; private set; }
        public int SpeedWhenUsed { get; private set; }

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
            var currentSpeed = SpeedWhenUsed;
            int secondCounter = 0;

            // (Nagel, 2022, s. 203)
            if (taxiwayQueue.Count >= 1)
            {
                var firstInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                while (remainingDistance > 0)
                {
                    remainingDistance = (int)(remainingDistance - currentSpeed);
                    currentSpeed += aircraft.Acceleration;
                    secondCounter++;
                    Console.WriteLine(currentSpeed);
                }
            }
        }
    }
}