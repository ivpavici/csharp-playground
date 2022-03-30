List<string> list = new() { "test", "test2", "test3" };

bool GetValueByPattern(string search, out string item)
{
    item = list.FirstOrDefault(x => x == search);

    return item != null;
}

string GetValueWithoutPattern(string search)
{
    return list.FirstOrDefault(x => x == search);
}

if (GetValueByPattern("test", out string item))
{
    Console.WriteLine(item);
}

var found = GetValueWithoutPattern("test4");
if (found != null)
{
    Console.WriteLine(found);
}


