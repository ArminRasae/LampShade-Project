using _01_LampShadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
           return _shopContext.Slides
                .Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Picture = x.Picture,
                    PictureALt = x.PictureALt,
                    PictureTitle = x.PictureTitle,
                    Heading = x.Heading,
                    Text = x.Text,
                    Title = x.Title,
                    BtnText = x.BtnText,
                    Link = x.Link,
                    
                }).ToList();
        }
    }
}
