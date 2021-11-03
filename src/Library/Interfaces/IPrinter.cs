namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz define las operaciones necesarias para imprimir los diferentes textos del programa
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Este metodo imprime las ofertas en estado disponible 
        /// </summary>
        /// <param name="offermanager"></param>
        void PrintOffersAvailability(OfferManager offermanager);
       
        /// <summary>
        /// Este metodo imprime las ofertas disponibles de la compania
        /// </summary>
        /// <param name="search"></param>
        /// <param name="company"></param>

        void PrintMyOffersAvailability(Search search, Company company);
        
        /// <summary>
        /// Este metodo imprime las ofertas filtradas por Ubicacion
        /// </summary>
        /// <param name="search"></param>
        /// <param name="location"></param>

        void PrintOffersByLocation(Search search, string location);
        
        /// <summary>
        /// Este metodo imprime las ofertas filtradas por Palabra
        /// </summary>
        /// <param name="search"></param>
        /// <param name="word"></param>
        void PrintOffersByWord(Search search, string word);

        /// <summary>
        /// Este metodo imprime las ofertas de una Catergoria
        /// </summary>
        /// <param name="search"></param>
        /// <param name="category"></param>
        void PrintOffersByCategory(Search search, string category);

        /// <summary>
        /// Este metodo imprime las ofertas de un emprendedor
        /// </summary>
        /// <param name="search"></param>
        /// <param name="entrepreneur"></param>
        void PrintOffersByEntrepreneur(Search search, Entrepreneur entrepreneur);
        
        /// <summary>
        /// Este metodo imprime todas las ofertas de una companía
        /// </summary>
        /// <param name="search"></param>
        /// <param name="company"></param>
        void PrintOffersByCompany(Search search, Company company);

        /// <summary>
        /// Metodo que imprime todos los permisos cargados en el sistema
        /// </summary>
        /// <param name="datamanager"></param>
        void PrintPermissions(DataManager datamanager);

        /// <summary>
        /// Metodo que imprime todos los Rubros cargados en el sistema
        /// </summary>
        /// <param name="datamanager"></param>
        void PrintAreaOfWork(DataManager datamanager);

        /// <summary>
        /// Metodo que Imprime todos los materiales existentes en el sistema
        /// </summary>
        /// <param name="datamanager"></param>
        void PrintMaterialType(DataManager datamanager);
        /// <summary>
        /// Metodo que imprime todos los permisos del usuario
        /// </summary>
        /// <param name="userbase"></param>    
        void PrintUserPermissions(UserBase userbase);

    }
}