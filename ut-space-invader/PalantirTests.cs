using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using space_invader;

namespace ut_space_invader
{
    [TestClass]
    public class PalantirTests
    {
        [TestMethod]
        public void TestPatternIndexes1()
        {
            var sourceLine = "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------o-----o------o-ooooo---o--o--o-------";
            var pattern = "-----";

            var palantir = new Palantir();
            var indexes = palantir.RetrieveAllPatternIndexes(sourceLine, pattern);
            Assert.AreEqual(14, indexes.Count);
        }

        [TestMethod]
        public void TestPatternIndexesWhenPatternToRecognizeIsLongerThanTheImage()
        {
            var sourceLine = "---";
            var pattern = "-----";

            var palantir = new Palantir();
            var indexes = palantir.RetrieveAllPatternIndexes(sourceLine, pattern);
            Assert.AreEqual(0, indexes.Count);
        }

        [TestMethod]
        public void TestMultiLinePatterns()
        {
            var sourceImage = new Image(new List<string>
            {
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------o-----o------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------"
            });


            var pattern = new Image(new List<string>
            {
                "-----",
                "ooooo"
            });

            var palantir = new Palantir();
            var match = palantir.CheckLineByLine(64, sourceImage, 0, pattern);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void TestMultiLinePatternsWhenPatternIsBiggerThanTheSource()
        {
            var sourceImage = new Image(new List<string>
            {
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------o-----o------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------"
            });


            var pattern = new Image(new List<string>
            {
                "-----",
                "ooooo",
                "ooooo",
            });

            var palantir = new Palantir();
            var match = palantir.CheckLineByLine(64, sourceImage, 0, pattern);
            Assert.IsFalse(match);
        }


        [TestMethod]
        public void TestMultiLinePatternsWhenSourceIsBiggerThanPattern()
        {
            var sourceImage = new Image(new List<string>
            {
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------o-----o------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------",
                "-------o--oooooo--o-oo-o--o-o-----oo--o-o-oo--o-oo-oo-o--------ooooooo------o-ooooo---o--o--o-------"
            });


            var pattern = new Image(new List<string>
            {
                "-----",
                "ooooo",
                "ooooo",
            });

            var palantir = new Palantir();
            var match = palantir.CheckLineByLine(64, sourceImage, 2, pattern);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void TestInvasionByInvader1()
        {
            var radar = new StaticRadar();
            var palantir = new Palantir();

            var invader1 = new Image(new List<string>
                {
                    "--o-----o--",
                    "---o---o---",
                    "--ooooooo--",
                    "-oo-ooo-oo-",
                    "ooooooooooo",
                    "o-ooooooo-o",
                    "o-o-----o-o",
                    "---oo-oo---"
                });

            var match = palantir.Match(radar.CurrentImage(), invader1);
            Assert.IsFalse(match);
        }

        [TestMethod]
        public void TestInvasionByInvader2()
        {
            var radar = new StaticRadar();
            var palantir = new Palantir();

            var invader = new Image(new List<string>
                {
                    "---oo---",
                    "--oooo--",
                    "-oooooo-",
                    "oo-oo-oo",
                    "oooooooo",
                    "--o--o--",
                    "-o-oo-o-",
                    "o-o--o-o"
                });

            var match = palantir.Match(radar.CurrentImage(), invader);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void TestInvasionByFakeInvaderExtractedFromRadarImage()
        {
            var radar = new StaticRadar();
            var palantir = new Palantir();

            var invader = new Image(new List<string>
                {
                    "----ooo----o-oooo---",
                    "-o-----o------------",
                    "------oooo----------",
                    "---o-o--------------",
                    "--o--------o--o---oo",
                    "-----------------o--",
                    "-o---o--o-oo--o--o-o",
                    "--oo-----o----o-----"
                });

            var match = palantir.Match(radar.CurrentImage(), invader);
            Assert.IsTrue(match);
        }
    }
}
