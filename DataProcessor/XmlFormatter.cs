using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessor
{
    public class XmlFormatter
    {

        Student s1 = new Student
        {
            Name = "Pratik",
            Age = 22
        };
        Student s2 = new Student
        {
            Name = "Ankit",
            Age = 24
        };
        StudentList list;
        public XmlFormatter()
        {
            list = new StudentList
                {
                    Students = new List<Student> {
                    new Student{ Name = "Abhishek", Age=25 }, // Inline initialization
                    s1, s2
                }
            };
        }

        

        public void XmlSerialization()
        {
            //for single list

            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using StringWriter writerSingle = new StringWriter();
            serializer.Serialize(writerSingle, list);
            Console.WriteLine(writerSingle.ToString());

            //This is for multiple 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using StringWriter writer  = new StringWriter();

            xmlSerializer.Serialize(writer, list);
            Console.WriteLine(writer.ToString());
        }


    }

    public class Student
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    public class StudentList
    {
        public List<Student>? Students { get; set; }
    }
}
