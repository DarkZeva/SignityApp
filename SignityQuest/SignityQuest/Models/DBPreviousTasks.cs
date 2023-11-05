using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SignityQuest.Models
{
    public class DBPreviousTasks
    {

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime todaysDate { get; set; }

        [Column(TypeName = "datetime")]

        public DateTime firstOccurrenceDate { get; set; }

        public int count { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime previousOccurenceDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime nextOccurrenceDate { get; set; }
    }
}
