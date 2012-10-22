using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GoogleChartWrapper
{
    public class GoogleChartWrapper
    {
        public string ChartTitle { get; set; }
        public ChartTypes ChartType { get; set; }
        public int ChartHeight { get; set; }
        public int ChartWidth { get; set; }
        public string DivChartName { get; set; }
        public string JSInclude { get; set; }
        //TODO: create the options property for charts that accept list of properties.

        public GoogleChartWrapper()
        {
            ChartTitle = "GoogleChartWrapper";
            DivChartName = "DivChart";
            ChartHeight = 250;
            ChartWidth = 300;
            ChartType = ChartTypes.PieChart;
        }

        public GoogleChartWrapper(String chartTitle, ChartTypes chartType, int chartHeight, int chartWidth, String divChartName)
        {
            ChartTitle = chartTitle;
            ChartType = chartType;
            ChartHeight = chartHeight;
            ChartWidth = chartWidth;
            DivChartName = divChartName;
        }

        public string GenerateSCript(DataTable data)
        {
            if (data.Rows.Count == 0)
                throw new DataException("There are no rows in data. This method does not accept empty DataTables.");

            StringBuilder jsString = GetStringBuilder();

            var columns = GetColumns(data);

            //Columns in the list object are rendered as "data.addColumn('number', 'Slices');"
            foreach (var c in columns)
                jsString.AppendLine("data.addColumn('" + c.Type.ToString().ToLower() + "', '" + c.Name + "');");

            jsString.AppendLine("data.addRows([");

            //generate data for datacolumns - each row should be rendered as ['Mushrooms', 3]
            foreach (DataRow r in data.Rows)
            {
                jsString.Append("[");

                foreach (DataColumn dc in data.Columns)
                {
                    jsString.Append(dc.DataType == System.Type.GetType("System.String") ? "'" : string.Empty);
                    jsString.Append(r[dc]);
                    jsString.Append(dc.DataType == System.Type.GetType("System.String") ? "'" : string.Empty);
                    jsString.Append(dc.Ordinal != data.Columns.Count - 1 ? "," : string.Empty);
                }

                jsString.Append("]");
                jsString.Append(data.Rows.IndexOf(r) != data.Rows.Count - 1 ? "," : string.Empty);
            }

            jsString.Append(AddScriptFooter());

            return jsString.ToString();
        }

        private StringBuilder GetStringBuilder()
        {
            StringBuilder jsString = new StringBuilder();

            //Basic google chart API reference
            jsString.AppendLine("<script type=\"text/javascript\" src=\"https://www.google.com/jsapi\"></script>");

            //Begining of chart generation script
            jsString.AppendLine("<script type=\"text/javascript\">");

            // Load the Visualization API and the piechart package.
            jsString.AppendLine("google.load('visualization', '1.0', { 'packages': ['corechart'] });");

            // Set a callback to run when the Google Visualization API is loaded.
            jsString.AppendLine("google.setOnLoadCallback(drawChart);");

            // Callback that creates and populates a data table, instantiates the pie chart, passes in the data and draws it.
            jsString.AppendLine("function drawChart() {");

            // Create the data table.
            jsString.AppendLine("var data = new google.visualization.DataTable();");

            return jsString;
        }

        private String AddScriptFooter()
        {
            var jsString = new StringBuilder();

            jsString.AppendLine("]);");

            // Set chart options
            jsString.AppendLine("var options = { 'title': '" + ChartTitle + "',");
            jsString.AppendLine(string.Format("'width': {0},", ChartWidth));
            jsString.AppendLine(string.Format("'height': {0}", ChartHeight));
            jsString.AppendLine("};");

            // Instantiate and draw our chart, passing in some options.
            jsString.AppendLine(string.Format("var chart = new google.visualization.{0}(document.getElementById('{1}'));", ChartType, DivChartName));
            jsString.AppendLine("chart.draw(data, options);");
            jsString.AppendLine("}");
            jsString.AppendLine("</script>");

            return jsString.ToString();
        }

        private List<ChartColumn> GetColumns(DataTable data)
        {
            var columnList = new List<ChartColumn>();

            foreach (DataColumn dc in data.Columns)
                columnList.Add(new ChartColumn(dc.ColumnName, getColumnType(dc)));

            return columnList;
        }

        //TODO: Workout other google data types
        private ColumnType getColumnType(DataColumn dataColumn)
        {
            if (dataColumn.DataType == System.Type.GetType("System.String"))
                return ColumnType.String;
            else if (dataColumn.DataType == System.Type.GetType("System.Int32"))
                return ColumnType.Number;
            else if (dataColumn.DataType == System.Type.GetType("System.Boolean"))
                return ColumnType.Boolean;
            else if (dataColumn.DataType == System.Type.GetType("System.DateTime"))
                return ColumnType.DateTime;
            else
                throw new Exception("DataType not recognised. Data type must be String, Int, Boolean or DataTime.");
        }

    }

    public enum ChartTypes { AreaChart, PieChart, BarChart, ColumnChart, LineChart };
}
