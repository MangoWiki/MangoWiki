using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangoWiki.Models
{
    /// <summary>
    /// The actor table associates usernames or IP addresses with integers for
    /// the benefit of other tables that need to refer to either logged-in or
    /// logged-out users. If something can only ever be done by logged-in users, it
    /// can refer to the user table directly.
    /// </summary>
    [Table("actor")]
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Guid UserID { get; set; }

        public string ActorName { get; set; }
    }
}
