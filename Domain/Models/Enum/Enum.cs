using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Enum
{
    public enum UserLogType
    {
        [Description("ورود")]
        Enter = 1,
        [Description("خروج")]
        Exit = 2
    }
    public enum LookupCategory
    {
        [Display(Name = "جنسیت")]
        [Description("جنسیت")]
        Gender = 1,
        [Display(Name = "پست سازمانی")]
        [Description("پست سازمانی")]
        Post = 2
    }

    public enum PartnerTeam
    {
        [Display(Name = "مدیریت")]
        [Description("مدیریت")]
        Manager = 1,
        [Display(Name = "توسعه دهنده")]
        [Description("توسعه دهنده")]
        Developer = 2,
        [Display(Name = "گزارشگر")]
        [Description("گزارشگر")]
        Reporter = 3,
        [Display(Name = "امنیت")]
        [Description("امنیت")]
        Security = 4,
        [Display(Name = "مرکز داده")]
        [Description("مرکز داده")]
        DataCenter = 5,
        [Display(Name = "Meli_OP_Ctrl")]
        [Description("Meli_OP_Ctrl")]
        Meli_OP_Ctrl = 6,
        [Display(Name = "مدیر توسعه دهنده")]
        [Description("مدیر توسعه دهنده")]
        DeveloperManager = 7,
        [Display(Name = "PmsOpt")]
        [Description("PmsOpt")]
        PmsOpt = 8,
        [Display(Name = "کنترل و تضمین کیفیت نرم افزار")]
        [Description("کنترل و تضمین کیفیت نرم افزار")]
        SQCA = 9,
        [Display(Name = "پشتیبانی نرم افزار")]
        [Description("پشتیبانی نرم افزار")]
        SoftwareSupport = 10,
        [Display(Name = "PMO")]
        [Description("PMO")]
        PMO = 11,
        [Display(Name = "مشاور")]
        [Description("مشاور")]
        Advisor = 12,
        [Display(Name = "اسناد ارتباطی")]
        [Description("اسناد ارتباطی")]
        CommunicationDocumentation = 13,
        [Display(Name = "ESB_Support")]
        [Description("ESB_Support")]
        ESB_Support = 14
    }
}
