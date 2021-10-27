//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            DataManager almacenar = new DataManager();
            AreaOfWork construccion = new AreaOfWork("construccion");
            AreaOfWork carpinteria = new AreaOfWork("carpinteria");
            AreaOfWork herreria = new AreaOfWork("herreria");
            almacenar.AddAreaOfWork(construccion);
            almacenar.AddAreaOfWork(construccion);
            almacenar.AddAreaOfWork(herreria);
            
            Company Compania1 = new Company("compania1");

            Permission materialesInflamables = new Permission("Materiales Inflamables");
            almacenar.AddPermission(materialesInflamables);
            Compania1.AddPermission(materialesInflamables);
            Console.WriteLine("Ingrese habilitación: ");
            string permiso = Console.ReadLine();
            Permission permiso1 = new Permission(permiso);
            Compania1.AddPermission(permiso1);
            Compania1.GetPermissions();

           /* Console.WriteLine("Ingrese Rubro: ");
            string rubro=Console.ReadLine();*/
            // @TODO 
            // CREAR FLUJO SIMULANDO LA LOGICA DEL PROGRAMA
            
            // if (AreaOfWork.CheckAreaOfWork(Convert.ToInt16(rubro)))
            // {
            //     Compania1.AddAreaOfWork(AreaOfWork.GetAreaOfWorkByIndex(Convert.ToInt16(rubro)));    
            // }
            // else
            // {
            //     Console.WriteLine("No exite el rubro Ingresado");
            // }

            // Console.WriteLine($"{Compania1.AreaOfWork}");

            // IPermissions permiso1 = new PermissionHazardous("permiso1");
            // IPermissions permiso2 = new PermissionBase("permiso2");
            // IPermissions permiso3 = new PermissionBase("permiso3");

        //     Compania1.AddPermission(permiso1);
        //     Compania1.AddPermission(permiso2);
            
        //    // Compania1.GetPermissions();
        //     Console.WriteLine(Compania1.SearchP(permiso1));
        //     Console.WriteLine(Compania1.SearchP(permiso3));
            

        }
    }
}