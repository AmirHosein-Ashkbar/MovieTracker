using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Domain.Entities;
public class Movie
{
    public Guid Id { get; set; }
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int ReleaseYear { get; set; }

}
