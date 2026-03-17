using System;
using System.Collections.Generic;
using MarksList.Models;
using Microsoft.EntityFrameworkCore;

namespace MarksList.Data;

public partial class MarksContext : DbContext
{
    public MarksContext()
    {
    }

    public MarksContext(DbContextOptions<MarksContext> options) : base(options)
    {
    }

    public virtual DbSet<Marks> Marks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marks>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}