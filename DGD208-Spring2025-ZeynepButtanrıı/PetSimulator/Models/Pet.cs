using PetSimulator.Enums;
using System;
using System.Threading.Tasks;

namespace PetSimulator.Models
{
    public class Pet
    {
        public string Name { get; private set; }
        public PetType Type { get; private set; }
        public int Hunger { get; private set; }
        public int Sleep { get; private set; }
        public int Fun { get; private set; }

        public event EventHandler<PetStat> StatChanged;
        public event EventHandler PetDied;

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
            Hunger = 50;
            Sleep = 50;
            Fun = 50;
        }

        public async Task DecreaseStatsAsync()
        {
            while (true)
            {
                await Task.Delay(3000); // Decrease stats every 3 seconds
                
                if (Hunger > 0) Hunger--;
                if (Sleep > 0) Sleep--;
                if (Fun > 0) Fun--;

                if (Hunger == 0 || Sleep == 0 || Fun == 0)
                {
                    PetDied?.Invoke(this, EventArgs.Empty);
                    break;
                }

                StatChanged?.Invoke(this, PetStat.Hunger);
                StatChanged?.Invoke(this, PetStat.Sleep);
                StatChanged?.Invoke(this, PetStat.Fun);
            }
        }

        public void IncreaseStat(PetStat stat, int amount)
        {
            switch (stat)
            {
                case PetStat.Hunger:
                    Hunger = Math.Min(100, Hunger + amount);
                    break;
                case PetStat.Sleep:
                    Sleep = Math.Min(100, Sleep + amount);
                    break;
                case PetStat.Fun:
                    Fun = Math.Min(100, Fun + amount);
                    break;
            }
            StatChanged?.Invoke(this, stat);
        }
    }
} 