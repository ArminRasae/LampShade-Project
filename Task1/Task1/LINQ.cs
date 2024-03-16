using Task1.Model;

List<Product> Products = new List<Product>
{
    new Product{ Id=1,Name = "Product A",Category ="Category 1",Price= 100},

    new Product{ Id=2,Name = "Product B",Category = "Category 2",Price =150},

    new Product{ Id=3,Name= "Product C",Category = "Category 1",Price = 120},

    new Product{ Id=4,Name = "Product D",Category= "Category 3",Price = 200 },

    new Product{ Id=5,Name = "Product E",Category = "Category 2",Price = 90},
};

var category1Products = Products
    .Where(x => x.Category.Contains("Category 1"))
    .Select(x => new { x.Name, x.Price })
    .ToList();
Console.WriteLine($"Products in Category 1 : ");
category1Products.ForEach(x => Console.WriteLine(x.Price));

//var max = Products.Max(x=>x.Price);
var max = Products.OrderByDescending(x => x.Price).First();
Console.WriteLine($"Product with the highest price : {max.Name} | {max.Price}");

var sum = Products.Sum(x => x.Price);
Console.WriteLine($"Total price of all products : {sum}");

var avg = Products.Average(x => x.Price);
Console.WriteLine($"Average price of products : {avg}");

var groupProducts = Products.GroupBy(x => x.Category);
foreach (var group in groupProducts)
{
    Console.WriteLine($"Category: {group.Key}");

    foreach (var item in group)
    {
        var res = item.Name;
    }
    var result = group.Select(x => $" Product : {x.Name}").ToList();
    result.ForEach(Console.WriteLine);

    Console.WriteLine();
}

void GroupByEx3()
{
    // Create a list of pets.
    List<Pet> petsList =
        new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
            new Pet { Name="Boots", Age=4.9 },
            new Pet { Name="Whiskers", Age=1.5 },
            new Pet { Name="Daisy", Age=4.3 } };

    // Group Pet objects by the Math.Floor of their age.
    // Then project an anonymous type from each group
    // that consists of the key, the count of the group's
    // elements, and the minimum and maximum age in the group.
    var query = petsList.GroupBy(x => Math.Floor(x.Age), (age, pets) => new
    {
        Key = age,
        Count = pets.Count(),
        Min = pets.Min(pet => pet.Age),
        Max = pets.Max(pet => pet.Age)
    });

    // Iterate over each anonymous type.
    foreach (var result in query)
    {
        Console.WriteLine("\nAge group: " + result.Key);
        Console.WriteLine("Number of pets in this age group: " + result.Count);
        Console.WriteLine("Minimum age: " + result.Min);
        Console.WriteLine("Maximum age: " + result.Max);
    }

    /*  This code produces the following output:

        Age group: 8
        Number of pets in this age group: 1
        Minimum age: 8.3
        Maximum age: 8.3

        Age group: 4
        Number of pets in this age group: 2
        Minimum age: 4.3
        Maximum age: 4.9

        Age group: 1
        Number of pets in this age group: 1
        Minimum age: 1.5
        Maximum age: 1.5
    */
}







