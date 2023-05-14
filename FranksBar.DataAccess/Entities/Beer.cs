using System.ComponentModel.DataAnnotations.Schema;

namespace FranksBar.DataAccess.Entities
{
    public class Beer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal PercentageAlcoholByVolume { get; set; }

        public virtual ICollection<BarBeer> BarBeers { get; set; }

        //public virtual ICollection<Brewery> Breweries { get; set; }
    }
}
