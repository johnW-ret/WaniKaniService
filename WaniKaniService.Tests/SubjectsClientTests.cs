using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaniKaniService.Models;

namespace WaniKaniService.Tests
{
    public partial class ClientTests
    {
        [TestClass]
        public class SubjectsClientTests
        {
            private const string subjectsResponseFolder = "subjects";

            [TestMethod]
            [DeploymentItem(@$"{rootResponseFolder}/{subjectsResponseFolder}/440.json")]
            public void TestMockKanji()
            {
                // setup server
                ApiEndpointTestServer.RunListener(new string[] { $"{baseUri}{subjectsResponseFolder}/" }, $"{rootResponseFolder}/{subjectsResponseFolder}/440");

                // create client
                WaniKaniClient waniKaniClient = new WaniKaniClient(fakeToken, baseUri);

                // get response
                Response<Subject> kanjiResponse = waniKaniClient.SubjectsClient.GetAsync(440).Result;

                // assert response
                Assert.IsNotNull(kanjiResponse);

                Assert.AreEqual(kanjiResponse.Object, "kanji");
                Assert.AreEqual(kanjiResponse.Url, "https://api.wanikani.com/v2/subjects/440");
                Assert.AreEqual(kanjiResponse.DataUpdatedAt, new DateTimeOffset(636579620708050340, new TimeSpan()));

                // assert response data
                Assert.IsNotNull(kanjiResponse.Data);

                Kanji kanji = (Kanji)kanjiResponse.Data;

                Assert.AreEqual(kanji.AmalgamationSubjectIds.Count, 3);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[0], 56);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[1], 88);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[2], 91);

                Assert.AreEqual(kanji.AuxiliaryMeanings.Count, 2);
                Assert.AreEqual(kanji.AuxiliaryMeanings[0].EnglishMeaning, "one");
                Assert.AreEqual(kanji.AuxiliaryMeanings[0].Type, AuxiliaryMeaningType.Blacklist);
                Assert.AreEqual(kanji.AuxiliaryMeanings[1].EnglishMeaning, "flat");
                Assert.AreEqual(kanji.AuxiliaryMeanings[1].Type, AuxiliaryMeaningType.Whitelist);

                Assert.AreEqual(kanji.Characters, "一");

                Assert.AreEqual(kanji.ComponentSubjectIds.Count, 1);
                Assert.AreEqual(kanji.ComponentSubjectIds[0], 1);

                Assert.AreEqual(kanji.CreatedAt, new DateTimeOffset(634659693190000000, new TimeSpan()));
                Assert.AreEqual(kanji.DocumentUrl, "https://www.wanikani.com/kanji/%E4%B8%80");
                Assert.IsNull(kanji.HiddenAt);
                Assert.AreEqual(kanji.LessonPosition, 2);
                Assert.AreEqual(kanji.Level, 1);

                Assert.AreEqual(kanji.Meanings.Count, 1);
                Assert.AreEqual(kanji.Meanings[0].EnglishMeaning, "One");
                Assert.AreEqual(kanji.Meanings[0].Primary, true);
                Assert.AreEqual(kanji.Meanings[0].AcceptedAnswer, true);

                Assert.AreEqual(kanji.MeaningHint, "To remember the meaning of <kanji>One</kanji>, imagine yourself there at the scene of the crime. You grab <kanji>One</kanji> in your arms, trying to prop it up, trying to hear its last words. Instead, it just splatters some blood on your face. \"Who did this to you?\" you ask. The number One points weakly, and you see number Two running off into an alleyway. He's always been jealous of number One and knows he can be number one now that he's taken the real number one out.");
                Assert.AreEqual(kanji.MeaningMnemonic, "Lying on the <radical>ground</radical> is something that looks just like the ground, the number <kanji>One</kanji>. Why is this One lying down? It's been shot by the number two. It's lying there, bleeding out and dying. The number One doesn't have long to live.");

