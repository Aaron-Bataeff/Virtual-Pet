namespace VirtualPet.Models
{
    public class Pet
    {
        public string Name { get; set; }

        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int Age { get; set; }

        public Pet(string name)
        {
            Name = name;

            Hunger = 50;
            Happiness = 50;
            Energy = 50;
            Age = 0;
        }

        public void Feed()
        {
            Hunger = Math.Max(0, Hunger - 20);
        }

        public void Play()
        {
            Happiness = Math.Min(100, Happiness + 15);
            Energy = Math.Max(0, Energy - 10);
        }

        public void Sleep()
        {
            Energy = Math.Min(100, Energy + 25);
        }

        public string GetMood()
        {
            if (Hunger >= 80)
                return "hungry";

            if (Energy <= 20)
                return "tired";

            if (Happiness <= 30)
                return "sad";

            return "happy";
        }

        public string GetStage()
        {
            if (Age < 10)
                return "baby";

            if (Age < 20)
                return "adult";

            return "cthulhu";
        }
    }
}