using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AccessConst;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using Domain.Models.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class BasicInformationController : BaseController
    {
        private ILookupService _lookupService;
        private ITeamService _teamService;
        private ITeamDetailService _teamDetailService;
        private IUsersService _usersService;

        public BasicInformationController(ILookupService lookupService, ITeamService teamService, ITeamDetailService teamDetailService, IUsersService usersService)
        {
            _lookupService = lookupService;
            _teamService = teamService;
            _teamDetailService = teamDetailService;
            _usersService = usersService;
        }

        #region BasicInformation

        public IActionResult Index()
        {
            SelectedSideBar(AccessConst.BaseInfo);
            var data = _lookupService.GetAll();
            return View(data);
        }

        public IActionResult CreateInformation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInformation(Lookup model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateInformation");
            }

            bool HasInformation = _lookupService.HaslookupWithDescription(model.Description, model.Category);
            if (HasInformation)
            {
                NotifyError("اطلاعات تکراری می باشد");
                return View("CreateInformation");
            }


            _lookupService.AddLookup(model, User);

            NotifySuccess("با موفقیت ثبت شد");
            return RedirectToAction("Index");
        }

        //public IActionResult CreateUserTest()
        //{
        //    return View();
        //}
        //public ActionResult GetAccountList()
        //{


        //    return Json(data);
        //}

        public IActionResult DeleteLookup(int LookupId)
        {
            _lookupService.DeleteLookup(LookupId, User);

            var data = _lookupService.GetAll();

            return PartialView("_lookupGrid", data);
        }


        public IActionResult EditLookup(int LookupId)
        {
            var model = _lookupService.GetByLookupId(LookupId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditLookup(Lookup model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("EditLookup");
            }

            //bool HasUser = _usersService.HasUserWithUserName(model.UserName);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithNationalcode(model.NationalCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithPersonnelCode(model.PersonnelCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}

            _lookupService.Editlookup(model, User);

            NotifySuccess("با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }


        #endregion


        #region ProjectTeam

        public IActionResult TeamInformation()
        {
            SelectedSideBar(AccessConst.TeamInfo);

            var data = _teamService.GetAll();
            return View(data);
        }

        public IActionResult CreateTeam()
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            var model = new CreateTeamVM();
            model.Details = new List<TeamDetail>();
            model.Details.Add(null);

            return View(model);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamVM Model)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateTeam",Model);
            }

            if (string.IsNullOrEmpty(Model.Team.Name))
            {
                NotifyError("نام تیم را ثبت نمایید");
                return View("CreateTeam", Model);
            }
            if (string.IsNullOrEmpty(Model.Team.Description))
            {
                NotifyError("شرح فعالیت را ثبت نمایید");
                return View("CreateTeam", Model);
            }

            _teamService.AddTeam(Model.Team,User);

            if (Model.Details.Count > 0)
            {
                foreach (var item in Model.Details)
                {
                    if (item.UserId > 0 && !string.IsNullOrEmpty(item.Position))
                    {
                        item.TeamId = Model.Team.Id;
                        _teamDetailService.AddTeamDetail(item, User);
                    }
                }
            }

            NotifySuccess("با موفقیت ثبت گردید");

            return RedirectToAction("TeamInformation", "BasicInformation");
        }


        public IActionResult AddSubUser(CreateTeamVM Model)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            Model.Details.Add(null);

            return PartialView("_AddSubUser", Model);
        }


        public IActionResult DeleteTeam(int TeamId)
        {
            _teamService.DeleteTeam(TeamId, User);


            var data = _teamService.GetAll();

            return PartialView("_TeamGrid", data);
        }

        public IActionResult EditTeam(int TeamId)
        {
            var model = _teamService.GetTeamById(TeamId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTeam(Team Model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("EditTeam", Model);
            }
            if (string.IsNullOrEmpty(Model.Name))
            {
                NotifyError("نام تیم را ثبت نمایید");
                return View("EditTeam", Model);
            }
            if (string.IsNullOrEmpty(Model.Description))
            {
                NotifyError("شرح فعالیت را ثبت نمایید");
                return View("EditTeam", Model);
            }

            _teamService.UpdateTeam(Model, User);

            return RedirectToAction("TeamInformation", "BasicInformation");
        }

        public IActionResult ShowModal(int TeamId)
        {
            var model = _teamDetailService.GetAllByTeamId(TeamId) ;

            return PartialView("_ShowMemberModal", model);
        }


        public IActionResult DeleteMember(int TeamDetailId)
        {
            var Detail = _teamDetailService.GetByPk(TeamDetailId);
            _teamDetailService.DeleteMemberById(TeamDetailId,User);
            var model = _teamDetailService.GetAllByTeamId(TeamDetailId);

            return PartialView("_DeleteMember");
        }

        public IActionResult AddMemberModal(int TeamId)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            var model = new CreateTeamVM();
            model.Team = new Team();
            model.Team.Id = TeamId;
            model.Details = new List<TeamDetail>();
            model.Details.Add(null);
            //model.Details = _teamDetailService.GetAllItemsByTeamId(TeamId);

            return PartialView("_AddMemberModal",model);
        }



        public IActionResult FinalAddMember(CreateTeamVM Model)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            if (Model.Details.Count > 0)
            {
                foreach (var item in Model.Details)
                {
                    if (item.UserId > 0 && !string.IsNullOrEmpty(item.Position))
                    {
                        item.TeamId = Model.Team.Id;
                        _teamDetailService.AddTeamDetail(item, User);
                    }
                }
            }

            NotifySuccess("با موفقیت ثبت گردید");

            return PartialView("_AddMemberModal", Model);
        }

        #endregion



    }
}