using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private readonly Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private readonly Dictionary<Tuple<string, string>, SortedSet<Person>> personsByNameTownOrEmaildomain = new Dictionary<Tuple<string, string>, SortedSet<Person>>();
    private readonly OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAgeRange = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.personsByEmail.ContainsKey(email))
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

        this.personsByEmail.Add(email, person);

        var emailDomain = new Tuple<string, string>("@", email.Split('@')[1]);
        this.personsByNameTownOrEmaildomain.AppendValueToKey(emailDomain, person);

        var tuple = new Tuple<string, string>(name, town);
        this.personsByNameTownOrEmaildomain.AppendValueToKey(tuple, person);
        this.personsByAge.AppendValueToKey(age, person);

        this.personsByTownAndAgeRange.EnsureKeyExists(town);
        this.personsByTownAndAgeRange[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return null;
        }

        return this.personsByEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return false;
        }
        var person = this.personsByEmail[email];

        this.personsByEmail.Remove(email);

        var emailDomain = new Tuple<string, string>("@", email.Split('@')[1]);
        this.personsByNameTownOrEmaildomain[emailDomain].Remove(person);

        var tuple = new Tuple<string, string>(person.Name, person.Town);
        this.personsByNameTownOrEmaildomain[tuple].Remove(person);

        this.personsByAge[person.Age].Remove(person);
        this.personsByTownAndAgeRange[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var emailDomainTuple = new Tuple<string, string>("@", emailDomain);
        if (!this.personsByNameTownOrEmaildomain.ContainsKey(emailDomainTuple))
        {
            yield break;
        }

        foreach (var person in this.personsByNameTownOrEmaildomain[emailDomainTuple])
        {
            yield return person;   
        }
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var tuple = new Tuple<string, string>(name, town);
        if (!this.personsByNameTownOrEmaildomain.ContainsKey(tuple))
        {
            yield break;
        }

        foreach (var person in this.personsByNameTownOrEmaildomain[tuple])
        {
            yield return person;
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAgeRange.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange = this.personsByTownAndAgeRange[town].Range(startAge, true, endAge, true);
        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }
}
