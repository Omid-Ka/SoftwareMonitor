using Core.Interfaces;
using Core.Services;
using Data.Repository;
using EmailService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var Logger = new Mock<ILogger<HomeController>>();
            var UserLogService = new Mock<IUserLogService>();
            var UserService = new Mock<IUsersService>();
            var EmailSender = new Mock<IEmailSender>();

            //Arrange
            HomeController controller = new HomeController(Logger.Object, UserLogService.Object , UserService.Object, EmailSender.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void LoginTest()
        {
            var UsersService = new Mock<IUsersService>();
            var UserLogService = new Mock<IUserLogService>();
            var UserAccessService = new Mock<IUserAccessService>();
            var AccessService = new Mock<IAccessService>();

            //Arrange
            LoginController controller = new LoginController(UsersService.Object, UserLogService.Object,
                UserAccessService.Object, AccessService.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;


            //Assert
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void ProjectTest()
        {
            var projectService = new Mock<IProjectService>();
            var usersService = new Mock<IUsersService>();
            var teamService = new Mock<ITeamService>();
            var partnersService = new Mock<IPartnersService>();
            var attachmentService = new Mock<IAttachmentService>();
            var projectVersionService = new Mock<IProjectVersionService>();

            //Arrange
            ProjectController controller = new ProjectController(projectService.Object, usersService.Object,
                teamService.Object, partnersService.Object, attachmentService.Object, projectVersionService.Object);

            // Act
            ViewResult result = controller.CreateProject() as ViewResult;


            //Assert
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void ProjectInfoTest()
        {

            var lookupService = new Mock<ILookupService>();
            var projectService = new Mock<IProjectService>();
            var testHeaderService = new Mock<ITestHeaderService>();
            var docReviewService = new Mock<IDocReviewService>();
            var codeReviewService = new Mock<ICodeReviewService>();
            var codeReviewDetailService = new Mock<ICodeReviewDetailService>();
            var loadAndSterssService = new Mock<ILoadAndSterssService>();
            var projectVersionService = new Mock<IProjectVersionService>();
            var projectCommentService = new Mock<IProjectCommentService>();
            var notificationService = new Mock<INotificationService>();

            //Arrange
            ProjectInfoController controller = new ProjectInfoController( lookupService.Object,
                 projectService.Object,  testHeaderService.Object,
                 docReviewService.Object,  codeReviewService.Object,
                 codeReviewDetailService.Object,  loadAndSterssService.Object,
                 projectVersionService.Object,  projectCommentService.Object,
                 notificationService.Object);

            // Act
            ViewResult result = controller.DocReview() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ReportsTest()
        {
            var projectService = new Mock<IProjectService>();
            var testHeaderService = new Mock<ITestHeaderService>();
            var docReviewService = new Mock<IDocReviewService>();
            var codeReviewService = new Mock<ICodeReviewService>();
            var LoadAndSterssService = new Mock<ILoadAndSterssService>();
            var CodeReviewDetailService = new Mock<ICodeReviewDetailService>();
            var ProjectVersionService = new Mock<IProjectVersionService>();
            

            //Arrange
            ReportsController controller = new ReportsController(projectService.Object,
                codeReviewService.Object, LoadAndSterssService.Object, CodeReviewDetailService.Object,
                testHeaderService.Object, docReviewService.Object, ProjectVersionService.Object);

            // Act
            ViewResult result = controller.FunctionalReport() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void VersionsTest()
        {
            var projectService = new Mock<IProjectService>();
            var projectVersionService = new Mock<IProjectVersionService>();

            //Arrange
            VersionsController controller = new VersionsController(projectVersionService.Object, projectService.Object);

            // Act
            ViewResult result = controller.CreateVersion() as ViewResult;


            //Assert
            Assert.IsNotNull(result);
        }
    }
}
