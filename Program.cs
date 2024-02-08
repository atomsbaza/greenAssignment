using System;
using greenAssignment;
using greenAssignment.Models;

namespace greenAssignment;

class Program
{
    #region No.3
    static PersonModel[] PersonModels = new[]
    {
            new PersonModel
            {
                PersonId = 1,
                Name = "Lee",
                Gender = "Male",
                DateOfBirth = new DateTime(1890, 5, 7),
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                UpdatedBy = -1,
                UpdatedDate = DateTime.Now
            },
            new PersonModel
            {
                PersonId = 2,
                Name = "Robert",
                Gender = "Male",
                DateOfBirth = new DateTime(1994, 7, 10),
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                UpdatedBy = -1,
                UpdatedDate = DateTime.Now
            },
            new PersonModel
            {
                PersonId = 3,
                Name = "Kris",
                Gender = "Female",
                DateOfBirth = new DateTime(1994, 12, 26),
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                UpdatedBy = -1,
                UpdatedDate = DateTime.Now
            }
    };

    static RelationshipModel[] RelationshipModels = new[]
    {
            new RelationshipModel
            {
                RelationshipID = 1,
                Person1ID = 1,
                Person2ID = 2,
                RelationshipType = "Son",
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                UpdatedBy = -1,
                UpdatedDate = DateTime.Now
            },
            new RelationshipModel
            {
                RelationshipID = 2,
                Person1ID = 1,
                Person2ID = 3,
                RelationshipType = "Daugther",
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                UpdatedBy = -1,
                UpdatedDate = DateTime.Now
            }
     };
    #endregion

    static void Main(string[] args)
    {
        RandomNumber();
        SearchByNameOlderToYounger();
        SearchByNameYoungerToOlder();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    #region No.1
    private static void RandomNumber()
    {
        Random random = new Random();
        int previousNumber = 1000;
        while (previousNumber > 0)
        {
            int randomNumber = random.Next(0, previousNumber);
            Console.WriteLine($"Generated: {randomNumber}");
            previousNumber = randomNumber;
        }
    }
    #endregion

    #region No.4
    private static void SearchByNameOlderToYounger()
    {
        Console.Write("Search Older To Younger: ");
        string searchTerm = Console.ReadLine();

        var person = PersonModels.FirstOrDefault(p => p.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

        if (person != null)
        {
            var relationships = new List<PersonModel>();
            var getRelationships = RelationshipModels
                .Where(r => r.Person1ID == person.PersonId || r.Person2ID == person.PersonId)
                .ToList();
            foreach (var relationship in getRelationships)
            {
                var getPersonInfo = PersonModels.FirstOrDefault(f => f.PersonId == relationship.Person2ID && f.DateOfBirth > person.DateOfBirth);

                if (getPersonInfo != null)
                {
                    relationships.Add(getPersonInfo);
                }
                else
                {
                    getPersonInfo = PersonModels.FirstOrDefault(f => f.PersonId != relationship.Person2ID && f.DateOfBirth > person.DateOfBirth);
                    if (getPersonInfo != null)
                    {
                        relationships.Add(getPersonInfo);
                    }
                }
            }
            
            if (relationships.Count > 0)
            {
                Console.WriteLine("Result: " + string.Join(" > ", relationships.Select(p => p.Name)));
            }
            else
            {
                Console.WriteLine("Result: Not Found");
            }
        }
        else
        {
            Console.WriteLine("Result: Not Found");
        }
    }
    #endregion

    #region No.5
    private static void SearchByNameYoungerToOlder()
    {
        Console.Write("Search Younger To Older: ");
        string searchTerm = Console.ReadLine();

        var person = PersonModels.FirstOrDefault(p => p.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

        if (person != null)
        {
            var relationships = new List<PersonModel>();
            var getRelationships = RelationshipModels
                .Where(r => r.Person1ID == person.PersonId || r.Person2ID == person.PersonId)
                .ToList();
            foreach (var relationship in getRelationships)
            {
                var getPersonInfo = PersonModels.FirstOrDefault(f => f.PersonId == relationship.Person2ID && f.DateOfBirth < person.DateOfBirth);

                if (getPersonInfo != null)
                {
                    relationships.Add(getPersonInfo);
                }
                else
                {
                    getPersonInfo = PersonModels.FirstOrDefault(f => f.PersonId != relationship.Person2ID && f.DateOfBirth < person.DateOfBirth);
                    if (getPersonInfo != null)
                    {
                        relationships.Add(getPersonInfo);
                    }
                }
            }

            if (relationships.Count > 0)
            {
                Console.WriteLine("Result: " + string.Join(" > ", relationships.Select(p => p.Name)));
            }
            else
            {
                Console.WriteLine("Result: Not Found");
            }
        }
        else
        {
            Console.WriteLine("Result: Not Found");
        }
    }
    #endregion
}

