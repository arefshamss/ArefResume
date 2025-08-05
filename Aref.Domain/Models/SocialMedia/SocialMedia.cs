using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.SocialMedia;

    public class SocialMedia:BaseEntity<short>
    {
        public required string Title { get; set; }
    
        public required string Link { get; set; }
    
        public string IconName { get; set; }
        
        public bool IsVisible { get; set; }
        
        public short DisplayPriority { get; set; }
    }