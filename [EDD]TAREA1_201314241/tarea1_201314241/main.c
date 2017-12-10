#include <stdio.h>
#include <stdlib.h>
#include "doble.h"





int main()
{
    lista *listadoble=(lista*)malloc(sizeof(lista));
listadoble->primero = NULL;
listadoble->ultimo=NULL;
    int n=0;
    int opcion=0;
     do
    {
        printf( "\n BIENVENIDOS AL MENU"  );
        printf( "\n1. INSERTAR UN VALOR."  );
        printf( "\n2. MOSTRAR UN VALOR." );
        printf( "\n3. ELIMINAR UN VALOR.\n" );
         printf( "\n" );

        scanf( "%d", &opcion );

        switch ( opcion )
        {
            case 1:
                    printf( "\n INSERTE EL VALOR: "  );
                     printf( "\n"  );
                    scanf( "%d", &n );
                    insertar_lista(listadoble,n);
                    break;

            case 2:
                    printf( "\n LOS VALORES SON: "  );
                    recorrer(listadoble);
                    break;

            case 3: printf( "\n   ELIMINAR \n");
                    printf( "\n"  );
                    scanf( "%d", &n );
                    eliminar(listadoble,n);
                    break;

         }



    } while ( opcion != 4 );



return 0;

}


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
if(aux==NULL)
{
    printf("la lista esta vacia");
}

while(aux!=NULL)
{


    printf("\n el valor es: %d \n", aux->valor);
    aux=aux->siguiente;
}
}



int eliminar(lista *listadoble, int valor)
{
    int encontrado=0;
    if(listadoble->primero==listadoble->ultimo)
    {
           /* el nodo es el unico en la lista*/
    if(listadoble->primero->valor==valor){
        listadoble->primero=NULL;
        free(listadoble->primero);
        return 1;

    }
    }else if(valor==listadoble->ultimo->valor)
    {
           /* el valor es el nodo ultimo*/
            nodo *aux2=listadoble->ultimo;
            listadoble->ultimo=aux2->anterior;
            listadoble->ultimo->siguiente=NULL;
            free(listadoble->ultimo->siguiente);
            aux2=NULL;
            free(aux2);
            return 1;
    }else if(valor==listadoble->primero->valor)
    {
           /* el valor es el nodo primero*/
            nodo *aux=listadoble->primero;
            listadoble->primero=aux->siguiente;
            listadoble->primero->anterior=NULL;
            free(listadoble->primero->anterior);
            aux=NULL;
            free(aux);
            return 1;
    }else
    {
           /* nodos en medio */

        nodo *tmp=listadoble->primero;

        while(tmp!=NULL)
        {
        if(tmp->valor==valor)
            {
            nodo *adelante=tmp->siguiente;
            nodo *atras=tmp->anterior;
            atras->siguiente=adelante;
            adelante->anterior=atras;
            tmp=NULL;
            free(tmp);
            return 1;
             break;
            }
            tmp=tmp->siguiente;

        }
        if(encontrado==0)
        {
        printf("ESE NUMERO NO EXISTE!!!, INTENTE DE NUEVO");
        }

    }

}


