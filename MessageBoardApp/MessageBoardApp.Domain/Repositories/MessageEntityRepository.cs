using AppApi.Domain.Abstractions;
using AppApi.Domain.Entities;

namespace AppApi.Domain.Repositories;

public interface IMessageEntityRepository :  IRepository<MessageEntity>
{
    // Intentionally empty
}