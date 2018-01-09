using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;


/// <summary>
/// Descripción breve de ArbolB
/// </summary>
public class ArbolB
{
	public ArbolB()
	{
	
	}

        private RamaArbol raiz;
        private String nodos = "";

        /**
         * Verifica el contenido del árbol
         * @return true - Si el árbol está vacío; false - Si no lo está
         */
        public Boolean estaVacio()
        {
            return raiz == null;
        }

        /**
         *
         * @param val
         */
        public void insertar(int codDes, String nomDes)
        {
            NodoRamaArbol nodo = new NodoRamaArbol(codDes, nomDes);
            if (estaVacio())
            {
                raiz = new RamaArbol();//creo pagina
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




        private Object inserta(NodoRamaArbol nodo, RamaArbol rama)
        {
            if (rama.esHoja())
            {
                rama.insertar(nodo);
                if (rama.getCuenta() == 5) //divido la rama 
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
                    if (nodo.getCodigoDestino() == temp.getCodigoDestino())
                    {
                        return rama;
                    }
                    else if (nodo.getCodigoDestino() < temp.getCodigoDestino())
                    {
                        Object obj = inserta(nodo, temp.getIzquierda());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getCuenta() == 5)
                            {
                                return dividir(rama);
                            }
                        }
                        return rama;
                    }
                    else if (temp.getSiguiente() == null)
                    {
                        Object obj = inserta(nodo, temp.getDerecha());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getCuenta() == 5)
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
            for (int i = 1; i < 6; i++, temp = temp.getSiguiente())
            {
                NodoRamaArbol nodo = new NodoRamaArbol(temp.getCodigoDestino(), temp.getNombreDestino());
                nodo.setIzquierda(temp.getIzquierda());
                nodo.setDerecha(temp.getDerecha());
                if (nodo.getDerecha() != null && nodo.getIzquierda() != null)
                {
                    izquierda.setHoja(false);
                    derecha.setHoja(false);
                }
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
            medio.setIzquierda(izquierda);
            medio.setDerecha(derecha);
            return medio;
        }

    
        public String getDot()
        {
            String aux = "digraph G{ \n  node[shape=record, height=.1, style=filled];";
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
                getGrafNodos(aux.getIzquierda());
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            getGrafNodos(aux.getDerecha());
        }

        

  
        public void graficarDestinos(ArbolB raiz)
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