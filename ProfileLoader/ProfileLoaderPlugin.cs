using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ZzukBot.ExtensionFramework.Interfaces;

namespace Aequasi.ProfileLoader
{
    /// <summary>
    /// ProfileLoaderPlugin for ZzukBot
    /// </summary>
    [Export(typeof(IPlugin))]
    public class ProfileLoaderPlugin : IPlugin
    {
        /// <summary>
        /// Loader is an instance of the Loader class. Handles the profile loading
        /// </summary>
        private readonly Loader _loader = new Loader();

        /// <summary>
        /// LoadProfile loads a profile based on the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ProfileData LoadProfile(LoaderOptions options)
        {
            return _loader.LoadProfile(options);
        }

        /// <summary>
        /// LoadProfileAsync loads a profile asyncronously, based on the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ProfileData> LoadProfileAsync(LoaderOptions options)
        {
            return await _loader.LoadProfileAsync(options);
        }

        /// <summary>
        /// Dispose does nothing
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Load does nothing
        /// </summary>
        /// <returns>true</returns>
        public bool Load()
        {
            return true;
        }

        /// <summary>
        /// Unload does nothing
        /// </summary>
        public void Unload()
        {
        }

        /// <summary>
        /// ShowGui does nothing
        /// </summary>
        public void ShowGui()
        {
        }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        public string Name { get; } = "ProfileLoader";
        /// <summary>
        /// Author of the plugin
        /// </summary>
        public string Author { get; } = "Aaron";
        /// <summary>
        /// Version of the program
        /// </summary>
        public int Version { get; } = 1;
    }
}
