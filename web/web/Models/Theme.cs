namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theme")]
    public partial class Theme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Theme()
        {
            ThemeNotes1 = new HashSet<ThemeNote>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string body { get; set; }

        public int? Notes { get; set; }

        [Column(TypeName = "date")]
        public DateTime createDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? editingDate { get; set; }

        public int? ThemeNotes { get; set; }

        public byte? category { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThemeNote> ThemeNotes1 { get; set; }
    }
}
