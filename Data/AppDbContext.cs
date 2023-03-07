using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CharacterCreator.Models;

namespace CharacterCreator.Data {
	public class AppDbContext : IdentityDbContext {
		public AppDbContext(DbContextOptions options) : base(options) {}

		// This is where we can put in models we want to turn into tables for the DB
		// If you add or remove something here add a migration (Add-Migration "") and then update the DB (Update-Database)
		public DbSet<Accounts> Accounts { get; set; }
		public DbSet<Character> Characters { get; set; }
	}
}