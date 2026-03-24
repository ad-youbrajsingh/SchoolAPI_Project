namespace SchoolAPI.Project.Application.Dtos.student;

public class CreateStudentRequestDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}