using Framework.SharedDomain;

namespace SliderManagment.Domains.Agg.Slider;

public class Slider:BaseEntity
{
    public string Heading { get; private set; }
    public string Title { get; private set; }
    public string Text { get; private set; }
    public string Picture { get; private set; }
    public string? Link { get; private set; }
    public string? LinkText { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string? BtnColorCode { get; private set; }

    public Slider()
    {
        IsRemove = false;
    }
    public Slider(string heading, string title, string text, string picture, string? link, string? linkText, string pictureAlt, string pictureTitle, string? btnColorCode)
    {
        Heading = heading;
        Title = title;
        Text = text;
        Picture = picture;
        Link = link;
        LinkText = linkText;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        BtnColorCode = btnColorCode;
    }
    public void Edit(string heading, string title, string text, string picture, string? link, string? linkText, string pictureAlt, string pictureTitle, string? btnColorCode) {
        Heading = heading;
        Title = title;
        Text = text;
        Picture = picture;
        Link = link;
        LinkText = linkText;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        BtnColorCode = btnColorCode;
    }

    public void Remove()
    {
        IsRemove = true;
    }
    public void Restore() {
        IsRemove = false;
    }
}