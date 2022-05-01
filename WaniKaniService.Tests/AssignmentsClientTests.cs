using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaniKaniService.Models;

namespace WaniKaniService.Tests
{
    public partial class ClientTests
    {
        [TestClass]
        public class AssignmentsClientTests
        {
            private const string assignmentsResponseFolder = "assignments";

            [TestMethod]
            [DeploymentItem(@$"{rootResponseFolder}/{assignmentsResponseFolder}/80463006.json")]
            public void TestMockKanji()
            {
                // setup server
                ApiEndpointTestServer.RunListener(new string[] { $"{baseUri}{assignmentsResponseFolder}/" }, $"{rootResponseFolder}/{assignmentsResponseFolder}/80463006");

                // create client
                WaniKaniClient waniKaniClient = new WaniKaniClient(fakeToken, baseUri);

                // get response
                Response<Assignment> assignmentResponse = waniKaniClient.AssignmentsClient.GetAsync(80463006).Result;

                // assert response
                Assert.IsNotNull(assignmentResponse);

                Assert.AreEqual(assignmentResponse.Object, "assignment");
                Assert.AreEqual(assignmentResponse.Url, "https://api.wanikani.com/v2/assignments/80463006");
                Assert.AreEqual(assignmentResponse.DataUpdatedAt, new DateTimeOffset(636475810235713770, new TimeSpan()));

                // assert response data
                Assert.IsNotNull(assignmentResponse.Data);

                Assignment assignment = assignmentResponse.Data;

                Assert.AreEqual(new DateTimeOffset(636402514906951330, new TimeSpan()), assignment.CreatedAt);
                Assert.AreEqual(8761, assignment.SubjectId);
                Assert.AreEqual(SubjectType.Radical, assignment.SubjectType);
                // level is in example but not response structure defintion? https://docs.api.wanikani.com/20170710/#get-a-specific-assignment
                Assert.AreEqual(8, assignment.SrsStage);
                Assert.AreEqual(new DateTimeOffset(636402514906951330, new TimeSpan()), assignment.UnlockedAt);
                Assert.AreEqual(new DateTimeOffset(636402516889806790, new TimeSpan()), assignment.StartedAt);
                Assert.AreEqual(new DateTimeOffset(636404012544918890, new TimeSpan()), assignment.PassedAt);
                Assert.IsNull(assignment.BurnedAt);
                Assert.AreEqual(new DateTimeOffset(636552864000000000, new TimeSpan()), assignment.AvailableAt);
                Assert.IsNull(assignment.ResurrectedAt);
            }

            [TestMethod]
            [DeploymentItem(@$"{rootResponseFolder}/{assignmentsResponseFolder}/all.json")]
            public void TestMockKanjiCollection()
            {
                // setup server
                ApiEndpointTestServer.RunListener(new string[] { $"{baseUri}{assignmentsResponseFolder}/" }, $"{rootResponseFolder}/{assignmentsResponseFolder}/all");

                // create client
                WaniKaniClient waniKaniClient = new WaniKaniClient(fakeToken, baseUri);

                // get pages collection
                PagesCollection<Assignment> assignmentCollectionResponsePages = waniKaniClient.AssignmentsClient.GetAllAsync(null!, 1).Result;

                // assert pages collection
                Assert.IsNotNull(assignmentCollectionResponsePages);
                Assert.AreEqual(1, assignmentCollectionResponsePages.Count);

                // get single response collection
                CollectionResponse<Assignment> assignmentCollectionResponse = assignmentCollectionResponsePages[0];

                // assert response collection
                Assert.IsNotNull(assignmentCollectionResponse.Data);
                Assert.AreEqual(1, assignmentCollectionResponse.Data.Count);

                Assert.AreEqual("collection", assignmentCollectionResponse.Object);
                Assert.AreEqual("https://api.wanikani.com/v2/assignments", assignmentCollectionResponse.Url.ToString());

                Assert.IsNotNull(assignmentCollectionResponse.Pages);
                Assert.AreEqual(500, assignmentCollectionResponse.Pages.PerPage);
                Assert.AreEqual("https://api.wanikani.com/v2/assignments?page_after_id=80469434", assignmentCollectionResponse.Pages.NextUrl!.ToString());
                Assert.IsNull(assignmentCollectionResponse.Pages.PreviousUrl);
                Assert.AreEqual(1600, assignmentCollectionResponse.TotalCount);
                Assert.AreEqual(new DateTimeOffset(636475810235713770, new TimeSpan()), assignmentCollectionResponse.DataUpdatedAt);

                // get response
                Response<Assignment> assignmentResponse = assignmentCollectionResponse.Data[0];

                // assert response
                Assert.IsNotNull(assignmentResponse);

                Assert.AreEqual(assignmentResponse.Object, "assignment");
                Assert.AreEqual(assignmentResponse.Url, "https://api.wanikani.com/v2/assignments/80463006");
                Assert.AreEqual(assignmentResponse.DataUpdatedAt, new DateTimeOffset(636449250704384320, new TimeSpan()));

                // assert response data
                Assert.IsNotNull(assignmentResponse.Data);

                Assignment assignment = assignmentResponse.Data;

                Assert.AreEqual(new DateTimeOffset(636402514906951330, new TimeSpan()), assignment.CreatedAt);
                Assert.AreEqual(8761, assignment.SubjectId);
                Assert.AreEqual(SubjectType.Radical, assignment.SubjectType);
                // level is in example but not response structure defintion? https://docs.api.wanikani.com/20170710/#get-a-specific-assignment
                Assert.AreEqual(8, assignment.SrsStage);
                Assert.AreEqual(new DateTimeOffset(636402514906951330, new TimeSpan()), assignment.UnlockedAt);
                Assert.AreEqual(new DateTimeOffset(636402516889806790, new TimeSpan()), assignment.StartedAt);
                Assert.AreEqual(new DateTimeOffset(636404012544918890, new TimeSpan()), assignment.PassedAt);
                Assert.IsNull(assignment.BurnedAt);
                Assert.AreEqual(new DateTimeOffset(636552864000000000, new TimeSpan()), assignment.AvailableAt);
                Assert.IsNull(assignment.ResurrectedAt);
            }
        }
    }
}