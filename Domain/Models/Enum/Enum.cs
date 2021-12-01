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
        Post = 2,
        [Display(Name = "تست های نرم افزاری")]
        [Description("تست های نرم افزاری")]
        Test = 3,
        [Display(Name = "شاخص های بررسی کد")]
        [Description("شاخص های بررسی کد")]
        Indicator = 4
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


    public enum TestType
    {
        [Display(Name = "عملکردی")]
        [Description("عملکردی")]
        Finctional = 1,
        [Display(Name = "غیر عملکردی")]
        [Description("غیر عملکردی")]
        Non_Finctional = 2

    }


    public enum CodeReviewDetailType
    {
        [Display(Name = "خوانایی کد")]
        [Description("خوانایی کد")]
        Readability = 1,
        [Display(Name = "شی گرایی")]
        [Description("شی گرایی")]  
        ObjectOriented = 2,
        [Display(Name = "ایمنی کد")]
        [Description("ایمنی کد")]
        CodeSecurity = 3,
        [Display(Name = "استفاده از منابع")]
        [Description("استفاده از منابع")]
        UseOfResources = 4,
        [Display(Name = "شاخص های پیچیدگی")]
        [Description("شاخص های پیچیدگی")]
        Complexity = 5,
        [Display(Name = "هشدارهای IDE")]
        [Description("هشدارهای IDE")]
        Warning = 6

    }


    public enum DocReviewTitle
    {
        [Display(Name = "نمودار توالی")]
        [Description("نمودار توالی")]
        SequenceDiagram = 1,

        [Display(Name = "نمودار فعالیت")]
        [Description("نمودار فعالیت")]
        ActivityDiagram = 2,

        [Display(Name = "نمودار کاربرد")]
        [Description("نمودار کاربرد")]
        ApplicationDiagram = 3,

        [Display(Name = "نمودار کلاس")]
        [Description("نمودار کلاس")]
        ClassDiagram = 4,

        [Display(Name = "ماژول ها")]
        [Description("ماژول ها")]
        Modules = 5,

        [Display(Name = "شرح فعالیت")]
        [Description("شرح فعالیت")]
        ActivityDescription = 6
    }

    public enum DocReviewAnswer
    {

        [Display(Name = "کامل")]
        [Description("کامل")]
        Complete = 1,

        [Display(Name = "ناقص")]
        [Description("ناقص")]
        Incomplete = 2,

        [Display(Name = "ندارد")]
        [Description("ندارد")]
        Less = 3
    }


    public enum VersionStatus
    {
        [Display(Name = "باز")]
        [Description("باز")]
        Open = 1,

        [Display(Name = "بسته")]
        [Description("بسته")]
        Close = 2
    }

    public enum AttachmentType
    {
        [Display(Name = "نمودار توالی")]
        [Description("نمودار توالی")]
        SequenceDiagram = 1,

        [Display(Name = "نمودار فعالیت")]
        [Description("نمودار فعالیت")]
        ActivityDiagram = 2,

        [Display(Name = "نمودار کاربرد")]
        [Description("نمودار کاربرد")]
        ApplicationDiagram = 3,

        [Display(Name = "نمودار کلاس")]
        [Description("نمودار کلاس")]
        ClassDiagram = 4,

        [Display(Name = "ماژول ها")]
        [Description("ماژول ها")]
        Modules = 5,

        [Display(Name = "شرح فعالیت")]
        [Description("شرح فعالیت")]
        ActivityDescription = 6,

        [Display(Name = "مرور سند")]
        [Description("مرور سند")]
        DocReview = 7,

        [Display(Name = "مرور کد")]
        [Description("مرور کد")]
        CodeReview = 8,

        [Display(Name = "آزمون فشار")]
        [Description("آزمون فشار")]
        StressTest = 9,

        [Display(Name = "آزمون بار")]
        [Description("آزمون بار")]
        LoadTest = 10,

        [Display(Name = "سایر")]
        [Description("سایر")]
        Other = 11
    }


}
