using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb
{
    public class RamaArbol
    {
        public NodoRamaArbol primero;
        public int cont;//cuantos ingresa
        public Boolean hoja;//si tiene mas hojas
        public String tempFlechas;


        public RamaArbol()
        {
            this.cont = 0;
            this.hoja = true;
        }

        public void insertar(NodoRamaArbol nodo)
        {
            if (estaEnBlanco())
            {
                primero = nodo;
                primero.setAnterior(null);
                primero.setSiguiente(null);
                cont++;
            }
            else 
            {
                NodoRamaArbol aux = this.primero;
                do
                {
                    
                    if (nodo.getNumeroAtacante() <= aux.getNumeroAtacante())
                    {
                        cont++;
                        if (aux == this.primero)
                        {
                            this.primero.setAnterior(nodo);
                            this.primero.setIzquieda(nodo.getderecha());
                            nodo.setSiguiente(primero);
                            this.primero = nodo;
                            break;
                        }
                        else
                        {
                            nodo.setAnterior(aux.getAnterior());
                            nodo.setSiguiente(aux);
                            aux.getAnterior().setSiguiente(nodo);
                            aux.getAnterior().setderecha(nodo.getIzquieda());
                            aux.setAnterior(nodo);
                            aux.setIzquieda(nodo.getderecha());
                            break;
                        }
                    }
                    else if (aux.getSiguiente() == null)
                    {
                        cont++;
                        aux.setSiguiente(nodo);
                        aux.setderecha(nodo.getIzquieda());
                        nodo.setAnterior(aux);
                        nodo.setSiguiente(null);
                        break;
                    }
                    aux = aux.getSiguiente();

                } while (aux != null);
            
            }
        
        }

        public int getcont()
        {
            return cont;
        }

        private Boolean estaEnBlanco()
        {
            return primero == null;
        }

       
        public NodoRamaArbol getPrimero()
        {
            return primero;
        }

       
        public void setPrimero(NodoRamaArbol primero)
        {
            this.primero = primero;
        }

      
        public Boolean esHoja()
        {
            return hoja;
        }

      
        public void setHoja(Boolean hoja)
        {
            this.hoja = hoja;
        }

        public String getGraphNodo()
        {

            tempFlechas = "";
            String temp = "nodo" + primero.getNumeroAtacante() + primero.getCoordenadax() + primero.getCoordenaday() + " [ label =\"";
            NodoRamaArbol tempRecorre = primero;
            int i = 0;
            String detalles = "";
            for (i = 0; i < cont; i++, tempRecorre = tempRecorre.getSiguiente())
            {
                temp += "<C" + i + ">|<D" + i + ">Coordenada x: " + tempRecorre.getCoordenadax() + "\\n" + "Coordenada y: " + tempRecorre.getCoordenaday() + "\\n" + "Unidad atacante: " + tempRecorre.getUnidad_atacante() + "\\n" + "Unidad Dañada: " + tempRecorre.getUnidad_dañada() + "\\n" + "Emisor: " + tempRecorre.getEmisor() + "\\n" + "Receptor: " + tempRecorre.getReceptor() + "\\n" + "Fecha: " + tempRecorre.getFecha() + "\\n" + "Tiempo: " + tempRecorre.getTiempo() + "\\n" +"Numero Ataque: "+ tempRecorre.getNumeroAtacante() + "|";
                if (tempRecorre.getIzquieda() != null)
                {
                    tempFlechas += "nodo" + primero.getNumeroAtacante() + primero.getCoordenadax() + primero.getCoordenaday() + ":C" + i + "->nodo" + tempRecorre.getIzquieda().primero.getNumeroAtacante() + tempRecorre.getIzquieda().primero.getCoordenadax() + tempRecorre.getIzquieda().primero.getCoordenaday() + "\n";
                }
            }
            temp += "<C" + i + ">\"  fillcolor=\"#FFFFFF\"];\n";
            tempRecorre = primero;
            while (tempRecorre.getSiguiente() != null)
            {
                tempRecorre = tempRecorre.getSiguiente();
            }
            if (tempRecorre.getderecha()!= null)
            {
                tempFlechas += "nodo" + primero.getNumeroAtacante() + primero.getCoordenadax() + primero.getCoordenaday() + ":C" + i + "->nodo" + tempRecorre.getderecha().primero.getNumeroAtacante() + tempRecorre.getderecha().primero.getCoordenadax() + tempRecorre.getderecha().primero.getCoordenaday() + "\n";
            }
            temp += tempFlechas;
            temp += detalles;
            return temp;
        }
    }
}