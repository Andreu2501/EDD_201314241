using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace ServicioWeb
{
    public class TablaHash
    {
        ElementoHash[] Tabla = new ElementoHash[43];
        int tamaño;
        float factOcupacion;
        float facVacio;
        int numDatos;
        bool insertar;
        int repetido;
        int iteracion;

        public TablaHash()
        {
            this.tamaño = 43;
            this.factOcupacion = numDatos / tamaño;
            this.factOcupacion = 0;
            this.numDatos = 0;
            this.insertar = false;
            this.repetido = 0;
            this.iteracion = 0;
        
        }

        public int funcionHash(string nickname)
        {
            if (nickname != string.Empty)
            {
                int clave;
                byte[] codigo = System.Text.ASCIIEncoding.ASCII.GetBytes(nickname);
                int suma = 0;
                for (int i = 0; i < nickname.Length; i++)
                {
                    suma = suma + codigo[i];
                
                }
                clave = suma % tamaño;

                if (clave > (tamaño - 1))
                {
                    clave = clave - tamaño;
                
                }
                return clave;
            }else
            {
                return -1;
            }
         }

        public int funcionHashInversa(string nickname, int tamaño_nuevo)
        {
            if (nickname != string.Empty)
            {
                int clave;
                byte[] codigo = System.Text.ASCIIEncoding.ASCII.GetBytes(nickname);
                int suma = 0;
                for (int i = 0; i < nickname.Length; i++)
                {
                    suma = suma + codigo[i];

                }
                clave = suma % tamaño_nuevo;
                return clave;
            }
            else {
                return -1;
            
            }
        
        }

        public void insertarHash(string nickname)
        {
            factOcupacion = (float)numDatos / tamaño;
            int clave = funcionHash(nickname);
            insertar = true;
            if (factOcupacion <= 0.5)
            {
                while (insertar == true)
                {
                    if (Tabla[clave] == null)
                    { //clave vacia entonces ingreso
                        Tabla[clave] = new ElementoHash(nickname);
                        insertar = false;
                        numDatos++;
                        iteracion = 0;
                    }
                    else 
                    {
                        if((Tabla[clave].nickname.CompareTo(nickname)==0))
                        {
                            //ya existe un nombre asi, nombre repetido
                            insertar=false;
                            repetido++;
                            break;
                        }else
                        {
                            iteracion++;
                            clave=clave+(iteracion*iteracion);
                            while(clave>(Tabla.Length-1))
                            {
                                clave=clave-Tabla.Length;
                            }
                        
                        }
                    
                    }
                
                }
            
            }else{
                //SE requiere expansion
               
                buscarPrimoSiguiente(tamaño);
                Expansion();
                insertarHash(nickname);

            
            }
        
        }
        public int buscarPrimoSiguiente(int num)
        {
            bool primo = false;
            int valor = num;
            int divisor;
            int contador = 0;
            while (primo == false)
            {
                valor++;
                divisor = 2;
                contador = 0;
                while (divisor <= valor)
                {
                    if (valor % divisor == 0)
                    {
                        contador++;
                        divisor++;
                    }
                    else
                    {
                        divisor++;
                    }
                
                
                }
                if (contador == 1)
                {
                    primo = true;
                }
            }
            return valor;
        }
        public void Expansion()
        {
            tamaño = buscarPrimoSiguiente(tamaño);
            ElementoHash[] aux = new ElementoHash[tamaño];
            int clave2;
            insertar = false;

            for (int i = 0; i < Tabla.Length; i++)
            {
                if (Tabla[i] != null)
                {
                    clave2 = funcionHash(Tabla[i].nickname);
                    insertar = true;
                    while (insertar == true)
                    {
                        if (aux[clave2] == null)
                        {
                            aux[clave2] = new ElementoHash(Tabla[i].nickname);

                            insertar = false;
                            iteracion = 0;

                        }
                        else 
                        {
                            iteracion++;
                            clave2 = clave2 + (iteracion * iteracion);

                            while (clave2 > (Tabla.Length - 1))
                            {
                                clave2 = clave2 - Tabla.Length;
                            }
                        }
                    }
                
                }
            
            }
            Tabla = aux;
        }

        public int buscarPrimoAnterior(int num)
        {
            bool primo = false;
            int valor = num;
            int divisor;
            int contador = 0;

            while (primo == false)
            {
                valor--;
                divisor = 2;
                contador = 0;
                while (divisor <= valor)
                {

                    if (valor % divisor == 0)
                    {
                        contador++;
                        divisor++;
                    }
                    else
                    {
                        divisor++;
                    }

                }

                if (contador == 1)
                {
                    primo = true;
                }
            }

           
            return valor;

        }
        public void Reduccion()
        {
            tamaño = buscarPrimoSiguiente(tamaño);
            ElementoHash[] aux = new ElementoHash[tamaño];
            int clave2;
            insertar = false;

            for (int i = 0; i < Tabla.Length; i++)
            {
                if (Tabla[i] != null && Tabla[i].eliminado == 0)
                {
                    clave2 = funcionHash(Tabla[i].nickname);
                    insertar = true;
                    while (insertar == true)
                    {
                        if (aux[clave2] == null)
                        {
                            aux[clave2] = new ElementoHash(Tabla[i].nickname);
                          
                            insertar = false;
                            iteracion = 0;
                        }
                        else
                        {
                            iteracion++;
                            clave2 = clave2 + (iteracion * iteracion);

                            while (clave2 > (aux.Length - 1))
                            {
                                clave2 = clave2 - aux.Length;
                            }
                        }
                        
                    }
                }
            
            }
            Tabla = aux;
        }
        public int buscarNombre(string name)
        {
            int clave;
            clave = funcionHash(name);
            bool buscar = true;

            while (buscar == true)
            {
                if (Tabla[clave] == null)
                {
                   
                    buscar = false;
                }
                else
                {
                    if (name.Equals(Tabla[clave].nickname))
                    {
                        iteracion = 0;
                        buscar = false;
                        return clave;
                    }
                    else
                    {
                        iteracion++;
                        clave = clave + (iteracion * iteracion);

                        while (clave > (Tabla.Length - 1))
                        {
                            clave = clave - Tabla.Length;
                        }
                    }
                }
            }
            return -1;
        }
        public void eliminarHash(string name)
        {
            int clave = buscarNombre(name);
            if (clave != -1)
            {
                Tabla[clave].eliminado = 1;
                
                numDatos--;
                facVacio = (float)numDatos / tamaño;

                if (facVacio <= 0.4)
                {
                    //invocamos a que la tabla se reduzca
                   
                    int primoAnt = buscarPrimoAnterior(tamaño);
                   
                    Reduccion();
                }

            }

        }

        public void GraficarHash()
        {
            int u = Tabla.Length - 1;
            System.IO.StreamWriter Archivo = new System.IO.StreamWriter("C:\\ARCHIVOSDOT\\TablaHash.dot");
            

            Archivo.Write("digraph G {\n");
            Archivo.Write("nodesep=.05;\n");
            Archivo.Write("rankdir=LR;\n");
            Archivo.Write("node [shape=record,width=.1,height=.1];\n");
            Archivo.Write("node0 [label = \"");
            for (int j = 0; j < Tabla.Length - 1; j++)
            {
                if (Tabla[j] != null && Tabla[j].eliminado == 0)
                {
                    Archivo.Write("<f" + j + ">" + j + "|");
                }
            }
            Archivo.Write("<f" + u + ">" + u + "\"" + ",height=2.5];\n");
            Archivo.Write("node [width = 1.5];\n");

            for (int j = 0; j < Tabla.Length; j++)
            {
                if (Tabla[j] != null && Tabla[j].eliminado == 0)
                {

                    Archivo.Write("node" + (j + 1) + "[label = \"{<n> " + Tabla[j].nickname + "}\"];\n");
                }
            }
            for (int j = 0; j < Tabla.Length; j++)
            {
                if (Tabla[j] != null && Tabla[j].eliminado == 0)
                {
                    Archivo.Write("node0:f" + j + "->" + "node" + (j + 1) + ":n;\n");
                }
            }
            Archivo.Write("\n}");
            Archivo.Close();

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("C:\\Graphviz2.38\\bin\\dot.exe");
            startInfo.Arguments = "dot -Tpng TablaHash.dot -o TablaHash.png";
            Process.Start(startInfo);

            try
            {
                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\TablaHash.dot -o  C:\\ARCHIVOSDOT\\TablaHash.png ");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
                //Obtiene el directorio actual
              //  string path = Directory.GetCurrentDirectory();
                //Console.WriteLine("El directorio actual es {0}", path);
               // path = path + "\\TablaHash.png";
               // Process.Start(path);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Proceso Fallido: {0}", e.ToString());
            }

        }

    }
}