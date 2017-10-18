namespace web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ThemeNote
    {
        public int id { get; set; }

        public byte Notes { get; set; }

        public int Theme { get; set; }

        public virtual Note Note { get; set; }

        public virtual Theme Theme1 { get; set; }
    }
}
