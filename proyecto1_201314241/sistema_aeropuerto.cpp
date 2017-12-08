#include "sistema_aeropuerto.h"

//----------------------------------------------AVIONES-------------------------------------------------------------
aviones::aviones(int id, QString tamano, int pasajeros, int desabordaje, int mantenimiento)
{
this->id=id;
this->tamano=tamano;
this->pasajeros=pasajeros;
this->desabordaje=desabordaje;
this->mantenimiento=mantenimiento;
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
        this->primero->siguiente=this->primero;
        this->primero->anterior=this->primero;
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

void cola_aviones::graficar_aviones()
{
 FILE *fichero;
    fichero = fopen("Cola_aviones.dot", "w+");
    fprintf(fichero, "digraph g{\n");
    aviones *aux = this->primero;
    while(aux!=NULL){
        fprintf(fichero,"%d",(&aux->id));
        fprintf(fichero,"[label=");
        fprintf(fichero, "\"");
        fprintf(fichero,"%d", aux->id);
        fprintf(fichero,"\"");
        fprintf(fichero, "];\n");
        if(aux->siguiente!=NULL){
            fprintf(fichero,"%d",(&aux->id));
            fprintf(fichero," -> ");
            fprintf(fichero, "%d",(&aux->siguiente->id));
            fprintf(fichero,";\n");

            fprintf(fichero,"%d",(&aux->id));
            fprintf(fichero," -> ");
            fprintf(fichero, "%d",(&aux->anterior->id));
            fprintf(fichero,";\n");
        }
        aux = aux->siguiente;
    }
    fprintf(fichero,"}\n");
    fclose(fichero);
    system("C:\\Graphviz2.38\\bin\\dot.exe -Tpng Cola_aviones.dot -o Cola_aviones.png");
    system("Cola.png");







}


//------------------------------------------PASAJEROS------------------------------------------------------------
pasajero::pasajero(int id, int n_maletas, int n_documentos, int n_turnos)
{
this->id=id;
this->n_maletas=n_maletas;
this->n_documentos=n_documentos;
this->n_turnos=n_turnos;

}

cola_pasajeros::cola_pasajeros()
{
this->primera=NULL;

}




//---------------------------------------EQUIPAJE-----------------------------------------------------------------
equipaje::equipaje(int maleta)
{
this->maleta=maleta;
}

lista_equipaje::lista_equipaje()
{
this->primero=NULL;
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



