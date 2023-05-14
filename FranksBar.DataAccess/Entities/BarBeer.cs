namespace FranksBar.DataAccess.Entities
{
    public class BarBeer
    {
        public Guid Id { get; set; }

        public Guid BarId { get; set; }

        public virtual Bar Bar { get; set; }

        public Guid BeerId { get; set; }

        public virtual Beer Beer { get; set; }
    }
}
