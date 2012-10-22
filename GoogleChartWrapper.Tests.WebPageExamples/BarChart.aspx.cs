using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GoogleChartWrapper.Tests.WebPageExamples
{
    public partial class BarChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Bar Chart Title", ChartTypes.BarChart, 400, 400, "barchart");

            //create datatable
            DataTable testdata = new DataTable("Cars Sold");

            //add columns
            DataColumn year = new DataColumn("Year", typeof(String));
            year.AllowDBNull = false;
            testdata.Columns.Add(year);

            DataColumn brazil = new DataColumn("Brazil");
            brazil.DataType = typeof(int);
            testdata.Columns.Add(brazil);

            DataColumn uk = new DataColumn("UK");
            uk.DataType = typeof(int);
            testdata.Columns.Add(uk);

            DataColumn usa = new DataColumn("USA");
            usa.DataType = typeof(int);
            testdata.Columns.Add(usa);

            DataColumn arge = new DataColumn("Argentina");
            arge.DataType = typeof(int);
            testdata.Columns.Add(arge);

            //adding new datarows
            testdata.Rows.Add("2009", 333, 2356, 1245, 6669);
            testdata.Rows.Add("2010", 2000, 4589, 9865, 2356);
            testdata.Rows.Add("2011", 2560, 1111, 3333, 999);
            testdata.Rows.Add("2012", 2450, 666, 123, 1236);

            //Generate Script
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", test.GenerateSCript(testdata));
        }
    }
}