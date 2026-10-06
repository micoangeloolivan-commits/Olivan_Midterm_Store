using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Olivan_Midterm_Store.Models;

 

namespace Olivan_Midterm_Store.Data;

 

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)

{

    public DbSet<Product> Products { get; set; }

    public DbSet<CartItem> Cart_Items { get; set; }

}

 