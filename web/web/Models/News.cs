using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class News
    {
        
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte id { get; set; }
        [Display(Name = "Заголовок")]
        [Required]
        [StringLength(100)]
        public string title { get; set; }
        [Display(Name = "Тело")]
        [Column(TypeName = "text")]
        [Required]
        public string body { get; set; }
        [Display(Name = "Дата создания")]
        [Column(TypeName = "date")]
        public DateTime date { get; set; }
    }
}
