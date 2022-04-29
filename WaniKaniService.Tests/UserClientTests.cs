using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaniKaniService.Models;

namespace WaniKaniService.Tests
{
    [TestClass]
    public class UserClientTests
    {
        private readonly string fakeToken = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";

        [TestMethod]
        [DeploymentItem(@"MockResponses/user.json")]
        public void TestMockUser()
        {
            string baseUri = "http://localhost:7575/";

            ApiEndpointTestServer.RunListener(new string[] { $"{baseUri}user/" });

            WaniKaniClient waniKaniClient = new WaniKaniClient(fakeToken, baseUri);

            Response<User> userResponse = waniKaniClient.UserClient.GetAsync().Result;

            Assert.IsNotNull(userResponse);

            Assert.AreEqual(userResponse.Object, "user");
            Assert.AreEqual(userResponse.Url, "https://api.wanikani.com/v2/user");
            Assert.AreEqual(userResponse.DataUpdatedAt, new DateTimeOffset(636586216130222450, new TimeSpan()));

            Assert.IsNotNull(userResponse.Data);

            User user = userResponse.Data;

            Assert.AreEqual(user.Id, "5a6a5234-a392-4a87-8f3f-33342afe8a42");
            Assert.AreEqual(user.Username, "example_user");
            Assert.AreEqual(user.Level, 5);
            Assert.AreEqual(user.ProfileUrl, "https://www.wanikani.com/users/example_user");
            Assert.AreEqual(user.StartedAt, new DateTimeOffset(634722943389584660, new TimeSpan()));
            Assert.IsNull(user.CurrentVacationStartedAt);

            Subscription subscription = user.Subscription;

            Assert.AreEqual(subscription.Active, true);
            Assert.AreEqual(subscription.Type, "recurring");
            Assert.AreEqual(subscription.MaxLevelGranted, 60);
            Assert.AreEqual(subscription.PeriodEndsAt, new DateTimeOffset(636801319394857480, new TimeSpan()));

            Preferences preferences = user.Preferences;

            Assert.AreEqual(preferences.DefaultVoiceActorId, 1);
            Assert.AreEqual(preferences.LessonsAutoplayAudio, false);
            Assert.AreEqual(preferences.LessonsBatchSize, 10);
            Assert.AreEqual(preferences.LessonsPresentationOrder, "ascending_level_then_subject");
            Assert.AreEqual(preferences.ReviewsAutoplayAudio, false);
            Assert.AreEqual(preferences.ReviewsDisplaySrsIndicator, true);



        }
    }
}