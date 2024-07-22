using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.Configuration.MusicConfiguration;

namespace MusicSchool.Service
{
    internal class MusicSchoolService
    {
        public static void CreateXmlIfNotExist()
        {
            if (!File.Exists(musicSchoolPath))
            {
                XDocument document = new();
                XElement musicScool = new ("music-school");
                document.Add(musicScool);
                document.Save(musicSchoolPath);
                

            }

        }
        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? musicScool = document.Descendants("music-school")
                .FirstOrDefault();
            if (musicScool == null)
            {
                return;
            }
            XElement classRoom = new XElement("class-room",
               new XAttribute("name", classRoomName)
            );
            musicScool.Add(classRoomName);
            document.Save(musicSchoolPath);
               

        }
        public static void AddTecher(string classRoomName, string techerName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (classRoom == null)
            {
                return;
            }
            XElement? techer = new XElement("Techaer",
                new XAttribute("name", techerName));
            classRoom.Add(techerName);
            document.Save(musicSchoolPath);

        }
        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            XDocument document = XDocument.Load (musicSchoolPath);
            XElement? classRoom = (from room in document.Descendants("class-room")
                                  where room.Attribute("name")?.Value == classRoomName
                                  select room
                                  ).FirstOrDefault();
            if (classRoom == null) { return; }

            XElement? instrument = new("instrument", instrumentName);
            XAttribute studentAttribute = new ("name", studentName);
            XElement student = new("student", studentAttribute, instrument);

            student.SetAttributeValue("name", "jon");
            instrument.Value = "piano";
            student.ReplaceWith(new XElement("zcczzcz", ""));


            classRoom.Add(student);
            document.Save(musicSchoolPath);
        }
/*        List<Student>[] Students;
*//*        public static XElement ConvertStudentToElement(Student, Students) => 
*/        
        /*public static void AddManyStudents(string classRoomName, params Students [] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (classRoom == null) { return; };
            List<XElement> studentList = students
                .Select(ConvertStudentToElement)
                .ToList();

        }*/
    }
}
