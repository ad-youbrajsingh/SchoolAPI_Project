using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Interfaces;

public interface IEventPublisher
{
    Task PublishStudentCreatedEvent(Student Student);
}