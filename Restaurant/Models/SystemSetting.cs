using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class SystemSetting :BaseEntity
{

    [Display(Name ="id")]
    public int SystemSettingId { get; set; }
    [Display(Name = "Logo")]
    public string SystemSettingLogoImageUrl { get; set; } = null!;
    [Display(Name = "logo2")]
    public string SystemSettingLogoImageUrl2 { get; set; } = null!;
    [Display(Name = "Copy Right")]
    public string SystemSettingCopyright { get; set; } = null!;
    [Display(Name = "Title")]
    public string SystemSettingWelcomeNoteTitle { get; set; } = null!;
    [Display(Name = "Welcom note Breef")]
    public string SystemSettingWelcomeNoteBreef { get; set; } = null!;
    [Display(Name = "welcom Description")]
    public string SystemSettingWelcomeNoteDesc { get; set; } = null!;
    [Display(Name = "welcom Url")]
    public string SystemSettingWelcomeNoteUrl { get; set; } = null!;
    [Display(Name = "welcom image")]
    public string SystemSettingWelcomeNoteImageUrl { get; set; } = null!;
    [Display(Name = "Map")]
    public string SystemSettingMapLocation { get; set; } = null!;
    [Display(Name = "Contact Map")]
    public string ContactUsLocation { get; set; } = null!;
    [Display(Name = "Phone")]
    public string ContactUsPhone { get; set; } = null!;
    [Display(Name = "Contact Email")]
    public string ContactUsEmail { get; set; } = null!;






}
