using Microsoft.EntityFrameworkCore;
using MyLoginPanel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoginPanel
{
    public static class GlobalVariables
    {
        public readonly static DbContextOptions<MyDbContext> Options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;
    }
}
