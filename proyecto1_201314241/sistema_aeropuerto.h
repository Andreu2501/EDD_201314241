#ifndef SISTEMA_AEROPUERTO_H
#define SISTEMA_AEROPUERTO_H
#include <QString>

struct aviones
{
int id;
QString tamano;
int pasajeros;
int desabordaje;
int mantenimiento;
aviones *siguiente;
aviones *anterior;
aviones(int id, QString tamano, int pasajeros, int desabordaje, int mantenimiento);
};


struct cola_aviones
{
    //cola doble
    aviones *primero;
    void insertar_aviones(aviones *nuevo_avion);
    void eliminar_aviones();
    void graficar_aviones();
    cola_aviones();

};

struct pasajero
{
int id;
int n_maletas;
int n_documentos;
int n_turnos;
pasajero *siguiente;
pasajero(int id, int n_maletas, int n_documentos,int n_turnos);
};

struct cola_pasajeros
{
    //cola simple
    pasajero *primera;
    void insertar_pasajeros(pasajero *nuevo_pasajero);
    void eliminar_pasajeros();
    cola_pasajeros();

};

struct escritorios
{
int id_cliente;
bool disponibilidad;
int n_documentos;
int turnos_restantes;
escritorios *siguiente;
escritorios *anterior;
escritorios(int id_cliente, bool disponibilidad, int n_documentos, int turnos_restantes);

};

struct lista_escritorios
{
    //lista doble enlazada
    escritorios *primero;
    void insertar_escritorios(escritorios *nuevo_escritorio);
    void eliminar_escritorios();
    lista_escritorios();


};

struct equipaje
{
int maleta;
equipaje *siguiente;
equipaje *anterior;
equipaje(int maleta);
};

struct lista_equipaje
{
    //lista doble enlazada circular
    equipaje *primero;
    void insertar_equipaje(equipaje *nuevo_equipaje);
    void eliminar_equipaje();
    lista_equipaje();

};

struct estaciones
{
int id;
QString tamano;
bool disponibilidad;
int turnos;
estaciones *siguiente;
estaciones(int id, QString tamano, bool disponibilidad, int turnos);

};

struct lista_estaciones
{
    //lista simple
    estaciones *primero;
    void insertar_estaciones(estaciones *nueva_estacion);
    void eliminar_estaciones();
    lista_estaciones();

};

struct nodo_cola_avion
{
int id;
QString tamano;
int turnos;
nodo_cola_avion *siguiente;
nodo_cola_avion(int id, QString tamano, int turnos);

};

struct cola_avion_mantenimiento
{
//cola simple
    nodo_cola_avion *primero;
    void insertar_cola_avion(nodo_cola_avion *nuevo_avion);
    void eliminar_cola_avion();
    cola_avion_mantenimiento();


};



#endif // SISTEMA_AEROPUERTO_H
