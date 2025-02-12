// Chandler Wixom, 2/12/2025, Lab 3 Mastermind, CS 1405
Console.WriteLine("In this game a string of 4 letters containing only a - g has been created\nNo letter is repeated twice and the order is completly random\nYou are to guess the order and placement of these letters");


int? randomInt = null;
Random tempRandom = new Random();
string egg = ""; // creates the string that we add to later
while (egg.Length <4) // stops picking leters after it reaches 4 letters
{
int tempIntRandom = tempRandom.Next(97,103); //picks random number in the range of the leters we are usings asci numbers a - g, 97 - 103
char randomChar = (char) tempIntRandom; // changes the randum number to a character 

if (!(egg.Contains(randomChar))) // checks if the string contains the character rolled and if it isnt already in it it will be added
{
egg = egg + randomChar; // you can add a character to a string !!! like math but letters
}
}

Console.ReadKey(true);


Console.WriteLine(egg);
string playerGuess;
do
{
playerGuess = Console.ReadLine();
if (playerGuess != egg)
    Console.WriteLine("Sorry thats wrong");
}
while (playerGuess != egg);