using System.ComponentModel.DataAnnotations.Schema;

namespace FranksBar.DataAccess.Entities
{
    public class Brewery
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<BreweryBeer> Beers { get; set; }
    }
}
