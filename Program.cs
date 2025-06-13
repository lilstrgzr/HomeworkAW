using System;
using System.IO;
using System.Linq; // Для работы с LINQ (упрощение обработки коллекций)

class Program
{
    static void Main(string[] args)
    {
        // Проверяем наличие аргументов командной строки
        if (args.Length == 0) { Console.WriteLine("Ошибка: Не переданы числа!"); return; }

        // Фильтруем числа: оставляем только нечётные и оканчивающиеся на 3 или -3
        var numbers = args.Where(x => int.TryParse(x, out int n) && n % 2 != 0 && Math.Abs(n % 10) == 3)
                         .Select(int.Parse).ToList();

        // Вычисляем сумму отфильтрованных чисел
        int sum = numbers.Sum();

        // Получаем путь к папке "Документы" текущего пользователя
        string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Записываем числа в файл numbers.txt (каждое число с новой строки)
        File.WriteAllLines(Path.Combine(docs, "numbers.txt"), numbers.Select(n => n.ToString()));

        // Записываем сумму в файл summ.txt (одно число)
        File.WriteAllText(Path.Combine(docs, "summ.txt"), sum.ToString());

        // Выводим сообщение об успешном завершении
        Console.WriteLine("Результаты сохранены в папке Документы!");
    }
}