using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace ServicioWeb
{
    public class ABB
    {
        int contador_clusher = 0;
        bool bandera1 = false;
        bool bandera2 = false;
        public class nodo
        {
            public arbolavl avl;
            public nodo izq;
            public nodo der;
            public string nickname;
            public string contraseña;
            public string correo;
            public int conectado;
            public int contador;
            public int contador_destruidas;
            public int contador_contactos;
            public lista_doble_enlazada lista;
            //apuntador de la lista
            //constructor
            public nodo(string nickname, string contraseña, string correo, int conectado, int contador, int contador_destruidas,int contador_contactos)
            {
                this.nickname = nickname;
                this.contraseña = contraseña;
                this.correo = correo;
                this.conectado = conectado;
                this.contador = contador;
                this.contador_destruidas = contador_destruidas;
                this.izq = null;
                this.der = null;
                this.lista = new lista_doble_enlazada();
                this.avl = new arbolavl();
                this.contador_contactos = contador_contactos;
            }
            // operaciones de acceso
            public string valorNodo() { return nickname; }
            public nodo subarbolIzdo() { return izq; }
            public nodo subarbolDcho() { return der; }
            public void nuevoValor(string d) { nickname = d; }
            public void ramaIzdo(nodo n) { izq = n; }
            public void ramaDcho(nodo n) { der = n; }

            public void insertar_lista(nodo_lista nuevo)
            {
                //agrego en cada acceso del nodo lista 
                this.lista.insertar_lista_juegos(nuevo);

            }

        }
        //declaracion del primer nodo
        public nodo raiz;

        //constructor del arbol
        public ABB()
        {
            raiz = null;
        }

        public void insertar(string nickname, string contraseña, string correo, int conectado, int contador, int contador_destruidas,int contactos)
        {
            nodo nuevo = new nodo(nickname, contraseña, correo, conectado, contador, contador_destruidas,contactos);

            if (this.raiz == null)
            {
                this.raiz = nuevo;
            }
            else
            {
                this.raiz = this.insertarnodo(raiz, nuevo);

            }

        }
        public nodo insertarnodo(nodo actual, nodo nuevo)
        {
            if (nuevo.nickname.CompareTo(actual.nickname) < 0)
            {
                if (actual.izq == null)
                {
                    actual.izq = nuevo;
                    return actual;
                }
                else
                {
                    actual.izq = insertarnodo(actual.izq, nuevo);
                    return actual;

                }
            }
            else if (nuevo.nickname.CompareTo(actual.nickname) > 0)
            {
                if (actual.der == null)
                {
                    actual.der = nuevo;
                    return actual;
                }
                else
                {
                    actual.der = insertarnodo(actual.der, nuevo);
                    return actual;


                }

            }
            else
            {
                return null;
            }

        }

        public int calcularAltura(nodo raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else
            {
                int hi = calcularAltura(raiz.izq);
                int hd = calcularAltura(raiz.der);
                return (hi > hd ? hi : hd) + 1;
            }
        }
        public int calcularNivel(nodo raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else
            {
                int hi = calcularNivel(raiz.izq);
                int hd = calcularNivel(raiz.der);
                return (hi > hd ? hi : hd) + 1;
            }
        }


        public int numeroRamas(nodo raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else
            {
                int ramai = numeroRamas(raiz.izq);
                int ramad = numeroRamas(raiz.der);
                if (raiz.izq != null || raiz.der != null)
                {
                    return ramai + ramad + 1;
                }
                return ramai + ramad;
            }
        }

        public int numeroHojas(nodo raiz)
        {
            if (raiz == null)
            {
                return 0;
            }
            else
            {
                if (raiz.izq == null && raiz.der == null)
                {
                    return 1;
                }
                else
                {
                    int hojasi = numeroHojas(raiz.izq);
                    int hojasd = numeroHojas(raiz.der);
                    return hojasi + hojasd;
                }

            }

        }

        public void graficar()
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\ARCHIVOSDOT\\usuarios.dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1];");
            archivo.WriteLine(inOrder(raiz));
            archivo.WriteLine(preorder(raiz));
            int altura = calcularAltura(raiz);
            int ramas = numeroRamas(raiz);
            int hojas = numeroHojas(raiz);
            int nivel = calcularNivel(raiz) - 1;
            archivo.WriteLine("nodoInformacion[label=\"<f0>Altura: " + altura + "|<f1>Ramas: " + ramas + "|<f2>Hojas: " + hojas + "|<f3>Nivel: " + nivel + "\"];");
            archivo.WriteLine(recorrido_principal(raiz));
            archivo.WriteLine("}");
            archivo.Close();

            cmdArbol();



        }

        public void cmdArbol()
        {
            try
            {


                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\usuarios.dot -o  C:\\ARCHIVOSDOT\\usuarios.png ");
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
        public void cmdTOPganas()
        {
            try
            {
                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\Top_Ganadas.dot -o  C:\\ARCHIVOSDOT\\Top_Ganadas.png ");
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
        public void cmdDestruidas()
        {
            try
            {


                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\Top_Destruidas.dot -o  C:\\ARCHIVOSDOT\\Top_Destruidas.png ");
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


        public string inOrder(nodo raiz)
        {
            StringBuilder b = new StringBuilder();
            if (raiz != null)
            {
                b.Append(inOrder(raiz.izq));
                b.Append(raiz.nickname);
                b.Append("[label=\"<f0>|<f1>");
                b.Append("Nickname: " + raiz.nickname + "\\n" + "Pass: " + raiz.contraseña + "\\n" + "Correo: " + raiz.correo + "\\n" + "Conectado: " + raiz.conectado);
                b.Append("|<f2>\"]\n");
                b.Append(inOrder(raiz.der));

            }
            return b.ToString();
        }

        public string preorder(nodo raiz)
        {
            StringBuilder b = new StringBuilder();
            if (raiz != null)
            {
                if (raiz.izq != null)
                {
                    b.Append(raiz.nickname);
                    b.Append(":f0->");
                    b.Append(raiz.izq.nickname);
                    b.Append(":f1;\n");
                }
                b.Append(preorder(raiz.izq));
                if (raiz.der != null)
                {

                    b.Append(raiz.nickname);
                    b.Append(":f2->");
                    b.Append(raiz.der.nickname);
                    b.Append(":f1;\n");
                }
                b.Append(preorder(raiz.der));

            }

            return b.ToString();
        }


        public void GraficarArbol(string fileName, string path)
        {
            try
            {
                var command = string.Format("dot.exe -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".dot", ".jpg")));
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

        //metodo de buscar nickname para insertar la lista
        public nodo buscarNodoAbb(nodo raiz, string nickname_base)
        {
            if (raiz == null)
            {
                return null;
            }
            else if (raiz.nickname.CompareTo(nickname_base) == 0)
            {
                return raiz;
            }
            else if (raiz.nickname.CompareTo(nickname_base) > 0)
            {
                return buscarNodoAbb(raiz.izq, nickname_base);
            }
            else
            {
                return buscarNodoAbb(raiz.der, nickname_base);
            }

        }

        public void agregar_lista_abb(nodo raiz, nodo_lista nuevo)
        {

            nodo encontrado = this.buscarNodoAbb(raiz, nuevo.nickname_base);
            //entran los que tienen partidas ganadas
            if (nuevo.bandera == 1)
            {
                encontrado.contador = encontrado.contador + 1;

            }
            encontrado.contador_destruidas = encontrado.contador_destruidas + nuevo.unidades_destruidas;

            encontrado.insertar_lista(nuevo);
        }

        public class nodo_lista
        {
            public string nickname_base;
            public string nickname_oponente;
            public int unidades_desplegadas;
            public int unidades_sobrevivientes;
            public int unidades_destruidas;
            public int bandera;
            public nodo_lista siguiente;
            public nodo_lista anterior;

            public nodo_lista(string nickname_base, string nickname_oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
            {
                this.nickname_base = nickname_base;
                this.nickname_oponente = nickname_oponente;
                this.unidades_desplegadas = unidades_desplegadas;
                this.unidades_sobrevivientes = unidades_sobrevivientes;
                this.unidades_destruidas = unidades_destruidas;
                this.bandera = bandera;
                this.anterior = null;
                this.siguiente = null;
            }

        }



        public class lista_doble_enlazada
        {
            public nodo_lista primero;


            public lista_doble_enlazada()
            {
                this.primero = null;


            }

            public void insertar_lista_juegos(nodo_lista nuevo)
            {
                if (this.primero == null)
                {
                    this.primero = nuevo;

                }
                else
                {
                    nodo_lista aux = this.primero;
                    while (aux.siguiente != null)
                    {
                        aux = aux.siguiente;

                    }
                    aux.siguiente = nuevo;
                    nuevo.anterior = aux;
                    aux = nuevo;

                }
            }





        }


        public nodo modificarL(string nickname_base, string oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
        {

            nodo encontrado_nodo = buscarNodoAbb(raiz, nickname_base);
            //mensaje de que se ha encontrado
            if (encontrado_nodo != null)
            {
                bandera1 = true;
                modificar_lista_juegos(encontrado_nodo, oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, bandera);

                return encontrado_nodo;
            }
            return null;
        }

        public void modificar_lista_juegos(nodo arbol, string oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
        {


            nodo_lista aux = arbol.lista.primero;
            if (arbol.lista.primero != null)
            {
                while (aux != null)
                {
                    if (aux.nickname_oponente.CompareTo(oponente) == 0)
                    {
                        //los dos usuarios se han encontrado!!!
                        bandera2 = true;
                        todosEncontrados();
                        modificarNodo(arbol, aux, arbol.nickname, aux.nickname_oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, bandera);
                        return;
                    }
                    aux = aux.siguiente;
                }

            }

        }
        //  CUANDO RETORNA 1 MUESTRA EL MENSAJE Y SE LLENA LOS CAMPOS
        public int todosEncontrados()
        {

            if (bandera1 == true && bandera2 == true)
            {
                return 1;

            }
            else
            {
                return 0;

            }


        }
        public void modificarNodo(nodo arbol, nodo_lista nodo, string nickname_base, string nickename_oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
        {

            nodo_lista nuevo = new nodo_lista(nickname_base, nickename_oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, bandera);

            eliminar_lista_modificar(arbol, nickename_oponente);

            arbol.lista.insertar_lista_juegos(nuevo);




        }
        public void ELIMINAR_LISTA_JUEGOS(nodo raiz, string nickname_base, string nickname_oponente)
        {
            nodo encontrado_nodo = buscarNodoAbb(raiz, nickname_base);
            eliminar_lista_modificar(encontrado_nodo, nickname_oponente);

        }
        public void eliminar_lista_modificar(nodo arbol, string nickname_oponente)
        {

            nodo_lista aux = arbol.lista.primero;
            if (arbol.lista.primero != null)
            {
                while (aux != null)
                {
                    if (aux.nickname_oponente.CompareTo(nickname_oponente) == 0)
                    {
                        if (aux != null)
                        {
                            if (aux == arbol.lista.primero)
                            {
                                arbol.lista.primero = aux.siguiente;
                                if (aux.siguiente != null)
                                {
                                    aux.siguiente.anterior = null;
                                    return;
                                }

                            }
                            else if (aux.siguiente != null)//no es el ultimo nodo
                            {
                                aux.anterior.siguiente = aux.siguiente;
                                aux.siguiente.anterior = aux.anterior;
                                return;

                            }
                            else
                            {
                                aux.anterior.siguiente = null;
                                aux = null;
                                return;
                            }

                        }

                    }
                    aux = aux.siguiente;
                }

            }

        }
        //eliminar un nodo del arbol
        public void eliminar(string valor)
        {

            raiz = eliminar(raiz, valor);
        }

        public nodo eliminar(nodo raizsub, string nickname)
        {
            if (raizsub == null)
            {
                //no se encontro el dato con la clave
            }
            else if (raizsub.nickname.CompareTo(nickname) > 0)
            {
                nodo iz;
                iz = eliminar(raizsub.subarbolIzdo(), nickname);
                raizsub.ramaIzdo(iz);
            }
            else if (raizsub.nickname.CompareTo(nickname) < 0)
            {
                nodo dr;
                dr = eliminar(raizsub.subarbolDcho(), nickname);
                raizsub.ramaDcho(dr);
            }
            else
            {
                nodo q;
                q = raizsub;
                if (q.subarbolIzdo() == null)
                {
                    raizsub = q.subarbolDcho();
                }
                else if (q.subarbolDcho() == null)
                {
                    raizsub = q.subarbolIzdo();
                }
                else
                {
                    q = reemplazar(q);
                }
                q = null;
            }
            return raizsub;

        }


        public nodo reemplazar(nodo act)
        {
            nodo a, p;
            p = act;
            a = act.subarbolIzdo();
            while (a.subarbolDcho() != null)
            {
                p = a;
                a = a.subarbolDcho();
            }

            act.nuevoValor(a.valorNodo());
            if (p == act)
                p.ramaIzdo(a.subarbolIzdo());
            else
                p.ramaDcho(a.subarbolIzdo());
            return a;

        }

        //MODIFICAR DEL ARBOL
        public int modificar(string datoviejo, string nickname, string contraseña, string correo, int conectado, int contador, int contador_destruidas,int contactos)
        {
            if (buscarNodoAbb(this.raiz, datoviejo) != null)
            {
                if (datoviejo.CompareTo(nickname) == 0)
                {
                    nodo encontrado = buscarNodoAbb(this.raiz, datoviejo);
                    encontrado.contraseña = contraseña;
                    encontrado.correo = correo;
                    encontrado.conectado = conectado;
                    encontrado.conectado = conectado;
                    encontrado.contador_destruidas = contador_destruidas;
                    encontrado.contador_contactos = contactos;
                    return 1;
                }
                else
                {
                    this.eliminar(datoviejo);
                    nodo n1 = new nodo(nickname, contraseña, correo, conectado, contador, contador_destruidas,contactos);
                    this.insertar(n1.nickname, n1.contraseña, n1.correo, n1.conectado, n1.contador, contador_destruidas,contactos);
                    return 1;
                }
                
            }
            else
            {
                return 0;
            }
            //PAUSA Y VOLVEMOS

        }



        //ARBOL ESPEJO

        public void espejo(nodo raiz)
        {

            if (this.raiz != null)
            {
                this.raiz = hacerespejo(raiz);
            }

        }

        public nodo hacerespejo(nodo raiz)
        {

            if (raiz == null)
            {
                return null;
            }
            else
            {
                nodo nuevonodo = new nodo(raiz.nickname, raiz.contraseña, raiz.correo, raiz.conectado, raiz.contador, raiz.contador_destruidas,raiz.contador_contactos);
                nuevonodo.nickname = raiz.nickname;
                nuevonodo.izq = hacerespejo(raiz.der);
                nuevonodo.der = hacerespejo(raiz.izq);
                return nuevonodo;
            }

        }
        //lista de los top mas ganados
        static lista_top TOP = new lista_top();
        //REALIZACION DEL TOP 10 PARTIDAS GANADAS

        public void recorridoTOP(nodo raiz)
        {
            if (raiz != null)
            {
                if (raiz.contador != 0)
                {
                    nodo_top n = new nodo_top(raiz.nickname, raiz.contador);
                    TOP.insertarTop(n);
                    recorrido(raiz);
                }

            }



        }
        public void recorrido(nodo raiz)
        {
            if (raiz != null)
            {

                if (raiz.izq != null)
                {
                    if (raiz.izq.contador != 0)
                    {
                        nodo_top n = new nodo_top(raiz.izq.nickname, raiz.izq.contador);
                        TOP.insertarTop(n);
                    }

                }
                recorrido(raiz.izq);

                if (raiz.der != null)
                {
                    if (raiz.der.contador != 0)
                    {
                        nodo_top n = new nodo_top(raiz.der.nickname, raiz.der.contador);
                        TOP.insertarTop(n);
                    }

                }
                recorrido(raiz.der);


            }


        }
        //REALIZACION DE PORCENTAJE DE NAVES DESTRUIDAS
        static lista_top naves = new lista_top();

        public void recorridoPrincipalNaves(nodo raiz)
        {
            if (raiz != null)
            {
                if (raiz.contador != 0)
                {
                    nodo_top n = new nodo_top(raiz.nickname, raiz.contador_destruidas);
                    naves.insertarTop(n);
                    recorrido_naves(raiz);
                }

            }



        }
        public void recorrido_naves(nodo raiz)
        {
            if (raiz != null)
            {

                if (raiz.izq != null)
                {
                    if (raiz.izq.lista.primero != null)
                    {
                        nodo_top n = new nodo_top(raiz.izq.nickname, raiz.izq.contador_destruidas);
                        naves.insertarTop(n);
                    }


                }
                recorrido_naves(raiz.izq);

                if (raiz.der != null)
                {
                    if (raiz.der.lista.primero != null)
                    {
                        nodo_top n = new nodo_top(raiz.der.nickname, raiz.der.contador_destruidas);
                        naves.insertarTop(n);
                    }

                }
                recorrido_naves(raiz.der);


            }


        }


        public class nodo_top
        {
            public nodo_top siguiente;
            public nodo_top anterior;
            public int num;
            public string nickname_base;

            public nodo_top(string nickname_base, int num)
            {
                this.nickname_base = nickname_base;
                this.num = num;
                this.siguiente = null;
                this.anterior = null;

            }

        }
        public class lista_top
        {
            public nodo_top primero;
            public nodo_top ultimo;
            public lista_top()
            {
                this.primero = null;
                this.ultimo = null;
            }
            public void insertarTop(nodo_top nuevo)
            {
                if (this.primero == null)
                {
                    this.primero = nuevo;
                    this.ultimo = nuevo;
                }
                else
                {
                    //insertar de primero
                    if (primero.num < nuevo.num || primero.num == nuevo.num)
                    {
                        this.primero.anterior = nuevo;
                        nuevo.siguiente = this.primero;
                        this.primero = nuevo;
                    }
                    else if (nuevo.num < this.ultimo.num || nuevo.num == this.ultimo.num)
                    {
                        //insrtando de ultimo
                        this.ultimo.siguiente = nuevo;
                        nuevo.anterior = this.ultimo;
                        this.ultimo = nuevo;
                    }
                    else
                    {
                        nodo_top aux = this.primero;
                        while (aux.num > nuevo.num)
                        {
                            aux = aux.siguiente;

                        }
                        nodo_top aux2 = aux.anterior;
                        aux.anterior = nuevo;
                        nuevo.siguiente = aux;
                        aux2.siguiente = nuevo;
                        nuevo.anterior = aux2;




                    }

                }


            }





        }

        public void graficarTOPGANADAS()
        {
            int cont = 1;
            TextWriter archivo;
            archivo = new StreamWriter("C:\\ARCHIVOSDOT\\Top_Ganadas.dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1];");
            nodo_top aux = TOP.primero;


            if (aux != null)
            {



                while (aux != null && cont <= 10)
                {
                    archivo.WriteLine(aux.nickname_base + "[label= \" Usuario" + cont + "\\n nickname:  " + aux.nickname_base + "\\n" + "partidas ganadas:  " + aux.num + "\"];");
                    cont++;
                    aux = aux.siguiente;
                }
                aux = TOP.primero;
                int cont2 = 1;


                while (aux != null)
                {
                    if (aux.siguiente != null && cont2 < 10)
                    {

                        archivo.WriteLine(aux.nickname_base + "->" + aux.siguiente.nickname_base + ";");
                        archivo.WriteLine(aux.siguiente.nickname_base + "->" + aux.nickname_base + ";");

                    }
                    aux = aux.siguiente;
                    cont2++;
                }





            }
            else
            {
                archivo.WriteLine("LA LISTA ESTA VACIA");

            }

            archivo.WriteLine("}");

            archivo.Close();
            cmdTOPganas();









        }

        public void graficarTOP_Unidades_destruidas()
        {
            int cont = 1;
            TextWriter archivo;
            archivo = new StreamWriter("C:\\ARCHIVOSDOT\\Top_Destruidas.dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1];");
            nodo_top aux = naves.primero;


            if (aux != null)
            {
                while (aux != null && cont <= 10)
                {
                    archivo.WriteLine(aux.nickname_base + "[label= \" Usuario" + cont + "\\n nickname:  " + aux.nickname_base + "\\n" + "unidades_destruidas:  " + aux.num + "\"];");
                    cont++;
                    aux = aux.siguiente;
                }
                aux = naves.primero;
                int cont2 = 1;

                while (aux != null)
                {


                    if (aux.siguiente != null && cont2 < 10)
                    {
                        archivo.WriteLine(aux.nickname_base + "->" + aux.siguiente.nickname_base + ";");
                        archivo.WriteLine(aux.siguiente.nickname_base + "->" + aux.nickname_base + ";");

                    }
                    aux = aux.siguiente;
                    cont2++;
                }

            }
            else
            {
                archivo.WriteLine("LA LISTA ESTA VACIA");

            }
            archivo.WriteLine("}");

            archivo.Close();
            cmdDestruidas();

        }


        public string graficar_lista_usuarios(nodo raiz)
        {
            StringBuilder b = new StringBuilder();

            b.Append("subgraph cluster" + contador_clusher + "{\n");
            b.Append("node[style=filled];\n");

            nodo_lista aux = raiz.lista.primero;
            while (aux != null)
            {
                b.Append(aux.nickname_base + aux.nickname_oponente + "[label=\"" + "Nickname Oponente: " + aux.nickname_oponente + "\\n" + "desplegadas: " + aux.unidades_desplegadas + "\\n" + "sobrevivientes: " + aux.unidades_sobrevivientes + "\\n" + "destruidas: " + aux.unidades_destruidas +"\\n"+"gano/perdio "+aux.bandera+ "\"];\n");
                aux = aux.siguiente;
            }
            b.Append("}\n");

            aux = raiz.lista.primero;

            if (aux != null)
            {
                b.Append(raiz.nickname + "->" + raiz.lista.primero.nickname_base + raiz.lista.primero.nickname_oponente + ";\n");
                while (aux != null)
                {
                    if (aux.siguiente != null)
                    {
                        b.Append(aux.nickname_base + aux.nickname_oponente + "->" + aux.siguiente.nickname_base + aux.siguiente.nickname_oponente + ";\n");
                        b.Append(aux.siguiente.nickname_base + aux.siguiente.nickname_oponente + "->" + aux.nickname_base + aux.nickname_oponente + ";\n");

                    }

                    aux = aux.siguiente;
                }


            }
            else
            {
                b.Append("LA LISTA ESTA VACIA");

            }

            contador_clusher++;
            return b.ToString();




        }
        StringBuilder b = new StringBuilder();
        //graficar usuarios y listas

        public string recorrido_principal(nodo raiz)
        {
            if (raiz != null)
            {
                if (raiz.lista.primero != null)
                {
                    b.Append(graficar_lista_usuarios(raiz));
                    recorrido_listas(raiz);
                }

            }

            return b.ToString();

        }
        public string recorrido_listas(nodo raiz)
        {

            if (raiz != null)
            {


                if (raiz.izq != null)
                {
                    if (raiz.izq.lista.primero != null)
                    {
                        b.Append(graficar_lista_usuarios(raiz.izq));
                    }

                }
                recorrido_listas(raiz.izq);

                if (raiz.der != null)
                {
                    if (raiz.der.lista.primero != null)
                    {
                        b.Append(graficar_lista_usuarios(raiz.der));
                    }

                }
                recorrido_listas(raiz.der);





            }
            return b.ToString();

        }

        public nodo buscarUsuarioContraseña(nodo raiz, string nickname_base, string contraseña)
        {
            if (raiz == null)
            {
                return null;
            }
            else if (raiz.nickname.CompareTo(nickname_base) == 0 && raiz.contraseña.CompareTo(contraseña) == 0)
            {
                return raiz;
            }
            else if (raiz.nickname.CompareTo(nickname_base) > 0)
            {

                return buscarUsuarioContraseña(raiz.izq, nickname_base, contraseña);
            }
            else if (raiz.nickname.CompareTo(nickname_base) < 0)
            {
                return buscarUsuarioContraseña(raiz.der, nickname_base, contraseña);
            }
            else
            {
                return null;
            }

        }

        //************************************************************************************************************
        //AVL
        //******************************************************************************
        public class nodo_contactos
        {
            //apuntador
            public nodo usuario;
            public string nickname;
            public string contraseña;
            public string correo;
            public nodo_contactos izquierda;
            public nodo_contactos derecha;

            public nodo_contactos(string nickname, string contraseña, string correo)
            {
                this.nickname = nickname;
                this.contraseña = contraseña;
                this.correo = correo;
                this.izquierda = null;
                this.derecha = null;
                this.usuario = null;

            }
            // operaciones de acceso
            public string valorNodo() { return nickname; }
            public nodo_contactos subarbolIzdo() { return izquierda; }
            public nodo_contactos subarbolDcho() { return derecha; }
            public void nuevoValor(string d) { nickname = d; }
            public void ramaIzdo(nodo_contactos n) { izquierda= n; }
            public void ramaDcho(nodo_contactos n) { derecha = n; }

        }
        public class arbolavl
        {
            public nodo_contactos raiz;
            public arbolavl()
            {
                this.raiz = null;
            }

            public nodo_contactos balancear(nodo_contactos actual)
            {
                int factorEquilibrio = getFE(actual);
                if (factorEquilibrio == -2)
                {
                    int fe2 = getFE(actual.izquierda);
                    if (fe2 == -1)
                    {
                        actual = RSDerecha(actual);
                        return actual;
                    }
                    else if (fe2 == 1)
                    {
                        actual = RDIzquierda(actual);
                        return actual;
                    }
                    else if (fe2 < 0)
                    {
                        actual.izquierda = balancear(actual.izquierda);
                    }
                    else if (fe2 > 0)
                    {
                        actual.derecha = balancear(actual.derecha);
                    }
                }
                else if (factorEquilibrio == 2)
                {
                    int fe2 = getFE(actual.derecha);
                    if (fe2 == 1)
                    {
                        actual = RSIzquierda(actual);
                        return actual;
                    }
                    else if (fe2 == -1)
                    {
                        actual = RDDerecha(actual);
                    }
                    else if (fe2 < 0)
                    {
                        actual.izquierda = balancear(actual.izquierda);
                    }
                    else if (fe2 > 0)
                    {
                        actual.derecha = balancear(actual.derecha);
                    }
                }
                else if (factorEquilibrio > 0)
                {
                    actual.derecha = balancear(actual.derecha);
                    return actual;
                }
                else if (factorEquilibrio < 0)
                {
                    actual.izquierda = balancear(actual.izquierda);
                    return actual;
                }
                return actual;
            
            
            }


            public void insertarAvl(nodo_contactos nuevo)
            {

                if (this.raiz == null)
                {
                    this.raiz = nuevo;
                }
                else
                {
                    this.raiz = this.insertarNodo(raiz, nuevo);
                }

            }

            public nodo_contactos insertarNodo(nodo_contactos actual, nodo_contactos nuevo)
            {
                if (nuevo.nickname.CompareTo(actual.nickname) < 0)
                {
                    if (actual.izquierda == null)
                    {
                        actual.izquierda = nuevo;
                        return actual;
                    }
                    else
                    {
                        actual.izquierda = insertarNodo(actual.izquierda, nuevo);
                        nodo_contactos deBalanceo = balancear(actual);
                        actual = deBalanceo;
                        return actual;

                    }

                }
                else
                {
                    if (actual.derecha == null)
                    {
                        actual.derecha = nuevo;
                        return actual;

                    }
                    else
                    {
                        actual.derecha = insertarNodo(actual.derecha, nuevo);
                        nodo_contactos deBalanceo = balancear(actual);
                        actual = deBalanceo;
                        return actual;

                    }



                }
                return null;
            }

            public int getFE(nodo_contactos actual)
            {
                if (actual == null)
                {
                    return -1;
                }
                int hi = getAltura(actual.izquierda);
                int hd = getAltura(actual.derecha);
                int respuesta = hd - hi;
                return respuesta;


            }

            public int getAltura(nodo_contactos actual)
            {
                if (actual == null)
                {
                    return 0;

                }
                else
                {
                    int hi = getAltura(actual.izquierda);
                    int hd = getAltura(actual.derecha);
                    return (hi > hd ? hi : hd) + 1;

                }

            }

            public nodo_contactos RSDerecha(nodo_contactos actual)
            {
                nodo_contactos auxiliar = actual.izquierda;
                actual.izquierda = auxiliar.derecha;
                auxiliar.derecha = actual;
                actual = auxiliar;
                return actual;



            }

            public nodo_contactos RSIzquierda(nodo_contactos actual)
            {
                nodo_contactos aux = actual.derecha;
                actual.derecha = aux.izquierda;
                aux.izquierda = actual;
                actual = aux;
                return actual;
            }

            public nodo_contactos RDDerecha(nodo_contactos actual)
            {
                nodo_contactos aux1 = actual.derecha;
                nodo_contactos aux2 = actual.derecha.izquierda;
                aux1.izquierda = aux2.derecha;
                aux2.derecha = aux1;
                actual.derecha = aux2.izquierda;
                aux2.izquierda = actual;
                actual = aux2;
                return actual;
            
            }

            public nodo_contactos RDIzquierda(nodo_contactos actual)
            {
                nodo_contactos aux1 = actual.izquierda;
                nodo_contactos aux2 = actual.izquierda.derecha;
                aux1.derecha = aux2.izquierda;
                aux2.izquierda = aux1;
                actual.izquierda = aux2.derecha;
                aux2.derecha = actual;
                actual = aux2;
                return actual;
            }

            public void graficarAVL()
            {
                TextWriter archivo;
                archivo = new StreamWriter("C:\\ARCHIVOSDOT\\Contactos.dot");
                archivo.WriteLine("digraph G{");
                archivo.WriteLine("node[shape=record, height=.1];");
                archivo.WriteLine(inOrderAVL(raiz));
                archivo.WriteLine(preorderAVL(raiz));
                //int altura = calcularAltura(raiz);
                //int ramas = numeroRamas(raiz);
                //int hojas = numeroHojas(raiz);
                //int nivel = calcularNivel(raiz) - 1;
                //archivo.WriteLine("nodoInformacion[label=\"<f0>Altura: " + altura + "|<f1>Ramas: " + ramas + "|<f2>Hojas: " + hojas + "|<f3>Nivel: " + nivel + "\"];");
                
                archivo.WriteLine("}");
                archivo.Close();
                cmdArbolAVL();
                


            }

            public string inOrderAVL(nodo_contactos raiz)
            {
                StringBuilder b = new StringBuilder();
                if (raiz != null)
                {
                    b.Append(inOrderAVL(raiz.izquierda));
                    b.Append(raiz.nickname);
                    b.Append("[label=\"<f0>|<f1>");
                    b.Append("Nickname: " + raiz.nickname + "\\n" + "Pass: " + raiz.contraseña + "\\n" + "Correo: " + raiz.correo );
                    b.Append("|<f2>\"]\n");
                    b.Append(inOrderAVL(raiz.derecha));

                }
                return b.ToString();
            }

            public string preorderAVL(nodo_contactos raiz)
            {
                StringBuilder b = new StringBuilder();
                if (raiz != null)
                {
                    if (raiz.izquierda!= null)
                    {
                        b.Append(raiz.nickname);
                        b.Append(":f0->");
                        b.Append(raiz.izquierda.nickname);
                        b.Append(":f1;\n");
                    }
                    b.Append(preorderAVL(raiz.izquierda));
                    if (raiz.derecha != null)
                    {

                        b.Append(raiz.nickname);
                        b.Append(":f2->");
                        b.Append(raiz.derecha.nickname);
                        b.Append(":f1;\n");
                    }
                    b.Append(preorderAVL(raiz.derecha));

                }

                return b.ToString();
            }

            public void cmdArbolAVL()
            {
                try
                {


                    var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\contactos.dot -o  C:\\ARCHIVOSDOT\\contactos.png ");
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

            //eliminar un nodo del arbol
            public void eliminarAVL(string valor)
            {

                raiz = eliminarAVL(raiz, valor);
            }

            public nodo_contactos eliminarAVL(nodo_contactos raizsub, string nickname)
            {
                if (raizsub == null)
                {
                    //no se encontro el dato con la clave
                }
                else if (raizsub.nickname.CompareTo(nickname) > 0)
                {
                    nodo_contactos iz;
                    iz = eliminarAVL(raizsub.subarbolIzdo(), nickname);
                    raizsub.ramaIzdo(iz);
                }
                else if (raizsub.nickname.CompareTo(nickname) < 0)
                {
                    nodo_contactos dr;
                    dr = eliminarAVL(raizsub.subarbolDcho(), nickname);
                    raizsub.ramaDcho(dr);
                }
                else
                {
                    nodo_contactos q;
                    q = raizsub;
                    if (q.subarbolIzdo() == null)
                    {
                        raizsub = q.subarbolDcho();
                    }
                    else if (q.subarbolDcho() == null)
                    {
                        raizsub = q.subarbolIzdo();
                    }
                    else
                    {
                        q = reemplazarAVL(q);
                    }
                    q = null;
                    this.raiz = balancear(this.raiz);
                }
                return raizsub;

            }


            public nodo_contactos reemplazarAVL(nodo_contactos act)
            {
                nodo_contactos a, p;
                p = act;
                a = act.subarbolIzdo();
                while (a.subarbolDcho() != null)
                {
                    p = a;
                    a = a.subarbolDcho();
                }

                act.nuevoValor(a.valorNodo());
                if (p == act)
                    p.ramaIzdo(a.subarbolIzdo());
                else
                    p.ramaDcho(a.subarbolIzdo());
                return a;

            }

            //MODIFICAR DEL AVL
            public nodo_contactos buscarNodoAVL(nodo_contactos raiz, string nickname)
            {
                if (raiz == null)
                {
                    return null;
                }
                else if (raiz.nickname.CompareTo(nickname) == 0)
                {
                    return raiz;
                }
                else if (raiz.nickname.CompareTo(nickname) > 0)
                {
                    return buscarNodoAVL(raiz.izquierda, nickname);
                }
                else
                {
                    return buscarNodoAVL(raiz.derecha, nickname);
                }

            }

            public int modificarAVL(string datoviejo,string nickname, string correo, string contraseña)
            {
                if (buscarNodoAVL(this.raiz, datoviejo) != null)
                {
                    if (datoviejo.CompareTo(nickname) == 0)
                    {
                        nodo_contactos encontrado = buscarNodoAVL(this.raiz, datoviejo);
                        encontrado.correo = correo;
                        encontrado.contraseña = contraseña;
                        return 1;
                    }
                    else
                    {
                        this.eliminarAVL(datoviejo);
                        nodo_contactos n1 = new nodo_contactos(nickname, contraseña, correo);
                        insertarAvl(n1);
                        return 1;
                    }
                    
                }
                else
                {
                    return 0;
                }
            }
           
        }
        ABB.arbolavl avl = new ABB.arbolavl();
        public void agregarPadre(string nickname)
        {
            nodo usuario = buscarNodoAbb(raiz, nickname);
            if (usuario != null)
            {
                if (usuario.avl.raiz == null)
                {
                    //si lo encuentra

                    ABB.nodo_contactos nodo = new ABB.nodo_contactos(usuario.nickname, usuario.contraseña, usuario.correo);
                    nodo.usuario = usuario;
                    // avl.insertarAvl(nodo);
                    usuario.avl.insertarAvl(nodo);
                    usuario.avl.graficarAVL();
                    
                }

            }
        }
       
        public void agregarContactosPadre(string padre,string nickname, string correo, string contraseña)
        {
            
            nodo encontradoContacto = buscarNodoAbb(raiz, nickname);
            if (encontradoContacto != null)
            {
                ABB.nodo_contactos nodo = new ABB.nodo_contactos(encontradoContacto.nickname, encontradoContacto.contraseña, encontradoContacto.correo);
                nodo.usuario = encontradoContacto;

                //agregar al avl del padre
                nodo encontrandoPadre = buscarNodoAbb(raiz, padre);
                encontrandoPadre.avl.insertarAvl(nodo);
                encontrandoPadre.avl.graficarAVL();
                encontrandoPadre.contador_contactos = encontrandoPadre.contador_contactos + 1;
            }
            else
            { 
                ABB.nodo_contactos nuevo=new ABB.nodo_contactos(nickname,contraseña,correo);
                nodo encontrandoPadre = buscarNodoAbb(raiz, padre);
                encontrandoPadre.avl.insertarAvl(nuevo);
                encontrandoPadre.avl.graficarAVL();

                encontrandoPadre.contador_contactos = encontrandoPadre.contador_contactos + 1; 
            
            }

           
        }
        public void eliminarContactoPadre(string padre, string nickname)
        {
            nodo encontradopadre = buscarNodoAbb(raiz, padre);
            if (encontradopadre != null)
            {
                avl.eliminarAVL(nickname);
            }
        }
        public void modificarContactos(string padre, string nickname_viejo, string nickname_nuevo, string correo, string contraseña)
        {
            nodo encontradopadre = buscarNodoAbb(raiz, padre);
            if (encontradopadre != null)
            {
                avl.modificarAVL(nickname_viejo, nickname_nuevo, correo, contraseña);
                
            }
        }
        public void graficasAVL_NODOSABB(string padre)
        { 
             nodo encontradoContacto = buscarNodoAbb(raiz, padre);
             if (encontradoContacto != null)
             {
                 encontradoContacto.avl.graficarAVL();
             }
        }
        //top de los contactos avl
        static lista_top topContactos = new lista_top();
        public void recorridoTopContactos(nodo raiz)
        {
            if (raiz != null)
            {
                if (raiz.contador_contactos != 0)
                {
                    nodo_top nuevo = new nodo_top(raiz.nickname, raiz.contador_contactos);
                    topContactos.insertarTop(nuevo);
                    recorridoTContactos(raiz);
                    
                }
            }

        }
        public void recorridoTContactos(nodo raiz)
        {
            if (raiz != null)
            {

                if (raiz.izq != null)
                {
                    if (raiz.izq.contador_contactos != 0)
                    {
                        nodo_top nuevo = new nodo_top(raiz.izq.nickname, raiz.izq.contador_contactos);
                        topContactos.insertarTop(nuevo);
                    }

                }
                recorridoTContactos(raiz.izq);

                if (raiz.der != null)
                {
                    if (raiz.der.contador_contactos != 0)
                    {
                        nodo_top nuevo = new nodo_top(raiz.der.nickname, raiz.der.contador_contactos);
                        topContactos.insertarTop(nuevo);
                    }
                }
                recorridoTContactos(raiz.der);


            }


        }
        public void graficarTOPCONTACTOS()
        {
            int cont = 1;
            TextWriter archivo;
            archivo = new StreamWriter("C:\\ARCHIVOSDOT\\Top_Contactos.dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1];");
            nodo_top aux = topContactos.primero;

            if (aux != null)
            {



                while (aux != null && cont <= 10)
                {
                    archivo.WriteLine(aux.nickname_base + "[label= \" Usuario" + cont + "\\n nickname:  " + aux.nickname_base + "\\n" + "numero_Contactos:  " + aux.num + "\"];");
                    cont++;
                    aux = aux.siguiente;
                }
                aux = topContactos.primero;
                int cont2 = 1;


                while (aux != null)
                {
                    if (aux.siguiente != null && cont2 < 10)
                    {

                        archivo.WriteLine(aux.nickname_base + "->" + aux.siguiente.nickname_base + ";");
                        archivo.WriteLine(aux.siguiente.nickname_base + "->" + aux.nickname_base + ";");

                    }
                    aux = aux.siguiente;
                    cont2++;
                }


            }
            else
            {
                archivo.WriteLine("LA LISTA ESTA VACIA");

            }

            archivo.WriteLine("}");

            archivo.Close();
            cmdTop_Contactos();

        }
        public void cmdTop_Contactos()
        {
            try
            {


                var command = string.Format(" dot.exe -Tpng C:\\ARCHIVOSDOT\\Top_Contactos.dot -o  C:\\ARCHIVOSDOT\\Top_Contactos.png ");
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
        //recorrer el arbol y mandar a la hash
        TablaHash tabla = new TablaHash();   
        public void recorridoTHP(nodo raiz)
        {
            if (raiz != null)
            {
               
                    tabla.insertarHash(raiz.nickname);  
                    recorridoTH(raiz);
            }

        }
        public void recorridoTH(nodo raiz)
        {
            if (raiz != null)
            {

                if (raiz.izq != null)
                {
                    tabla.insertarHash(raiz.izq.nickname); 

                }
                recorridoTH(raiz.izq);

                if (raiz.der != null)
                {
                    tabla.insertarHash(raiz.der.nickname); 

                }
                recorridoTH(raiz.der);


            }

           
        }

        public void graficarTH()
        {
            tabla.GraficarHash();
        }

        public void ELIMINARHASH(string name)
        {
            tabla.eliminarHash(name);
        }



    }
}           
        

    
