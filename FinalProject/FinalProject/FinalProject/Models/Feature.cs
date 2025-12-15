using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
        public ICollection<EventFeature> EventFeatures { get; set; } = new List<EventFeature>();
    }
}
