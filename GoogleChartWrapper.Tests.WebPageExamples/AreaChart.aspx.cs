using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GoogleChartWrapper.Tests.WebPageExamples
{
    public partial class AreaChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Area Chart Title", ChartTypes.AreaChart, 400, 400, "areachart");

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

            //adding new datarows
            testdata.Rows.Add("2009", 333, 2356);
            testdata.Rows.Add("2010", 2000, 4589);
            testdata.Rows.Add("2011", 4560, 1111);
            testdata.Rows.Add("2012", 2450, 666);

            //Generate Script
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", test.GenerateSCript(testdata));
        }
    }
}