using GraphQL.Types;
using StarWars.Core.Data;

namespace StarWars.Core.Models
{
    public class StarWarsQuery : ObjectGraphType
    {
        private IDroidRepository _droidRepository { get; set; }

        public StarWarsQuery(IDroidRepository droidRepository)
        {
            Field<DroidType>(
                "hero",
                resolve: context => droidRepository.Get(1)
            );
        }
    }
}
