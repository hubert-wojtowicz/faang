int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

Console.WriteLine($"a={a}");
Console.WriteLine($"b={b}");
Console.WriteLine($"swapping in place...");
b = a ^ b;
a = a ^ b;
b = a ^ b;
Console.WriteLine($"a={a}");
Console.WriteLine($"b={b}");

// other option is to use diff = a-b