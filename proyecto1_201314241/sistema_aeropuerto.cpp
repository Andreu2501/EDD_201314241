#include "sistema_aeropuerto.h"
#include <QMessageBox>

//----------------------------------------------AVIONES-------------------------------------------------------------
aviones::aviones(int id, QString tamano, int pasajeros, int desabordaje, int mantenimiento)
{
this->id=id;
this->tamano=tamano;
this->pasajeros=pasajeros;
this->desabordaje=desabordaje;
this->mantenimiento=mantenimiento;
this->siguiente=NULL;
this->anterior=NULL;
}

cola_aviones::cola_aviones()
{
this->primero=NULL;
}
//Cola doble
void cola_aviones::insertar_aviones(aviones *nuevo_avion)
{
if (this->primero==NULL)
    {
        this->primero=nuevo_avion;

    }else{
        aviones *tmp=this->primero;
        while(tmp->siguiente!=NULL)
        {
            tmp=tmp->siguiente;
        };
        tmp->siguiente=nuevo_avion;
        nuevo_avion->anterior=tmp;

    }
}
char* aviones::getinfo()
{
QByteArray ba= this->tamano.toLatin1();
char* texto= (char*)malloc(sizeof(char)*100);
strcpy(texto, ba.data());
return texto;
}

void cola_aviones::eliminar_aviones()
{
aviones *aux=this->primero;
if(this->primero->siguiente==NULL)
{
    this->primero==NULL;
    QMessageBox msgBox;
    msgBox.setText("Se acaba de eliminar al ultimo avion en la cola");
msgBox.exec();


}else
{
   this->primero=this->primero->siguiente;

}
    delete aux;



}

void cola_aviones::graficar_aviones()
{
 FILE *fichero;
    fichero = fopen("Cola_aviones.dot", "w+");
    fprintf(fichero, "digraph g{\n");
    fprintf(fichero, "node[shape=record];");
    aviones *aux = this->primero;
    while(aux!=NULL){
        fprintf(fichero,"%d",(&aux->id));
        fprintf(fichero,"[label=");
        fprintf(fichero, "\"");
        fprintf(fichero,"Aviones \\n id: %d \\n tamano: %s \\n pasajeros: %d \\n desabordaje(turnos): %d \\n mantenimiento(turnos): %d ", aux->id, aux->getinfo(),aux->pasajeros, aux->desabordaje,aux->mantenimiento);
        fprintf(fichero,"\"");
        fprintf(fichero, "];\n");
        if(aux->siguiente!=NULL){
            fprintf(fichero,"%d",(&aux->id));
            fprintf(fichero," -> ");
            fprintf(fichero, "%d",(&aux->siguiente->id));
            fprintf(fichero,";\n");

               fprintf(fichero,"%d",(&aux->siguiente->id));
            fprintf(fichero," -> ");
            fprintf(fichero, "%d",(&aux->id));
            fprintf(fichero,";\n");
        }
        aux = aux->siguiente;
    }
    fprintf(fichero,"}\n");
    fclose(fichero);
    system("C:\\Graphviz2.38\\bin\\dot.exe -Tpng Cola_aviones.dot -o Cola_aviones.png");
    system("Cola_aviones.png");









}


//------------------------------------------PASAJEROS------------------------------------------------------------
pasajero::pasajero(int id, int n_maletas, int n_documentos, int n_turnos)
{
this->id=id;
this->n_maletas=n_maletas;
this->n_documentos=n_documentos;
this->n_turnos=n_turnos;
this->siguiente=NULL;

}

cola_pasajeros::cola_pasajeros()
{
this->primero=NULL;
}

void cola_pasajeros::insertar_pasajeros(pasajero *nuevo_pasajero)
{
if(this->primero==NULL)
    {
        this->primero=nuevo_pasajero;
    }else
    {
       pasajero *aux=this->primero;
       while(aux->siguiente!=NULL)
       {
         aux=aux->siguiente;

       }
       aux->siguiente=nuevo_pasajero;

    }

}

void cola_pasajeros::eliminar_pasajeros()
{
pasajero *aux=this->primero;
if(this->primero->siguiente==NULL)
{
    this->primero==NULL;
    QMessageBox msgBox;
    msgBox.setText("Se acaba de eliminar a la ultima persona en la cola");
msgBox.exec();
}else
{
   this->primero=this->primero->siguiente;

}
    delete aux;

}

