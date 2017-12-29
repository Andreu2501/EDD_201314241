using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Diagnostics;



namespace ServicioWeb
{
    public class MatrizOrtogonal
    {
        public lista_cabecera eFilas;
        public lista_cabecera eColumnas;

        public MatrizOrtogonal()
        {
            this.eFilas = new lista_cabecera();
            this.eColumnas = new lista_cabecera();
        }
        public class nodo_matriz
        {
            public nodo_matriz arriba;
            public nodo_matriz abajo;
            public nodo_matriz siguiente;
            public nodo_matriz anterior;
            public string unidad;
           // public int movimiento;
           // public int alcance;
          //  public int daño;
           // public int vida;
            public string jugador;
            public int fila;
            public int columna;
            public int nivel;
            public nodo_matriz(string jugador,int fila, int columna, string unidad, int nivel)
            {
                this.abajo = null;
                this.anterior = null;
                this.arriba = null;
                this.abajo = null;
                this.jugador = jugador;
                this.fila = fila;
                this.columna = columna;
                this.unidad = unidad;
                this.nivel = nivel;


            }

        }

        public class encabezado
        {
            public encabezado siguiente;
            public encabezado anterior;
            public encabezado arriba;
            public encabezado abajo;
            public nodo_matriz acceso;
            public int id;
            public int nivel;

            public encabezado(int id, int nivel)
            {
                this.acceso = null;
                this.siguiente = null;
                this.anterior = null;
                this.abajo = null;
                this.arriba = null;
                this.id = id;
                this.nivel = nivel;


            }


        }
      

        //*******************************************************************************************************************************
        //LISTA CABECERA
        //*******************************************************************************************************************************   

        public class lista_cabecera
        {
            public encabezado primero;
            public int tamaño;

            public lista_cabecera()
            {
                this.primero = null;
                this.tamaño = 0;

            }

            public void insertar(encabezado nuevo)
            {
                if (this.primero == null)
                {
                    this.primero = nuevo;
                }
                else
                {    //inserto al inicio
                    if (nuevo.id < this.primero.id)
                    {
                        nuevo.siguiente = this.primero;
                        this.primero.anterior = nuevo;
                        this.primero = nuevo;
                    }
                    else
                    {
                        encabezado actual = this.primero;
                        while (actual.siguiente != null)
                        {    //inserto en el medio
                            if (nuevo.id < actual.siguiente.id)
                            {
                                nuevo.siguiente = actual.siguiente;
                                actual.siguiente.anterior = nuevo;
                                nuevo.anterior = actual;
                                actual.siguiente = nuevo;
                                break;
                            }

                            actual = actual.siguiente;
                        }
                        //inserto al final
                        if (actual.siguiente == null)
                        {
                            actual.siguiente = nuevo;
                            nuevo.anterior = actual;
                        }
                    }
                }

            }
            //obteniendo el nodo de cada encabeado segun su id
            public encabezado getencabezado(int id)
            {
                encabezado actual = this.primero;
                while (actual != null)
                {
                    if (actual.id == id)
                    {
                        return actual;
                    }

                    actual = actual.siguiente;
                }

                return null;


            }

            

        
         
        }
        public encabezado getNivelCorrecto(encabezado encontrado, int nivelBuscado)
        {
            while (encontrado.nivel != nivelBuscado)
            {
                encontrado = encontrado.arriba;
            }
            return encontrado;

        }


        
        //*******************************************************************************************************************************
        //MATRIZ
        //*******************************************************************************************************************************   

