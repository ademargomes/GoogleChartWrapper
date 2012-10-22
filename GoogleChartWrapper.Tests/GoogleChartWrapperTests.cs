using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleChartWrapper.Tests
{
    [TestFixture]
    class GoogleChartWrapperTests
    {
        [Test]
        public void ShouldInstantiateChartClass()
        {
            GoogleChartWrapper test = new GoogleChartWrapper();
            Assert.IsInstanceOf<GoogleChartWrapper>(test);
            Assert.AreEqual("GoogleChartWrapper", test.ChartTitle);
            Assert.AreEqual("DivChart", test.DivChartName);
            Assert.AreEqual(250, test.ChartHeight);
            Assert.AreEqual(300, test.ChartWidth);
            Assert.AreEqual(ChartTypes.PieChart, test.ChartType);
        }

        [Test]
        public void ShouldInstantiateChartClassPassingArgs()
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Chart Title", ChartTypes.BarChart, 400, 400, "DivName");

            Assert.IsInstanceOf<GoogleChartWrapper>(test);
            Assert.AreEqual("Chart Title", test.ChartTitle);
            Assert.AreEqual(ChartTypes.BarChart, test.ChartType);
            Assert.AreEqual(400, test.ChartHeight);
            Assert.AreEqual(400, test.ChartWidth);
            Assert.AreEqual("DivName", test.DivChartName);
        }


        [Test]
        public void ShouldThrowErrorIfDataTableIsEmpty_GenerateScript() 
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Chart Title", ChartTypes.BarChart, 400, 400, "DivName");
            DataTable testdata = new DataTable("Cars Sold");

            Assert.Throws<DataException>(delegate { test.GenerateSCript(testdata); });
        }

        [Test]
        public void ShouldGenerateScriptBasedOnDataTable()
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Chart Title", ChartTypes.BarChart, 400, 400, "DivName");

            //create datatable
            DataTable testdata = new DataTable("Cars Sold");

            //add columns
            DataColumn year = new DataColumn("Year", typeof(int));
            year.AllowDBNull = false;
            testdata.Columns.Add(year);

            DataColumn brazil = new DataColumn("Brazil");
            brazil.DataType = typeof(int);
            brazil.Caption = "Units Sold in Brazil";
            testdata.Columns.Add(brazil);

            DataColumn uk = new DataColumn("UK");
            uk.DataType = typeof(int);
            uk.Caption = "Units Sold in uk";
            testdata.Columns.Add(uk);

            //adding new datarows
            testdata.Rows.Add(2010, 2000, 2500);
            testdata.Rows.Add(2011, 2560, 2879);
            testdata.Rows.Add(2012, 2450, 1201);

            //Generate Script
            var testscript = test.GenerateSCript(testdata);

            Assert.IsNotNullOrEmpty(testscript);
        }
    }
}



