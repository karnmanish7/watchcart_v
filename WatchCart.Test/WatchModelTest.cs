using System;
using NUnit.Framework;
using WatchCart.Models;
using WatchCart.Models.Constants;

namespace WatchCart.Test
{
    [TestFixture]
    public class WatchModelTest
    {
        [Test]
        public void AnalogModelIsValid()
        {
            AnalogWatch analogWatch = new AnalogWatch();

            Assert.That(analogWatch, Has.Property("WatchId"));
            Assert.That(analogWatch, Has.Property("BrandName"));
            Assert.That(analogWatch, Has.Property("StrapType"));
            Assert.That(analogWatch, Has.Property("StrapColor"));
            Assert.That(analogWatch, Has.Property("Segment"));
            Assert.That(analogWatch, Has.Property("Price"));
            Assert.That(analogWatch, Has.Property("NumberOfHands"));
            Assert.That(analogWatch, Has.Property("HasCalender"));
            Assert.That(analogWatch, Is.AssignableTo(typeof(Watch)));
        }

        [Test]
        public void DigitalModelIsValid()
        {
            DigitalWatch digitalWatch = new DigitalWatch();

            Assert.That(digitalWatch, Has.Property("WatchId"));
            Assert.That(digitalWatch, Has.Property("BrandName"));
            Assert.That(digitalWatch, Has.Property("StrapType"));
            Assert.That(digitalWatch, Has.Property("StrapColor"));
            Assert.That(digitalWatch, Has.Property("Segment"));
            Assert.That(digitalWatch, Has.Property("Price"));
            Assert.That(digitalWatch, Has.Property("DisplayMode"));
            Assert.That(digitalWatch, Has.Property("HasBackLight"));
            Assert.That(digitalWatch, Is.AssignableTo(typeof(Watch)));
        }

        [Test]
        public void AnalogWatchShouldOverrideToString()
        {
            AnalogWatch analogWatch = new AnalogWatch { WatchId = 1101, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000, NumberOfHands = 2, HasCalender = false };
            var actual = analogWatch.ToString();

            Assert.AreEqual(string.Format("Model Id: 1101, Brand: FASTTRACK, Segment: BASIC, Strap Type: METALIC, Strap Color: BLACK, Price: 4000, Watch Type: AnalogWatch, No_Hands: 2, Calendar: False "), actual);   
        }

        [Test]
        public void DigitalWatchShouldOverrideToString()
        {
            DigitalWatch digitalWatch = new DigitalWatch { WatchId = 2111, BrandName = "TITAN", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 8000, DisplayMode = "24Hour", HasBackLight = true };
            var actual = digitalWatch.ToString();

            Assert.AreEqual(string.Format("Model Id: 2111, Brand: TITAN, Segment: BASIC, Strap Type: METALIC, Strap Color: BLACK, Price: 8000, Watch Type: DigitalWatch, DisplayMode: 24Hour, BackLight: True "), actual);
        }

        [Test]
        public void ShouldBeTwoTypesOfWatch()
        {
            string[] watchTypes= Enum.GetNames(typeof(WatchTypes));
            Assert.AreEqual(2, watchTypes.Length);
            Assert.Contains("AnalogWatch", watchTypes);
            Assert.Contains("DigitalWatch", watchTypes);
        }

        [Test]
        public void ShouldBeThreeBrands()
        {
            string[] brandNames = Enum.GetNames(typeof(BrandName));
            Assert.AreEqual(3, brandNames.Length);
            Assert.Contains("FASTTRACK", brandNames);
            Assert.Contains("TITAN", brandNames);
            Assert.Contains("TIMEX", brandNames);
        }

        [Test]
        public void ShouldBeThreeStrapTypes()
        {
            string[] strapType = Enum.GetNames(typeof(StrapType));
            Assert.AreEqual(2, strapType.Length);
            Assert.Contains("METALIC", strapType);
            Assert.Contains("LEATHER", strapType);
        }

        [Test]
        public void ShouldBeThreeColor()
        {
            string[] strapColor = Enum.GetNames(typeof(StrapColor));
            Assert.AreEqual(3, strapColor.Length);
            Assert.Contains("BLACK", strapColor);
            Assert.Contains("BROWN", strapColor);
            Assert.Contains("GOLD", strapColor);
        }

        [Test]
        public void ShouldBeThreeSegments()
        {
            string[] segments = Enum.GetNames(typeof(Segment));
            Assert.AreEqual(3, segments.Length);
            Assert.Contains("BASIC", segments);
            Assert.Contains("PREMIUM", segments);
            Assert.Contains("PLATINUM", segments);
        }

        [Test]
        public void AnalogShouldBeWatchType()
        {
            AnalogWatch analog = new AnalogWatch();
            Assert.IsInstanceOf<Watch>(analog);
        }

        [Test]
        public void DigitalShouldBeWatchType()
        {
            DigitalWatch digital = new DigitalWatch();
            Assert.IsInstanceOf<Watch>(digital);
        }
    }
}
