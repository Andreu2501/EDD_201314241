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
        static ABB Miarbol = new ABB();
        static MatrizOrtogonal matriz = new MatrizOrtogonal();
        static Listas guardar = new Listas();
        
        
       

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
//*****************************************
        //ABC USUARIOS
        [WebMethod]
        public string insertarUsuario(string nickname, string contraseña, string correo, int conectado)
        {
            Miarbol.insertar(nickname, contraseña, correo, conectado, 0, 0);
            return "se inserto exitosamente los usuarios";
        }

        [WebMethod]
        public string modificarUsuario(string nickname, string dato_nuevo, string contraseña_nuevo, string correo_nuevo, int conectado_nuevo)
        {
            Miarbol.modificar(nickname, dato_nuevo, contraseña_nuevo, correo_nuevo, conectado_nuevo, 0, 0);

            return "se modifico exitosamente los usuarios";
        }

        [WebMethod]

        public string eliminarUsuario(string nickname_eliminar)
        {

            Miarbol.eliminar(nickname_eliminar);
            return "se ha eliminado el usuario exitosamente";
        }

//***********************************************
        //ABC JUEGOS
        [WebMethod]
        public string insertarjuego(string nickname_base, string nickname_oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int gano)
        {
            ABB.nodo_lista nuevo = new ABB.nodo_lista(nickname_base, nickname_oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, gano);
            Miarbol.agregar_lista_abb(Miarbol.raiz, nuevo);
            return "se ha insertado exitosamente los juegos";
        }

        [WebMethod]
        public string modificarJuego(string nickname_base, string nickname_oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int gano)
        {
            Miarbol.modificarL(nickname_base, nickname_oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, gano);
            return "se ha modificado exitosamente los juegos del usuario";
        }

        [WebMethod]
        public string eliminarJuego(string nickname_base, string nickname_oponente)
        {
            Miarbol.ELIMINAR_LISTA_JUEGOS(Miarbol.raiz, nickname_base, nickname_oponente);
            return "se ha eliminado exitosamente del juego del usuaririo";
        }
