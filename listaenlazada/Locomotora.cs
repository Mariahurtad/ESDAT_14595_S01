using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaenlazada
{
    internal class Locomotora
    {
        public Vagon Primero {  get; set; }

        public void AgregaIni(int valor)
        {
            // Agregar un dato al inicio
            Vagon nuevo = new Vagon(valor); 
            if (this.Primero == null)
            {
                this.Primero = nuevo;
            } else
            {
                Vagon prim = this.Primero;
                nuevo.Sig = this.Primero;
                this.Primero = nuevo; // conectamos la locomotora con el nuevo vagon 

            }

        }

        public void AgregaFin(int valor)
        {
            Vagon nuevo = new Vagon(valor);
            if (this.Primero == null)
            {
                this.Primero = nuevo;
            }
            else if (this.Primero.Sig == null)
            {
                this.Primero.Sig = nuevo;
            }
            else
            {
                Vagon ultimo = Primero;
                while (ultimo.Sig != null)
                {
                    ultimo = ultimo.Sig;
                } 
                ultimo.Sig = nuevo;
            }  
        }
        public void EliminarSegundo()
        {
            Vagon actual = Primero;

            if (actual == null || actual.Sig == null)
            {
                Console.WriteLine("Los vagones on insuficientes");
                return;
            }
            else
            {
                Vagon conservar = Primero.Sig.Sig;
                actual.Sig = conservar;
            }
            Primero = actual;
        }
        public void Imprime()
        {
            Vagon tmp = Primero;
            while (tmp != null)
            {
                Console.WriteLine($"{tmp.Dato}, ");
                tmp = tmp.Sig;
            }
        }

        public bool BuscarValor(int valorBuscar)
        {
            Vagon tmp = Primero;
            while (tmp != null)
            {
                if (tmp.Dato == valorBuscar)
                {
                    return true;
                }
                tmp = tmp.Sig;
            }
            return false;
        }

        public int Get(int idx)
        {
            Vagon tmp = Primero;
            int indice = 0;
            while (tmp != null)
            {
                if (indice == idx)
                {
                    return tmp.Dato;
                }
                indice++;
                tmp = tmp.Sig;
            }
            return int.MinValue;
        }

        public int Lenght()
        {
            Vagon tmp = Primero;
            int contar = 0;
            while (tmp != null)
            {
                contar++;
                tmp = tmp.Sig;
            }
            return contar;
        }
        public void  MezclaFinal(Locomotora ListFin)
        {
            int cant = ListFin.Lenght();
            for (int i = 0; i <= cant; i++) 
            {
              this.AgregaFin(ListFin.Get(i));
            }
           
        }
        public void MezclaFinal2 (Locomotora ListFin)
        {
            Vagon actual = ListFin.Primero;
           
            if (this.Primero == null)
            {
                this.Primero = actual;
            } else
            {
                Vagon tmp = Primero;
                    while (tmp.Sig != null)
                {
                    tmp = tmp.Sig;
                }
                    tmp.Sig = actual;
            }
        }
    }
}
