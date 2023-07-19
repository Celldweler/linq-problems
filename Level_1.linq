<Query Kind="Statements">
  <Reference Relative="..\..\..\..\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll">C:\Users\Raime\Desktop\raw-codding-advanced\Reflection\WebApp\bin\Debug\netcoreapp3.1\WebApp.dll</Reference>
  <Namespace>WebApp</Namespace>
</Query>

/*All tasks should be done as a single line of code like: Console.WriteLine(YOUR CODE HERE);
	Linq Tasks
		Level 1:
			Methods to use:
				String: 
					string.Join, string.Concat, new string
					string.Split, 
					Contains, StartsWith, EndsWith
				Linq: 
					Select, Where, Skip[While], Take[While],
					Min, Max, Sum, Average, Count,
					Reverse,
					All, Any, Contains
					First[OrDefault], Last[OrDefault], Single[OrDefault],
					Range, Repeat,
					ToArray, ToList*/

var s = "aabb";
s.Substring("aa".Length).Dump();

(
"Tasks:\n"
	+ "\t1. Print all numbers from 10 to 50 separated by commas"
	+ "\n\t2. Print only that numbers from 10 to 50 that can be divided by 3"
	+ "\n\t3. Output word \"Linq\" 10 times"
	+ "\n\t4. Output all words with letter 'a' in string \"aaa;abb;ccc;dap\""
	+ "\n\t5. Output number of letters 'a' in the words with this letter in string \"aaa;abb;ccc;dap\" separated by comma"
	+ "\n\t6. Output true if word \"abb\" exists in line  \"aaa;xabbx;abb;ccc;dap\", otherwise false"
	+ "\n\t7. Get the longest word in string \"aaa;xabbx;abb;ccc;dap\""
	+ "\n\t8. Calculate average length of word in string \"aaa;xabbx;abb;ccc;dap\""
	+ "\n\t9. Print the shortest word reversed in string \"aaa;xabbx;abb;ccc;dap;zh\""
	+ "\n\t10. Print true if in the first word that starts from \"aa\" all letters are 'b' otherwise false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\""
	+ "\n\t11. Print last word in sequence that excepting first two elements that ends with \"bb\""
).Dump();
var sequence = Enumerable.Range(10, 41);

string.Join(", ",sequence.Select(x => x.ToString()).ToArray()).Dump("1. Print all numbers from 10 to 50 separated by commas.");


sequence.Where(x => x % 3 == 0)
.Dump("2. Print only that numbers from 10 to 50 that can be divided by 3");

Enumerable.Repeat("Linq", 10).Dump("Output word \"Linq\" 10 times");

// task 4
var words = "aaa;abb;ccc;dap".Split(";");
words.Where(x => x.Contains("a"))
.Dump("4. Output all words with letter 'a' in string \"aaa;abb;ccc;dap\"");

var words2 = "aaa;abb;ccc;dap".Split(";");
var res = string.Join(", ",
	words2.Where(x => x.Contains("a"))
		.Select(x => $"{x} - {x.Count(c => c.Equals('a'))}")
)
.Dump("5. Output number of letters 'a' in the words with this letter in string \"aaa;abb;ccc;dap\" separated by comma");


var line = "aaa;xabbx;abb;ccc;dap";
var searchWord = "abb";
line.Contains(searchWord).Dump("6. Output true if word \"abb\" exists in line  \"aaa;xabbx;abb;ccc;dap\", otherwise false");


var words3 = "aaa;xabbx;abb;ccc;dap".Split(";");
var cachedMaxLen = words3.Max(y => y.Length);
words3.Where(x => x.Length == cachedMaxLen)
.Dump("7. Get the longest word in string \"aaa;xabbx;abb;ccc;dap\"");

"aaa;xabbx;abb;ccc;dap".Split(";")
.Average(x => x.Length)
.Dump(" 8. Calculate average length of word in string \"aaa;xabbx;abb;ccc;dap\"");


var words9 = "aaa;xabbx;abb;ccc;dap;zh".Split(";");
new String(
	words9.FirstOrDefault(x => x.Length == words9.Min(y => y.Length))
		.Reverse().ToArray()
)
.Dump(" 9. Print the shortest word reversed in string \"aaa;xabbx;abb;ccc;dap;zh\"");


var words10 = "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(";");
words10.Any(x => x.StartsWith("aa") && x.Substring("aa".Length).All(c => c == 'b'))
.Dump(" 10. Print true if in the first word that starts from \"aa\" all letters are 'b' otherwise false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\"");


words10.Skip(2)
.Last(x => x.EndsWith("bb"))
.Dump(" 11. Print last word in sequence that excepting first two elements that ends with \"bb\"");