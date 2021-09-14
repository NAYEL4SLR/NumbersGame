using System;               /* Nael Sharabi   klass (SUT21) */
using System.Threading;
using System.Collections.Generic;
namespace NumbersGame
{
    class Program
    {
        static Random ran = new Random();
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.Write("\n\t\t\t* (( Välkommen till mitt gissningsspel"+
                                                                     " )) * \n\n" +
                    "  [1] Enkelt \n" +
                    "  [2] Normalt\n" +
                    "  [3] Svårt\n" +
                    "  [4] Brutalt!\n" +
                    "  [5] Skapa din egen svårighetsnivå\n" +
                    "  [6] Avsluta spelet   \n\n" +
                    "   Välj:  ");
                Int32.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        Easy();
                        break;
                    case 2:
                        Normal();
                        break;
                    case 3:
                        Hard();
                        break;
                    case 4:
                        Brutal();
                        break;
                    case 5:
                        CustomLevel();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\tVälkommen åter :-)");
                        Thread.Sleep(2000);
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\t\tFelaktig inmatning!   " +
                        "Var god och välj mellan 1 - 6\n");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Easy()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t* Gissningsspel ( Nivå: Lätt ) * \n\n");
            Console.WriteLine("   Alright lilla pojke :-)\n\n\tDu får 7 " +
                "försök för att gissa mitt tal som ligger mellan 1 - 15 \n");
            int trials = 7;
            int num = ran.Next(1, 16);
            Play(trials, num);

        }
        static void Normal()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t* Gissningsspel ( Nivå: Mellannivå ) * " +
                                                                         "\n\n");
            Console.WriteLine("\n\n\tDu får 5 försök för att gissa mitt tal som"+
                              " ligger mellan 1 - 20 \n");
            int trials = 5;
            int num = ran.Next(1, 21);
            Play(trials, num);
        }
        static void Hard()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t* Gissningsspel ( Nivå: Svårt ) * \n\n");
            Console.WriteLine("   En lagom nivå för tuffa spelare!\n\tDu får 5 " +
                "försök för att gissa mitt tal som ligger mellan 1 - 30 \n");
            int trials = 5;
            int num = ran.Next(1, 31);
            Play(trials, num);
        }
        static void Brutal()
        {
            Console.Clear();
            int trials = 3;
            Console.WriteLine("\n\n\t\t\t* Gissningsspel ( Nivå: Brutalt ) * \n\n");
            Console.WriteLine("   Du måste vara galen för att välja den här" +
               " nivån\n\t Du får 3 försök för att gissa mitt tal som ligger" +
               " mellan 1 - 35 \n");
            int num = ran.Next(1, 36);
            Play(trials, num);
        }
        static void CustomLevel()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t* Gissningsspel ( Nivå: Anpassningsbar" +
                                                                 "  ) * \n\n");
            int trials = 0, value = 0, numbers = 0;
            while (trials == 0)
            {
                Console.Write("\n   *Hur många försök vill du ha?   " +
                    "\n\t Obs! Du måste ha minst ett försök:   ");
                Int32.TryParse(Console.ReadLine(), out trials);
            }
            while (value <= 5)
            {
                Console.Write("\n   *Från '1' till vilket värde vill" +
                         " du gissa mellan?\n\t Obs! Minst 6:   ");
                Int32.TryParse(Console.ReadLine(), out value);
            }
            while ((numbers > value) || (numbers == 0))
            {
                Console.Write("\n   *Hur många tal vill du gissa på samtidigt?" +
                    "   \n\t Obs! Du måste välja från 1 till {0}(maxvärdet)" +
                    "   ", value);
                Int32.TryParse(Console.ReadLine(), out numbers);
            }
            List<int> list = new List<int>();
            for (int i = 0; i < numbers; i++)
            {
                list.Add(ran.Next(0, value + 1));
            }
            Play(trials, list);
            Console.ReadLine();
        }
        static void Play(int trials, int num)
        {
            bool game = true;    
            while (game)
            {
                if (trials == 0)
                {
                    Console.WriteLine("   Du har slut på försök!  :(\n\n" +
                        "\tTalet var: [{0}]", num);
                    Thread.Sleep(3200);
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\t\t\t\t* GAME OVER *");
                    return;
                }
                Console.Write("\n\tDin gissning:  ");
                bool input = Int32.TryParse(Console.ReadLine(), out int guessing);
                if (input)
                {
                    if (guessing == num)
                    {
                        Console.Write("\tWoho! Du gjorde det!  :-)  " +
                                          "Talet var: " + num);
                        Console.ReadKey();
                        game = false;
                    }
                    else if ((guessing == num -2) || (guessing == num - 1))
                    {
                        Console.WriteLine("\n\tDet var nära!  Försök lite högre");
                    }
                    else if ((guessing == num + 2) || (guessing == num + 1))
                    {
                        Console.WriteLine("\n\tDet var nära!  Försök lite lägre");
                    }
                    else if (guessing < num)
                    {
                        Console.WriteLine("\n\tTyvärr du gissade för lågt!");
                    }
                    else if (guessing > num)
                    {
                        Console.WriteLine("\n\tTyvärr du gissade för högt!");
                    }
                }
                else
                {
                    Console.WriteLine("\t\tFelaktig inmatning!   " +
                        "Var god och skriv ett heltal!\n");
                }
                if (trials == 2)
                {
                    Console.WriteLine("\n\n\tDu har nästan inga försök kvar." +
                        "   Välj noga nu :) .\n");
                }
                if (!input)
                    continue;
                trials--;
            }
        }
        static void Play(int trials, List<int> list)
        {
            bool game = true;
            while (game)
            {
                if (trials == 0)
                {
                    Console.WriteLine("   Du har slut på försök!  :(");
                    Thread.Sleep(3200);
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\t\t\t\t* GAME OVER *");
                    return;
                }
                Console.Write("\n\tDin gissning:  ");
                bool input = Int32.TryParse(Console.ReadLine(), out int guessing);
                if (input)
                {
                    List<int> guessedList = new List<int>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (guessing == list[i])
                        {
                            Console.Write("\n\t[{0}] Woho! Du gjorde det!  :-)  " +
                                         "Talet var: [{1}]", i, list[i]);
                            Console.ReadLine();
                            guessedList.Add(guessing);
                            if (guessedList.Count == list.Count)
                                game = false;
                        }
                        else if ((guessing == list[i] - 2) || 
                            (guessing == list[i] - 1))
                        {
                            Console.WriteLine("\n\t [{0}] Det var nära!  Försök" +
                                " lite högre", i);
                        }
                        else if ((guessing == list[i] + 2) ||
                                 (guessing == list[i] + 1))
                        {
                            Console.WriteLine("\n\t [{0}] Det var nära!  " +
                                           "Försök lite lägre", i);
                        }
                        else if (guessing < list[i])
                        {
                            Console.WriteLine("\n\t [{0}] Tyvärr du gissade för" +
                                " lågt!", i);
                        }
                        else if (guessing > list[i])
                        {
                            Console.WriteLine("\n\t [{0}] Tyvärr du gissade för " +
                                "högt!", i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\t\tFelaktig inmatning!   " +
                        "Var god och skriv ett heltal!\n");
                }
                if (trials == 2)
                    Console.WriteLine("\n\n\tDu har nästan inga försök kvar." +
                        "   Välj noga nu :) .\n");
                
                if (!input)
                    continue;
                trials--;
            }
        }
        
        
    }
}
