using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Knoledge.xuliehua
{
    public class XuLieHua
    {
        public static void Test()
        {
            var stu2 = new Student()
            {
                Name = "chenchang",
                Age = 26,
                PhoneNum = "15721527020"
            };
            var stu = new Student()
            {
                Name = "chenchang",
                Age = 26,
                PhoneNum = "15721527020"
            };
            var stu3 = stu;
            
            
            
            var stuClone = Clone(stu);
            stu3.Age = 88;
            Console.WriteLine(stu.Age);
            Console.WriteLine(stuClone.Age);
            Console.WriteLine(stu == stu2);
            Console.WriteLine(stu==stuClone);
            Console.WriteLine(stu == stu3);
        }

        public static T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
    }
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; }
    }
}
