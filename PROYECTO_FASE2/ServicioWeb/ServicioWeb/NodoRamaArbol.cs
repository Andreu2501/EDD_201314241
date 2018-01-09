using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb
{
    public class NodoRamaArbol
    {
        public string coordenada_x;
        public int coordenada_y;
        public string unidad_atacante;
        public int resultado;
        public string unidad_dañada;
        public string emisor;
        public string receptor;
        public string fecha;
        public string tiempo;
        public int numero_ataque;
        public NodoRamaArbol anterior;
        public NodoRamaArbol siguiente;
        public RamaArbol derecha;
        public RamaArbol izquierda;
        public NodoRamaArbol(string x, int y, string atacante, int resultado, string unidad_dañada, string emisor, string receptor, string fecha, string tiempo, int numero_ataque)
        {
            this.coordenada_x = x;
            this.coordenada_y = y;
            this.unidad_atacante = atacante;
            this.resultado = resultado;
            this.unidad_dañada = unidad_dañada;
            this.emisor = emisor;
            this.receptor = receptor;
            this.fecha = fecha;
            this.tiempo = tiempo;
            this.numero_ataque = numero_ataque;
            this.anterior = null;
            this.siguiente = null;
            this.derecha = null;
            this.izquierda = null;
        
        
        }

        public string getCoordenadax()
        {
            return coordenada_x;
        }

        public void setCoordenadax(string coordenada_x)
        {
            this.coordenada_x = coordenada_x;
        }

        public int getCoordenaday()
        {
            return coordenada_y;
        }

        public void setCoordenaday(int coordenada_y)
        {
            this.coordenada_y = coordenada_y;
        
        }

        public string getUnidad_atacante()
        {
            return this.unidad_atacante;
        
        }
        public void setUnidad_atacante(string atacante)
        {
            this.unidad_atacante = atacante;
        
        }

        public int getResultado()
        {
            return resultado;
        
        }

        public void setResultado(int resultado)
        {
            this.resultado = resultado;
        }

        public string getUnidad_dañada()
        {
            return unidad_dañada;
        }

        public void setUnidad_dañada(string unidad_dañada)
        {
            this.unidad_dañada = unidad_dañada;
        }

        public string getEmisor()
        {
            return emisor;
        }

        public void setEmisor(string emisor)
        {
            this.emisor = emisor;
        }

        public string getReceptor()
        {
            return receptor;
        }

        public void setReceptor(string receptor)
        {
            this.receptor = receptor;
        
        }

        public string getFecha()
        {
            return fecha;
        }

        public void setFecha(string fecha)
        {
            this.fecha = fecha;
        }

        public string getTiempo()
        {
            return tiempo;
        }

        public void setTimpo(string tiempo)
        {
            this.tiempo = tiempo;
        }

        public int getNumeroAtacante()
        {
            return numero_ataque;
        }

        public void setNumeroAtacante(int n_ataque)
        {
            this.numero_ataque = n_ataque;
        }

        public NodoRamaArbol getAnterior()
        {
            return anterior;
        }

        public void setAnterior(NodoRamaArbol Anterior)
        {
            this.anterior = Anterior;
        }

        public NodoRamaArbol getSiguiente()
        {
            return siguiente;
        }

        public void setSiguiente(NodoRamaArbol siguiente)
        {
            this.siguiente = siguiente;
        }

        public RamaArbol getderecha()
        {
            return derecha;
        }

        public void setderecha(RamaArbol derecha)
        {
            this.derecha = derecha;
        }

        public RamaArbol getIzquieda()
        {
            return izquierda;
        }

        public void setIzquieda(RamaArbol izquierda)
        {
            this.izquierda = izquierda;
        }
    }
}