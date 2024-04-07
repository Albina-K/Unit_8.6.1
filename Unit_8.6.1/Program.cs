using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_8._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(@"\User\Luft\SkillFactoryNew"))
            {
                try
                {
                    var dirInfo = new DirectoryInfo(@"\User\Luft\SkillFactoryNew");
                    DateTime lastAccessTime = Directory.GetLastAccessTime(@"\User\Luft\SkillFactoryNew");
                    DateTime currentTime = DateTime.Now;
                    TimeSpan timeDifference = currentTime - lastAccessTime;
                    if (timeDifference > TimeSpan.FromMinutes(1))
                    {
                        //Console.WriteLine("Папка не была использована за последние 30 минут");
                        foreach (DirectoryInfo directoryInfo in dirInfo.GetDirectories())
                        {
                            directoryInfo.Delete(true);
                            //Console.WriteLine("Папки удалены");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                try
                {
                    var dirInfo = new DirectoryInfo(@"\User\Luft\SkillFactoryNew");
                    DateTime lastAccessTime2 = File.GetLastAccessTime(@"\User\Luft\SkillFactoryNew");
                    DateTime currentTime2 = DateTime.Now;
                    TimeSpan timeDifference2 = currentTime2 - lastAccessTime2;
                    if (timeDifference2 > TimeSpan.FromMinutes(1))
                    {
                       // Console.WriteLine("Файлы не были использованы за последние 30 минут");
                        foreach (FileInfo fileInfo in dirInfo.GetFiles())
                        {
                            fileInfo.Delete();
                           // Console.WriteLine("Файлы удалены");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
        }

        
    }
}