void cola_pasajeros::graficaar_pasajeros()
{
 FILE *fichero;
    fichero = fopen("Cola_pasajeros.dot", "w+");
    fprintf(fichero, "digraph g{\n");
    fprintf(fichero, "node[shape=record];");
    pasajero *aux = this->primero;
    while(aux!=NULL){
        fprintf(fichero,"%d",(&aux->id));
        fprintf(fichero,"[label=");
        fprintf(fichero, "\"");
        fprintf(fichero,"Pasajeros \\n id: %d \\n n.maletas: %d \\n n.documentos: %d \\n n.turnos: %d", aux->id, aux->n_maletas, aux->n_documentos, aux->n_turnos);
        fprintf(fichero,"\"");
        fprintf(fichero, "];\n");
        if(aux->siguiente!=NULL){


            fprintf(fichero,"%d",(&aux->id));

            fprintf(fichero," -> ");


            fprintf(fichero, "%d",(&aux->siguiente->id));
            fprintf(fichero,";\n");
        }
        aux = aux->siguiente;
    }
    fprintf(fichero,"}\n");
    fclose(fichero);
    system("C:\\Graphviz2.38\\bin\\dot.exe -Tpng Cola_pasajeros.dot -o Cola_pasajeros.png");
    system("Cola_pasajeros.png");





}




//---------------------------------------EQUIPAJE-----------------------------------------------------------------
equipaje::equipaje(int maleta)
{
this->maleta=maleta;
this->siguiente=NULL;
this->anterior=NULL;
}

lista_equipaje::lista_equipaje()
{
this->primero=NULL;
}

void lista_equipaje::insertar_equipaje(equipaje *nuevo_equipaje)
{
if (this->primero==NULL)
    {
        this->primero=nuevo_equipaje;
        this->primero->siguiente=this->primero;
        this->primero->anterior=this->primero;
    }else{
        equipaje *tmp=this->primero;
        do
        {
            tmp=tmp->siguiente;
        }while(tmp->siguiente!=this->primero);
        tmp->siguiente=nuevo_equipaje;
        nuevo_equipaje->anterior=tmp;
        nuevo_equipaje->siguiente=this->primero;
        this->primero->anterior=nuevo_equipaje;

    }
}
void lista_equipaje::graficar_equipaje(){
FILE *fichero;
    fichero = fopen("lista_equipaje.dot", "w+");
    fprintf(fichero, "digraph g{\n");
    fprintf(fichero, "node[shape=record];");
    equipaje *aux = this->primero;
       if(aux!=NULL)
    {
        do
        {
             fprintf(fichero,"%d",(&aux->maleta));
        fprintf(fichero,"[label=");
        fprintf(fichero, "\"");
        fprintf(fichero,"Equipaje \\n Maleta: %d ", aux->maleta);
        fprintf(fichero,"\"");
        fprintf(fichero, "];\n");
        fprintf(fichero,"%d",(&aux->maleta));
        fprintf(fichero," -> ");
   fprintf(fichero,"%d",(&aux->siguiente->maleta));

   fprintf(fichero,";\n");
         fprintf(fichero,"%d",(&aux->siguiente->maleta));

            fprintf(fichero," -> ");
             fprintf(fichero,"%d",(&aux->maleta));

            fprintf(fichero,";\n");


                 aux = aux->siguiente;
        }while(aux!=this->primero);

             // aux = aux->siguiente;

    }


    fprintf(fichero,"}\n");
    fclose(fichero);
    system("C:\\Graphviz2.38\\bin\\dot.exe -Tpng lista_equipaje.dot -o lista_equipaje.png");
    system("lista_equipaje.png");
}



//---------------------------------------ESCRITORIOS--------------------------------------------------------------
escritorios::escritorios(int id_cliente, bool disponibilidad, int n_documentos, int turnos_restantes)
{
this->id_cliente=id_cliente;
this->disponibilidad=disponibilidad;
this->n_documentos=n_documentos;
this->turnos_restantes=turnos_restantes;

}

lista_escritorios::lista_escritorios()
{
this->primero=NULL;
}
//--------------------------------------MANTENIMIENTO-------------------------------------------------------------

estaciones::estaciones(int id, QString tamano, bool disponibilidad, int turnos)
{
this->id=id;
this->tamano=tamano;
this->disponibilidad=disponibilidad;
this->turnos=turnos;
}

lista_estaciones::lista_estaciones()
{
this->primero=NULL;

}

nodo_cola_avion::nodo_cola_avion(int id, QString tamano, int turnos)
{
this->id=id;
this->tamano=tamano;
this->turnos=turnos;

}

cola_avion_mantenimiento::cola_avion_mantenimiento()
{
this->primero=NULL;

}



