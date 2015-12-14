using System;
using System.Linq;
using System.Collections.Generic;

public class PersonCollectionSlow : IPersonCollection
{
    private readonly List<Person> persons = new List<Person>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        this.persons.Add(person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.persons.Count;
        }
    }

    public Person FindPerson(string email)
    {
        return this.persons.FirstOrDefault(p => p.Email == email);
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        return this.persons.Remove(person);
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        this.persons.Sort();
        foreach (var person in this.persons)
        {
            if (person.Email.EndsWith("@" + emailDomain))
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        this.persons.Sort();
        foreach (var person in this.persons)
        {
            if (person.Name == name && person.Town == town)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return this.persons.FindAll(p => p.Age >= startAge && p.Age <= endAge)
                            .OrderBy(p => p.Age)
                            .ThenBy(p => p.Email);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        return this.persons.FindAll(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                            .OrderBy(p => p.Age)
                            .ThenBy(p => p.Email);
    }
}
