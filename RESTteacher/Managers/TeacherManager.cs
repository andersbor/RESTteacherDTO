using RESTteacher.Models;

namespace RESTteacher.Managers
{
    public class TeacherManager
    {
        private static int _nextId = 1;

        public static readonly List<Teacher> Data = new List<Teacher> {
          new Teacher() {Id = _nextId++, Name = "Anders", Salary = 1234},
          new Teacher() {Id = _nextId++, Name = "Brian", Salary = 10000},
          new Teacher() {Id = _nextId++, Name = "Carl", Salary = 4444}
        };

        public IEnumerable<Teacher> GetAll(string? name = null, int? minSalary = null, string? orderBy = null)
        {
            List<Teacher> result = Data;
            if (name != null) result = result.FindAll(teacher => teacher.Name.Contains(name));
            if (minSalary != null) result = result.FindAll(teacher => teacher.Salary >= minSalary);
            if (orderBy != null)
                switch (orderBy.ToLower())
                {
                    case "name": result = result.OrderBy(teacher => teacher.Name).ToList(); break;
                    case "salary": result = result.OrderBy(teacher => teacher.Salary).ToList(); break;
                }
            return result;
        }

        public Teacher? GetById(int id)
        {
            return Data.FirstOrDefault(teacher => teacher.Id == id);
        }

        public Teacher Add(Teacher teacher)
        {
            teacher.Id = _nextId++;
            Data.Add(teacher);
            return teacher;
        }

        public Teacher? Remove(int id)
        {
            Teacher? teacher = Data.FirstOrDefault(teacher => teacher.Id == id);
            if (teacher == null) return null;
            Data.Remove(teacher);
            return teacher;
        }
    }
}