        public void insertarMatriz(string jugador,int fila, int columna, string unidad, int nivel)
        {
            nodo_matriz nuevo = new nodo_matriz(jugador, fila, columna, unidad, nivel);

            //INSERCION_FILAS
            //devuelve un nodo del encabezado si lo encuentra
            encabezado nivel0 = eFilas.getencabezado(fila);

            if (nivel0 == null) //Si no existe encabezado se crea.
            {

                //CREANDO LOS 4 NODOS
                nivel0 = new encabezado(fila, 0);
                encabezado nivel1 = new encabezado(fila, 1);
                encabezado nivel2 = new encabezado(fila, 2);
                encabezado nivel3 = new encabezado(fila, 3);
                //REALIZO LOS ENLACES
                nivel0.arriba = nivel1;
                nivel1.arriba = nivel2;
                nivel2.arriba = nivel3;
                nivel3.abajo = nivel2;
                nivel2.abajo = nivel1;
                nivel1.abajo = nivel0;
                //INSERTO EL NIVEL0
                eFilas.insertar(nivel0);
              
                encabezado actualizarnivel = getNivelCorrecto(nivel0, nuevo.nivel);
                nivel0 = actualizarnivel;
                nivel0.acceso = nuevo;


            }
            else
            {
                encabezado actualizarnivel = getNivelCorrecto(nivel0, nuevo.nivel);
                nivel0 = actualizarnivel;
                nodo_matriz actual1 = nivel0.acceso;
                if (actual1 == null)
                {
                    nivel0.acceso = nuevo;
                }
                else
                {
                    if (nuevo.columna == actual1.columna)
                    {
                        actual1 = nuevo;
                    }
                    else if (nuevo.columna < actual1.columna)//insercion al inicio
                    {
                        nuevo.siguiente = actual1;
                        actual1.anterior = nuevo;
                        nivel0.acceso = nuevo;

                        actual1 = nuevo;
                    }
                    else
                    {
                        nodo_matriz actual = nivel0.acceso;
                        while (actual.siguiente != null)
                        {
                            if (nuevo.columna < actual.siguiente.columna) //Inserción en el medio
                            {
                                nuevo.siguiente = actual.siguiente;
                                actual.siguiente.anterior = nuevo;
                                nuevo.anterior = actual;
                                actual.siguiente = nuevo;
                                break;
                            }

                            actual = actual.siguiente;
                        }

                        if (actual.siguiente == null) //Inserción al final
                        {
                            actual.siguiente = nuevo;
                            nuevo.anterior = actual;
                        }
                    }
                }
            }
            //FIN_FILAS

            //INSERCION_COLUMNAS
            //devuelve un nodo del encabezado si lo encuentra
            encabezado nivel0_c = eColumnas.getencabezado(columna);

            if (nivel0_c == null) //Si no existe encabezado se crea.
            {
                //eFila = new encabezado(fila,nivel);
                //eFilas.insertar(eFila);

                //CREANDO LOS 4 NODOS
                nivel0_c = new encabezado(columna, 0);
                encabezado nivel1_c = new encabezado(columna, 1);
                encabezado nivel2_c = new encabezado(columna, 2);
                encabezado nivel3_c = new encabezado(columna, 3);
                //REALIZO LOS ENLACES
                nivel0_c.arriba = nivel1_c;
                nivel1_c.arriba = nivel2_c;
                nivel2_c.arriba = nivel3_c;
                nivel3_c.abajo = nivel2_c;
                nivel2_c.abajo = nivel1_c;
                nivel1_c.abajo = nivel0_c;

                //INSERTO EL NIVEL0
                eColumnas.insertar(nivel0_c);
                
                encabezado actualizarnivel_c = getNivelCorrecto(nivel0_c, nuevo.nivel);
                nivel0_c = actualizarnivel_c;

                nivel0_c.acceso = nuevo;


                


            }
            else
            {
                encabezado actualizarnivel_c = getNivelCorrecto(nivel0_c, nuevo.nivel);
                nivel0_c = actualizarnivel_c;
                //nivel0_c.acceso = nuevo;

                nodo_matriz actual1_c = nivel0_c.acceso;

                if (actual1_c == null)
                {
                    nivel0_c.acceso = nuevo;
                }
                else
                {
                    if (nuevo.fila == actual1_c.fila)
                    {
                        actual1_c = nuevo;
                    }
                    else if (nuevo.fila < actual1_c.fila) //Inserción al inicio
                    {
                        nuevo.abajo = actual1_c;
                        actual1_c.arriba = nuevo;
                        nivel0_c.acceso = nuevo;
                        actual1_c = nuevo;

                       

                      

                    }
                    else
                    {
                        nodo_matriz actual = nivel0_c.acceso;
                        while (actual.abajo != null)
                        {
                            if (nuevo.fila < actual.abajo.fila) //Inserción en el medio
                            {
                                nuevo.abajo = actual.abajo;
                                actual.abajo.arriba = nuevo;
                                nuevo.arriba = actual;
                                actual.abajo = nuevo;
                                break;
                            }

                            actual = actual.abajo;
                        }

                        if (actual.abajo == null) //Inserción al final
                        {
                            actual.abajo = nuevo;
                            nuevo.arriba = actual;
                        }
                    }
                }
            }
            //FIN_COLUMNAS
            enlaces(nuevo, 1);
        }



