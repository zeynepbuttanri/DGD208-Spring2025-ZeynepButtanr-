using PetSimulator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PetSimulator.Models
{
    public class ItemDatabase
    {
        private readonly List<Item> items;

        public ItemDatabase()
        {
            items = new List<Item>
            {
                new Item("Dog Food", ItemType.Food, 20, PetStat.Hunger),
                new Item("Cat Food", ItemType.Food, 20, PetStat.Hunger),
                new Item("Bird Seed", ItemType.Food, 15, PetStat.Hunger),
                new Item("Fish Food", ItemType.Food, 10, PetStat.Hunger),
                new Item("Rabbit Food", ItemType.Food, 15, PetStat.Hunger),
                new Item("Ball", ItemType.Toy, 25, PetStat.Fun),
                new Item("Cat Toy", ItemType.Toy, 20, PetStat.Fun),
                new Item("Bird Toy", ItemType.Toy, 15, PetStat.Fun),
                new Item("Fish Toy", ItemType.Toy, 10, PetStat.Fun),
                new Item("Rabbit Toy", ItemType.Toy, 20, PetStat.Fun),
                new Item("Dog Bed", ItemType.Bed, 30, PetStat.Sleep),
                new Item("Cat Bed", ItemType.Bed, 25, PetStat.Sleep),
                new Item("Bird Cage", ItemType.Bed, 20, PetStat.Sleep),
                new Item("Fish Tank", ItemType.Bed, 15, PetStat.Sleep),
                new Item("Rabbit Hutch", ItemType.Bed, 25, PetStat.Sleep),
                new Item("Medicine", ItemType.Medicine, 40, PetStat.Hunger),
                new Item("Frisbee", ItemType.Toy, 35, PetStat.Fun),
                new Item("Laser Pointer", ItemType.Toy, 30, PetStat.Fun),
                new Item("Bird Mirror", ItemType.Toy, 25, PetStat.Fun),
                new Item("Bubble Maker", ItemType.Toy, 20, PetStat.Fun),
                new Item("Carrot Toy", ItemType.Toy, 30, PetStat.Fun),
                new Item("Treat Ball", ItemType.Toy, 25, PetStat.Fun),
                new Item("Catnip", ItemType.Toy, 35, PetStat.Fun),
                new Item("Bird Bell", ItemType.Toy, 20, PetStat.Fun),
                new Item("Fish Castle", ItemType.Toy, 25, PetStat.Fun),
                new Item("Rabbit Tunnel", ItemType.Toy, 30, PetStat.Fun)
            };
        }

        public IEnumerable<Item> GetItemsForPetType(PetType petType)
        {
            return items.Where(item => item.Name.ToLower().Contains(petType.ToString().ToLower()));
        }

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }
    }
} 