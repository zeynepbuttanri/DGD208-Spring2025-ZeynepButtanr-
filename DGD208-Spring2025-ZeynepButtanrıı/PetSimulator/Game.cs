using PetSimulator.Enums;
using PetSimulator.Models;
using PetSimulator.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetSimulator
{
    public class Game
    {
        private readonly List<Pet> pets;
        private readonly ItemDatabase itemDatabase;
        private readonly Menu mainMenu;
        private bool isRunning;

        public Game()
        {
            pets = new List<Pet>();
            itemDatabase = new ItemDatabase();
            mainMenu = new Menu(new[]
            {
                "Adopt a Pet",
                "View Pets",
                "Use Item on Pet",
                "Display Creator Info",
                "Exit"
            });
            isRunning = true;
        }

        public async Task RunAsync()
        {
            while (isRunning)
            {
                int choice = mainMenu.DisplayAndGetChoice();
                await HandleMenuChoiceAsync(choice);
            }
        }

        private async Task HandleMenuChoiceAsync(int choice)
        {
            switch (choice)
            {
                case 1:
                    await AdoptPetAsync();
                    break;
                case 2:
                    DisplayPets();
                    break;
                case 3:
                    await UseItemOnPetAsync();
                    break;
                case 4:
                    DisplayCreatorInfo();
                    break;
                case 5:
                    isRunning = false;
                    break;
            }
        }

        private async Task AdoptPetAsync()
        {
            Console.Clear();
            Console.WriteLine("Choose a pet type:");
            var petTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>();
            var petMenu = new Menu(petTypes.Select(pt => pt.ToString()));
            int choice = petMenu.DisplayAndGetChoice();
            PetType selectedType = petTypes.ElementAt(choice - 1);

            Console.Write("Enter pet name: ");
            string name = Console.ReadLine();

            var pet = new Pet(name, selectedType);
            pets.Add(pet);
            pet.PetDied += OnPetDied;
            _ = pet.DecreaseStatsAsync();

            Console.WriteLine($"\n{name} has been adopted!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayPets()
        {
            Console.Clear();
            if (!pets.Any())
            {
                Console.WriteLine("You don't have any pets yet!");
            }
            else
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine($"\n{pet.Name} ({pet.Type})");
                    
                    // Display ASCII art based on pet type
                    switch (pet.Type)
                    {
                        case PetType.Dog:
                            Console.WriteLine(@"
    / \__
   (    @\___
   /         O
  /   (_____/
 /_____/   U");
                            break;
                        case PetType.Cat:
                            Console.WriteLine(@"
 /\_/\
( o.o )
 > ^ <");
                            break;
                        case PetType.Bird:
                            Console.WriteLine(@"
   /\
  /  \
 /    \
(>    <)
 \    /
  \  /
   \/");
                            break;
                        case PetType.Fish:
                            Console.WriteLine(@"
    /\
   /  \
  /    \
 /      \
/        \
\        /
 \      /
  \    /
   \  /
    \/");
                            break;
                        case PetType.Rabbit:
                            Console.WriteLine(@"
 (\_/)
( -.-)
(> < )");
                            break;
                    }
                    
                    Console.WriteLine($"\nHunger: {pet.Hunger}");
                    Console.WriteLine($"Sleep: {pet.Sleep}");
                    Console.WriteLine($"Fun: {pet.Fun}");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private async Task UseItemOnPetAsync()
        {
            if (!pets.Any())
            {
                Console.WriteLine("You don't have any pets!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Select a pet:");
            var petMenu = new Menu(pets.Select(p => p.Name));
            int petChoice = petMenu.DisplayAndGetChoice();
            var selectedPet = pets[petChoice - 1];

            Console.WriteLine("\nSelect an item:");
            var items = itemDatabase.GetItemsForPetType(selectedPet.Type).ToList();
            var itemMenu = new Menu(items.Select(i => i.Name));
            int itemChoice = itemMenu.DisplayAndGetChoice();
            var selectedItem = items[itemChoice - 1];

            Console.WriteLine($"\nUsing {selectedItem.Name} on {selectedPet.Name}...");
            await Task.Delay(1000); // Simulate item usage
            selectedPet.IncreaseStat(selectedItem.AffectedStat, selectedItem.EffectAmount);

            Console.WriteLine($"\n{selectedPet.Name}'s {selectedItem.AffectedStat} increased by {selectedItem.EffectAmount}!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayCreatorInfo()
        {
            Console.Clear();
            Console.WriteLine("Created by: Zeynep Buttanrı");
            Console.WriteLine("Student Number: 225040087");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void OnPetDied(object sender, EventArgs e)
        {
            if (sender is Pet pet)
            {
                pets.Remove(pet);
                Console.WriteLine($"\n{pet.Name} has died! Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
} 