using SQLite.Scaffolder;
using System;

namespace SQLite.Scaffolder.Components
{
    internal class ColumnDefinition
    {
        internal string Name { get; set; }

        internal DataType Type { get; set; }

        internal Nullable IsNullable { get; set; }

        internal PrimaryKey IsPrimaryKey { get; set; }

        internal Unique IsUnique { get; set; }

        internal Type UserDefinedClass { get; set; }

        public override string ToString()
        {
            string dataTypeText = string.Empty;
            switch(Type)
            {
                case DataType.Blob:
                    {
                        dataTypeText = "Blob";
                        break;
                    }
                case DataType.Boolean:
                    {
                        dataTypeText = "Boolean";
                        break;
                    }
                case DataType.DateTime:
                    {
                        dataTypeText = "DateTime";
                        break;
                    }
                case DataType.Integer:
                    {
                        dataTypeText = "Integer";
                        break;
                    }
                case DataType.Real:
                    {
                        dataTypeText = "Real";
                        break;
                    }
                case DataType.Text:
                    {
                        dataTypeText = "Text";
                        break;
                    }
            }

            return string.Format("{0} ({1})", Name, dataTypeText);
        }
    }
}