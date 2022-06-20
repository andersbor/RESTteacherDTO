namespace RESTteacher.Models
{
    public class Teacher
    {
        private string? name;
        private int salary;

        public Teacher() { }

        public Teacher(TeacherDTO value)
        {
            Name = value.Name;
            Salary = value.Salary;
        }

        public int Id { get; set; }
        public string? Name
        {
            get => name;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (value.Length < 4)
                    throw new ArgumentException("name must be at least 4 characters " + name);
                name = value;
            }
        }

        public int Salary
        {
            get => salary; set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Salary", value, "Salary must be at least 0");
                salary = value;
            }
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Salary;
        }
    }
}
