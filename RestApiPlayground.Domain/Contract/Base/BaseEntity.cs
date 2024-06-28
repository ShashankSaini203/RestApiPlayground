using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiPlayground.Domain.Contract.Base
{
    public class BaseEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public BaseEntity()
        {
            this.ModifiedDate = DateTime.Now;
        }
    }
}
