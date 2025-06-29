﻿using Microsoft.EntityFrameworkCore;
using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Configuration;



namespace WebStudio.Application_core.Database_Context;



public class RepositoryContext:DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Employee> Employees { get; set; }
}