        public nodo_matriz buscarNiveles(int fila, int columna, int nivel)
        {
            encabezado filaActual = eFilas.getencabezado(fila);
            encabezado columnaActual = eColumnas.getencabezado(columna);
            filaActual = getNivelCorrecto(filaActual, nivel);
            columnaActual = getNivelCorrecto(columnaActual, nivel);
            if (filaActual != null && columnaActual != null)
            {
                nodo_matriz actual = filaActual.acceso;
                while (actual != null)
                {
                    if (actual.columna == columna)
                    {
                        break;
                    }
                    actual = actual.siguiente;
                }
                if (actual != null && actual.columna == columna)
                {
                    return actual;

                }
            }

            return null;

        }

        public nodo_matriz enlaces(nodo_matriz actual, int insertando)
        {
            //se supone que actual es el nodo que acabas de insertar
            //el int de insertando servira para saber si queres hacer los enlaces 
            //insertando = 1 = hacer enlaces
            //insertando = 0 = quitar enlaces
            if (insertando == 1)
            {
                int nivelAbajo = actual.nivel - 1;
                int nivelArriba = actual.nivel + 1;
                while (nivelAbajo != -1)
                {
                    nodo_matriz posicionAbajo = buscarNiveles(actual.fila, actual.columna, nivelAbajo);
                    if (posicionAbajo != null)
                    {
                        actual.abajo = posicionAbajo;
                        posicionAbajo.arriba = actual;
                        break;
                    }
                    nivelAbajo--;
                }
                while (nivelArriba != 4)
                {
                    nodo_matriz posicionArriba = buscarNiveles(actual.fila, actual.columna, nivelArriba);
                    if (posicionArriba != null)
                    {
                        actual.arriba = posicionArriba;
                        posicionArriba.abajo = actual;
                        break;
                    }
                    nivelArriba++;
                }
                return actual;
            }
            else
            { //eliminar enlaces
                //Los enlaces ya deberían existir. 
                /*
                 * Esto mas que todo lo que hara es que va a cambiar los enlaces ej. S
                 * nivel1.nivel2.nivel3
                 * y se elimina el nivel 2
                 * nivel1 . nivel3
                 * */
                //deberia salirte con un eliminar normal de una lista doble enlazada
                //Con la diferencia que envez de usar apuntadores anterior y siguiente
                //usas los de arriba y abajo

                //pilaaasssss -u-
                /*
                if (actual.abajo != null)
                {
                    actual = actual.arriba;
                }
                else 
                {
                    actual.abajo.arriba = actual.arriba;
                    if (actual.arriba != null)
                    {
                        actual.arriba.abajo = actual.abajo;
                    }
                }*/


                return null;
            }
        }


