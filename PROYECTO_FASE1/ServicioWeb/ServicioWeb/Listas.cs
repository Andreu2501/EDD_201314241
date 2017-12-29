using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb
{
    public class Listas
    {

        //*************************************************************************************************************
        //***********************************************************************************************************
        //para los reportes

        //lista para los reportes
        public class nodoM
        {
            public string jugador;
            public string columna;
            public int fila;
            public string unidad;
            public int num;
            public nodoM siguiente;
            public nodoM(string jugador, string columna, int fila, string unidad, int num)
            {
                this.jugador = jugador;
                this.columna = columna;
                this.fila = fila;
                this.unidad = unidad;
                this.num = num;

            }


        }

      
            public nodoM primero;

            public Listas()
            {
                this.primero = null;

            }
            public void insertar_achivo(nodoM nuevo)
            {
                if (this.primero == null)
                {
                    this.primero = nuevo;

                }
                else
                {
                    nodoM aux = this.primero;
                    while (aux.siguiente != null)
                    {
                        aux = aux.siguiente;
                    }
                    aux.siguiente = nuevo;


                }


            }


        }
    }
