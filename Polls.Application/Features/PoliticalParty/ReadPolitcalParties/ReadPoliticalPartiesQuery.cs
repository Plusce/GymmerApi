using MediatR;

namespace Polls.Application.Features.PoliticalParty.ReadPolitcalParties;

public class ReadPoliticalPartiesQuery: IRequest<IEnumerable<string?>>
{
    
}