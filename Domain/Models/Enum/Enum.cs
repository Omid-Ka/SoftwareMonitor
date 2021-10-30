using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public enum PartnerTeam
    {
        [Description("مدیریت")]
        Manager = 1,
        [Description("توسعه دهنده")]
        Developer = 2,
        [Description("گزارشگر")]
        Reporter = 3,
        [Description("امنیت")]
        Security = 4,
        [Description("مرکز داده")]
        DataCenter = 5,
        [Description("Meli_OP_Ctrl")]
        Meli_OP_Ctrl = 6,
        [Description("مدیر توسعه دهنده")]
        DeveloperManager = 7,
        [Description("PmsOpt")]
        PmsOpt = 8,
        [Description("کنترل و تضمین کیفیت نرم افزار")]
        SQCA = 9,
        [Description("پشتیبانی نرم افزار")]
        SoftwareSupport = 10,
        [Description("PMO")]
        PMO = 11,
        [Description("مشاور")]
        Advisor = 12,
        [Description("اسناد ارتباطی")]
        CommunicationDocumentation = 13,
        [Description("ESB_Support")]
        ESB_Support = 14
    }
}
