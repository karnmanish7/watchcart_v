using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WatchCart.Models;
using WatchCart.Repository;

namespace WatchCart.Test
{
    [TestFixture]
    public class WatchRepositoryTest
    {
        WatchRepository repository;

        [SetUp]
        public void SetUp()
        {
            var mockData = new Mock<IWatchCatalog>();
            mockData.Setup(data => data.Catalog).Returns(this.Catalog);
            repository = new WatchRepository(mockData.Object);
        }
        [TearDown]
        public void TearDown()
        {
            repository = null;
        }

        [Test]
        public void WatchCatalogShouldReturnAListOfWatch()
        {
            WatchCatalog watchCatalog = new WatchCatalog();
            Assert.NotNull(watchCatalog.Catalog);
            Assert.IsAssignableFrom<List<Watch>>(watchCatalog.Catalog);
            Assert.True(watchCatalog.Catalog.Count == 0);
        }
        [Test]
        public void ShouldReturnAWatch()
        {
            var result = repository.GetWatches("AnalogWatch", "FASTTRACK", "METALIC", "BLACK", "BASIC");
            Assert.NotNull(result);
            Assert.That(result, Has.Count.EqualTo(1), "There should only 1 match with these specifications");
        }

        [Test]
        [TestCase("WristWatch", "FASTTRACK", "METALIC", "BLACK", "BASIC")]
        [TestCase("AnalogWatch", "FOSSIL", "METALIC", "BLACK", "BASIC")]
        [TestCase("DigitalWatch", "TITAN", "METALIC", "BLUE", "BASIC")]
        [TestCase("SmartWatch", "TIMEX", "METALIC", "BLACK", "SILVER")]
        public void ShouldReturnEmptyList(string watchtype, string brandname, string straptype, string strapcolor, string segment)
        {
            var result = repository.GetWatches(watchtype, brandname, straptype, strapcolor, segment);
            Assert.True(result.Count == 0);
        }

        public List<Watch> Catalog => new List<Watch>()
        {
            new AnalogWatch(){WatchId=1101, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=1102, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=1103, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="BASIC",Price=4000, NumberOfHands=2,HasCalender=false},

            new AnalogWatch(){WatchId=1201, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=1202, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="PREMIUM",Price=6000, NumberOfHands=2,HasCalender=false},

            new AnalogWatch(){WatchId=2101, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4500, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=2102, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=4500, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=2103, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="BASIC",Price=5000, NumberOfHands=2,HasCalender=false},

             new AnalogWatch(){WatchId=2301, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="PLATINUM",Price=7500, NumberOfHands=2,HasCalender=true},
            new AnalogWatch(){WatchId=2302, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="PLATINUM",Price=7500, NumberOfHands=2,HasCalender=true},
            new AnalogWatch(){WatchId=2303, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=8000, NumberOfHands=2,HasCalender=true},

            new AnalogWatch(){WatchId=3101, BrandName="TIMEX",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=3500, NumberOfHands=2,HasCalender=false},
            new AnalogWatch(){WatchId=3102, BrandName="TIMEX",StrapType="METALIC",StrapColor="BROWN",Segment="BASIC",Price=3500, NumberOfHands=2,HasCalender=false},

            new DigitalWatch(){WatchId=1111,BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=6000, DisplayMode="24Hour",HasBackLight=false},
            new DigitalWatch(){WatchId=1112, BrandName="FASTTRACK",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=8000, DisplayMode="24Hour",HasBackLight=false},
            new DigitalWatch(){WatchId=1113,BrandName="FASTTRACK",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=10000, DisplayMode="24Hour",HasBackLight=false},

            new DigitalWatch(){WatchId=2111, BrandName="TITAN",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=8000, DisplayMode="24Hour",HasBackLight=true},
            new DigitalWatch(){WatchId=2112, BrandName="TITAN",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=10000, DisplayMode="24Hour",HasBackLight=true},
            new DigitalWatch(){WatchId=2113, BrandName="TITAN",StrapType="METALIC",StrapColor="GOLD",Segment="PLATINUM",Price=12000, DisplayMode="24Hour",HasBackLight=true},

            new DigitalWatch(){WatchId=3111, BrandName="TIMEX",StrapType="METALIC",StrapColor="BLACK",Segment="BASIC",Price=4000, DisplayMode="24Hour",HasBackLight=false},
            new DigitalWatch(){WatchId=3112, BrandName="TIMEX",StrapType="METALIC",StrapColor="BROWN",Segment="PREMIUM",Price=6000, DisplayMode="24Hour",HasBackLight=false},
        };
    }
}
