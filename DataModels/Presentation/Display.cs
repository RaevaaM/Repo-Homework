using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDataAccess.DataModels;
using HDataAccess.Abstarct;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HDataAccess.Presentation
{
    public class Display
    {

        private int closeOperationId = 7;
        private int closeOperationId2 = 3;
        private GenericRepository<Horse> repoH = new GenericRepository<Horse>();
        private GenericRepository<HorseBreed> repoHB = new GenericRepository<HorseBreed>();
        public Display()
        {
            In();
            Input();
        }
        private void Menu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Edit Horse Table");
            Console.WriteLine("2. Edit Horse Breed Table");
            Console.WriteLine("3. Exit");
        }
        private void In()
        {
            var operation = -1;
            do
            {
                Menu();
                switch (operation)
                {
                    case 1:
                        EditHorseTable();
                        break;
                    case 2:
                        EditHorseBreedTable();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId2);
        }

        private void EditHorseBreedTable()
        {
            ShowMenu();

        }

        private void EditHorseTable()
        {
            ShowMenu();

        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Editing..." + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Get entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Save entry");
            Console.WriteLine("7. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Get();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        Save();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Save()
        {
            repoH.Save();
            repoHB.Save();
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            repoH.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Get()
        {
            Console.WriteLine("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Horse horse = repoH.GetById(id);
            if (horse != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + horse.Id);
                Console.WriteLine("Name: " + horse.Name);
                Console.WriteLine("Height: " + horse.Height);
                Console.WriteLine("Weight: " + horse.Weight);
                Console.WriteLine("Color: " + horse.Color);
                Console.WriteLine("Breed: " + horse.Breed);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Horse horse = repoH.GetById(id);
            if (horse != null)
            {
                Console.WriteLine("Enter name: ");
                horse.Name = Console.ReadLine();
                Console.WriteLine("Enter height: ");
                horse.Height = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter weight: ");
                horse.Weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter color: ");
                horse.Color = Console.ReadLine();
                repoH.Update(horse);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Horse horse = new Horse();
            Console.WriteLine("Enter name: ");
            horse.Name = Console.ReadLine();
            Console.WriteLine("Enter height: ");
            horse.Height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight: ");
            horse.Weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter color: ");
            horse.Color = Console.ReadLine();
            repoH.Add(horse);
        }

        private void ListAll()
        {
            if (true)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "HORSES" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var horses = repoH.GetAll();
                foreach (var item in horses)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.Id, item.Name, item.Height, item.Weight, item.Color, item.Breed);
                }
            }
            else
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "HORSE BREEDS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var horseBr = repoHB.GetAll();
                foreach (var item in horseBr)
                {
                    Console.WriteLine("{0} {1} {2}", item.Id, item.BreedName, item.Horses);
                }
            }

        }
    }
}
