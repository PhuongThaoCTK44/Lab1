using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
	public class DataSeeder : IDataSeeder
	{
		private readonly BlogDbContext _dbContext;
		public DataSeeder(BlogDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Initialize()
		{
			_dbContext.Database.EnsureCreated();
			if (_dbContext.Posts.Any()) return;
			var authors = AddAuthors();
			var categories = AddCategories();
			var tags = AddTags();
			var posts = AddPosts(authors, categories, tags);
		}
		private IList<Author> AddAuthors()
		{
			var authors = new List<Author>()
			{
				new()
				{
					FullName = "Jason Mouth",
					UrlSlug = "jason-mouth",
					Email ="json@gmail.com",
					JoinedDate = new DateTime(2022,10,21)
				},
				new()
				{
					FullName = "Le Petit Prince",
					UrlSlug = "Le-Petit-Prince",
					Email ="le@gmail.com",
					JoinedDate = new DateTime(2022,9,21)
				},
				new()
				{
					FullName = "LEtranger",
					UrlSlug = "letranger",
					Email ="letranger@gmail.com",
					JoinedDate = new DateTime(2022,8,21)
				},
				new()
				{
					FullName = "Les miserables",
					UrlSlug = "Les-miserables",
					Email ="les@gmail.com",
					JoinedDate = new DateTime(2022,7,21)
				},

				new()
				{
					FullName = "LAvare",
					UrlSlug = "lavare",
					Email ="lavare@gmail.com",
					JoinedDate = new DateTime(2022,6,21)
				}


			};
			_dbContext.Author.AddRange(authors);
			_dbContext.SaveChanges();

			return authors;
		}
		private IList<Category> AddCategories()
		{
			var categories = new List<Category>()
			{
				new() { Name = ".Net Core", Description = ".Net Core", UrlSlug = "net-core", ShowOnMenu = true },
				new() { Name = "Architecture", Description = "Architecture", UrlSlug = "architecture", ShowOnMenu = true },
				new() { Name = "Messaging", Description = "Messaging", UrlSlug = "messaging", ShowOnMenu = true },
				new() { Name = "OOP", Description = "OOP", UrlSlug = "oop", ShowOnMenu = true },
				new() { Name = "Design Patterns", Description = "Design Patterns", UrlSlug = "design-patterns", ShowOnMenu = true },
				new() { Name = "Portraiture", Description = "Portraiture", UrlSlug = "portraiture", ShowOnMenu = true },
				new() { Name = "Representation", Description = "Representation", UrlSlug = "representation", ShowOnMenu = true },
				new() { Name = "Narration", Description = "Narration", UrlSlug = "narration", ShowOnMenu = true },
				new() { Name = "Definition", Description = "Definition", UrlSlug = "definition", ShowOnMenu = true },
				new() { Name = "Procedure", Description = "Procedure", UrlSlug = "procedure", ShowOnMenu = true },
			};
			_dbContext.AddRange(categories);
			_dbContext.SaveChanges();
			return categories;
		}
		private IList<Tag> AddTags()
		{

			var tags = new List<Tag>()
			{
				new() { Name = "Google", Description = "Google applications", UrlSlug = "google-applications" },
				new() { Name = "ASP.NET MVC", Description = "ASP.NET MVC", UrlSlug = "asp.net-mvc" },
				new() { Name = "Razor Page", Description = "Razor Page", UrlSlug = "razor-page" },
				new() { Name = "Blazor", Description = "Blazor", UrlSlug = "blazor" },
				new() { Name = "Aria", Description = "Aria", UrlSlug = "aria" },
				new() { Name = "Acss", Description = "Acss", UrlSlug = "acss" },
				new() { Name = "Amp", Description = "Amp", UrlSlug = "amp" },
				new() { Name = "Api", Description = "Api", UrlSlug = "api" },
				new() { Name = "Bem", Description = "Bem", UrlSlug = "bem" },
				new() { Name = "Cdn", Description = "Cdn", UrlSlug = "cdn" },
				new() { Name = "Crud", Description = "Crud", UrlSlug = "crud" },
				new() { Name = "Cssom", Description = "Cssom", UrlSlug = "cssom" },
				new() { Name = "Cms", Description = "Cms", UrlSlug = "cms" },
				new() { Name = "Cta", Description = "Cta", UrlSlug = "cta" },
				new() { Name = "EcmaScript", Description = "EcmaScript", UrlSlug = "ecmaScript" },
				new() { Name = "Foss", Description = "Foss", UrlSlug = "foss" },
				new() { Name = "Ftu", Description = "Ftu", UrlSlug = "ftu" },
				new() { Name = "Gui", Description = "Gui", UrlSlug = "gui" },
				new() { Name = "Ide", Description = "Ide", UrlSlug = "ide" },
				new() { Name = "IIfe", Description = "IIfe", UrlSlug = "iife" },

			};
			_dbContext.AddRange(tags);
			_dbContext.SaveChanges();

			return tags;
		}
		private IList<Post> AddPosts(
		IList<Author> authors,
		IList<Category> categories,
		IList<Tag> tags)
		{
			var posts = new List<Post>()
			{
				new()
				{
					Title ="ASP.NET Core Diagnostic Scenarios",
					ShortDescription = "David and friends has a great repos",
					Description = "Here's a few great DON'T and DO examples",
					Meta = "David and friends has a great repos",
					UrlSlug = "aspnet-core-diagnostic-scenarios",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Lorem ipsum dolor sit amet",
					ShortDescription = " Maecenas imperdiet",
					Description = "Mauris ullamcorper dapibus est ac finibus",
					Meta = "Morbi ac ligula sagitti",
					UrlSlug = " metus-urna-scelerisque-ipsum",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title =" Sed ornare enim sit amet",
					ShortDescription = "Proin tempor in tellus et suscipit repos",
					Description = "Sed ac dictum nunc",
					Meta = "Sed ut ligula nec leoos",
					UrlSlug = "sit-amet-elit-sed-augue",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Mauris et vestibulum libero",
					ShortDescription = "Praesent id laoreet dui",
					Description = "Aliquam nunc erat",
					Meta = "Nulla eu pretium nisl",
					UrlSlug = "molestie-eu-est-pretium",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="ASP.NET Core Diagnostic Scenarios",
					ShortDescription = "David and friends has a great repos",
					Description = "Here's a few great DON'T and DO examples",
					Meta = "David and friends has a great repos",
					UrlSlug = "aspnet-core-diagnostic-scenarios",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="ASP.NET Core Diagnostic Scenarios",
					ShortDescription = "David and friends has a great repos",
					Description = "Here's a few great DON'T and DO examples",
					Meta = "David and friends has a great repos",
					UrlSlug = "aspnet-core-diagnostic-scenarios",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="ASP.NET Core Diagnostic Scenarios",
					ShortDescription = "David and friends has a great repos",
					Description = "Here's a few great DON'T and DO examples",
					Meta = "David and friends has a great repos",
					UrlSlug = "aspnet-core-diagnostic-scenarios",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title =" Nam sit amet finibus sem",
					ShortDescription = "Morbi placerat nibh lorem",
					Description = "Integer rhoncus porta est",
					Meta = "Nullam sagittis lectus ut blandit vestibulum",
					UrlSlug = "hendrerit-quis-quam-et",
					Published = true,
					PostedDate = new DateTime(2021,6,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Quisque vehicula efficitur",
					ShortDescription = "Morbi euismod mollis",
					Description = "Cras eleifend fringilla neque",
					Meta = "Morbi euismod mollis",
					UrlSlug = "eget-tincidunt-nulla-consectetur",
					Published = true,
					PostedDate = new DateTime(2021,5,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Maecenas viverra elit a justo suscipit",
					ShortDescription = "Quisque tincidunt massa in hendrerit",
					Description = "Cras sed nisl mauris",
					Meta = "Quisque tincidunt massa in hendrerit",
					UrlSlug = "est-sem-vehicula-velit",
					Published = true,
					PostedDate = new DateTime(2021,4,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Vestibulum rhoncus libero",
					ShortDescription = "Aenean iaculis tempor justo",
					Description = " Nullam luctus porttitor velit",
					Meta = "Aenean iaculis tempor justo",
					UrlSlug = "diam-vitae-pulvinar-facilisis",
					Published = true,
					PostedDate = new DateTime(2021,3,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Mauris pellentesque egestas diam",
					ShortDescription = "Vivamus hendrerit vestibulum",
					Description = "Morbi non urna ex",
					Meta = "Vivamus hendrerit vestibulum",
					UrlSlug = "eros-dui-sodales-tortor",
					Published = true,
					PostedDate = new DateTime(2021,2,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Ut sapien massa",
					ShortDescription = "Vivamus ullamcorper dolor",
					Description = "Orci varius natoque penatibus",
					Meta = "Vivamus ullamcorper dolor",
					UrlSlug = "ligula-tortor-volutpat-dui",
					Published = true,
					PostedDate = new DateTime(2021,1,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Donec eu dui nulla",
					ShortDescription = "Cras magna massa",
					Description = "Duis tempor vehicula risus",
					Meta = "Cras magna massa",
					UrlSlug = "nec-congue-diam-quam-eget-elit",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Orci varius natoque penatibus",
					ShortDescription = "Sed imperdiet lectus iaculis",
					Description = "Sed imperdiet lectus iaculis",
					Meta = "Sed imperdiet lectus iaculis",
					UrlSlug = "maximus-enim-sit-amet",
					Published = true,
					PostedDate = new DateTime(2021,8,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Suspendisse lacinia nibh non porta efficitur",
					ShortDescription = "Duis tempor vehicula risus",
					Description = "Praesent laoreet pulvinar augue",
					Meta = "Duis tempor vehicula risus",
					UrlSlug = "sit-amet-rutrum-nunc-auctor-convallis",
					Published = true,
					PostedDate = new DateTime(2021,7,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Nullam vel odio quis mi ultricies euismod",
					ShortDescription = "The passage experienced a surge in popularity",
					Description = "Today it's seen all around the web",
					Meta = "The passage experienced a surge in popularity",
					UrlSlug = "laying-out-pages-with-meaningless",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title =" In rhoncus turpis in neque volutpat",
					ShortDescription = "Use our generator to get your own",
					Description = "A practice not without controversy",
					Meta = "Use our generator to get your own",
					UrlSlug = "and-again-during-the-90s-as-desktop-publishers",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="As Cicero would put it",
					ShortDescription = "Consulting a Latin dictionary led",
					Description = "It's difficult to find examples of",
					Meta = "Consulting a Latin dictionary led",
					UrlSlug = " letter-by-letter-resetting",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Latin scholar from Hampden-Sydney College",
					ShortDescription = "McClintock's eye for detail certainly",
					Description = "So far he hasn't relocated where he once",
					Meta = "McClintock's eye for detail certainly",
					UrlSlug = "even-the-leap-into-electronic",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="As an alternative theory",
					ShortDescription = "Library Edition ran out of room on page",
					Description = "It's admittedly an odd way for Cicero",
					Meta = "Library Edition ran out of room on page",
					UrlSlug = "precisely-as-incoherent-in-English",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Whether a medieval typesetter",
					ShortDescription = "While another begins with the now ubiquitous",
					Description = "One brave soul did take a stab at translating",
					Meta = "While another begins with the now ubiquitous",
					UrlSlug = "whether-a-medieval-typesetter",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Here is the classic lorem ipsum passage",
					ShortDescription = "Twho may be, let him love fellows of a polecat",
					Description = "The desperate insistence on loving",
					Meta = "Twho may be, let him love fellows of a polecat",
					UrlSlug = "here-is-the-classic-lorem-ipsum-passage",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Now a pure snore disturbeded sum dust",
					ShortDescription = "Nick Richardson described the translation",
					Description = "That is cheated out of its justification ",
					Meta = "Nick Richardson described the translation",
					UrlSlug = "now-a-pure-snore-disturbeded-sum-dust",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="The French lettering company",
					ShortDescription = "Which later merged with Adobe Systems",
					Description = "Other word processors like Microsoft",
					Meta = "Which later merged with Adobe Systems",
					UrlSlug = "the-french-lettering-company",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="Some claim lorem ipsum threatens",
					ShortDescription = "The program came bundled with",
					Description = "More recently the growth of web design",
					Meta = "The program came bundled with ",
					UrlSlug = "Some-claim-lorem-ipsum-threatens",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="The strength of lorem ipsum is its weakness",
					ShortDescription = "To some designing a website around",
					Description = "What kills me here is that we’re talking about creating",
					Meta = "To some designing a website around",
					UrlSlug = "the-strength-of-lorem-ipsum-is-its-weakness",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="But despite zealous cries for the demise",
					ShortDescription = "Lorem Ipsum exists because words are powerful",
					Description = "If you fill up your page with draft copy",
					Meta = "Lorem Ipsum exists because words are powerful",
					UrlSlug = "But-despite-zealous-cries-for-the-demise",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="So when is it okay to use lorem ipsum",
					ShortDescription = "You don't want them wondering",
					Description = "Leveraging agile frameworks to provide",
					Meta = "You don't want them wondering",
					UrlSlug = "so-when-is-it-okay-to-use-lorem-ipsum",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				},
				new()
				{
					Title ="The same Wordpress template might eventually",
					ShortDescription = "Bacon ipsum dolor amet chicken",
					Description = "Fully unlicensed legalese for those times",
					Meta = "Bacon ipsum dolor amet chicken",
					UrlSlug = "the-same-Wordpress-template-might-eventually",
					Published = true,
					PostedDate = new DateTime(2021,9,30,10,20,0),
					ModifiedDate = null,
					ViewCount = 10,
					Author = authors[0],
					Category = categories[0],
					Tags = new List<Tag>()
					{
						tags[0]
					}
				}
			};

			_dbContext.AddRange(posts);
			_dbContext.SaveChanges();
			return posts;
		}
	}
}
