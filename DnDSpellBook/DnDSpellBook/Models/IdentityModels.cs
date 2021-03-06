﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity;

namespace DnDSpellBook.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Character> Characters { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Character> Characters { get; set; }

        public virtual DbSet<Spell> Spells { get; set; }

        public virtual DbSet<SpellList> SpellLists { get; set; }
        public ApplicationDbContext()
            : base("Spellbook", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}