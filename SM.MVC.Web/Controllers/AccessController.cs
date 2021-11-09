using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Access;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class AccessController : BaseController
    {
        private IAccessGroupService _accessGroupService;
        private IAccessGroupDetailService _accessGroupDetailService;
        private IAccessService _accessService;

        public AccessController(IAccessGroupService accessGroupService, IAccessGroupDetailService accessGroupDetailService, IAccessService accessService)
        {
            _accessGroupService = accessGroupService;
            _accessGroupDetailService = accessGroupDetailService;
            _accessService = accessService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AccessGroups

        public IActionResult AccessGroups()
        {
            var data = _accessGroupService.GetAllGroups();
            return View(data);
        }

        public IActionResult CreateAccessGroup()
        {
            var model = new CreateAccesGroupVM();

            var AccessList = _accessService.GetAllNotUsedAccess();

            model.Accesses = new List<AccessVM>();
            if (AccessList.Any())
            {
                model.Accesses = AccessList;
            }
            else
            {
                model.Accesses.Add(null);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAccessGroup(CreateAccesGroupVM model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateAccessGroup", model);
            }

            if (string.IsNullOrEmpty(model.GroupName))
            {
                NotifyError("عنوان ثبت نگردیده است");
                return View("CreateAccessGroup", model);
            }

            var HasDuplicate = _accessGroupService.HasDuplicate(model.GroupName);
            if (HasDuplicate)
            {
                NotifyError("عنوان تکراری است");
                return View("CreateAccessGroup", model);
            }

            var Entity = new AccessGroup()
            {
                Name = model.GroupName
            };

            _accessGroupService.AddAccessGroup(Entity, User);


            var SelectedAccess = model.Accesses.Where(x => x.Selected);

            foreach (var Item in SelectedAccess)
            {
                _accessGroupDetailService.AddGroupDetail(new AccessGroupDetail()
                {
                    AccessGroupId = Entity.Id,
                    AccessId = Item.AccessId

                }, User);
            }



            NotifySuccess("با موفقیت ثبت گردید");
            return RedirectToAction("AccessGroups", "Access");
        }

        public IActionResult DeleteGroup(int Id)
        {
            _accessGroupService.DeleteGroup(Id, User);

            var data = _accessGroupService.GetAllGroups();

            return PartialView("_GroupGrid", data);
        }

        public IActionResult EditGroup(int Id)
        {
            var data = _accessGroupService.GetById(Id);

            var model = new CreateAccesGroupVM();

            model.GroupName = data.Name;
            model.AccessGroupId = data.Id;

            var NotUsedAccessList = _accessService.GetAllNotUsedAccess();
            var CurrentAccess = _accessService.GetAllCurrentAccessByGroupId(Id);

            var AllAccess = CurrentAccess.Union(NotUsedAccessList).ToList();

            model.Accesses = new List<AccessVM>();
            if (AllAccess.Any())
            {
                model.Accesses = AllAccess;
            }
            else
            {
                model.Accesses.Add(null);
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult EditGroup(CreateAccesGroupVM model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("EditGroup", model);
            }

            if (string.IsNullOrEmpty(model.GroupName))
            {
                NotifyError("عنوان ثبت نگردیده است");
                return View("EditGroup", model);
            }

            var HasDuplicate = _accessGroupService.HasDuplicate(model.GroupName);
            if (HasDuplicate)
            {
                NotifyError("عنوان تکراری است");
                return View("EditGroup", model);
            }

            var Entity = _accessGroupService.GetById(model.AccessGroupId);
            Entity.Name = model.GroupName;

            _accessGroupService.UpdateAccessGroup(Entity, User);


            var SelectedAccess = model.Accesses.Where(x => x.Selected);

            _accessGroupDetailService.DisableAllAccessByGroupId(model.AccessGroupId, User);

            foreach (var Item in SelectedAccess)
            {
                _accessGroupDetailService.AddGroupDetail(new AccessGroupDetail()
                {
                    AccessGroupId = Entity.Id,
                    AccessId = Item.AccessId

                }, User);
            }



            NotifySuccess("با موفقیت ویرایش گردید");
            return RedirectToAction("AccessGroups", "Access");
        }


        #endregion

        #region MyRegion

        public IActionResult UserAccessModal(int UserId)
        {
            var AccessGroups = _accessGroupService.GetAllGroups();
            var model = new List<UserAccessVN>();

            foreach (var item in AccessGroups)
            {
                var Details = _accessGroupDetailService.GetAllDetailByGroupId(item.Id);

                model.Add(new UserAccessVN()
                {
                    AccessGroup = item,
                    AccessGroupDetails = Details
                });

            }


            return PartialView("_UserAccessModal",model);
        }



        #endregion
    }
}