        public void graficar_fila(TextWriter archivo,int nivel)
        {
            encabezado aux3 = eFilas.primero;

            int cont = 400;
            if (aux3 == null)
            {

                return;
            }
            else
            {
                //primero
               
                while (aux3 != null)
                {
                    encabezado actualizarnivel = getNivelCorrecto(aux3, nivel);
                    if (actualizarnivel.acceso != null)
                    {
                        archivo.WriteLine("Fila" + aux3.id + "[ label=\"" + "FILA" + aux3.id + "\"];\n");

                    }
                    aux3 = aux3.siguiente;
                    cont++;
                }



                //ENLACES
           
               encabezado aux4 = eFilas.primero;
               aux4 = eFilas.primero;
               encabezado aux5 = aux4.siguiente;
                int a = 0;
                if (aux4 != null)
                  {
                     while (aux4 != null)
                     {
                          encabezado subiraux4 = getNivelCorrecto(aux4, nivel);
                             if (subiraux4.acceso != null)
                                {
                                 while (aux5 != null)
                                {
                                      encabezado subiraux5 = getNivelCorrecto(aux5, nivel);
                                    if (subiraux5.acceso != null)
                                       {
                                         if (subiraux4 != subiraux5)
                                            {

                                                archivo.WriteLine("Fila" + subiraux4.id + "-> Fila" + subiraux5.id + ";\n");
                                                archivo.WriteLine("Fila" + subiraux5.id + "-> Fila" + subiraux4.id + ";\n");


                                                    break;
                                              }

                                        }
                                              aux5 = aux5.siguiente;


                                                    }

                                                }
                                                aux4 = aux4.siguiente;
                                            }



                                        }
                                        archivo.Write("\n");                          
                //ACCESOS
             encabezado aux6 = eFilas.primero;
                while (aux6 != null)
                {
                    encabezado subiraux6 = getNivelCorrecto(aux6, nivel);
                    if (subiraux6.acceso != null)
                    {

                        archivo.WriteLine("Fila" + subiraux6.id + " -> \"Unidad" + subiraux6.acceso.fila + "," + subiraux6.acceso.columna + "\";\n");
                        archivo.WriteLine("\"Unidad" + subiraux6.acceso.fila + "," + subiraux6.acceso.columna + "\"" + " -> Fila" + subiraux6.id + ";\n");


                        aux6 = aux6.siguiente;

                    }
                    else
                    {
                        aux6 = aux6.siguiente;
                    }
                }

            }
        }

        
        public void graficar_columna(TextWriter archivo,int nivel)
            {
                encabezado aux3 = eColumnas.primero;

                int cont = 300;
                if (aux3 == null)
                {

                    return;
                }
                else
                {
                    //primero
                    while(aux3!=null){
                    encabezado actualizarnivel = getNivelCorrecto(aux3, nivel);
                    if (actualizarnivel.acceso != null)
                    {
                        archivo.WriteLine("Columna" + aux3.id + "[ label=\"" + devolverLetra( aux3.id)+ "\"];\n");
                       
                    }
                    aux3 = aux3.siguiente;
                    cont++;
                    }
                  
                  
                    //ENLACES DE ENCABEZADOS


                    encabezado aux4 = eColumnas.primero;


                    aux4 = eColumnas.primero;
                    encabezado aux5 = aux4.siguiente;
                    int a = 0;
                    if (aux4 != null)
                    {

                        while (aux4!= null)
                        {
                            encabezado subiraux4 = getNivelCorrecto(aux4, nivel);
                            if (subiraux4.acceso != null)
                            {
                               
                                while (aux5 != null)
                                {
                                    encabezado subiraux5 = getNivelCorrecto(aux5, nivel);   
                                    if (subiraux5.acceso != null)
                                    {
                                        if (subiraux4 != subiraux5)
                                        {
                                            archivo.WriteLine("Columna" + subiraux4.id + "-> Columna" + subiraux5.id + ";\n");
                                            archivo.WriteLine("Columna" + subiraux5.id + "-> Columna" + subiraux4.id + ";\n");

                                            break;
                                        }
                                        
                                    }
                                    aux5 = aux5.siguiente;
                                   

                                }
                                
                            }
                            aux4 = aux4.siguiente;
                        }



                    }
                    archivo.Write("\n");







                    //ACCESOS
                    encabezado aux6 = eColumnas.primero;
                    
                    if (aux6 != null)
                    {
                        while (aux6 != null)
                        {
                            encabezado subiraux6 = getNivelCorrecto(aux6, nivel);
                            if (subiraux6.acceso != null)
                            {

                                archivo.WriteLine("Columna" + subiraux6.id + " -> \"Unidad" + subiraux6.acceso.fila + "," + subiraux6.acceso.columna + "\";\n");
                                archivo.WriteLine("\"Unidad" + subiraux6.acceso.fila + "," + subiraux6.acceso.columna + "\"" + " ->   Columna" + subiraux6.id + ";\n");


                                aux6 = aux6.siguiente;
                            }
                            else { aux6 = aux6.siguiente; }
                           
                        }

                    }
                }
            }
            
        public void ParaGraficarNiveles()
        {
            int contador = 0;
            while (contador != 4)
            {
            graficarMatriz(contador);
            cmdMatriz(contador);
              contador++;

             }

        }

        public void graficarMatriz(int nivel)
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\ARCHIVOSDOT\\Matriz"+nivel+".dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1,style=filled];");
            archivo.WriteLine("edge[color=black];");
            archivo.WriteLine("rankdir=UD;\n");
            encabezado aux = eColumnas.primero;
            encabezado auxFila = eFilas.primero;
           
            archivo.WriteLine("{rank=min;Nivel" + nivel + ";\n");

