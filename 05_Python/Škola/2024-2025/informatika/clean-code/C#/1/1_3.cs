using System;

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Display()
    {
        Console.WriteLine(this.name + " is " + this.age + " years old.");
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person("Alice", 30);
        person.Display();
    }
}
