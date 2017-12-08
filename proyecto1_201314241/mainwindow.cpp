#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "sistema_aeropuerto.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}
cola_aviones *cola=new cola_aviones();
cola_pasajeros *p=new cola_pasajeros();
lista_equipaje *l=new lista_equipaje();

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    QString id=ui->lineEdit->text();
    QString tamano=ui->lineEdit_2->text();
    QString personas=ui->lineEdit_3->text();
    QString desabordaje=ui->lineEdit_4->text();
    QString mantenimiento=ui->lineEdit_5->text();
    aviones *nodo=new aviones(id.split(" ")[0].toInt(), tamano, personas.split(" ")[0].toInt(),desabordaje.split(" ")[0].toInt(),mantenimiento.split(" ")[0].toInt() );
    cola->insertar_aviones(nodo);
    ui->lineEdit->clear();
    ui->lineEdit_2->clear();
    ui->lineEdit_3->clear();
    ui->lineEdit_4->clear();
    ui->lineEdit_5->clear();
}

void MainWindow::on_pushButton_2_clicked()
{
    cola->graficar_aviones();
}

void MainWindow::on_pushButton_3_clicked()
{
    cola->eliminar_aviones();
}

void MainWindow::on_pushButton_4_clicked()
{
     QString id=ui->lineEdit->text();
    QString maletas=ui->lineEdit_2->text();
    QString doc=ui->lineEdit_3->text();
    QString turnos=ui->lineEdit_4->text();
    pasajero *nuevo=new pasajero(id.split(" ")[0].toInt(),maletas.split(" ")[0].toInt(),doc.split(" ")[0].toInt(),turnos.split(" ")[0].toInt());
    p->insertar_pasajeros(nuevo);
     ui->lineEdit->clear();
    ui->lineEdit_2->clear();
    ui->lineEdit_3->clear();
    ui->lineEdit_4->clear();
}

void MainWindow::on_pushButton_5_clicked()
{
    p->graficaar_pasajeros();
}

void MainWindow::on_pushButton_6_clicked()
{
    p->eliminar_pasajeros();
}

void MainWindow::on_pushButton_7_clicked()
{
     QString id=ui->lineEdit->text();
     equipaje *nuevo=new equipaje(id.split(" ")[0].toInt());
     l->insertar_equipaje(nuevo);
     ui->lineEdit->clear();

}

void MainWindow::on_pushButton_8_clicked()
{
    l->graficar_equipaje();
}