//*********************************************************************************************
        [WebMethod]
        public string graficarUsuario()
        {
            Miarbol.graficar();
            return "el arbol se ha graficado correctamente";
        }

        [WebMethod]
        public string graficarEspejo()
        {
            Miarbol.espejo(Miarbol.raiz);
            Miarbol.graficar();
            return "el arbol espejo se ha graficado correctamente";
        }

      /*  [WebMethod]
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
         
         Miarbol.recorrido(Miarbol.raiz);
          Miarbol.graficarTOPGANADAS();
          Miarbol.recorrido_naves(Miarbol.raiz);
          Miarbol.graficarTOP_Unidades_destruidas();
         // Miarbol.modificarL("allan", "lorena", 1, 1, 1, 1);
          //Miarbol.ELIMINAR_LISTA_JUEGOS(Miarbol.raiz, "allan", "jr");
           //ABB.nodo_lista N1 = new ABB.nodo_lista("gaby", "lucas3", 0, 3, 2, 0);
            
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N);
           //Miarbol.agregar_lista_abb(Miarbol.raiz, N1);
          // Miarbol.espejo(Miarbol.raiz);
          //Miarbol.espejo(Miarbol.raiz);
          // Miarbol.graficar();*/
           

         //  return "insertardo";
            
        //}
     /*
        [WebMethod]
        public string matrices()
        {
            matriz.insertarMatriz("pablo",1, 3, "barco",  0);
            matriz.insertarMatriz("pedro",1, 5, "barco2",0);
            matriz.insertarMatriz("andrea",1, 1, "nave", 0);

            matriz.insertarMatriz("celeste",1, 7, "submarino", 1);

            matriz.insertarMatriz("jr",5, 5, "vela",  1);
            matriz.insertarMatriz("telma",5, 1, "nave3", 1);

            matriz.insertarMatriz("mau",5, 7, "submarino3", 2);
            matriz.insertarMatriz("conejo",5, 2, "vela3",  2);
            matriz.insertarMatriz("dog",6, 4, "nave34", 2);
            matriz.insertarMatriz("ser",6, 8, "submarino34", 3);
            matriz.insertarMatriz("kl",4, 2, "vela38", 3);
           // matriz.insertarMatriz(5, 7, "bus", 0, 2, 4, 5, 3);
           // matriz.insertarMatriz(3, 1, "barquito", 0, 2, 4, 5, 3);
           // matriz.insertarMatriz(3, 3, "navega", 0, 2, 3, 2, 3);
         //   matriz.insertarMatriz(3, 1, "astronauta", 0, 2, 4, 5, 0);
            matriz.ParaGraficarNiveles();
       
          
           
            return "exitosa matriz";*/
      //  }

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
                Miarbol.recorridoTOP(Miarbol.raiz);
                Miarbol.graficarTOPGANADAS();
                Miarbol.recorridoPrincipalNaves(Miarbol.raiz);
                Miarbol.graficarTOP_Unidades_destruidas();
                // Miarbol.graficar();
                
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
                    //guardando los 1;
                   
                        Listas.nodoM nuevo = new Listas.nodoM(palabras[0], palabras[1], Convert.ToInt32(palabras[2]), palabras[3], Convert.ToInt32(palabras[4]));
                        guardar.insertar_achivo(nuevo);
                      
                   
                   
                   // int col=matriz.getLetra(Convert.ToChar(palabras[1]));
                    //int nivel=matriz.setnivel(palabras[3]);
                    //matriz.insertarMatriz(palabras[0],col ,Convert.ToInt32(palabras[2]), palabras[3],nivel);
                    lineas = f.ReadLine();
                }

                f.Close();
                //Reportede0();
                //Reporte1();//sobrevivientes
                   
                
                // Miarbol.graficar();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e.Message);
            }
            return "el archivo se ha leido el archivo tablero exitosamente";
        }

        [WebMethod]
        public string leerJuegoActual()
        {
            string ubicacionArchivo = ("C:\\Users\\Andrea Flores\\Desktop\\CARGAS\\juegoActual.csv");
            try
            {
                StreamReader f = new StreamReader(ubicacionArchivo);
                string lineas = f.ReadLine();
                lineas = f.ReadLine();
                while (lineas != null)
                {

                    char[] delimitador = { ',' };
                    string[] palabras = lineas.Split(delimitador);
                    
                    lineas = f.ReadLine();
                }

                f.Close();
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e.Message);
            }
            return "el archivo se ha leido el archivo juego exitoso exitosamente";
        
        }

        [WebMethod]

        public string Reportede0()
        {
            MatrizOrtogonal matriz_destruida = new MatrizOrtogonal();
            
            Listas.nodoM aux = guardar.primero;
            while (aux != null)
            {
                if (aux.num == 0)
                {
                    int col = matriz.getLetra(Convert.ToChar(aux.columna));
                    int nivel = matriz.setnivel(aux.unidad);
                    matriz_destruida.insertarMatriz(aux.jugador, aux.fila, col, aux.unidad, nivel);
                }
                aux = aux.siguiente;

            }
            matriz_destruida.ParaGraficarNiveles();
           
            return "Reporte de destruidos generado";        
        }
         [WebMethod]
        public string Reporte1()
        {
            MatrizOrtogonal matriz_sobrevivientes = new MatrizOrtogonal();
            Listas.nodoM aux = guardar.primero;
            while (aux != null)
            {
                if (aux.num == 1)
                {
                    int col = matriz.getLetra(Convert.ToChar(aux.columna));
                    int nivel = matriz.setnivel(aux.unidad);
                    matriz_sobrevivientes.insertarMatriz(aux.jugador, aux.fila, col, aux.unidad, nivel);
                }
                aux = aux.siguiente;

            }
            matriz_sobrevivientes.ParaGraficarNiveles();

            return "Reporte de sobrevivientes generado"; 
        
        }

         [WebMethod]
         public bool VerificarExistenciaUsuario(string nickname, string contraseña)
         {
            
            ABB.nodo devuelve= Miarbol.buscarUsuarioContraseña(Miarbol.raiz, nickname, contraseña);
            if (devuelve != null)
            {
                return true;
            }
            
             return false;
         }

         [WebMethod]
         public string graficarTopGanadasLista()
         {

            Miarbol.graficarTOPGANADAS();
            return "grafica generada";
         }

         [WebMethod]
         public string graficarTopDestruidas()
         {

             Miarbol.graficarTOP_Unidades_destruidas();
             return "grafica generada";
         }

         [WebMethod]
         public string TOPGANADAS()
         {

             Miarbol.recorrido(Miarbol.raiz);
             return "listaTOP";
         }

         [WebMethod]
         public string TOPDESTRUIDAS()
         {

             Miarbol.recorrido_naves(Miarbol.raiz);
             return "listaDestruidas";
         }

         [WebMethod]
         public string InsertarMatrizJuego(string columna, string fila, string unidad,string jugador)
         {
            int fil=Convert.ToInt32(fila);
             int col=matriz.getLetra(Convert.ToChar(columna));
             int nivel= matriz.setnivel(unidad);
             matriz.insertarMatriz(jugador,fil,col,unidad,nivel);
             matriz.ParaGraficarNiveles();
             return "se ha insertado exitosamente";
         }
    }
}