using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_ef.DataContexts;

public class UserContext(DbContextOptions<UserContext> options) : IdentityDbContext(options)
{ 
}