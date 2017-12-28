using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;


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

            Miarbol.espejo(Miarbol.raiz);
            Miarbol.graficar();
           
            return "espejo listo";
        }

        [WebMethod]
        public string InsertarArbol()
        {
            
           Miarbol.insertar("andrea","123","a@",0,0,0);
           Miarbol.insertar("nelson", "123", "a@", 0,0,0);
           Miarbol.insertar("olga", "123", "a@", 0,0,0);
           Miarbol.insertar("allan", "123", "a@", 0,0,0);
           Miarbol.insertar("duglas", "123", "a@", 0,0,0);
           Miarbol.insertar("pedro", "123", "a@", 0,0,0);
           Miarbol.insertar("laura", "123", "a@", 0, 0, 0);
           Miarbol.insertar("princesa", "123", "a@", 0, 0, 0);
           Miarbol.insertar("mau", "123", "a@", 0, 0, 0);
           Miarbol.insertar("dori", "123", "a@", 0, 0, 0);
           Miarbol.insertar("marco", "123", "a@", 0, 0, 0);
           Miarbol.insertar("fresa", "123", "a@", 0, 0, 0);
           Miarbol.insertar("galleta", "123", "a@", 0, 0, 0);
           Miarbol.insertar("skapy", "123", "a@", 0, 0, 0);
         
          // Miarbol.eliminar("nelson");
          // Miarbol.modificar("pedro", "aroldo", "890", "@", 0);
          ABB.nodo_lista N = new ABB.nodo_lista("andrea","lucas1",0,3,2,0);
          ABB.nodo_lista N1 = new ABB.nodo_lista("andrea", "jr1", 3, 1, 3, 1);
          ABB.nodo_lista N2 = new ABB.nodo_lista("andrea", "lorena1", 3, 1, 6, 1);
          ABB.nodo_lista N22 = new ABB.nodo_lista("pedro", "lucas2", 0, 3, 8, 1);
          ABB.nodo_lista N21 = new ABB.nodo_lista("pedro", "jr2", 3, 1, 9, 1);
          ABB.nodo_lista N23 = new ABB.nodo_lista("pedro", "lorena2", 3, 1, 2, 1);
          ABB.nodo_lista N10 = new ABB.nodo_lista("laura", "jr3", 3, 1, 29, 1);
          ABB.nodo_lista N19= new ABB.nodo_lista("galleta", "lorenas4", 3, 1, 32, 1);
          ABB.nodo_lista N30 = new ABB.nodo_lista("galleta", "paco4", 3, 1, 2, 1);
          ABB.nodo_lista N31 = new ABB.nodo_lista("galleta", "sol4", 3, 1, 1, 1);
          ABB.nodo_lista N32 = new ABB.nodo_lista("galleta", "luna4", 3, 1, 4, 1);
          ABB.nodo_lista N12 = new ABB.nodo_lista("marco", "mike5", 0, 3, 90, 1);
          ABB.nodo_lista N50 = new ABB.nodo_lista("marco", "alba5", 0, 3, 2, 1);
          ABB.nodo_lista N51 = new ABB.nodo_lista("marco", "jorge5", 0, 3, 3, 1);
          ABB.nodo_lista N52 = new ABB.nodo_lista("marco", "luz5", 0, 3, 4, 1);
          ABB.nodo_lista N53 = new ABB.nodo_lista("marco", "carol5", 0, 3, 5, 1);

          ABB.nodo_lista N13 = new ABB.nodo_lista("fresa", "jr6", 3, 1, 100, 1);
          ABB.nodo_lista N14 = new ABB.nodo_lista("dori", "lorena7", 3, 1, 57, 1);
          ABB.nodo_lista N15 = new ABB.nodo_lista("mau", "lorena8", 3, 1, 49, 1);
          ABB.nodo_lista N16 = new ABB.nodo_lista("duglas", "lucas9", 0, 3, 37, 1);
          ABB.nodo_lista N17 = new ABB.nodo_lista("olga", "jr10", 3, 1, 150, 1);
          ABB.nodo_lista N18 = new ABB.nodo_lista("skapy", "lorena11", 3, 400, 1, 1);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N1);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N2);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N22);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N21);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N23);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N10);

          Miarbol.agregar_lista_abb(Miarbol.raiz, N19);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N30);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N31);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N32);

          Miarbol.agregar_lista_abb(Miarbol.raiz, N12);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N50);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N51);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N52);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N53);

          Miarbol.agregar_lista_abb(Miarbol.raiz, N13);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N14);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N15);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N16);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N17);
          Miarbol.agregar_lista_abb(Miarbol.raiz, N18);
         
         // Miarbol.recorrido(Miarbol.raiz);
          //Miarbol.graficarTOPGANADAS();
          //Miarbol.recorrido_naves(Miarbol.raiz);
          //Miarbol.graficarTOP_Unidades_destruidas();
         // Miarbol.modificarL("allan", "lorena", 1, 1, 1, 1);
          //Miarbol.ELIMINAR_LISTA_JUEGOS(Miarbol.raiz, "allan", "jr");
           //ABB.nodo_lista N1 = new ABB.nodo_lista("gaby", "lucas3", 0, 3, 2, 0);
            
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N);
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N1);
          // Miarbol.espejo(Miarbol.raiz);
          //Miarbol.espejo(Miarbol.raiz);
           Miarbol.graficar();
           

           return "insertardo";
            
        }
        [WebMethod]
        public string matrices()
        {
            matriz.insertarMatriz(1, 3, "barco", 0, 2, 3, 2, 0);
            matriz.insertarMatriz(1, 5, "barco2", 0, 2, 3, 2, 0);
            matriz.insertarMatriz(1, 1, "nave", 0, 2, 4, 5, 0);

            matriz.insertarMatriz(1, 7, "submarino", 0, 2, 4, 5, 1);

            matriz.insertarMatriz(5, 5, "vela", 0, 2, 3, 2, 1);
            matriz.insertarMatriz(5, 1, "nave3", 0, 2, 4, 5, 1);

            matriz.insertarMatriz(5, 7, "submarino3", 0, 2, 4, 5, 2);
            matriz.insertarMatriz(5, 2, "vela3", 0, 2, 3, 2, 2);
            matriz.insertarMatriz(6, 4, "nave34", 0, 2, 4, 5, 2);
            matriz.insertarMatriz(6, 8, "submarino34", 0, 2, 4, 5, 3);
            matriz.insertarMatriz(4, 2, "vela38", 0, 2, 3, 2, 3);
           // matriz.insertarMatriz(5, 7, "bus", 0, 2, 4, 5, 3);
           // matriz.insertarMatriz(3, 1, "barquito", 0, 2, 4, 5, 3);
           // matriz.insertarMatriz(3, 3, "navega", 0, 2, 3, 2, 3);
         //   matriz.insertarMatriz(3, 1, "astronauta", 0, 2, 4, 5, 0);
            matriz.ParaGraficarNiveles();
       
          
           
            return "exitosa matriz";
        }

        [WebMethod]
        public string leercsvUsuarios()
        {   
            
            string ubicacionArchivo=("C:\\Users\\Andrea Flores\\Desktop\\CARGAS\\usuarios.csv");
            try
            {
                StreamReader f = new StreamReader(ubicacionArchivo);
                string lineas = f.ReadLine();
                lineas = f.ReadLine();
                while (lineas != null)
                {
                    
                        char[] delimitador = { ',' };
                        string[] palabras = lineas.Split(delimitador);
                        Miarbol.insertar(palabras[0], palabras[1], palabras[2], Convert.ToInt32(palabras[3].ToString()), 0, 0);
                        lineas = f.ReadLine();         
                }
                
                f.Close();
               // Miarbol.graficar();
                
            }
            catch (Exception e)
            { 
                Console.WriteLine("Exception"+e.Message);
            }
            return "archivo leido de usuarios" ;
        }

        [WebMethod]
        public string leercsvJuegos_usuarios()
        {
            //leercsvUsuarios();
            string ubicacionArchivo=("C:\\Users\\Andrea Flores\\Desktop\\CARGAS\\juegos.csv");
            try
            {
                StreamReader f = new StreamReader(ubicacionArchivo);
                string lineas = f.ReadLine();
                lineas = f.ReadLine();
                while (lineas != null)
                {
                    
                        char[] delimitador = { ',' };
                        string[] palabras = lineas.Split(delimitador);
                        ABB.nodo_lista nuevo = new ABB.nodo_lista(palabras[0],palabras[1],Convert.ToInt32(palabras[2].ToString()), Convert.ToInt32(palabras[3].ToString()),Convert.ToInt32(palabras[4].ToString()),Convert.ToInt32(palabras[5].ToString()));
                        Miarbol.agregar_lista_abb(Miarbol.raiz,nuevo);
                        lineas = f.ReadLine();         
                }
                
                f.Close();
                Miarbol.graficar();
                
            }
            catch (Exception e)
            { 
                Console.WriteLine("Exception"+e.Message);
            }


            return "archivo leido exitosamente, juego de usuarios";
        }

        [WebMethod]
        public string leercsvTablero()
        {

            string ubicacionArchivo = ("C:\\Users\\Andrea Flores\\Desktop\\CARGAS\\tablero.csv");
            try
            {
                StreamReader f = new StreamReader(ubicacionArchivo);
                string lineas = f.ReadLine();
                lineas = f.ReadLine();
                while (lineas != null)
                {

                    char[] delimitador = { ',' };
                    string[] palabras = lineas.Split(delimitador);

                    //matriz.insertarMatriz(
                    lineas = f.ReadLine();
                }

                f.Close();
                // Miarbol.graficar();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e.Message);
            }
            return "el archivo se ha leido exitosamente";
        }

   
    }
}