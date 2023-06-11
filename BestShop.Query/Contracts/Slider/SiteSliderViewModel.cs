﻿namespace BestShop.Query.Contracts.Slider;

public class SiteSliderViewModel
{
    public long Id { get; set; }
    public string Heading { get;  set; }
    public string Title { get;  set; }
    public string Text { get;  set; }
    public string Picture { get;  set; }
    public string? Link { get;  set; }
    public string? LinkText { get;  set; }
    public string PictureAlt { get;  set; }
    public string PictureTitle { get;  set; }
    public string? BtnColorCode { get;  set; }
}