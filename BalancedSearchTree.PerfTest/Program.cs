using System.Diagnostics;
using BalancedSearchTree;

const int setNumber = 8;
// const int setNumber = 5;
int setSize = 100;

for (int i = 0; i < setNumber; i++)
{
    var input = GenerateSetOfSize(setSize);

    var tree = new BalancedTree<int>();
    InsertTest(setSize, input, tree);
    SearchTest(setSize, input, tree);
    RemoveTest(setSize, input, tree);

    if (i < 4)
        setSize *= 10;
    else
        setSize *= 2;
}



static List<int> GenerateSetOfSize(int size)
{
    var data = new List<int>();
    for (int i = 0; i < size; i++)
        data.Add(new Random().Next());

    return data;
}

static int GetRandomValue(List<int> input)
{
    var randomIndex = new Random().Next(input.Count - 1);
    return input[randomIndex];
}

static Stopwatch InsertTest(int setSize, List<int> input, BalancedTree<int> tree)
{
    Console.WriteLine($"Insert in tree test");
    
    var sw = Stopwatch.StartNew();
    foreach (var value in input)
        tree.Insert(value);
    sw.Stop();

    Console.WriteLine($"Set size = {setSize}, Time: {sw.ElapsedMilliseconds} ms, Time: {sw.ElapsedMilliseconds / 1000.0} sec");
    return sw;
}

static void SearchTest(int setSize, List<int> input, BalancedTree<int> tree)
{
    Console.WriteLine($"Search tree test");
    var searchResults = new List<long>();
    for (int searchIndex = 0; searchIndex < 10; searchIndex++)
    {
        int randomValue = GetRandomValue(input);
        
        var sw = Stopwatch.StartNew();
        var node = tree.Search(randomValue);
        sw.Stop();
        
        searchResults.Add(sw.ElapsedMilliseconds);
    }

    Console.WriteLine($"Set size = {setSize}, Time Avg: {searchResults.Average()} ticks");
}

static void RemoveTest(int setSize, List<int> input, BalancedTree<int> tree)
{
    Console.WriteLine($"Remove tree test");
    var removeResults = new List<long>();
    for (int searchIndex = 0; searchIndex < 10; searchIndex++)
    {
        int randomValue = GetRandomValue(input);
        
        Stopwatch sw = Stopwatch.StartNew();
        tree.Remove(randomValue);
        sw.Stop();
        
        removeResults.Add(sw.ElapsedTicks);
    }

    Console.WriteLine($"Set size = {setSize}, Time Avg: {removeResults.Average()} ticks");
}