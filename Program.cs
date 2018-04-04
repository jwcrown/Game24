using System;
using System.Collections.Generic;
using System.Text;

namespace Game24
{
    class Program
    {
        public static string again = "";
        static void Main(string[] args)
        {
            // Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            string start = "";
            do 
            {
                System.Console.WriteLine("Please enter your name!");
                string myName = Console.ReadLine();
                System.Console.WriteLine("Hello " + myName + " 👋");
                
                Console.Title = "ASCII Art";
                string title = @"
    ██████╗ ██╗  ██╗     ██████╗ █████╗ ██████╗ ██████╗      ██████╗  █████╗ ███╗   ███╗███████╗
    ╚════██╗██║  ██║    ██╔════╝██╔══██╗██╔══██╗██╔══██╗    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
     █████╔╝███████║   ██║      ███████║██████╔╝██║  ██║    ██║  ███╗███████║██╔████╔██║█████╗  
    ██╔═══╝ ╚════██║    ██║     ██╔══██║██╔══██╗██║  ██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
    ███████╗     ██║    ╚██████╗██║  ██║██║  ██║██████╔╝    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
    ╚══════╝     ╚═╝     ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                                                ";           
                Console.WriteLine(title);
                System.Console.WriteLine("Would you like to see the rules? (y/n) 📚");
                string desc = Console.ReadLine().ToLower();
                if(desc.Equals("y"))
                {
                    Description();
                }
                System.Console.WriteLine("Ready to play 24 Card Game? 🎉 🎉");
                System.Console.WriteLine("Enter y to Start 👍\n\n");
                start = Console.ReadLine().ToLower();
                
            } while (start != "y" && start != "n");
            
            if(start.ToLower().Equals("y"))
            {
                do
                {
                    GetCard();
                    Play();
                } while(again.Equals("y"));              
            }
            else{    
                string thanks = @"
  _____ _                 _                           __                    _             _             _ 
 |_   _| |__   __ _ _ __ | | __  _   _  ___  _   _   / _| ___  _ __   _ __ | | __ _ _   _(_)_ __   __ _| |
   | | | '_ \ / _` | '_ \| |/ / | | | |/ _ \| | | | | |_ / _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` | |
   | | | | | | (_| | | | |   <  | |_| | (_) | |_| | |  _| (_) | |    | |_) | | (_| | |_| | | | | | (_| |_|
   |_| |_| |_|\__,_|_| |_|_|\_\  \__, |\___/ \__,_| |_|  \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, (_)
                                 |___/                               |_|            |___/         |___/   ";
                Console.WriteLine(thanks);
            }
        }

        public static List<string> GetTokens(string expression)
        {
            string operators = "*/+-()";
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in expression.Replace(" ", string.Empty))//removes any spaces from expression
            {
                // blank space
                if (operators.IndexOf(c) >= 0)//checking if character in string is an operation
                {
                    if ((sb.Length > 0))
                    {
                        tokens.Add(sb.ToString());//adds number to string
                        sb.Length = 0;
                    }
                    tokens.Add(c.ToString());//adds operators
                } 
                else 
                {
                    sb.Append(c);//builds number
                }
            }

            if ((sb.Length > 0)) 
            {
                tokens.Add(sb.ToString());//adds final number to tokens
            }
            return tokens;
        }


        public static void GetCard()
        {
            Deck d = new Deck();
            Player me = new Player("Me");            
            // availability for user to type 'draw' to get card
            // maybe another do while
            // availability to save results into txt file
            Card firstCard = me.Draw(d);
            Card secondCard = me.Draw(d);
            Card thirdCard = me.Draw(d);
            Card fourthCard = me.Draw(d);
            System.Console.WriteLine("Here are your cards:");
            me.DisplayHand();
        }
        public static void Play()
        {
            System.Console.WriteLine("\nType new for new cards\nEnter your expressions: 😊");
            string input = "";
            double exp = 0.0;
            do
            {
                input = Console.ReadLine().ToLower();
                if (input == "new"){
                    again = "y";
                }
                else{

                exp = Evaluate(input);
                if(exp == 24)
                {
                    string title = @"

 ██████╗  ██████╗  ██████╗ ██████╗          ██╗ ██████╗ ██████╗ 
██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗         ██║██╔═══██╗██╔══██╗
██║  ███╗██║   ██║██║   ██║██║  ██║         ██║██║   ██║██████╔╝
██║   ██║██║   ██║██║   ██║██║  ██║    ██   ██║██║   ██║██╔══██╗
╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝    ╚█████╔╝╚██████╔╝██████╔╝
 ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝      ╚════╝  ╚═════╝ ╚═════╝ 
                                                                
👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏 👏
";           
                Console.WriteLine(title);
                    System.Console.WriteLine("Would you like to Play Again? (y/n) ↩️");
                    again = Console.ReadLine().ToLower();                      
                }               
                else
                {
                    string wrong = @"
██╗    ██╗██████╗  ██████╗ ███╗   ██╗ ██████╗ 
██║    ██║██╔══██╗██╔═══██╗████╗  ██║██╔════╝ 
██║ █╗ ██║██████╔╝██║   ██║██╔██╗ ██║██║  ███╗
██║███╗██║██╔══██╗██║   ██║██║╚██╗██║██║   ██║
╚███╔███╔╝██║  ██║╚██████╔╝██║ ╚████║╚██████╔╝
 ╚══╝╚══╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ";           
                Console.WriteLine(wrong);
                    System.Console.WriteLine("Try again!"); 
                } 
                }
            } while (again != "y" && again != "n");
            
        }
        public static double Evaluate(string expression)
        {
            List<string> tokens = GetTokens(expression);//returns an array of numbers and operators in correct order
            Stack<double> operandStack = new Stack<double>();//for numbers
            Stack<string> operatorStack = new Stack<string>();//for operators
            int tokenIndex = 0;
            while (tokenIndex < tokens.Count)
            {
                string token = tokens[tokenIndex];
                if (token.Equals("("))
                {
                    operatorStack.Push(token); // Push '(' to stack
                }
                else if (token.Equals(")"))
                {
                    //Process all the operators in the stack until seeing '('
                    while (operatorStack.Peek() != "(")
                    {
                        processAnOperator(operandStack, operatorStack);
                    }                    
                    operatorStack.Pop(); // Pop the '(' symbol from the stack
                }
                else if (token.Equals("+") || token.Equals("-"))
                {
                    while(operatorStack.Count != 0 && (operatorStack.Peek().Equals("+") || operatorStack.Peek().Equals("-")))
                    {
                        processAnOperator(operandStack, operatorStack);
                    }
                    // push the + or - operator into the operator stack
                    operatorStack.Push(token.ToString());
                }
                else if(token.Equals("*") || token.Equals("/"))
                {
                    // Process all *, / in the top of the operator stack
                    while (operatorStack.Count != 0 && (operatorStack.Peek().Equals('*') || operatorStack.Peek().Equals('/')))
                    {
                        processAnOperator(operandStack, operatorStack);
                    }
                    // push the * or / operator into the operator stack
                    operatorStack.Push(token.ToString());                    
                }
                else 
                {   //An operand scanned
                    //Push an operand to the stack
                    operandStack.Push(Convert.ToDouble(token));
                }   // back to the while loop to extract the next token
                tokenIndex += 1;
            }

            // phase 2: process all the remaining operators in the stack
            while (operatorStack.Count != 0) 
            {
                processAnOperator(operandStack, operatorStack);
            } 

            // return the result
            return operandStack.Pop();
        }

        public static void Description()
        {
            System.Console.WriteLine("🃏🂠🂡🂢🂣🂤🂫🂬🂭🂴🂿🂾🂽🃉🃖🃣🃢🃡🃨🃧🃮🃓🂫🂪🂮🂢🂣🂵🂶🂷🂸🂺🂻🂼🂽🂾🂿🃁🃃🃊🃍🃎🃌🃘🃙🃖🃛🃜🂢🂣🃝🃟🃝🃑🃉🃖🃣🃏\n\n\nRULES: ☝️️\nMake 24 with all 4 numbers on the card.\nYou can add, subtract, multiply or divide. You have to use\nall four numbers. Each number may be used only once.\nFor example: if the numbers are 2, 2, 6, 8:\nYou could make 24 by explaining (8-2) x (6-2) = 24.\n(There might be more than one solution!!!)\n\n");
        }
        public static void processAnOperator(Stack<double> operandStack, 
            Stack<string> operatorStack)
        {
            string op = operatorStack.Pop();//operation
            double op1 = operandStack.Pop();//num
            double op2 = operandStack.Pop();//num
            if (op == "+"){
                operandStack.Push(op2 + op1);
                Console.WriteLine(op2 + op1);
            }
            else if (op == "-"){
                operandStack.Push(op2 - op1);
                Console.WriteLine(op2 - op1);
            }
            else if (op == "*"){
                operandStack.Push((op2) * (op1));            
                Console.WriteLine((op2) * (op1));               
            }            
            else if (op == "/"){
                operandStack.Push(op2 / op1);
                Console.WriteLine(op2 / op1);               
            }
            
        }

    }
}