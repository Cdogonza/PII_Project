
namespace ClassLibrary
{
    

    public interface IDatamanager
    {
         void AddAreaOfWork(IDatamanager area)
        {
            areaofwork.Add(area);
        }
        public  void RemoveAreaOfWork(AreaOfWork area)
        {
            areaofwork.Remove(area);
        }

        public  List<AreaOfWork> GetAreasOfWork()
        {
            return areaofwork;
        }

        public  void GetTextToPrint()
        {
            int contador=1;
            foreach (AreaOfWork item in areaofwork)
            {
               Console.WriteLine($"{contador}- {item}");
               contador+=1;
            }
        }
    
        public  bool CheckAreaOfWork(int indice)
        {
            if (indice <= areaofwork.Count ){
                return true;
            }
            else
            {
                return false;
            } 
            
        }

        public string GetAreaOfWorkByIndex(int indice)
        {
            indice-=1;
            return areaofwork[indice].ToString();
        }


    }
}