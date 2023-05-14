namespace FranksBar.DataAccess.Entities
{
    public class BreweryBeer
    {
        public Guid Id { get; set; }

        public Guid BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }

        public Guid BeerId { get; set; }

        public virtual Beer Beer { get; set; }
    }
}
