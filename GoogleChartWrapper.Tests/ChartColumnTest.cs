using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleChartWrapper.Tests
{
    [TestFixture]
    class ChartColumnTest
    {
        [Test]
        public void ShouldInstantiateColumnClass()
        {
            ChartColumn test = new ChartColumn("Test",ColumnType.String);
            Assert.IsInstanceOf<ChartColumn>(test);
        }

        [Test]
        public void ShouldThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(delegate { ChartColumn test = new ChartColumn(null, ColumnType.String); });
        }

        [Test]
        public void ShouldThrowExceptionIfNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(delegate { ChartColumn test = new ChartColumn(String.Empty, ColumnType.String); });
        }
    }
}
