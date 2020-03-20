using System;
using System.IO;
using ArhGzip_Another.Utils_A;

namespace ArhGzip_Another
{
    public class Parameters
    {
        public readonly ProcUst Mode;
        public readonly string PathToSourceFile;
        public readonly string PathToResultFile;

        public Parameters(string[] args)
        {
            string mas;
            mas = Convert.ToString(Console.ReadLine());
            if (mas == "compress")
            {
                Mode = ProcUst.compress;
            }
            else
            {
                Mode = ProcUst.decompress;
            }
            PathToSourceFile = Convert.ToString(Console.ReadLine());
            PathToResultFile = Convert.ToString(Console.ReadLine());
          
        }

       private void ModeCheckDialog(string mode)
        {
            mode = mode.ToLower();

            while (mode != "compress" && mode != "decompress")
            {
                Console.WriteLine($"У программы нет режима {mode}.");
                Console.WriteLine("Программа работает в двух режимах compress или decompress!");
                Console.Write("Введите желаемый режим: ");
                mode = Console.ReadLine();
            }
        }

        private void PathCheck(string path)
        {
            var a = Path.GetInvalidPathChars();
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new ArgumentException($"{path} - некорректный путь к файлу!");
        }

        private void RewriteFileDialog(string path)
        {
            Console.WriteLine($"{path} - файл существует!");
            Console.WriteLine("Перезаписать?(введите: да/нет)");

            var answer = Console.ReadLine();

            while (answer != "да" && answer != "нет")
            {
                Console.WriteLine("Перезаписать существующий файл?(введите: да/нет)");
                answer = Console.ReadLine();
            }

            if (answer == "нет")
                throw new ArgumentException($"{path} - неверный файл.");
        }
    }
}

