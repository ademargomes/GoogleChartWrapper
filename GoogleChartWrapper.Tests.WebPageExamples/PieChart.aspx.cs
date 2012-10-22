using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GoogleChartWrapper.Tests.WebPageExamples
{
    public partial class PieChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleChartWrapper test = new GoogleChartWrapper("Chart Title", ChartTypes.PieChart, 400, 400, "piechart");

            //create datatable
            DataTable testdata = new DataTable("Cars Sold");

            //add columns
            DataColumn year = new DataColumn("Year", typeof(String));
            year.AllowDBNull = false;
            testdata.Columns.Add(year);

            DataColumn cars = new DataColumn("Cars");
            cars.DataType = typeof(int);
            testdata.Columns.Add(cars);

            //adding new datarows
            testdata.Rows.Add("2009", 333);
            testdata.Rows.Add("2010", 2000);
            testdata.Rows.Add("2011", 2560);
            testdata.Rows.Add("2012", 2450);

            //Generate Script
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "test", test.GenerateSCript(testdata));
        }
    }
}