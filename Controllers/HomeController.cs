using Microsoft.AspNetCore.Mvc;
using VoraFilms.Models;
using System.Diagnostics;

namespace VoraFilms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var featuredWork = new List<PortfolioItem>
            {
                new PortfolioItem { 
                    Title = "Traditional Gujarati Wedding", 
                    Category = "Wedding", 
                    ImageUrl = "/images/wedding-gujarati.jpg",
                    Location = "Ahmedabad"
                },
                new PortfolioItem { 
                    Title = "Punjabi Wedding Ceremony", 
                    Category = "Wedding", 
                    ImageUrl = "/images/wedding-punjabi.jpg",
                    Location = "Delhi"
                },
                new PortfolioItem { 
                    Title = "South Indian Traditional", 
                    Category = "Wedding", 
                    ImageUrl = "/images/wedding-south.jpg",
                    Location = "Chennai"
                }
            };
            
            ViewBag.FeaturedWork = featuredWork;
            return View();
        }

        public IActionResult About()
        {
            var teamMembers = new List<TeamMember>
            {
                new TeamMember { 
                    Name = "Rajesh Vora", 
                    Position = "Founder & Lead Photographer",
                    Experience = "12+ Years",
                    Specialization = "Wedding Photography",
                    Bio = "Passionate about capturing authentic Indian wedding moments"
                },
                new TeamMember { 
                    Name = "Priya Sharma", 
                    Position = "Senior Photographer",
                    Experience = "8+ Years", 
                    Specialization = "Candid & Portrait",
                    Bio = "Expert in capturing emotional moments and traditional ceremonies"
                }
            };
            
            ViewBag.TeamMembers = teamMembers;
            return View();
        }

        public IActionResult Services()
        {
            var services = new List<PhotographyService>
            {
                new PhotographyService {
                    Name = "Complete Wedding Package",
                    Description = "Full coverage of your wedding events",
                    Price = "₹75,000",
                    Features = new List<string> {
                        "Pre-wedding Shoot", "All Ceremonies Coverage", "1000+ Edited Photos", 
                        "Premium Album", "Cinematic Video", "Drone Coverage"
                    }
                },
                new PhotographyService {
                    Name = "Engagement Shoot",
                    Description = "Beautiful couple photography",
                    Price = "₹15,000",
                    Features = new List<string> {
                        "2 Hours Session", "2 Outfits", "50 Edited Photos", 
                        "Online Gallery", "Print Release"
                    }
                }
            };
            
            ViewBag.Services = services;
            return View();
        }

        public IActionResult Portfolio()
        {
            var portfolioItems = GetPortfolioItems();
            ViewBag.PortfolioItems = portfolioItems;
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Here you would typically:
                    // 1. Save to database
                    // 2. Send email notification
                    // 3. Send confirmation to client
                    
                    _logger.LogInformation($"New contact form submission from {model.Name}");
                    
                    TempData["SuccessMessage"] = "धन्यवाद! We've received your message and will contact you within 24 hours.";
                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing contact form");
                    ModelState.AddModelError("", "An error occurred while sending your message. Please try again.");
                }
            }
            
            return View(model);
        }

        public IActionResult IndianWeddings()
        {
            var weddingStyles = new List<WeddingStyle>
            {
                new WeddingStyle {
                    Name = "Punjabi Wedding",
                    Description = "Vibrant and colorful celebrations",
                    ImageUrl = "/images/punjabi-wedding.jpg",
                    Traditions = new List<string> { "Sangeet", "Mehndi", "Anand Karaj" }
                },
                new WeddingStyle {
                    Name = "South Indian Wedding",
                    Description = "Traditional and elegant ceremonies", 
                    ImageUrl = "/images/south-wedding.jpg",
                    Traditions = new List<string> { "Muhurtham", "Kashi Yatra", "Saptapadi" }
                }
            };
            
            ViewBag.WeddingStyles = weddingStyles;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<PortfolioItem> GetPortfolioItems()
        {
            return new List<PortfolioItem>
            {
                new PortfolioItem { Title = "Mehndi Ceremony", Category = "Wedding", ImageUrl = "/images/mehndi.jpg" },
                new PortfolioItem { Title = "Sangeet Night", Category = "Wedding", ImageUrl = "/images/sangeet.jpg" },
                new PortfolioItem { Title = "Haldi Function", Category = "Wedding", ImageUrl = "/images/haldi.jpg" },
                new PortfolioItem { Title = "Corporate Event", Category = "Commercial", ImageUrl = "/images/corporate.jpg" },
                new PortfolioItem { Title = "Baby Photography", Category = "Portrait", ImageUrl = "/images/baby.jpg" }
            };
        }
    }

    public class PortfolioItem
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
    }

    public class TeamMember
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
    }

    public class PhotographyService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public List<string> Features { get; set; }
    }

    public class WeddingStyle
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Traditions { get; set; }
    }
}