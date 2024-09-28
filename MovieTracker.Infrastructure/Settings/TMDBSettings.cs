using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Infrastructure.Settings;
public class TMDBSettings
{
    public static readonly string Name = "TMDBSettings";
    public string BaseUrl { get; set; }
    public string Token { get; set; }
    public string ImageBaseUrl { get; set; }
}
