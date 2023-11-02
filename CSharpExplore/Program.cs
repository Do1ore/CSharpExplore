using CSharpExplore;

 var classPerson = new PersonClass { Name = "Vlad", Age = 21 };

 Console.WriteLine(classPerson);

 ChangeClassValue(classPerson);

 Console.WriteLine(classPerson);


 void ChangeClassValue(PersonClass person)
 {
     person.Name = "New Name";
     person = null;
     person = new PersonClass { Name = "Nick", Age = 45 };
 }

//2
 
var structPerson = new PersonStruct { Name = "Vlad", Age = 21 };

Console.WriteLine(structPerson.ToString());

ChangeStructValue(structPerson);

Console.WriteLine(structPerson.ToString());


void ChangeStructValue(PersonStruct person)
{
    person.Name = "New Name";
    person = new PersonStruct { Name = "Nick", Age = 45 };
}