using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal
{
    public class SzuroMemoDbContext: DbContext
    {
        #region Constructor

        public SzuroMemoDbContext(DbContextOptions options): base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<Screening> Screenings { get; set; }

        #endregion
    }
}