            int cont = 300;
            while (aux != null)
            {
                encabezado aux7 = getNivelCorrecto(aux, nivel);
                if (aux7.acceso != null)
                {
                    archivo.WriteLine("Columna" + aux.id + ";");
                    aux = aux.siguiente;
                    cont++;
                }
                else
                {
                    aux = aux.siguiente;
                }
            }
            archivo.WriteLine("};\n");
            if (eColumnas.primero != null)
            {
                //METODO GRAFICAR COLUMNA
                graficar_columna(archivo,nivel);
             
               

            }
            if (auxFila!= null)
            {
                //METODO GRAFICAR FILA
                graficar_fila(archivo,nivel);

  
                
                if (eFilas.primero != null)
                {
                    //ACCESOS DE FILA
                    
                    while (auxFila != null)
                    {
                        encabezado subirauxFila = getNivelCorrecto(auxFila, nivel);
                        //subo fila actual
                        
                        if (subirauxFila.acceso != null)
                        {
                            archivo.WriteLine("{rank=same;  Fila" + subirauxFila.id + ";");
                            nodo_matriz falso = subirauxFila.acceso;
                            while (falso != null)
                            {

                                archivo.WriteLine("\"Unidad" + falso.fila + "," + falso.columna + "\";");
                                falso = falso.siguiente;
                            }
                            archivo.WriteLine("}");
                            archivo.WriteLine("\n");
                            auxFila = auxFila.siguiente;
                        }
                        else { auxFila = auxFila.siguiente; }

                    }


                }
                encabezado nc = eColumnas.primero;
                while (nc != null)
                {
                    encabezado PARANIVELES = getNivelCorrecto(nc, nivel);
                    if (PARANIVELES.acceso != null)
                    {
                        archivo.WriteLine("Nivel" + nivel + "-> Columna" + PARANIVELES.id + ";\n");
                        archivo.WriteLine("Columna" + PARANIVELES.id+ "-> Nivel" + nivel + ";\n");
                        break;
                    }
                    nc = nc.siguiente;

                }
                encabezado nf =eFilas.primero;
                while (nf != null)
                {
                    encabezado PARANIVELESF = getNivelCorrecto(nf, nivel);
                    if (PARANIVELESF.acceso != null)
                    {
                        archivo.WriteLine("Nivel" + nivel + " -> Fila" + PARANIVELESF.id + ";\n");
                        archivo.WriteLine("Fila" + PARANIVELESF.id + "-> Nivel" + nivel + ";\n");
                        break;
                    }
                    nf = nf.siguiente;

                }

                       
                graficarNodosInteriores(archivo, nivel);


            }
           
