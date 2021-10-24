
namespace ClassLibrary
{
    public abstract class CompanyBase
    { 
        public string Name { get;  set; }
        public string Location { get; set;}     
        public string AreaOfWork {get; set;}
        protected CompanyBase(string name)
        {
            this.Name = name;
            this.Location = Location;
        }

        // en el program tenemos que hacer el chequeo si existe el areaofwork y lo agregamos.
        public void AddAreaOfWork(string area)
        {
             this.AreaOfWork = area;            
        }

}
}