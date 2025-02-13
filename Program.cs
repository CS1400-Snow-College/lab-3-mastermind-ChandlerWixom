// Chandler Wixom, 2/12/2025, Lab 3 Mastermind, CS 1405

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;


Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

Console.WriteLine("This is the String Game\n\nPick how long you want the string to be and the range of letters available in the string");
Console.WriteLine("There must be atleast enough letters to fill up the string as no letter is repeated in this string ");
Console.WriteLine("The letters will be in a random order and your goal is to guess where they are\n");

int length;
Console.Write("How long do you want the secrete string to be? : ");
do
{
length = Convert.ToInt32(Console.ReadLine());

    if (length <2)
    {
        Console.WriteLine("Number must be greater then 1");
    }
}
while (length <2);



Console.Write("\nWhat is the range of letters you want starting from a - ");
int endingInt;
char endingChar;
do
{
string endingString = Console.ReadLine().ToLower().Trim();
endingChar = endingString[0];
endingInt = endingChar;
 if (endingInt < 96 + length)
 {
    Console.WriteLine("Too Little Letters available for the length");
 }
 else if (endingInt > 123)
 Console.WriteLine("Not Valid");
 else
 {

 }
}
while (endingInt < 96 + length || endingInt > 123);

Console.Clear();
Console.Write("If the letter is ");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("RED ");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("then the letter isn't in the string at all");

Console.Write("If the letter is ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("YELLOW ");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("then the letter is in the string but not in that location");

Console.Write("If the letter is ");
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("GREEN ");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("then the letter is in the right spot");

Console.WriteLine($"String is {length} letters long  Range is a - {endingChar}");

int? randomInt = null;
Random tempRandom = new Random();
string secreat = ""; // creates the string that we add to later
while (secreat.Length < length) // stops picking leters after it reaches 4 letters
{
    int tempIntRandom = tempRandom.Next(97, endingInt +1); //picks random number in the range of the leters we are usings asci numbers a - g, 97 - 103
    char randomChar = (char)tempIntRandom; // changes the randum number to a character 

    if (!(secreat.Contains(randomChar))) // checks if the string contains the character rolled and if it isnt already in it it will be added
    {
        secreat = secreat + randomChar; // you can add a character to a string !!! like math but letters
    }
}

//Console.WriteLine(secreat); // wip


string playerGuess;
int guessCount = 0;
do
{
    do
    {
        playerGuess = Console.ReadLine().ToLower().Trim();
        if (playerGuess.Length < secreat.Length)
        {
            Console.WriteLine("Too Little Letters");
        }
        else if (playerGuess.Length > secreat.Length)
            Console.WriteLine("Too Many Letters");
        else
        {
            
        }
    }
    while (playerGuess.Length != secreat.Length);

    if (playerGuess != secreat)
    {
        int correctLetters = 0;
        int wrongLetters = 0;
        int mehLetters = 0;
        Console.Write("Sorry, ");

        for (int checkPosition = 0; checkPosition < secreat.Length; checkPosition++) // idea reaplace with color?
        {


            char playerGuessChar = playerGuess.ElementAt(checkPosition);
            char eggChar = secreat.ElementAt(checkPosition);
            if (playerGuessChar == eggChar) // correct
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(playerGuessChar);
                Console.ForegroundColor = ConsoleColor.White;
                correctLetters++;
            }
            else if (secreat.Contains(playerGuessChar)) // meh
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(playerGuessChar);
                Console.ForegroundColor = ConsoleColor.White;
                mehLetters++;
            }
            else
            {
                if (playerGuessChar != eggChar) // wrong
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerGuessChar);
                    Console.ForegroundColor = ConsoleColor.White;
                    wrongLetters++;
                }
            }


        }
        Console.WriteLine(" is wrong");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{correctLetters} Correct; ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{mehLetters} Close; ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{wrongLetters} Wrong");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
    guessCount++;
}
while (playerGuess != secreat);

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(playerGuess);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("You got it!!!");
Console.WriteLine($"That took you {guessCount} tries");