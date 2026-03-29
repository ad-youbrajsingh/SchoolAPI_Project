using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Handlers.Commands;
using SchoolAPI.Project.Application.Interfaces;

namespace SchoolAPI.Project.Tests.unitTests.Commands.Student;

public class CreateStudentCommandHandlerTests
{
    private readonly Mock<IStudentRepository> _mock;
    private readonly Mock<ILogger<CreateStudentCommandHandler>> _loggerMock;
    private readonly Mock<IEventPublisher> _eventPublisherMock;
    private readonly CreateStudentCommandHandler _handler;

    public CreateStudentCommandHandlerTests()
    {
        _mock = new Mock<IStudentRepository>();
        _loggerMock = new Mock<ILogger<CreateStudentCommandHandler>>();
        _eventPublisherMock = new Mock<IEventPublisher>();
        _handler = new CreateStudentCommandHandler(_mock.Object, _loggerMock.Object, _eventPublisherMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Create_Student_and_create_Id()
    {
        var Command = new CreateStudentCommand
        {
            FirstName = "John",
            LastName = "Cena",
            Email = "john.cena@gmail.com",
            DateOfBirth = new DateOnly(2003, 10, 02)
        };

        Domain.Entities.Student createdStudent = null;

        _mock.Setup(x => x.AddStudentAsync( It.IsAny<Domain.Entities.Student>(), It.IsAny<CancellationToken>()))
                        .Callback<Domain.Entities.Student, CancellationToken>((student, token) =>
                        {
                            createdStudent = student;
                        })
                        .Returns(Task.CompletedTask);

        var result = await _handler.Handle(Command,CancellationToken.None);

        result.Should().Be(createdStudent.Id);
    }


}