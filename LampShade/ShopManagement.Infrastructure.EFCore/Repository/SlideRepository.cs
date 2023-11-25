
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlideCommand GetDetailsBy(long id)
        {
           var query = _context.Slides
                .Select(x => new EditSlideCommand
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureTitle = x.PictureTitle,
                    PictureAlt = x.PictureALt,
                    Heading = x.Heading,
                    Text = x.Text,
                    Title = x.Title,
                    BtnText = x.BtnText,
                    Link = x.Link,

                })
                .FirstOrDefault(x => x.Id == id);

           return query;

        }

        public List<SlideViewModelCommand> GetList()
        {
            var query = _context.Slides
                .Select(x => new SlideViewModelCommand
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    Heading = x.Heading,
                    Title = x.Title,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToFarsi(),

                    
                });

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
