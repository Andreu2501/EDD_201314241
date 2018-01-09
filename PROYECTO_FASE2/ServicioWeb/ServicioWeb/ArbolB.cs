using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;

namespace ServicioWeb
{
    public class ArbolB
    {
        public RamaArbol raiz;
        public String nodos = "";
        public int Orden;
        public Boolean estaVacio()
        {
            return this.raiz == null;
        }


        public void insertar(string coordenada_x, int coordenada_y, string unidad_atacante, int resultado, string tipo_unidad_dañada, string emisor, string receptor, string fecha, string tiempo, int numero_ataque)
        {
            NodoRamaArbol nodo = new NodoRamaArbol(coordenada_x, coordenada_y, unidad_atacante, resultado, tipo_unidad_dañada, emisor, receptor, fecha, tiempo, numero_ataque);
            if (estaVacio())
            {
                raiz = new RamaArbol();
                raiz.insertar(nodo);
            }
            else
            {
                Object obj = inserta(nodo, raiz);
                if (obj is NodoRamaArbol)
                {
                    raiz = new RamaArbol();
                    raiz.insertar((NodoRamaArbol)obj);
                    raiz.setHoja(false);
                }
            }
        
        }

        public Object inserta(NodoRamaArbol nodo, RamaArbol rama)
        {
            if (rama.esHoja())
            {
                rama.insertar(nodo);
                if (rama.getcont() == Orden) //DONDE TENGO QUE PONER EL PARAMETRO
                {
                    return dividir(rama);
                }
                else
                {
                    return rama;
                }
            }
            else
            {
                NodoRamaArbol temp = rama.getPrimero();
                do
                {
                    if (nodo.getNumeroAtacante() == temp.getNumeroAtacante())
                    {
                        return rama;
                    }
                    else if (nodo.getNumeroAtacante() < temp.getNumeroAtacante())
                    {
                        Object obj = inserta(nodo, temp.getIzquieda());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getcont()== Orden)
                            {
                                return dividir(rama);
                            }
                        }
                        return rama;
                    }
                    else if (temp.getSiguiente() == null)
                    {
                        Object obj = inserta(nodo, temp.getderecha());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getcont() == Orden)
                            {
                                return dividir(rama);
                            }
                        }
                        return rama;
                    }
                    temp = temp.getSiguiente();
                } while (temp != null);
            }
            return rama;
        }

        private NodoRamaArbol dividir(RamaArbol rama)
        {
            RamaArbol derecha = new RamaArbol(), izquierda = new RamaArbol();
            NodoRamaArbol medio = null, temp = rama.getPrimero();
            for (int i = 1; i < Orden+1; i++, temp = temp.getSiguiente())
            {
                NodoRamaArbol nodo = new NodoRamaArbol(temp.getCoordenadax(), temp.getCoordenaday(), temp.getUnidad_atacante(), temp.getResultado(), temp.getUnidad_dañada(), temp.getEmisor(), temp.getReceptor(),temp.getFecha(), temp.getTiempo(), temp.getNumeroAtacante());
                nodo.setIzquieda(temp.getIzquieda());
                nodo.setderecha(temp.getderecha());
                if (nodo.getderecha() != null && nodo.getIzquieda() != null)
                {
                    izquierda.setHoja(false);
                    derecha.setHoja(false);
                }
                if (Orden == 5 || Orden==6)
                {
                    switch (i)
                    {
                        case 1:
                        case 2:
                            izquierda.insertar(nodo);
                            break;
                        case 3:
                            medio = nodo;
                            break;
                        case 4:
                        case 5:
                            derecha.insertar(nodo);
                            break;
                    }
                }
                else if (Orden == 3 ||Orden==4)
                {
                    switch (i)
                    {
                        
                        case 1:
                            izquierda.insertar(nodo);
                            break;
                        case 2:
                            medio = nodo;
                            break;
                     
                        case 3:
                            derecha.insertar(nodo);
                            break;
                    }

                }
                else if (Orden == 7)
                {
                    switch (i)
                    {

                        case 1:
                            izquierda.insertar(nodo);
                            break;
                        case 4:
                            medio = nodo;
                            break;

                        case 5:
                            derecha.insertar(nodo);
                            break;
                    }

                }
                else { }
            }
            medio.setIzquieda(izquierda);
            medio.setderecha(derecha);
            return medio;
        }


        public String getDot()
        {
            String aux = "digraph G{ \nnode [shape = record, height=.1,style=filled];";
            aux += "splines=line; \n";
            getGrafNodos(raiz);
            aux += nodos;
            aux += "}";
            return aux;
        }



        private void getGrafNodos(RamaArbol raiz)
        {
            if (raiz == null)
            {
                return;
            }
            nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {
                getGrafNodos(aux.getIzquieda());
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            getGrafNodos(aux.getderecha());
        }




        public void graficarB(ArbolB raiz)
        {

            StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter(@"C:\\ARCHIVOSDOT\\b.dot");
                fichero.Write(raiz.getDot());
            }
            catch (Exception e) { Console.Write(e.ToString()); }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2) { Console.Write(e2.ToString()); }
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Graphviz2.38\\bin\\dot.exe");
                startInfo.Arguments = "-Tpng C:\\ARCHIVOSDOT\\b.dot -o C:\\ARCHIVOSDOT\\b.png";
                Process.Start(startInfo);
                Process.Start("b.png");
            }
            catch (Exception ex)
            {
                Console.Write("Error en generar archivo dot " + ex.ToString());
            }
        }
    }
}