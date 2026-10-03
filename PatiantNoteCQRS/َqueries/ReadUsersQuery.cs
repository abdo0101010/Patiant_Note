using MediatR;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS._َqueries
{
    public class ReadUsersQuery:IRequest<List<User>>
    {
    }
}
