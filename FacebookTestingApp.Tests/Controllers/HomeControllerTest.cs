using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Facebook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FacebookTestingApp;
using FacebookTestingApp.Controllers;
using FacebookTestingApp.Tests.FacebookAttribute;
using FacebookTestingApp.Tests.Models;

namespace FacebookTestingApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest :Controller
    {
        [TestMethod]
        [FacebookAccessTokenAttribute]
        public async Task<ActionResult> Index()
        {
            var access_token = HttpContext.Items["access_token"].ToString();
            if (access_token != null)
            {
                try
                {
                    var appsecret_proof = access_token.GenerateAppSecretProof();
                    var fb = new FacebookClient(access_token);
                    dynamic myInfo = await fb.GetTaskAsync(
                        "me?fields=first_name,last_name,locale,email,name,birthday,gender,location,bio,age_range"
                            .GraphAPICall(appsecret_proof));

                    dynamic profileImgResult = await fb.GetTaskAsync(
                        "{0}/picture?width=200&height=200&redirect=false".GraphAPICall((string)myInfo.id,
                            appsecret_proof));

                    var facebookProfile = new FacebookProfileViewModel()
                    {
                        FirstName = myInfo.first_name,
                        LastName = myInfo.last_name,
                        Locale = myInfo.locale,
                        Email = myInfo.email,
                        FullName = myInfo.name,
                        Birthday = myInfo.birthday,
                        Gender = myInfo.gender,
                        Location = myInfo.location,
                        Bio = myInfo.bio,
                        Age = myInfo.age_range
                    };
                    return View(facebookProfile);
                }
                catch (FacebookApiLimitException e)
                {
                    throw new HttpException(500, e.Message);
                }
            }

            return null;
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
