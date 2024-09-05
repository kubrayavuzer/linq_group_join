using linq_group_join;
class Program
{
    static void Main(string[] args)
    {
        List<students> student = new List<students>
        {
            new students {StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new students {StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new students {StudentId = 3, StudentName = "Mehmet", ClassId = 1},
            new students { StudentId = 4, StudentName = "Fatma", ClassId = 3},
            new students {StudentId = 5, StudentName = "Ahmet", ClassId = 2},
        };

        List<Class> classes = new List<Class>
        {

            new Class {ClassId = 1, ClassName = "Matematik"},
            new Class {ClassId =2, ClassName = "Türkçe"},
            new Class {ClassId = 3, ClassName = "Kimya"},

        };

        var groupJoin = from cls in classes
                        join std in student
                        on cls.ClassId equals std.StudentId into group_Join
                        select new
                        {
                            ClassName = cls.ClassName,
                            student = group_Join

                        };

        foreach (var group in groupJoin)
        {
            Console.WriteLine($"Sınıf: {group.ClassName}");

            foreach (var students in group.student)
            {

                Console.WriteLine($"Öğrenci: {students.StudentName}");
            }


        }
    }
}
