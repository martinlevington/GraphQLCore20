using GraphQL.Types;

namespace StarWars.Core.Models
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id).Description("The Id of the Droid");
            Field(x => x.Name, nullable: true).Description("The Name of the Droid.");
        }
    }
}
