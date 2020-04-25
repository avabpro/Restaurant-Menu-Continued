using System;
using System.Collections.Generic;

namespace RestaurantMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu testMenu = new Menu();
            testMenu.AddMenuItem(14, "bread", "appetizer", true);
            testMenu.AddMenuItem(18, "soup", "appetizer", true);

            testMenu.PrintMenu();
        }

    }

    class Menu
    {
        private DateTime lastUpdated;

        private List<MenuItem> menuList = new List<MenuItem>();

        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }

        public List<MenuItem> MenuList
        {
            get { return menuList; }
        }

        public Menu()
        {
            LastUpdated = DateTime.Now;
        }

        public void PrintMenu()
        {
            foreach (MenuItem item in menuList)
            {
                item.Print();
            }
        }

        

        public void AddMenuItem(double price, string description, string category, Boolean isNew)

        {
            menuList.Add(new MenuItem(price, description, category, isNew));

        }

        public void RemoveMenuItem(MenuItem toRemove)

        {
            menuList.Remove(toRemove);
        }

        public MenuItem this[int index]
        {
            get
            {
                return menuList[index];
            }

            set
            {
                menuList[index] = value;

            }


        }
    }

    class MenuItem
    {
        private double price;
        private string description;
        private string category;
        private Boolean isNew;



        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                price = value;

            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Description cannot be left empty.");
                }
                description = value;

            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (value != "appetizer" && value != "main course" && value != "dessert")
                {
                    throw new ArgumentException("Category must be one of the following: appetizer, main course, dessert");
                }
                category = value;

            }
        }

        public Boolean IsNew
        {
            get { return isNew; }
            set
            { isNew = value; }
        }

        public MenuItem(double price, string description, string category, Boolean isNew)
        {
            Price = price;
            Description = description;
            Category = category;
            IsNew = isNew;
        }

        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o == null || o.GetType() != GetType())
            {
                return false;
            }

            MenuItem menuObj = o as MenuItem;
            return Description == menuObj.Description;
        }

        public void Print()
        {
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Description: {price}");
            Console.WriteLine($"Description: {category}");
            Console.WriteLine($"Description: {isNew}");
        }

    }

}
