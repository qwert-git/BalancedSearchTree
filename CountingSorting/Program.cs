using System.Diagnostics;
using CountingSorting;

const int setNumber = 8;
var setSize = 100;

for (int i = 0; i < setNumber; i++)
{
    var arr = GenerateDataSetOfSize(setSize);

    var sw = Stopwatch.StartNew();
    var res = Sort.CountingSort(arr);
    sw.Stop();

    Console.WriteLine($"Set size = {res.Length}, Time = {sw.ElapsedMilliseconds} ms, Time = {sw.ElapsedMilliseconds / 1000} sec");

    if (i < 4)
        setSize *= 10;
    else
        setSize *= 2;
}

static int[] GenerateDataSetOfSize(int size)
{
    var data = new int[size];
    for (int i = 0; i < size; i++)
        data[i] = new Random().Next();

    return data;
}