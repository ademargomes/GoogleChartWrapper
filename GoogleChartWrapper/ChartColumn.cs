using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleChartWrapper
{
    public class ChartColumn
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }

        public ChartColumn(String name, ColumnType type)
        {
            if (name == null)
                throw new ArgumentNullException("Column name cannot be null", "Column name is null.");

            if (name == string.Empty)
                throw new ArgumentException("Column name cannot be empty", "Column name is empty.");

            Name = name;
            Type = type;
        }
    }

    public enum ColumnType { String, Number, Boolean, Date, DateTime, TimeOfDay }
}
