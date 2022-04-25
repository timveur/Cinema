using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public partial class FilmsGenres
    {
        public string AllGenres => String.Join(",", Genres.NameGenre);
    }
}
