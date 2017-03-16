# zzuk-profile-loader

Add a reference to the DLL from Releases

Then, in your code:

```csharp
using ProfileLoader;

ProfileData profileData = Loader.LoadProfile(fullFileName, profileName, ProfileType.JSON); // JSON
OR
ProfileData profileData = Loader.LoadProfile(fullFileName, profileName, ProfileType.XML); // XML (will download to json for parsing)

Can also use the async methods:

ProfileData profileData = await Loader.LoadProfileAsync(fullFileName, profileName, ProfileType.JSON); // JSON
OR
ProfileData profileData = await Loader.LoadProfileAsync(fullFileName, profileName, ProfileType.XML); // XML (will download to json for parsing)
```
