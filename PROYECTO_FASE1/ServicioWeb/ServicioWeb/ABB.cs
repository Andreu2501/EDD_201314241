using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;


namespace ServicioWeb
{
    public class ABB
    {
        bool bandera1 = false;
        bool bandera2 = false;
      public class nodo 
        {
            public nodo izq;
            public nodo der;
            public string nickname;
            public string contraseña;
            public string correo;
            public int conectado;
            public lista_doble_enlazada lista;
            //apuntador de la lista
            //constructor
            public nodo(string nickname, string contraseña, string correo, int conectado)
            {
                this.nickname = nickname;
                this.contraseña = contraseña;
                this.correo = correo;
                this.conectado = conectado;
                this.izq = null;
                this.der = null;
                this.lista=new lista_doble_enlazada();
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
            raiz=null;
        }

        public void insertar(string nickname, string contraseña, string correo, int conectado)
        {
            nodo nuevo = new nodo(nickname, contraseña, correo, conectado);
    
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
            else if(nuevo.nickname.CompareTo(actual.nickname) > 0){
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
         
            }else{
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
                int ni = calcularNivel(raiz.izq);
                int nd = calcularNivel(raiz.der);
                return (ni > nd ? ni : nd);
            }
        }


        public int numeroRamas(nodo raiz)
        {
            if(raiz==null)
            {
                return 0;
            }else
            {
                int ramai=numeroRamas(raiz.izq);
                int ramad = numeroRamas(raiz.der);
                if(raiz.izq!=null || raiz.der!=null)
                {
                    return ramai+ramad+1;
                }
                     return ramai+ramad;
            }
          }

        public int numeroHojas(nodo raiz)
        {
            if(raiz==null)
            {
                return 0;
            }else
            {
                if(raiz.izq==null && raiz.der==null)
                {
                    return 1;
                }else
                {
                    int hojasi=numeroHojas(raiz.izq);
                    int hojasd=numeroHojas(raiz.der);
                    return hojasi+hojasd;
                }
            
            }
              
        }

          public void graficar()
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\Andrea Flores\\Documents\\DICIEMBRE2017\\PROYECTO1\\ServicioWeb\\REPORTES\\arbol2017.dot");
            archivo.WriteLine("digraph G{");
            archivo.WriteLine("node[shape=record, height=.1];");
            archivo.WriteLine(inOrder(raiz));
            archivo.WriteLine(preorder(raiz));
            archivo.WriteLine("}");
            archivo.Close();
             
           // var filename = "arbol2017.dot";
            //string path = Directory.GetCurrentDirectory();
            //GraficarArbol(filename, "C:\\Users\\Andrea Flores\\Documents\\DICIEMBRE2017\\PROYECTO1\\ServicioWeb\\REPORTES\\arbol2017.dot");



        }


     

        public string inOrder(nodo raiz)
        {
            StringBuilder b = new StringBuilder();
            if (raiz != null)
            {
                b.Append(inOrder(raiz.izq));
                b.Append(raiz.nickname);
                b.Append("[label=\"<f0>|<f1>");
                b.Append(raiz.nickname);
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


        public  void GraficarArbol(string fileName, string path)
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
        public nodo buscarNodoAbb(nodo raiz,string nickname_base)
        {
            if(raiz==null)
            {
                return null;
            }else if(raiz.nickname.CompareTo(nickname_base)==0)
            {
                return raiz;
            }else if(raiz.nickname.CompareTo(nickname_base)>0)
            {
                return buscarNodoAbb(raiz.izq,nickname_base);
            }else
            {
               return buscarNodoAbb(raiz.der,nickname_base);
            }

          }

          public void agregar_lista_abb(nodo raiz, nodo_lista nuevo)
          {
              nodo encontrado = this.buscarNodoAbb(raiz,nuevo.nickname_base);
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
                    modificar_lista_juegos(encontrado_nodo, oponente,unidades_desplegadas,unidades_sobrevivientes,unidades_destruidas,bandera);
                    
                    return encontrado_nodo;
                }
                return null;
            }

        public void modificar_lista_juegos(nodo arbol, string oponente,int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
            {


                nodo_lista aux = arbol.lista.primero;
                if (  arbol.lista.primero != null)
                {
                    while (aux != null)
                    {
                        if (aux.nickname_oponente.CompareTo(oponente) == 0)
                        {
                            //los dos usuarios se han encontrado!!!
                            bandera2 = true;
                            todosEncontrados();
                            modificarNodo(arbol,aux,arbol.nickname,aux.nickname_oponente,unidades_desplegadas,unidades_sobrevivientes,unidades_destruidas,bandera);
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
            public void modificarNodo(nodo arbol,nodo_lista nodo, string nickname_base, string nickename_oponente, int unidades_desplegadas, int unidades_sobrevivientes, int unidades_destruidas, int bandera)
            {
                
                nodo_lista nuevo = new nodo_lista(nickname_base, nickename_oponente, unidades_desplegadas, unidades_sobrevivientes, unidades_destruidas, bandera);
                
                eliminar_lista_modificar(arbol,nickename_oponente);
               
               arbol.lista.insertar_lista_juegos(nuevo);
                

                                                                                                                                                                                            
            
            }
            public void ELIMINAR_LISTA_JUEGOS(nodo raiz, string nickname_base,string nickname_oponente)
            {
                nodo encontrado_nodo = buscarNodoAbb(raiz, nickname_base);
                eliminar_lista_modificar(encontrado_nodo, nickname_oponente);
            
            }
            public void eliminar_lista_modificar(nodo arbol,string nickname_oponente)
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
            }else if(raizsub.nickname.CompareTo(nickname)>0)
            {
                nodo iz;
                iz = eliminar(raizsub.subarbolIzdo(), nickname);
                raizsub.ramaIzdo(iz);
            }
            else if (raizsub.nickname.CompareTo(nickname)<0)
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
        public int modificar(string datoviejo,string nickname, string contraseña, string correo, int conectado)
        { 
            if(buscarNodoAbb(this.raiz,datoviejo)!=null)
            {
                this.eliminar(datoviejo);
                nodo n1=new nodo(nickname,contraseña,correo,conectado);
                this.insertar(n1.nickname,n1.contraseña,n1.correo,n1.conectado);
                return 1;
            }else
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
                nodo nuevonodo = new nodo(raiz.nickname, raiz.contraseña, raiz.correo, raiz.conectado);
                nuevonodo.nickname = raiz.nickname;
                nuevonodo.izq = hacerespejo(raiz.der);
                nuevonodo.der = hacerespejo(raiz.izq);
                return nuevonodo;
            }
            
        }
       
            
       //REALIZACION DEL TOP 10 PARTIDAS GANADAS


        }
            
   
        

    }
