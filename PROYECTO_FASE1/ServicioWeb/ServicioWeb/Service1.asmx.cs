using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace ServicioWeb
{

    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/webService",Name="ServicioWeb",Description="servicio web de Naval Wars")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        ABB Miarbol = new ABB();
        MatrizOrtogonal matriz = new MatrizOrtogonal();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string horayfecha()
        {
            return DateTime.Today.ToString();
        }
        [WebMethod]
        public string insertarespejo()
        {
            

            Miarbol.graficar();
           
            return "espejo listo";
        }

        [WebMethod]
        public string InsertarArbol()
        {
            
           Miarbol.insertar("andrea","123","a@",0);
           Miarbol.insertar("nelson", "123", "a@", 0);
           Miarbol.insertar("carol", "123", "a@", 0);
           Miarbol.insertar("allan", "123", "a@", 0);
           Miarbol.insertar("duglas", "123", "a@", 0);
           Miarbol.insertar("pedro", "123", "a@", 0);
         
          // Miarbol.eliminar("nelson");
          // Miarbol.modificar("pedro", "aroldo", "890", "@", 0);
          ABB.nodo_lista N = new ABB.nodo_lista("allan","lucas",0,3,2,0);
          ABB.nodo_lista N1 = new ABB.nodo_lista("allan", "jr", 3, 1, 4, 0);
          ABB.nodo_lista N2 = new ABB.nodo_lista("allan", "lorena", 3, 1, 4, 0);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N1);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N2);
          Miarbol.modificarL("allan", "lorena", 1, 1, 1, 1);
          Miarbol.ELIMINAR_LISTA_JUEGOS(Miarbol.raiz, "allan", "jr");
           //ABB.nodo_lista N1 = new ABB.nodo_lista("gaby", "lucas3", 0, 3, 2, 0);
            
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N);
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N1);
          // Miarbol.espejo(Miarbol.raiz);
           
           Miarbol.graficar();

           return "insertardo";
            
        }
        [WebMethod]
        public string matrices()
        {
            matriz.insertarMatriz(3, 3, "barco", 0, 2, 3, 2, 0);
            matriz.insertarMatriz(3, 1, "nave", 0, 2, 4, 5, 1);
            matriz.insertarMatriz(5, 7, "submarino", 0, 2, 4, 5, 1);
            matriz.insertarMatriz(5, 7, "vela", 0, 2, 3, 2, 0);
            matriz.insertarMatriz(5, 7, "bus", 0, 2, 4, 5, 3);
            matriz.insertarMatriz(3, 1, "barquito", 0, 2, 4, 5, 3);
            matriz.insertarMatriz(3, 3, "navega", 0, 2, 3, 2, 3);
            matriz.insertarMatriz(3, 1, "astronauta", 0, 2, 4, 5, 0);
       
          
           
            return "exitosa matriz";
        }
   
    }
}