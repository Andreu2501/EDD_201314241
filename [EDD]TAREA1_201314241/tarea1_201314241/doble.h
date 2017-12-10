#ifndef DOBLE_H_INCLUDED
#define DOBLE_H_INCLUDED

typedef struct nodo nodo;
typedef struct lista lista;

struct nodo
{
int valor;
nodo *siguiente;
nodo *anterior;

};

struct lista
{
nodo *primero;
nodo *ultimo;
};

void menu(int n, int opcion);
void insertar_lista(lista *listadoble, int valor);
void recorrer(lista *listadoble);
int eliminar(lista *listadoble, int valor);

#endif // DOBLE_H_INCLUDED
