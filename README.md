# zzuk-profile-loader

Add a reference to the DLL from Releases

Then, in your code:

```csharp
using ProfileLoader;

namespace Example
{
    class Program
    {
        public static void Main()
        {
            // JSON
            ProfileData profileData = Loader.LoadProfile(fullFileName, profileName, ProfileType.JSON);
            
            //OR
            
            // XML (will download to json for parsing)
            ProfileData profileData = Loader.LoadProfile(fullFileName, profileName, ProfileType.XML); 
        }
        
        /**
         * Can also use the async methods.
         */
        public static async Task AsyncMain()
        {
            // JSON
            ProfileData profileData = await Loader.LoadProfileAsync(fullFileName, profileName, ProfileType.JSON);
            
            //OR
            
            // XML (will download to json for parsing)
            ProfileData profileData = await Loader.LoadProfileAsync(fullFileName, profileName, ProfileType.XML); 
        }
    }
}
```
