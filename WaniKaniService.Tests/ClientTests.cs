namespace WaniKaniService.Tests
{
    // TODO: revserse expected an actual parameters in some of the method calls 🙂
    public partial class ClientTests
    {
        /// <summary>
        /// A fake token that matches API key regex
        /// </summary>
        private static readonly string fakeToken = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";

        /// <summary>
        /// A URI to run a server for testing
        /// </summary>
        private static readonly string baseUri = "http://localhost:7575/";

        /// <summary>
        /// The root response folder for test server responses
        /// </summary>
        private const string rootResponseFolder = "MockResponses";
    }
}
