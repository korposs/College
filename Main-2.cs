using System;

// Абстрактный класс для печатных изданий
abstract class PrintedMaterial
{
    public string Title { get; set; }
    public int Year { get; set; }
    public Publisher Publisher { get; set; }

    public virtual void Print()
    {
        Console.WriteLine("Печатаем печатный материал.");
    }

    public override string ToString()
    {
        if(Publisher == null)
            return this.GetType().ToString() + $" - Название: {Title}, Год: " + (Year >= 0 ? Year : (Math.Abs(Year) + " до Н.Э.") + ", издательство отсутствует\n");
        else
            return this.GetType().ToString() + $" - Название: {Title}, Год: " + (Year >= 0 ? Year : (Math.Abs(Year) + " до Н.Э.") + $", {Publisher.ToString()}\n");

    }
}

// Класс Журнал, наследуется от PrintedMaterial
class Magazine : PrintedMaterial
{
    public string Category { get; set; }

    public override void Print()
    {
        Console.WriteLine("Печатаем журнал.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Тема: {Category}";
    }
}

// Класс Книга, наследуется от PrintedMaterial
class Book : PrintedMaterial
{
    public Author author { get; set; }

    public override void Print()
    {
        Console.WriteLine("Печатаем книгу.");
    }

    public override string ToString()
    {
        return base.ToString() + $"{author}";
    }
}

// Класс Учебник, наследуется от Book
class Textbook : Book
{
    public string Subject { get; set; }

    public override void Print()
    {
        Console.WriteLine("Печатаем учебник.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Предмет: {Subject}";
    }
}

// Класс Персона
public class Person
{
    public string Name { get; set; }

    public override string ToString()
    {
        return this.GetType().ToString() + $" - Имя: {Name}\n";
    }
}

// Класс Автор, наследуется от Person
public class Author : Person
{
    public override string ToString()
    {
            return base.ToString();;
    }
}

// Бесплодный класс Издательство
sealed public class Publisher
{
    public string Name { get; set; }

    public override string ToString()
    {
            return this.GetType().ToString() + $" - Название: {Name}";

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
