using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegDetails.Model
{
    [Table("attachments")]
    public class AttachmentModel
    {
        [Key]

        public int AttachmentId { get; set; }
        [MaxLength(100)]
        public string AttachmentName { get; set; }
        [MaxLength(100)]
        public string AttachmentType { get; set; }
        [MaxLength(500)]
        public string AttachmentPath { get; set; }

    }
}
