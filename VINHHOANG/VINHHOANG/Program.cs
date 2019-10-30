using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VINHHOANG
{
    public interface IItem
    {
        string name();
        float price();
    }// End of the interface Item.  
    public abstract class TauNgam : IItem
    {
        public abstract string name();
        public abstract float price();

    }
    public abstract class Food : IItem
    {
        public abstract string name();
        public abstract float price();
    }

    public class VIP : TauNgam
    {
        public override float price()
        {
            return 250.0f;
        }

        public override string name()
        {
            return "VIP seats";
        }
 
    }// End of the abstract class VegPizza.  

    public class Normal : TauNgam
    {
        public override float price()
        {
            return 150.0f;
        }

        public override string name()
        {
            return "Normal seats";
        }
    }
    public abstract class FastFood : Food
    {

        public override abstract string name();
        public override abstract float price();

    }// End of the Pepsi class 
    public abstract class SoftDrink : Food
    {
        public override abstract string name();
        public override abstract float price();

    }// End of the Pepsi class 
    public class Burger : FastFood
    {

        public override string name()
        {
            return "Burger";
        }
        public override float price()
        {
            return 35.0f;
        }


    }// End of the MediumPepsi class 
    public class Pizza : FastFood
    {

        public override string name()
        {
            return "Pizza";
        }
        public override float price()
        {
            return 50.0f;
        }


    }// End of the MediumPepsi class 
    public class NuocMia : SoftDrink
    {

        public override string name()
        {
            return "Nuoc Mia";
        }

        public override float price()
        {
            return 35.0f;
        }


    }// End of the MediumPepsi class 
    public class NuocCam : SoftDrink
    {

        public override string name()
        {
            return "Nuoc Cam";
        }
        public override float price()
        {
            return 50.0f;
        }


    }// End of the MediumPepsi class 
    public class OrderedItems
    {
        //For Seat
        List<IItem> items = new List<IItem>();

        public void addItems(IItem item)
        {

            items.Add(item);
        }
        //for Food
        List<IItem> items2 = new List<IItem>();
        public void addItems2(IItem item)
        {

            items2.Add(item);
        }
        public float getCost()
        {
            float cost = 0.0f;
            foreach (IItem item in items)
            {
                cost += item.price();
            }
            foreach (IItem item in items2)
            {
                cost += item.price();
            }
            return cost;
        }

        public void showItems()
        {
            Console.WriteLine("Type of Seat");
            foreach (IItem item in items)
            {
                Console.WriteLine("Item :" + item.name());
                Console.WriteLine("Price : " + item.price());
            }
            Console.WriteLine("Type of Food");
            foreach (IItem item in items2)
            {
                Console.WriteLine("Item :" + item.name());
                Console.WriteLine("Price : " + item.price());
            }
        }


    }// End of the OrderedItems class
    public class OrderBuilder
    {
        public OrderedItems GetOrdered()
        {
            Console.WriteLine("Chao mung ban den dich vu su dung ghe tau ngam cua chung toi ");
            OrderedItems itemsOrder = new OrderedItems();
            Console.WriteLine("Enter type of seat ");
            Console.WriteLine("        1. VIP       ");
            Console.WriteLine("        2. Normal   ");
            Console.WriteLine("        3. Exit            ");
            int choiceShit = Convert.ToInt32(Console.ReadLine());
            switch (choiceShit)
            {
                case 1:
                    itemsOrder.addItems(new VIP());
                    break;
                case 2:
                    itemsOrder.addItems(new Normal());
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            Console.WriteLine("Enter the choice of Food ");
            Console.WriteLine("        1. Fast Food       ");
            Console.WriteLine("        2. Soft Drink   ");
            Console.WriteLine("        3. Exit            ");
            int choiceFood = Convert.ToInt32(Console.ReadLine());
            switch (choiceFood)
            {
                case 1:
                    Console.WriteLine("You ordered Fast Food ");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("    1. Burger ");
                    Console.WriteLine("    2. Pizza ");
                    Console.WriteLine("------------------------");
                    int breadSize = Convert.ToInt32(Console.ReadLine());
                    switch (breadSize)
                    {
                        case 1:
                            itemsOrder.addItems2(new Burger());
                            break;

                        case 2:
                            itemsOrder.addItems2(new Pizza());
                            break;

                        case 3:
                            break;
                        default:
                            break;

                    }
                    break;
                case 2:
                    Console.WriteLine("You ordered Soft Drink ");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("    1. Nuoc Mia ");
                    Console.WriteLine("    2. Nuoc Cam ");
                    Console.WriteLine("------------------------");
                    int pepsySize = Convert.ToInt32(Console.ReadLine());
                    switch (pepsySize)
                    {
                        case 1:
                            itemsOrder.addItems2(new NuocMia());
                            break;

                        case 2:
                            itemsOrder.addItems2(new NuocCam());
                            break;

                        case 3:
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return itemsOrder;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            OrderBuilder builder = new OrderBuilder();

            OrderedItems orderedItems = builder.GetOrdered();

            orderedItems.showItems();

            Console.WriteLine();
            Console.WriteLine("Tong hoa don cua ban la : " + orderedItems.getCost());
            Console.ReadLine();
        }
    }
}