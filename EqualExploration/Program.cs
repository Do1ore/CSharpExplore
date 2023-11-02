
using System.Threading.Channels;

Person person = new Person("David", 12);
Person person2 = new Person("David", 12);
Console.WriteLine(person.GetHashCode() + " " + person2.GetHashCode());
Console.WriteLine(person.Equals(person2));
Console.WriteLine(person == person2);

record Person(string Name, int Age);
