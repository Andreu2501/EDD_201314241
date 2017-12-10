#include "doble.h"

void inicializar(lista *listadoble)
{
    listadoble->primero=NULL;
    listadoble->ultimo=NULL;
}




void insertar_lista(lista *listadoble, int valor)
{
nodo *nuevo=malloc(sizeof(nodo));
nuevo->valor=valor;
nuevo->siguiente=NULL;
if(listadoble->primero==NULL)
{
    listadoble->primero=nuevo;
    listadoble->ultimo=nuevo;
}else
{
listadoble->ultimo->siguiente=nuevo;
nuevo->anterior=listadoble->ultimo;
listadoble->ultimo=nuevo;
}
}


void recorrer(lista *listadoble)
{
nodo *aux=listadoble->primero;
while(aux!=NULL)
{


    printf("el valor es: %d \n", aux->valor);
    aux=aux->siguiente;
}
}
