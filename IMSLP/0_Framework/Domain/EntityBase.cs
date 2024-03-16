namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            this.CreationDate = DateTime.Now;
        }

    }
}
