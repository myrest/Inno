using DbSchemaGenerator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbSchemaGenerator.CodeTemplates
{
    partial class DomainCodeHelper
    {
        private AbsTableSchema tableObject;
        private string tableName;
        private string nameSpace;
        public DomainCodeHelper(string NameSpace, AbsTableSchema TableObject, string TableName)
        {
            this.tableObject = TableObject;
            this.tableName = TableName;
            this.nameSpace = NameSpace;
        }
    }
}
