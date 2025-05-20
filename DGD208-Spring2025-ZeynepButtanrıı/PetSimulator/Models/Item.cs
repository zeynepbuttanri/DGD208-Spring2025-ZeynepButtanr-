using PetSimulator.Enums;

namespace PetSimulator.Models
{
    public class Item
    {
        public string Name { get; private set; }
        public ItemType Type { get; private set; }
        public int EffectAmount { get; private set; }
        public PetStat AffectedStat { get; private set; }

        public Item(string name, ItemType type, int effectAmount, PetStat affectedStat)
        {
            Name = name;
            Type = type;
            EffectAmount = effectAmount;
            AffectedStat = affectedStat;
        }
    }
} 