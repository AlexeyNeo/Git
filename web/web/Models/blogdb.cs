namespace web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class blogdb : DbContext
    {
        public blogdb()
            : base("name=Blogdb")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<ThemeNote> ThemeNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Themes)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.category);

            modelBuilder.Entity<News>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .HasMany(e => e.ThemeNotes)
                .WithRequired(e => e.Note)
                .HasForeignKey(e => e.Notes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Theme>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Theme>()
                .Property(e => e.body)
                .IsUnicode(false);

            modelBuilder.Entity<Theme>()
                .HasMany(e => e.ThemeNotes1)
                .WithRequired(e => e.Theme1)
                .HasForeignKey(e => e.Theme)
                .WillCascadeOnDelete(false);
        }
    }
}