                Assert.AreEqual(kanji.Readings.Count, 3);
                Assert.AreEqual(kanji.Readings[0].Type, ReadingType.Onyomi);
                Assert.AreEqual(kanji.Readings[0].Primary, true);
                Assert.AreEqual(kanji.Readings[0].AcceptedAnswer, true);
                Assert.AreEqual(kanji.Readings[0].KanaReading, "いち");
                Assert.AreEqual(kanji.Readings[1].Type, ReadingType.Kunyomi);
                Assert.AreEqual(kanji.Readings[1].Primary, false);
                Assert.AreEqual(kanji.Readings[1].AcceptedAnswer, false);
                Assert.AreEqual(kanji.Readings[1].KanaReading, "ひと");
                Assert.AreEqual(kanji.Readings[2].Type, ReadingType.Nanori);
                Assert.AreEqual(kanji.Readings[2].Primary, false);
                Assert.AreEqual(kanji.Readings[2].AcceptedAnswer, false);
                Assert.AreEqual(kanji.Readings[2].KanaReading, "かず");

                Assert.AreEqual(kanji.ReadingMnemonic, "As you're sitting there next to <kanji>One</kanji>, holding him up, you start feeling a weird sensation all over your skin. From the wound comes a fine powder (obviously coming from the special bullet used to kill One) that causes the person it touches to get extremely <reading>itchy</reading> (いち)");
                Assert.AreEqual(kanji.ReadingHint, "Make sure you feel the ridiculously <reading>itchy</reading> sensation covering your body. It climbs from your hands, where you're holding the number <kanji>One</kanji> up, and then goes through your arms, crawls up your neck, goes down your body, and then covers everything. It becomes uncontrollable, and you're scratching everywhere, writhing on the ground. It's so itchy that it's the most painful thing you've ever experienced (you should imagine this vividly, so you remember the reading of this kanji).");

