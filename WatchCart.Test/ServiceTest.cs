using NUnit.Framework;
using WatchCart.Service;
using Moq;
using WatchCart.Models;
using WatchCart.Repository;
using System.Collections.Generic;

namespace WatchCart.Test
{
    public class ServiceTest
    {
        //[TestCase("1", 2, ExpectedResult = 1)]
        //[TestCase("1", 3, ExpectedResult = 1)]
        //[TestCase("2", 3, ExpectedResult = 2)]
        //[TestCase("3", 3, ExpectedResult = 3)]
        //public int ValidateShouldReturnInteger(string input, int limit)
        //{
        //    return InputValidatorService.Validate(input, limit);
        //}

        //[TestCase("4", 3)]
        //[TestCase("0", 3)]
        //[TestCase("s", 3)]
        //public void ValidateShouldThrowException(string input, int limit)
        //{
        //    var actual = Assert.Throws<InvalidInputException>(() => InputValidatorService.Validate(input, limit));
        //    Assert.AreEqual($"Invalid User Input: {input}, Please Try Again", actual.Message);
        //}

        [Test]
        public void GetWatchesShouldReturnAnalogWatch()
        {
            string watchType = "AnalogWatch";
            string brandName = "FASTTRACK";
            string strapType = "METALIC";
            string strapColor = "BLACK";
            string Segment = "BASIC";
            List<Watch> watches = new List<Watch> { new AnalogWatch() { WatchId = 1101, BrandName = "FASTTRACK", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 4000, NumberOfHands = 2, HasCalender = false } };

            var mockRepo = new Mock<IWatchRepository>();
            mockRepo.Setup(repo => repo.GetWatches(watchType, brandName, strapType, strapColor, Segment)).Returns(watches);
            WatchService watchService = new WatchService(mockRepo.Object);
            var actual = watchService.GetWatches(1, 1, 1, 1, 1);
            Assert.IsAssignableFrom<AnalogWatch>(actual);
            Assert.AreEqual("AnalogWatch", actual.GetType().Name);
        }

        [Test]
        public void GetWatchesShouldReturnDigitalWatch()
        {
            string watchType = "DigitalWatch";
            string brandName = "TITAN";
            string strapType = "METALIC";
            string strapColor = "BLACK";
            string Segment = "BASIC";
            List<Watch> watches = new List<Watch> { new DigitalWatch { WatchId = 2111, BrandName = "TITAN", StrapType = "METALIC", StrapColor = "BLACK", Segment = "BASIC", Price = 8000, DisplayMode = "24Hour", HasBackLight = true } };

            var mockRepo = new Mock<IWatchRepository>();
            mockRepo.Setup(repo => repo.GetWatches(watchType, brandName, strapType, strapColor, Segment)).Returns(watches);
            WatchService watchService = new WatchService(mockRepo.Object);
            var actual = watchService.GetWatches(2, 2, 1, 1, 1);
            Assert.IsAssignableFrom<DigitalWatch>(actual);
            Assert.AreEqual("DigitalWatch", actual.GetType().Name);
        }

        [TestCase(1, 2, 1, 1, 1)]
        public void GetWatchesShouldThrowExceptionForInvalidWatch(int watchtype, int brandname, int straptype, int strapcolor, int segment)
        {
            string watchType = "AnalogWatch";
            string brandName = "TITAN";
            string strapType = "METALIC";
            string strapColor = "BLACK";
            string Segment = "BASIC";
            List<Watch> watches = new List<Watch>();
            var mockRepo = new Mock<IWatchRepository>();
            mockRepo.Setup(repo => repo.GetWatches(watchType, brandName, strapType, strapColor, Segment)).Returns(watches);
            WatchService watchService = new WatchService(mockRepo.Object);
            var actual = Assert.Throws<NoMatchFoundException>(() => watchService.GetWatches(watchtype, brandname, straptype, strapcolor, segment));
            Assert.AreEqual("No Match Found, Please Try Another Combination", actual.Message);
        }
    }
}
