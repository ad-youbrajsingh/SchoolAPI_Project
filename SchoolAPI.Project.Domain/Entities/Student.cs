namespace SchoolAPI.Project.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if(DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
