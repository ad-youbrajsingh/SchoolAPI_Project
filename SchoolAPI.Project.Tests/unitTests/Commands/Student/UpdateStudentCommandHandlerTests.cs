using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Handlers.Commands;
using SchoolAPI.Project.Application.Interfaces;

namespace SchoolAPI.Project.Tests.unitTests.Commands.Student;

public class UpdateStudentCommandHandlerTests
{
    private readonly Mock<IStudentRepository> _mock;
    private readonly Mock<ILogger<UpdateStudentCommandHandler>> _logger;
    private readonly UpdateStudentCommandHandler _handler;

    public UpdateStudentCommandHandlerTests()
    {
        _mock = new Mock<IStudentRepository>();
        _logger = new Mock<ILogger<UpdateStudentCommandHandler>>();
        _handler = new UpdateStudentCommandHandler(_mock.Object, _logger.Object);
    }

    [Fact]
    public async Task Handle_Should_Update_Student()
    {
        // Given
        var studentId = new Guid();

        var command = new UpdateStudentCommand
        {
            Id = studentId,
            FirstName = "John",
            LastName = "Cena",
            Email = "john@gmail.com",
            DateOfBirth = new DateOnly(2003, 10, 02)
        };

        var existingStudent = new Domain.Entities.Student
        {
            Id = studentId,
            FirstName = "Old",
            LastName = "Name",
            Email = "old@gmail.com",
            DateOfBirth = new DateTime(1999, 1, 1)
        };

        _mock.Setup(x => x.GetStudentByIdAsync(studentId, It.IsAny<CancellationToken>())).ReturnsAsync(existingStudent);

        _mock.Setup(x => x.UpdateStudentAsync(It.IsAny<Domain.Entities.Student>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var result = await _handler.Handle(command, CancellationToken.None);

        existingStudent.FirstName.Should().Be("John");

        _mock.Verify(x => x.UpdateStudentAsync(It.IsAny<Domain.Entities.Student>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Throw_When_Student_Not_Found()
    {
        var studentId = new Guid();

        var command = new UpdateStudentCommand
        {
            Id = studentId,
            FirstName = "Updated",
            LastName = "Name",
            Email = "updated@gmail.com",
            DateOfBirth = new DateOnly(2000, 1, 1)
        };

        _mock.Setup(x => x.GetStudentByIdAsync(studentId, It.IsAny<CancellationToken>())).ReturnsAsync((Domain.Entities.Student)null!);

        Func<Task> act = async () => await _handler.Handle(command,CancellationToken.None);
        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

}