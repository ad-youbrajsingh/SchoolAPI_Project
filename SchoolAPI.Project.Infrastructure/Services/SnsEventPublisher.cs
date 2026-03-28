using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Infrastructure.Services;

public class SnsEventPublisher : IEventPublisher
{
    private readonly IAmazonSimpleNotificationService _sns;
    private readonly string _topicArn;

    public SnsEventPublisher(IAmazonSimpleNotificationService sns, IConfiguration config)
    {
        _sns = sns;
        _topicArn = config["AWS:SnsTopicArn"]!;

    }
    public async Task PublishStudentCreatedEvent(Student student)
    {
        var message = JsonSerializer.Serialize(student);

        var request = new PublishRequest
        {
            TopicArn = _topicArn,
            Message = message
        };

        await _sns.PublishAsync(request);
    }
}