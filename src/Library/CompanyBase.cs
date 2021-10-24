
namespace ClassLibrary
{
    public abstract class CompanyBase
    { 
        public string Name { get;  set; }
        public string Location { get; set;}

        protected CompanyBase(string name)
        {
            this.Name = name;
            this.Location = Location;
        }

}
}