using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition_View.SQL_Class
{
    class PhotoContextFactory : IDbContextFactory<PhotoContext>
    {
        public PhotoContext Create()
        {
            return new PhotoContext("DefaultConnection");
        }
    }
}
