using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aequasi.ProfileLoader;

namespace ProfileLoaderTests
{
    [TestClass]
    public class LoaderTest
    {
        [TestMethod]
        public void TestLoadProfileXml()
        {
            Loader loader = new Loader();
            const string profileName = "Elwynn_1-5";
            string fileName = Path.GetFullPath("./") + profileName + ".xml";

            ProfileData profileData = loader.LoadProfile(
                new LoaderOptions{
                    FileName = fileName,
                    ProfileName = profileName,
                    ProfileExtension = ProfileExtension.Xml,
                    ProfileType = ProfileType.Grinding
                }
            );

            Assert.AreEqual(profileName, profileData.Name);
            Assert.AreEqual("Grinding", profileData.Type);

            Assert.AreEqual(17, profileData.Profile.Hotspots.Count);
            Assert.AreEqual(2, profileData.Profile.VendorHotspots.Count);
            Assert.AreEqual(0, profileData.Profile.GhostHotspots.Count);
            Assert.AreEqual(0, profileData.Profile.Blackspots.Count);
            Assert.AreEqual(1, profileData.Profile.Repair.Count);
        }

        [TestMethod]
        public void TestLoadProfileJson()
        {
            Loader loader = new Loader();
            const string profileName = "Elwynn_1-5";
            string fileName = Path.GetFullPath("./") + profileName + ".json";

            ProfileData profileData = loader.LoadProfile(
                new LoaderOptions {
                    FileName = fileName,
                    ProfileName = profileName,
                }
            );

            Assert.AreEqual(profileName, profileData.Name);
            Assert.AreEqual("Grinding", profileData.Type);

            Assert.AreEqual(17, profileData.Profile.Hotspots.Count);
            Assert.AreEqual(2, profileData.Profile.VendorHotspots.Count);
            Assert.AreEqual(0, profileData.Profile.GhostHotspots.Count);
            Assert.AreEqual(0, profileData.Profile.Blackspots.Count);
            Assert.AreEqual(1, profileData.Profile.Repair.Count);
        }

        [TestMethod]
        public void TestProfileTypes()
        {
            Loader loader = new Loader();
            const string profileName = "Elwynn_1-5";
            string fileName = Path.GetFullPath("./") + profileName + ".xml";
            ProfileType[] types = { ProfileType.Gathering, ProfileType.Grinding, ProfileType.Questing, ProfileType.Travel };
            
            foreach (ProfileType type in types) {
                ProfileData profileData = loader.LoadProfile(
                    new LoaderOptions {
                        FileName = fileName,
                        ProfileName = profileName,
                        ProfileType = type,
                        ProfileExtension = ProfileExtension.Xml
                    }
                );

                Assert.AreEqual(type.ToString(), profileData.Type);
            }
        }
    }
}
