using Infrastructure.Model;

namespace WebService.Model.Entities
{
    public class Branch : IEntity
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        
        // Navigation Property
        
        public List<Teacher> Teachers { get; set; }
    }
}
