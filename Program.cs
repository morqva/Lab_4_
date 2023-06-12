using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введіть шлях до каталогу: ");
        string directoryPath = Console.ReadLine(); 

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Каталог не існує.");
            return;
        }

        Console.Write("Введіть шаблон файлів (наприклад, *.txt): ");
        string filePattern = Console.ReadLine(); 

        string[] files = Directory.GetFiles(directoryPath, filePattern);

        foreach (string filePath in files)
        {
            try
            {
                FileAttributes attributes = File.GetAttributes(filePath);
                attributes &= ~FileAttributes.Hidden; 
                File.SetAttributes(filePath, attributes);

                Console.WriteLine("Атрибути файлу {0} було змінено.", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: {0}", ex.Message);
            }
        }
    }
}
