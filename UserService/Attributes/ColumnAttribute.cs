namespace UserService.Attributes {
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ColumnAttribute : Attribute{
        public string ColumnName { get; }
        public ColumnAttribute( string name) { 
            ColumnName = name;
        }
    }
}
