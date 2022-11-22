using Entities.Abstract;


namespace Entities.Concrate
{
    public class Tourniquet : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}