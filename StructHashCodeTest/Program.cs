string a = "Hello";
string b = "Hello";
Console.WriteLine($"{a.GetHashCode()}, {b.GetHashCode()}");

a += "!";
Console.WriteLine($"{a.GetHashCode()}, {b.GetHashCode()}");


Console.WriteLine();

Person person = new Person
{
    Age = 12,
    Name = "Pavel"
};
Person person2 = new Person
{
    Age = 12,
    Name = "Pavel"
};
Person person3 = new Person
{
    Age = 12,
    Name = "Pavel3"
};
Person person4 = new Person
{
    Age = 14,
    Name = "Pavel4"
};
//Same hash code
Console.WriteLine(person.GetHashCode());
Console.WriteLine(person2.GetHashCode());
Console.WriteLine(person3.GetHashCode());
Console.WriteLine(person4.GetHashCode());

public struct Person
{
    public int Age { get; set; }
    public string Name { get; set; }
}