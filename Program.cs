using System;

namespace Puzzle
{
    class Program
    {
        static int[] pile = { 3, 5, 7 };
        static int index;
        static int num;
        static string player="User1";
        
        static void Main(string[] args)
        {                   
            int total = Total(pile);                                      

            while (total > 1)
            {
                ShowPiles(pile);

                Input_Pile();
                Input_Num();              

                pile[index] = pile[index] - num;
                total = Total(pile);
                player=ChangePlayer(player);
            }

            player = ChangePlayer(player);
            Console.WriteLine(" <<< The Winner is {0} >>>", player);
            Console.WriteLine("--------  Game Over --------");
            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }

        static void ShowPiles(int[] pile)
        {
            for(int i=0;i<3;i++)
            {
                Console.Write("Pile{0} : ", i+1);
                for (int j=0; j<pile[i]; j++)
                {                    
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        static bool Input_Pile()
        {
            int input;
            while(true)
            {   
                Console.WriteLine("{0},Please select which pile you want to pick:  (Or Input 99 to Exit.)", player);
                input = Convert.ToInt32(Console.ReadLine());
                if(input==99)
                {
                    Environment.Exit(0);
                }
                index = input - 1;
                string msg = "Only Pile ";

                for (int i = 0; i < 3; i++)
                {
                    if (index == i && pile[i] > 0)
                    {
                        return true;
                    }
                    
                    if(pile[i]>0)
                    {
                        msg += (i+1).ToString() + " ";
                    }                    
                }

                msg += "can be selected !";
                Console.WriteLine(msg);
            }            
        }

        static bool Input_Num()
        {
            int input;
            while (true)
            {          
                Console.WriteLine("How many do you take from the pile you selected?  (Or Input 99 to Exit.) ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 99)
                {
                    Environment.Exit(0);
                }
                num = input;

                if(num>pile[index])
                {
                    Console.WriteLine("There are only {0} could be taken.Please input another number.", pile[index]);
                }
                else
                {
                    return true;
                }
            }
        }

        static int Total(int[] pile)
        {
            int total = 0;

            foreach(int i in pile)
            {
                total += i;
            }
            return total;
        }

        static string ChangePlayer(string player)
        {
            return  player=="User1" ? "User2" : "User1";           
        }
    }

    
}
