namespace SchoolAPI.Project.Application.Dtos.student;

public class StudentResponseDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int Age { get; set; }
}