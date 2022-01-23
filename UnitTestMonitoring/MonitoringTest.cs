using Core.Interfaces;
using Core.Services;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SM.MVC.Web.Controllers;

namespace UnitTestMonitoring
{
    [TestClass]
    public class MonitoringTest
    {
        //private IAccessGroupService _accessGroupService;
        //private IAccessGroupDetailService _accessGroupDetailService;
        //private IAccessService _accessService;
        //private IUserAccessService _userAccessService;
        //private IProjectService _projectService;
        //private IProjectUsersRelationService _projectUsersRelationService;

        //public MonitoringTest(IAccessGroupService accessGroupService, IAccessGroupDetailService accessGroupDetailService, IAccessService accessService, IUserAccessService userAccessService, IProjectService projectService, IProjectUsersRelationService projectUsersRelationService)
        //{
        //    _accessGroupService = accessGroupService;
        //    _accessGroupDetailService = accessGroupDetailService;
        //    _accessService = accessService;
        //    _userAccessService = userAccessService;
        //    _projectService = projectService;
        //    _projectUsersRelationService = projectUsersRelationService;
        //}


        [TestMethod]
        public void AccessTest()
        {

            var _accessGroupService = new Mock<IAccessGroupService>();
            var _accessGroupDetailService = new Mock<IAccessGroupDetailService>();
            var _accessService = new Mock<IAccessService>();
            var _userAccessService = new Mock<IUserAccessService>();
            var _projectService = new Mock<IProjectService>();
            var _projectUsersRelationService = new Mock<IProjectUsersRelationService>();


            //Arrange
            AccessController controller = new AccessController(_accessGroupService.Object,
                _accessGroupDetailService.Object, _accessService.Object, _userAccessService.Object,
                _projectService.Object, _projectUsersRelationService.Object);

            // Act
            ViewResult result = controller.AccessGroups() as ViewResult;


            //Assert
            Assert.IsNotNull(result);


        }


        [TestMethod]
        public void AccountTest()
        {

            var _UsersService = new Mock<IUsersService>();
            var _LookupService = new Mock<ILookupService>();
            var _UserLogService = new Mock<IUserLogService>();
            var _ProjectService = new Mock<IProjectService>();


            //Arrange
            AccountController controller = new AccountController(_UsersService.Object, _LookupService.Object,
                _UserLogService.Object, _ProjectService.Object);

            // Act
            ViewResult result = controller.CreateUser() as ViewResult;


            //Assert
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void AdminTest()
        {
            //Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void BasicInformationTest()
        {

            var _TeamService = new Mock<ITeamService>();
            var _LookupService = new Mock<ILookupService>();
            var _TeamDetailService = new Mock<ITeamDetailService>();
            var _UsersService = new Mock<IUsersService>();

            //Arrange
            BasicInformationController controller =
                new BasicInformationController(_LookupService.Object , _TeamService.Object , _TeamDetailService.Object, _UsersService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CommentTest()
        {

            var projectService = new Mock<IProjectService>();
            var projectCommentService = new Mock<IProjectCommentService>();
            var projectVersionService = new Mock<IProjectVersionService>();
            var usersService = new Mock<IUsersService>();
            var notificationService = new Mock<INotificationService>();

            //Arrange
            CommentController controller = new CommentController( projectService.Object ,
                 projectCommentService.Object, projectVersionService.Object,
                 usersService.Object, notificationService.Object);

            // Act
            ViewResult result = controller.Comments() as ViewResult;


            //Assert
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void HomeTest()
        {
        }


        [TestMethod]
        public void LoginTest()
        {
        }


        [TestMethod]
        public void ProjectTest()
        {
        }


        [TestMethod]
        public void ProjectInfoTest()
        {
        }


        [TestMethod]
        public void ReportsTest()
        {
        }


        [TestMethod]
        public void VersionsTest()
        {
        }
    }
}
