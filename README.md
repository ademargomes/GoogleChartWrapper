Google Chart Wrapper
=========================================================================

**This library provides a easy way to use the NEW google charts API from your c#/vb.net code.**

All you have to do is to pass a datatable to the object and ask it for the javascript to be included in the aspx page.

The library is in a very early stage and any help would be appreciated.

In case you find any problem please let me know, I am happy to hear from you and try to find the solution as quick as possible. 
Leave a comment or get in touch on Twitter : @ademarsgomes

How To Use It?
------------------
Build the project and copy GoogleChartWrapper.dll to your bin folder, then add the reference to the DLL.

To use in your code:

	//This constructor allows you to inform title, chart type, width, height, div name (name of the div where the chart will be rendered)
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

Test projects
------------------
The test project called GoogleChartWrapper.Tests.WebPageExamples contains few asp.net pages with examples of different types of charts.
The other test project is a unit test project using nUnit.

Copyright (c) 2012 Ademar Gomes
------------------
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.