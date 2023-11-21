using System;

// Базовый класс для печатных изданий
abstract class PrintedMaterial
{
    public string Title { get; set; }
    public int Year { get; set; }
    public override string ToString()
    {
        return $"{GetType().Name} - Title: {Title}, Year: {Year}";
    }
}

// Класс Журнал, наследуется от PrintedMaterial
public class Magazine : PrintedMaterial
{
    public string Category { get; set; }

    public override string ToString()
    {
        return base.ToString() + $", Category: {Category}";
    }
}

// Класс Книга, наследуется от PrintedMaterial
public class Book : PrintedMaterial
{
    public string Author { get; set; }

    public override string ToString()
    {
        return base.ToString() + $", Author: {Author}";
    }
}

// Класс Учебник, наследуется от Book
public class Textbook : Book
{
    public string Subject { get; set; }

    public override string ToString()
    {
        return base.ToString() + $", Тема: {Subject}";
    }
}

// Класс Персона
public class Person
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} - Имя: {Name}";
    }
}

// Класс Автор, наследуется от Person
public class Author : Person
{
    public string Genre { get; set; }

    public override string ToString()
    {
        return base.ToString() + $", Genre: {Genre}";
    }
}

// Класс Издательство
sealed class Publisher
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} - Название: {Name}";
    }
}
// Пример использования
class Program
{
    static void Main()
    {
        Publisher mospechat = new Publisher { Name = "Моспечать" };
        Publisher bbc = new Publisher { Name = "BBC" };
        Author BashAr = new Author { Name = "Башинов Арья"};
        Author hermes = new Author { Name = "Гермес Трисмегист" };
        PrintedMaterial[] printedMaterials = new PrintedMaterial[]
        {
            new Magazine { Title = "National Geographic", Year = 2022, Category = "Наука", Publisher = bbc },
            new Book { Title = "Изумрудные Скрижали Гермеса Трисмегиста", Year = -360, author = hermes},
            new Textbook { Title = "Программирование на C# для чайников", Year = 2023, author = BashAr, Subject = "Программирование"},
            new Textbook { Title = "Сборник анекдотов для чайников", Year = 2021, author = BashAr, Subject = "Юмор"},
        };

        foreach (var printedMaterial in printedMaterials)
        {
            printedMaterial.Print();
            Console.WriteLine(printedMaterial.ToString());
            Console.WriteLine();
        }
    }
}