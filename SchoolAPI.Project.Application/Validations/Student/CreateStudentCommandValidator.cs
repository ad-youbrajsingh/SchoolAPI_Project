using FluentValidation;
using SchoolAPI.Project.Application.Commands.Student;

namespace SchoolAPI.Project.Application.Validations.Student;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is Mandatory!")
            .MaximumLength(50);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is Mandatory!")
            .MaximumLength(50);
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is Mandatory!")
            .MaximumLength(50);
        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("DateOfBirth is Mandatory!")
            .LessThan(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Date of Birth must be in past!");
    }
}