            archivo.WriteLine("label = \"MATRIZ ORTOGONAL \";\n");
            archivo.WriteLine("}");
            archivo.Close();
        }








        public void graficarNodosInteriores(TextWriter archivo,int nivel)
        {
            //primero mandamos el encabezado
            encabezado primero=eFilas.primero;
            //recibo el nodo primero
            
            while (primero != null)
            {
                encabezado subirFilas = getNivelCorrecto(primero, nivel);

                nodo_matriz aux = subirFilas.acceso;
                if (subirFilas.acceso != null)
                {
                    if (aux != null)
                    {
                        while (aux != null) 
                        {

                            archivo.WriteLine("\"Unidad" + aux.fila + "," + aux.columna + "\""+"[ label=\" Jugador: " + aux.jugador+"\\n"+"Unidad "+aux.unidad+"\\n"+aux.fila+","+devolverLetra(aux.columna)+ "\"];\n");
                            aux = aux.siguiente;
                        }

                        aux = subirFilas.acceso;
                        while (aux.siguiente != null)
                        {
                            archivo.WriteLine("\"Unidad" + aux.fila + "," + aux.columna + "\"" + "->" + "\"Unidad" + aux.siguiente.fila + "," + aux.siguiente.columna + "\";\n");
                            archivo.WriteLine("\"Unidad" + aux.siguiente.fila + "," + aux.siguiente.columna + "\"" + "->" + "\"Unidad" + aux.fila + "," + aux.columna + "\";\n");
                            if (aux.abajo != null)
                            {

                                archivo.WriteLine("\"Unidad" + aux.fila + "," + aux.columna + "\"" + "->" + "\"Unidad" + aux.abajo.fila + "," + aux.abajo.columna + "\";\n");
                                archivo.WriteLine("\"Unidad" + aux.abajo.fila + "," + aux.abajo.columna + "\"" + "->" + "\"Unidad" + aux.fila + "," + aux.columna + "\";\n");


                            }
                            aux = aux.siguiente;
                        }
                        if (aux.abajo != null)
                        {
                            archivo.WriteLine("\"Unidad" + aux.fila + "," + aux.columna + "\"" + "->" + "\"Unidad" + aux.abajo.fila + "," + aux.abajo.columna + "\";\n");
                            archivo.WriteLine("\"Unidad" + aux.abajo.fila + "," + aux.abajo.columna + "\"" + "->" + "\"Unidad" + aux.fila + "," + aux.columna + "\";\n");

                        }

                    }
                   
                    primero = primero.siguiente;
                    continue;

                }
                else
                {
              
                    primero = primero.siguiente;
                }
            }




        }

        public void cmdMatriz(int cont)
        {
            try
            {


                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\Matriz"+cont+".dot -o  C:\\ARCHIVOSDOT\\Matriz"+cont+".png ");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }



        }
        // entra el numero y me devuelve la letra para ingresarla
        public string devolverLetra(int n)
        {
            if (n == 0)
            {
                return "A";
            }
            else if (n == 1)
            {
                return "B";
            }
            else if (n == 2)
            {
                return "C";
            }
            else if (n == 3)
            {
                return "D";
            }
            else if (n == 4)
            {
                return "E";
            }
            else if (n == 5)
            {
                return "F";
            }
            else if (n == 6)
            {
                return "G";
            }
            else if (n == 7)
            {
                return "H";
            }
            else if (n == 8)
            {
                return "I";
            }
            else if (n == 9)
            {
                return "J";
            }
            else if (n == 10)
            {
                return "K";
            }
            else if (n == 11)
            {
                return "L";
            }
            else if (n == 12)
            {
                return "M";
            }
            else if (n == 13)
            {
                return "N";
            }
            else if (n == 14)
            {
                return "Ñ";
            }
            else if (n == 15)
            {
                return "O";
            }
            else if (n == 16)
            {
                return "P";
            }
            else if (n == 17)
            {
                return "Q";
            }
            else if (n == 18)
            {
                return "R";
            }
            else if (n == 19)
            {
                return "S";
            }
            else if (n == 20)
            {
                return "T";
            }
            else if (n == 21)
            {
                return "U";
            }
            else if (n == 22)
            {
                return "V";
            }
            else if (n == 23)
            {
                return "W";
            }
            else if (n == 24)
            {
                return "X";
            }
            else if (n == 25)
            {
                return "Y";
            }
            else if (n == 26)
            {
                return "Z";
            }
            else if (n == 27)
            {
                return "AA";

            }
            else if (n == 28)
            {
                return "BB";
            }
            else if (n == 29)
            {
                return "CC";
            }
            else if (n == 30)
            {
                return "DD";
            }
            else if (n == 31)
            {
                return "EE";
            }
            else if (n == 32)
            {
                return "FF";
            }
            else if (n == 33)
            {
                return "GG";
            }
            else if (n == 34)
            {
                return "HH";
            }
            else if (n == 35)
            {
                return "II";
            }
            else if (n == 36)
            {
                return "JJ";
            }
            else if (n == 37)
            {
                return "KK";
            }
            else if (n == 38)
            {
                return "L";
            }
            else if (n == 39)
            {
                return "MM";
            }
            else if (n == 40)
            {
                return "N";
            }
            else if (n == 41)
            {
                return "ÑÑ";
            }
            else if (n == 42)
            {
                return "OO";
            }
            else if (n == 43)
            {
                return "PP";
            }
            else if (n == 44)
            {
                return "QQ";
            }
            else if (n == 45)
            {
                return "RR";
            }
            else if (n == 46)
            {
                return "SS";
            }
            else if (n == 47)
            {
                return "TT";
            }
            else if (n == 48)
            {
                return "UU";
            }
            else if (n == 49)
            {
                return "VV";
            }
            else if (n == 50)
            {
                return "WW";
            }
            else if (n == 51)
            {
                return "XX";
            }
            else if (n == 52)
            {
                return "YY";
            }
            else
            {
                return "ZZ";
            }


        }
        //entra la letra y sale un numero
        //paso 1)
        public int getLetra(char character)
        {
            
            int ascii = (int)character;

            return ascii - 65;
        
        }

        //informacion de la unidad
        public int setnivel(string unidad)
        {
  
            var letra = unidad.ToCharArray();
            //Nivel0
            if ((letra[0] == 83))//nivel0 Submarino
            {

                return 0;
            }else if((letra[0]==70))//nivel 1 Fragata
            {
                return 1;
            }
            else if ((letra[0] == 67))//nivel 1  Crucero
            {
                return 1;
            }
            else if ((letra[0] == 66))//nivel 2 Bombardero
            {
                return 2;
            }
            else if ((letra[0] == 67) && (letra[0] == 97))//nivel 2 Caza
            {
                return 2;
            }
            else if ((letra[0] == 72))//nivel 2 Helicoptero
            {
                return 2;

            }
            else if ((letra[0] == 78))//nivel 3 Neosatelite
            {
                return 3;
            }
            else
            {
                return -1;
            }
                   
        }



        

       
          
    }
}
