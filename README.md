# WaniKaniService

A C# implementation of the [WaniKani v2 API](https://docs.api.wanikani.com).

## How to use

```csharp
using WaniKaniService;
...
// construct the client
WaniKaniClient wkClient = new WaniKaniClient(apIkey);

// await response
Response<User> userResponse = await wkClient.UserClient.GetAsync();

Console.WriteLine(userResponse.Data.Level);
```

## Notes
> **Warning**<br>
> This package is still in pre-release, so anticipate breaking changes in every new release. For example, [filters](https://docs.api.wanikani.com/20170710/#filters) are accepted as parameters through client interface methods using    ``strings``.
> 
> In future releases, ``string`` parameters are planned to be replaced by a filter builder which builds ``string`` filters automatically used by the Http request.

## Coverage
- Not all features and entities have been implemented.
  - See [Models](https://github.com/johnW-ret/WaniKaniService/tree/main/WaniKaniService/Models) for a list of supported entities and [Clients](https://github.com/johnW-ret/WaniKaniService/tree/main/WaniKaniService/Clients) for a list of supported clients and features. 
  - _Contributions are welcome with accompanying tests_, but design according to the style and patterns used in the main branch.
