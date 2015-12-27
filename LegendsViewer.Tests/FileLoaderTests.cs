using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegendsViewer.Tests
{
    [TestClass]
    public class FileLoaderTests
    {
        private FileLoader sut;

        private TextBox HistoryText;
        private TextBox SitesText;
        private TextBox MapText;

        [TestInitialize]
        public void Setup()
        {
            var DummyButton = new Button();
            var DummyTextBox = new TextBox();

            HistoryText = new TextBox();
            SitesText = new TextBox();
            MapText = new TextBox();

            sut = new FileLoader(null, DummyButton, DummyTextBox, DummyButton, HistoryText, DummyButton, SitesText,
                DummyButton, MapText, null, null);
        }

        [TestMethod]
        public void FindsOtherFilesWhenLoadingXml()
        {
            var tempFolder = Path.GetTempPath();
            var workingFolder = Directory.CreateDirectory(Path.Combine(tempFolder, Guid.NewGuid().ToString()));

            var xmlFile = Path.Combine(workingFolder.FullName, "region1-01050-01-01-legends.xml");
            File.Create(xmlFile);

            var historyFile = Path.Combine(workingFolder.FullName, "region1-01050-01-01-world_history.txt");
            File.Create(historyFile);

            var sitesFile = Path.Combine(workingFolder.FullName, "region1-01050-01-01-world_sites_and_pops.txt");
            File.Create(sitesFile);

            var mapFile = Path.Combine(workingFolder.FullName, "region1-01050-01-01-world_map.bmp");
            File.Create(mapFile);

            sut.LocateOtherFiles(xmlFile);

            Assert.AreEqual(historyFile, HistoryText.Text);
            Assert.AreEqual(sitesFile, SitesText.Text);
            Assert.AreEqual(mapFile, MapText.Text);
        }

        
    }
}