<Query Kind="Statements">
  <Reference Relative="..\..\..\..\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll">C:\Users\Raime\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll</Reference>
  <Namespace>WebApp</Namespace>
</Query>

/*
Tasks:    
    10. Output sum of total number of pages in all books and all int values inside all sequences in data
    11. Get the dictionary with the key - book author, value - list of author's books
    12. Output all films of "Matt Damon" excluding films with actors whose name are presented in data as strings
 */

var data = new List<object>
{
    "Hello",
    new Book { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
    new List<int> {4, 6, 8, 2},
    new [] {"Hello inside array"},
    new Film
    {
        Author = "Martin Scorsese", 
        Name= "The Departed",
        Actors = new List<Actor>
        {
            new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
            new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
            new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
        }
        
    },
    new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
        new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
    }},
    new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
    "Leonardo DiCaprio"
};

//Task_1();
//Task_2();
//Task_3();
//Task_4();
//Task_5();
//Task_6();
//Task_7();
//Task_8();
Task_9();

void Task_1() {
	//1. Output all elements excepting ArtObjects
	data.OfType<ArtObject>().Dump();
}

void Task_2() {
	// 2. Output all actors names
	data.OfType<ArtObject>()
	    .Where(x => x is Film)
	    .Cast<Film>()
	    .SelectMany(x => x.Actors)
		.Select(a => a.Name)
		.Dump();
	
}

void Task_3() {
    //3. Output number of actors born in august
	data.OfType<ArtObject>()
	    .Where(x => x is Film)
	    .Cast<Film>()
	    .SelectMany(x => x.Actors)
		.Where(a => a.Birthdate.Month == 8)
		.Dump();
	
}

void Task_4() {
    // 4. Output two oldest actors names
	data.OfType<ArtObject>()
	    .Where(x => x is Film)
	    .Cast<Film>()
	    .SelectMany(x => x.Actors)
		.OrderBy(x => x.Birthdate)
		.Take(2)
		.Dump();
	
}

void Task_5() {
    // 5. Output number of books per authors
	data.OfType<Book>()
	  	.GroupBy(x => x.Author)
		.Select(x => new {
			AuthorName = x.Key,
			NumberOfBooks = x.Count()
		})
		.Dump();
	
}

// 6. Output number of books per authors and films per director
void Task_6() {
    // 5. Output number of books per authors
	data.OfType<ArtObject>()
	  	.GroupBy(x => x.GetType().Name)
		.Select(x => new {
			TypeOfArtObj = x.Key,
			Items = x.GroupBy(x => x.Author)
	 				 .Select(x => new {
	 				 	AuthorName = x.Key,
	 				 	NUmbers = x.Count()
	 				 })
	 		})
		.Dump();
}

void Task_7() {
	// 7. Output how many different letters used in all actors names
	data.OfType<Film>()
		.SelectMany(x => x.Actors)
		.Select(x => x.Name.ToLower())
		.Aggregate((x, y) => x + y)		
		.Where(x => char.IsLetter(x))
		.GroupBy(x => x)
		.Count()
		//.Select(w => new {
		//	Letter = w.Key,
		//	Count = w.Count()
		//})
		.Dump();
}

void Task_8() {
//8. Output names of all books ordered by names of their authors
//and number of pages

	data.OfType<Book>()
		.OrderBy(x => x.Author)
		.ThenBy(x => x.Pages)
		.Dump();
}

void Task_9() {
// 9. Output actor name and all films with this actor

	data.OfType<Film>()
		.SelectMany(f => f.Actors.Select(a =>
			new { aN = a.Name, fN = f.Name }))
		.GroupBy(x => x.aN)
		.Select(x => new {
			ActorName = x.Key,
			Films = x.Select(f => f.fN).ToList(),
		})
		.Dump();
}


List<object> FindNonArtObject(List<object> objects)
{
    var listNonArtObjects = new List<object>();

    return listNonArtObjects;
}

object? _findNonArtObject(object obj)
{
    if (obj == null)
        throw new ArgumentNullException(nameof(obj));
    
    var typeOfArtObject = typeof(ArtObject);
    var typeOfObj = obj.GetType();

    if (typeOfObj.IsClass && !typeOfObj.FullName.StartsWith("System."))
    {
        
    }
    if (typeOfArtObject.IsAssignableFrom(typeOfObj))
    {
        return null;
    }

    return obj;
}



class Actor {
    public string Name { get; set; }
    public DateTime Birthdate {get; set; }
}

abstract class ArtObject {

    public string Author { get; set;}
    public string Name { get; set;}
    public int Year { get; set;}
}
class Film : ArtObject {

    public int Length { get; set;}
    public IEnumerable<Actor> Actors { get; set;}
}
class Book : ArtObject {

    public int Pages { get; set; }
}
