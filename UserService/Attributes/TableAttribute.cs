using System;
namespace UserService.Attributes {
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TableAttribute : Attribute {
        public string TableName { get;}
        public TableAttribute(string name) {
            TableName = name;
        }
    }
}
