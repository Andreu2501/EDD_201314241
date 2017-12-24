using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            public int movimiento;
            public int alcance;
            public int daño;
            public int vida;
            public int fila;
            public int columna;
            public int nivel;
            public nodo_matriz(int fila, int columna, string unidad, int movimiento, int alcance, int daño,int vida, int nivel)
            {
                this.abajo = null;
                this.anterior = null;
                this.arriba = null;
                this.abajo = null;
                this.fila = fila;
                this.columna = columna;
                this.unidad = unidad;
                this.movimiento = movimiento;
                this.alcance = alcance;
                this.daño = daño;
                this.vida = vida;
                this.nivel=nivel;

            
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

            public encabezado(int id,int nivel)
            {
                this.acceso = null;
                this.siguiente = null;
                this.anterior = null;
                this.abajo=null;
                this.arriba=null;
                this.id =id;
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
                    if (nuevo.id<this.primero.id) 
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
		    while(encontrado.nivel != nivelBuscado)
            {
			    encontrado = encontrado.arriba;
		    }
		    return encontrado;

        }
        //*******************************************************************************************************************************
                                                                //MATRIZ
        //*******************************************************************************************************************************   

        public void insertarMatriz(int fila, int columna, string unidad, int movimiento, int alcance, int daño,int vida, int nivel)
        {
            nodo_matriz nuevo = new nodo_matriz(fila, columna, unidad, movimiento, alcance, daño, vida, nivel);

            //INSERCION_FILAS
            //devuelve un nodo del encabezado si lo encuentra
            encabezado nivel0 = eFilas.getencabezado(fila);
               
            if (nivel0 == null) //Si no existe encabezado se crea.
            {
             
                //CREANDO LOS 4 NODOS
               nivel0 = new encabezado(fila, 0);
               encabezado nivel1 = new encabezado(fila, 1);
               encabezado  nivel2 = new encabezado(fila, 2);
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
                else{
                if (nuevo.columna == actual1.columna)
                {
                    actual1 = nuevo;
                }else if(nuevo.columna<actual1.columna)//insercion al inicio
                {
                    nuevo.siguiente = actual1;
                    actual1.anterior = nuevo;
                    actual1 = nuevo;
                }
                else
                {
                    nodo_matriz actual = nivel0.acceso;
                    while (actual.siguiente != null)
                    {
                        if (nuevo.columna<actual.siguiente.columna) //Inserción en el medio
                        {
                            nuevo.siguiente = actual.siguiente;
                            actual.siguiente.anterior = nuevo;
                            nuevo.anterior = actual;
                            nuevo.siguiente = nuevo;
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
                else{
                if (nuevo.fila == actual1_c.fila)
                {
                    actual1_c = nuevo;
                }
                else if (nuevo.fila < actual1_c.fila) //Inserción al inicio
                {
                    nuevo.abajo = actual1_c;
                    actual1_c.arriba = nuevo;
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
           encabezado filaActual =eFilas.getencabezado(fila);
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
            if(insertando==1){
                int nivelAbajo = actual.nivel -1;
                int nivelArriba = actual.nivel+1;
                while(nivelAbajo!=-1){
                    nodo_matriz  posicionAbajo = buscarNiveles(actual.fila, actual.columna,nivelAbajo);
                if(posicionAbajo!=null)
                {
                    actual.abajo = posicionAbajo;
                    posicionAbajo.arriba = actual;
                    break;
                }
                    nivelAbajo--;
                }
                    while(nivelArriba!=4){
                    nodo_matriz posicionArriba = buscarNiveles(actual.fila, actual.columna, nivelArriba);
                      if(posicionArriba!=null){
                        actual.arriba = posicionArriba;
                        posicionArriba.abajo = actual;
                        break;
                    }
                    nivelArriba++;
                }
                return actual;
            }else{ //eliminar enlaces
        //Los enlaces ya deberían existir. 
        /*
         * Esto mas que todo lo que hara es que va a cambiar los enlaces ej. S
         * nivel1->nivel2->nivel3
         * y se elimina el nivel 2
         * nivel1 -> nivel3
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







    }
}