                Assert.AreEqual(kanji.Slug, "一");
                Assert.AreEqual(kanji.VisuallySimilarSubjectIds.Count, 0);
                Assert.AreEqual(kanji.SpacedRepetitionSystemId, 1);
            }

            [TestMethod]
            [DeploymentItem(@$"{rootResponseFolder}/{subjectsResponseFolder}/types=kanji.json")]
            public void TestMockKanjiCollection()
            {
                // setup server
                ApiEndpointTestServer.RunListener(new string[] { $"{baseUri}{subjectsResponseFolder}/" }, $"{rootResponseFolder}/{subjectsResponseFolder}/types=kanji");

                // create client
                WaniKaniClient waniKaniClient = new WaniKaniClient(fakeToken, baseUri);

                // get pages collection
                PagesCollection<Subject> kanjiCollectionResponsePages = waniKaniClient.SubjectsClient.GetAllAsync("types=kanji", 1).Result;

                // assert pages collection
                Assert.IsNotNull(kanjiCollectionResponsePages);
                Assert.AreEqual(1, kanjiCollectionResponsePages.Count);

                // get single response collection
                CollectionResponse<Subject> kanjiCollectionResponse = kanjiCollectionResponsePages[0];

                // assert response collection
                Assert.IsNotNull(kanjiCollectionResponse.Data);
                Assert.AreEqual(1, kanjiCollectionResponse.Data.Count);

                Assert.AreEqual("collection", kanjiCollectionResponse.Object);
                Assert.AreEqual("https://api.wanikani.com/v2/subjects?types=kanji", kanjiCollectionResponse.Url.ToString());

                Assert.IsNotNull(kanjiCollectionResponse.Pages);
                Assert.AreEqual(1000, kanjiCollectionResponse.Pages.PerPage);
                Assert.AreEqual("https://api.wanikani.com/v2/subjects?page_after_id=1439\u0026types=kanji", kanjiCollectionResponse.Pages.NextUrl.ToString());
                Assert.IsNull(kanjiCollectionResponse.Pages.PreviousUrl);
                Assert.AreEqual(2027, kanjiCollectionResponse.TotalCount);
                Assert.AreEqual(new DateTimeOffset(636588941399469690, new TimeSpan()), kanjiCollectionResponse.DataUpdatedAt);

                // get single response
                Response<Subject> kanjiResponse = kanjiCollectionResponse.Data[0];

                Assert.AreEqual(kanjiResponse.Object, "kanji");
                Assert.AreEqual(kanjiResponse.Url, "https://api.wanikani.com/v2/subjects/440");
                Assert.AreEqual(kanjiResponse.DataUpdatedAt, new DateTimeOffset(636579620708050340, new TimeSpan()));

                // assert response data
                Assert.IsNotNull(kanjiResponse.Data);

                Kanji kanji = (Kanji)kanjiResponse.Data;

                Assert.AreEqual(kanji.AmalgamationSubjectIds.Count, 3);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[0], 56);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[1], 88);
                Assert.AreEqual(kanji.AmalgamationSubjectIds[2], 91);

                Assert.AreEqual(kanji.Characters, "一");

                Assert.AreEqual(kanji.ComponentSubjectIds.Count, 1);
                Assert.AreEqual(kanji.ComponentSubjectIds[0], 1);

                Assert.AreEqual(kanji.CreatedAt, new DateTimeOffset(634659693190000000, new TimeSpan()));
                Assert.AreEqual(kanji.DocumentUrl, "https://www.wanikani.com/kanji/%E4%B8%80");
                Assert.IsNull(kanji.HiddenAt);
                Assert.AreEqual(kanji.LessonPosition, 2);
                Assert.AreEqual(kanji.Level, 1);

                Assert.AreEqual(kanji.Meanings.Count, 1);
                Assert.AreEqual(kanji.Meanings[0].EnglishMeaning, "One");
                Assert.AreEqual(kanji.Meanings[0].Primary, true);
                Assert.AreEqual(kanji.Meanings[0].AcceptedAnswer, true);

                Assert.AreEqual(kanji.Readings.Count, 3);
                Assert.AreEqual(kanji.Readings[0].Type, ReadingType.Onyomi);
                Assert.AreEqual(kanji.Readings[0].Primary, true);
                Assert.AreEqual(kanji.Readings[0].AcceptedAnswer, true);
                Assert.AreEqual(kanji.Readings[0].KanaReading, "いち");
                Assert.AreEqual(kanji.Readings[1].Type, ReadingType.Kunyomi);
                Assert.AreEqual(kanji.Readings[1].Primary, false);
                Assert.AreEqual(kanji.Readings[1].AcceptedAnswer, false);
                Assert.AreEqual(kanji.Readings[1].KanaReading, "ひと");
                Assert.AreEqual(kanji.Readings[2].Type, ReadingType.Nanori);
                Assert.AreEqual(kanji.Readings[2].Primary, false);
                Assert.AreEqual(kanji.Readings[2].AcceptedAnswer, false);
                Assert.AreEqual(kanji.Readings[2].KanaReading, "かず");

                Assert.AreEqual(kanji.MeaningHint, "To remember the meaning of <kanji>One</kanji>, imagine yourself there at the scene of the crime. You grab <kanji>One</kanji> in your arms, trying to prop it up, trying to hear its last words. Instead, it just splatters some blood on your face. \"Who did this to you?\" you ask. The number One points weakly, and you see number Two running off into an alleyway. He's always been jealous of number One and knows he can be number one now that he's taken the real number one out.");
                Assert.AreEqual(kanji.MeaningMnemonic, "Lying on the <radical>ground</radical> is something that looks just like the ground, the number <kanji>One</kanji>. Why is this One lying down? It's been shot by the number two. It's lying there, bleeding out and dying. The number One doesn't have long to live.");
                Assert.AreEqual(kanji.ReadingMnemonic, "As you're sitting there next to <kanji>One</kanji>, holding him up, you start feeling a weird sensation all over your skin. From the wound comes a fine powder (obviously coming from the special bullet used to kill One) that causes the person it touches to get extremely <reading>itchy</reading> (いち)");
                Assert.AreEqual(kanji.ReadingHint, "Make sure you feel the ridiculously <reading>itchy</reading> sensation covering your body. It climbs from your hands, where you're holding the number <kanji>One</kanji> up, and then goes through your arms, crawls up your neck, goes down your body, and then covers everything. It becomes uncontrollable, and you're scratching everywhere, writhing on the ground. It's so itchy that it's the most painful thing you've ever experienced (you should imagine this vividly, so you remember the reading of this kanji).");

                Assert.AreEqual(kanji.Slug, "一");
                Assert.AreEqual(kanji.VisuallySimilarSubjectIds.Count, 0);
                Assert.AreEqual(kanji.SpacedRepetitionSystemId, 1);
            }
        }
    }
}