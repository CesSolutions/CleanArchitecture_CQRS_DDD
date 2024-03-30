using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Infrastructure.EF.Contexts
{
internal class DbContextFactory : IDesignTimeDbContextFactory<ReadDbContext>
{
    public ReadDbContext CreateDbContext(string[] args)
    {
        var option = new DbContextOptionsBuilder<ReadDbContext>();
        option.UseSqlServer("Data source=.; Initial Catalog=Traveler; Integrated Security=True");
        return new ReadDbContext(option.Options);
    }
}
}
