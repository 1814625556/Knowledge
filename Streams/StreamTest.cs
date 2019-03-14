using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Knoledge.Streams
{
    public class StreamTest
    {
        public static void ReadOrWrite()
        {
            try
            {
                //写文件流
                string str = "hh";
                byte[] bytes1 = new byte[1024];
                bytes1 = Encoding.UTF8.GetBytes(str);
                FileStream fst = new FileStream("sd", FileMode.OpenOrCreate, FileAccess.Write);
                fst.Write(bytes1, 0, bytes1.Length);
                var position = fst.Position;
                fst.Close();
                //读文件流
                FileStream fs = File.OpenRead("sd");
                byte[] bytes2 = new byte[position];
                int num = fs.Read(bytes2, 0, Convert.ToInt32(position));
                fs.Close();
                var result = Encoding.UTF8.GetString(bytes2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static void TestDriverInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    WriteLine($"Drive name: {drive.Name}");
                    WriteLine($"Format: {drive.DriveFormat}");
                    WriteLine($"Type: {drive.DriveType}");
                    WriteLine($"Root directory: {drive.RootDirectory}");
                    WriteLine($"Volume label: {drive.VolumeLabel}");
                    WriteLine($"Free space: {drive.TotalFreeSpace}");
                    WriteLine($"Available space: {drive.AvailableFreeSpace}");
                    WriteLine($"Total size: {drive.TotalSize}");

                    WriteLine();

                }
            }
        }

        public static string GetDocumentsFolder()
        {
            string str = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return str;
            
            
        }
        /// <summary>
        /// 文件属性测试
        /// </summary>
        public static void Test1()
        {
            FileInfo fi = new FileInfo(@"G:\zaihui\cc.txt");
            Console.WriteLine($"Name:{fi.Name}");
            Console.WriteLine($"Directory:{fi.Directory}");
            Console.WriteLine($"Extension:{fi.Extension}");
            Console.WriteLine($"IsReadOnly:{fi.IsReadOnly}");
            Console.WriteLine($"Length:{fi.Length}");
            Console.WriteLine($"CreationTime:{fi.CreationTime}");
            Console.WriteLine($"LastAccessTimeUtc:{fi.LastAccessTimeUtc}");
            Console.WriteLine($"LastAccessTime:{fi.LastAccessTime}");
        }
        /// <summary>
        /// 按行读取txt文件
        /// </summary>
        public static void Test2()
        {
            string[] lines = File.ReadAllLines(@"G:\zaihui\cc.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
        /// <summary>
        /// 读取该目录下的所有文件
        /// </summary>
        public static void Test3()
        {
            string[] fileNames = Directory.GetFiles(@"G:\zaihui");
            foreach (var file in fileNames)
            {
                Console.WriteLine(file);
            }

            string[] dirNames = Directory.GetDirectories(@"G:\zaihui");
            foreach (var dir in dirNames)
            {
                Console.WriteLine(dir);
            }
        }


    }
}
