using _0_Framework.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureALt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }
        public Slide(string link,string picture, string pictureALt, string pictureTitle, string heading, string title, string text, string btnText)
        {
            Link = link;
            Picture = picture;
            PictureALt = pictureALt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;  
            IsRemoved = false;
        }

        public void Edit(string link,string picture, string pictureALt, string pictureTitle, string heading, string title, string text, string btnText)
        {
            Link = link;
            Picture = picture;
            PictureALt = pictureALt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }

}
