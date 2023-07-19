<Query Kind="Statements">
  <Reference Relative="..\..\..\..\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll">C:\Users\Raime\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll</Reference>
  <Namespace>WebApp</Namespace>
</Query>

/*
Level 3:
	Methods to use:
		All Level 2 methods
		Join
		Aggregate
	Tasks:
		1. Implement extension method on int that calculates Factorial
		2. Express string.Join using Aggregate
		3. Express string.Concat using Aggregate
		4. Output all films in such format: FilmName DirectorName (DirectorCountry)
			Prepare:
				
	5. Output all films of each director separated by commas

*/

List<Film> films = new List<Film>()
{
    new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
    new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },
    new Film { Name = "The Recruit", Director ="Roger Donaldson" }
};
List<Director> directors = new List<Director>()
{
    new Director { Name = "Jonathan Demme", Country = "USA" },
    new Director { Name = "Roger Donaldson", Country = "New Zealand" },
};

films.Join(directors, f => f.Director,
	d => d.Name, (f, d) => $"{f.Name} - {d.Name} - {d.Country}")
.Dump();


directors.Join(films, d => d.Name, f => f.Director, (d, f) => new {
	DirName = d.Name,
	Film = f.Name
})
.GroupBy(x => x.DirName)
.Select(x => new {
	Director = x.Key,
	Films = LinqExtensions.Join(", ", x.Select(fn => fn.Film).ToArray())
})
.Dump();
var i =  5;

//i.Factorial().Dump();
LinqExtensions.Join(',', "Hello", "World", "Guys").Dump();
LinqExtensions.Join(" - ", "Hello", "World", "Guys").Dump();
// 4! = 4 * 3 * 2 * 1
static class LinqExtensions 
{
	public static int Factorial(this int num) 
	{
		var fact = 1;
		for(int i = 2; i <= num; i++) {
			fact *= i;
		}
		
		return fact;
	}
	
	public static string Join(char separator, params string[] s) {
		
		var strs =  s.AsEnumerable();
		
		return strs.Aggregate((currentAgg, nextV) => $"{currentAgg}{separator}{nextV}");
	}
	
	public static string Join(string separator, params string[] s) {
		var strs =  s.AsEnumerable();
		
		return strs.Aggregate((currentAgg, nextV) => $"{currentAgg}{separator}{nextV}");
	}
	
	public static string Concat(params string[] s) {
		var strs =  s.AsEnumerable();
		
		return strs.Aggregate((currentAgg, nextV) => $"{currentAgg}{nextV}");
	}
}

class Film
{
    public string Name { get; set; }
    public string Director { get; set; }
}
class Director
{
    public string Name { get; set; }
    public string Country { get; set; }
}
