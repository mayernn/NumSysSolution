using NumSysLib;

while (true)
{
    Console.Write("Число: ");
    string? value = Console.ReadLine();
    if (string.IsNullOrEmpty(value)) break;
    try
    {
        Console.Write("Из системы: ");
        if (!int.TryParse(Console.ReadLine(), out int fromBase))
            throw new FormatException("Ошибка ввода данных: основание должно быть целым числом.");
        Console.Write("В систему: ");
        if (!int.TryParse(Console.ReadLine(), out int toBase))
            throw new FormatException("Ошибка ввода данных: основание должно быть целым числом.");
        Console.WriteLine("Результат: " + Adapter.Convert(value, fromBase, toBase));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
    Console.WriteLine();
}
