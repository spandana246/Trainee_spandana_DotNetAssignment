using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, double price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
        }
    }
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public event Action<Item> ItemAdded;
        public event Action<Item> ItemUpdated;
        public event Action<int> ItemDeleted;

        public void AddItem(Item item)
        {
            items.Add(item);
            ItemAdded?.Invoke(item);
        }

        public void DisplayAllItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public Item FindItemById(int id)
        {
            return items.FirstOrDefault(i => i.ID == id);
        }

        public void UpdateItem(int id, string name, double price, int quantity)
        {
            var item = FindItemById(id);
            if (item != null)
            {
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
                ItemUpdated?.Invoke(item);
            }
        }

        public void DeleteItem(int id)
        {
            var item = FindItemById(id);
            if (item != null)
            {
                items.Remove(item);
                ItemDeleted?.Invoke(id);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            // Subscribing to events
            inventory.ItemAdded += item => Console.WriteLine($"Item added: {item}");
            inventory.ItemUpdated += item => Console.WriteLine($"Item updated: {item}");
            inventory.ItemDeleted += id => Console.WriteLine($"Item with ID {id} deleted.");

            bool running = true;
            while (running)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Item item = new Item(id, name, price, quantity);
                        inventory.AddItem(item);
                        break;
                    case 2:
                        inventory.DisplayAllItems();
                        break;
                    case 3:
                        Console.Write("Enter ID: ");
                        int searchId = int.Parse(Console.ReadLine());
                        var foundItem = inventory.FindItemById(searchId);
                        Console.WriteLine(foundItem != null ? foundItem.ToString() : "Item not found.");
                        break;
                    case 4:
                        Console.Write("Enter ID: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new Price: ");
                        double newPrice = double.Parse(Console.ReadLine());
                        Console.Write("Enter new Quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());

                        inventory.UpdateItem(updateId, newName, newPrice, newQuantity);
                        break;
                    case 5:
                        Console.Write("Enter ID: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        inventory.DeleteItem(deleteId);
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
