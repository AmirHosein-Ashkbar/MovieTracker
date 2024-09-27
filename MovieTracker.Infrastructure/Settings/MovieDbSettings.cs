using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Infrastructure.Settings;
public class MovieDbSettings
{
    public static readonly string Name = "MovieDbSettings";
    public string BaseUrl { get; set; }
    public string Token { get; set; }
    public string ImageBaseUrl { get; set; }
}
