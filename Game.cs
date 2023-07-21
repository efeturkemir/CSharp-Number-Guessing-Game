using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    internal class Game
    {
        private int money = 500;
        private string diff = "easy";
        Random rnd = new Random();
        Dictionary<string, (int, int, int)> difficultyMap = new Dictionary<string, (int, int, int)>
        {
            { "easy", (500, 1, 7 ) },
            { "normal", (2000, 1, 30) },
            { "hard", (40000, 1, 100) },
        };
        private int luckyNumber;
        
        public void play()
        {
            (int moneyVal, int minVal, int maxVal) value = difficultyMap[diff];
            luckyNumber = rnd.Next(value.minVal, value.maxVal);
            Console.WriteLine($"Guess a number between {value.minVal} and {value.maxVal}, entry cost is $100");
            int option; 
            int guess = Convert.ToInt32(Console.ReadLine());
            if (guess == luckyNumber)
            {
                Console.WriteLine($"You earned ${value.moneyVal}!");
                money += value.moneyVal;
                Console.WriteLine("1. Play Again");
                Console.WriteLine("2. Go Back");
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1 && money > 300)
                {
                    Console.Clear();
                    play();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    start();
                }
                else
                {
                    Console.WriteLine("You dont have enough money!");
                    start();
                }
            }
            else
            {
                
                Console.WriteLine("You lose! the lucky number was " + luckyNumber);
                money -= 100;
                Console.WriteLine("1. Try Again");
                Console.WriteLine("2. Go Back");
                option =  Convert.ToInt32(Console.ReadLine());
                if(option == 1 && money > 300)
                {
                    Console.Clear();
                    play();
                }
                else if(option == 2)
                {
                    Console.Clear();
                    start();
                }
                else
                {
                    Console.WriteLine("You dont have enough money!");
                    start();
                }
            }

        }

        public void balance() {
           
            Console.WriteLine("Your current money is: " + money);
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Go back");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option) {
                case 1:
                    Console.WriteLine("How much do you want to deposit?");
                    int depositMoney = Convert.ToInt32(Console.ReadLine());
                    money += depositMoney;
                    balance();

                        break;
                      
                case 2:
                    Console.Clear();
                    start();
                    break;
            
            }
        }
        public void difficulty()
        {
            Console.WriteLine("Select a difficulty, current difficulty is " + diff);
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard"); 
            Console.WriteLine("4. Cancel");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
            diff = "easy";
                    Console.Clear();
                    start();
            break;
                case 2:
                    diff = "normal";
                    Console.Clear();
                    start();
                    break;
                case 3:
                    diff = "hard";
                    Console.Clear();
                    start();
                    break;
                case 4:
                    Console.Clear();
                    start();
                    break;
                default:
                    Console.WriteLine("Wrong option!");
                    difficulty();
                    break;
            }
        }
     
       public void start()
        {
          
            Console.WriteLine("****Welcome****");
            Console.WriteLine("1.Play");
            Console.WriteLine("2.Check Your Balance");
            Console.WriteLine("3.Select Gamemode");
            Console.WriteLine("4.Exit");
           int option = Convert.ToInt32(Console.ReadLine());
            if (option != 4)
            {
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        if (money > 300)
                            play();
                        else
                        {
                            Console.WriteLine("You dont have enough money!");
                            start();
                        }
                        break;
                    case 2:
                        balance();
                        break;
                    case 3:
                        difficulty();
                        break;
                    default: Console.WriteLine("Incorrect option");
                        start();
                        break;
                }
            }
        }
    }
}

