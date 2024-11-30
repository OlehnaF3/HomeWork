using System;
using System.Drawing;
using HomeWork.Enum;
public static class Programm
{

public static (string name, string surname, byte age, bool havepet, string[] namesOfPet, byte numberOfFavoriteColor, string[] arrayColor) User;
public static void Main(string[] args)
{
    User = Foo();
    Writeturple(User);
}
public static (string name, string surname, byte age, bool havepet, string[] namesOfPet, byte numberOfFavoriteColor, string[] arrayColor) Foo()
{
    string[] nameOfPet;
    Console.WriteLine("What you name?");
    string Name = Console.ReadLine();
    Console.WriteLine("What you surname?");
    string Surname = Console.ReadLine();
    Console.WriteLine("How many Age?");
    byte Age = CorretlyInput();
    Console.WriteLine("Do you have a pet? Write \"Yes\" or \"No\"");
    bool havePet = Console.ReadLine() == "Yes" ? true : false;
    if (havePet)
    {
        Console.WriteLine("Write how many pet you have");
        nameOfPet = CreatePetNameArray(CorretlyInput());
    }
    else
    {
        nameOfPet = null;
    }
    Console.WriteLine("Write how many you have favorite color");
    byte numberOfFavoriteColor = CorretlyInput();
    string[] arrayColor = CreateArrayColor(numberOfFavoriteColor);

    return (Name, Surname, Age, havePet, nameOfPet, numberOfFavoriteColor, arrayColor);
}
public static void Writeturple((string name, string surname, byte age, bool havePet, string[] namesOfPet, byte numberOfFavoriteColor, string[] arrayColor) User)
{
    Console.WriteLine($"You name : \"{User.name}\"\nYou surname : \"{User.surname}\"\nAre you old : \"{User.age}\"\nThe number of favorite colors : \"{User.numberOfFavoriteColor}\"");
    Console.WriteLine("You have pets : \"{0}\"", User.havePet ? "Yes" : "No");
    if (User.havePet)
    {
        foreach (string names in User.namesOfPet)
        {
            Console.WriteLine("Names of pets : \"{0}\"", names);
        }
    }
    if (User.numberOfFavoriteColor != 0)
    {
        foreach (string color in User.arrayColor)
        {
            Console.WriteLine("You favorite color : \"{0}\"", color);
        }
    }
    Console.WriteLine();
}
public static byte CorretlyInput(bool corretly = false, byte s = 0)
{
    do
    {
        try
        {
            s = byte.Parse(Console.ReadLine());
            if (s == 0)
            {
                Console.WriteLine("You can't write 0");
                corretly = true;
            }
            else if (s > 100)
            {
                Console.WriteLine("You can't write >100");
                corretly = true;
            }
            else
            {
                corretly = false;
            }

        }

        catch
        {
            Console.WriteLine("Write correctly number");
            corretly = true;
        }
    } while (corretly);
    return s;
}

public static string[] CreatePetNameArray(byte scorePet)
{
    string[] strings = new string[scorePet];
    for (int i = 0; i < strings.Length; i++)
    {
        Console.WriteLine("Write name {0} pet", i + 1);
        strings[i] = Console.ReadLine();
    }
    return strings;
}
public static string[] CreateArrayColor(byte numberOfFavoriteColor)
{
    string[] arrayColor = new string[numberOfFavoriteColor];
    for (int i = 0; i < arrayColor.Length; i++)
    {
        Console.WriteLine("You favorite color {0}", i);
        arrayColor[i] = CheckCorretlyColor();
    }
    return arrayColor;
}
public static bool CheckColor(string color)
{
    var colors = Enum.GetValues(typeof(EnumColor.Color));

    foreach (var equl in colors)
    {
        if (equl.ToString() == color) return true;
    }
    return false;
}

/// <summary>
/// Дефолтное количество попыток 3
/// </summary>
/// <param name="color"></param>
/// <param name="tryscore"></param>
/// <returns></returns>
public static string CheckCorretlyColor(string? color = null, byte tryscore = 3)
{
    do
    {
        color = Console.ReadLine();
            if (!CheckColor(color))
            {
                if (tryscore == 0)
                {
                    break;
                }
                Console.WriteLine("Write another color, I do not know what kind of color it is");
                tryscore--;
                
            }
            
    } while (!CheckColor(color));
    return color;
}
}