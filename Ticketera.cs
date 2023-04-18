using System;
using System.Collections.Generic;
class Ticketera
{ 
    private static Dictionary<int,Cliente> DicClientes;

    private static  int UltimoIDEntrada = 1;

    
    public static int DevolverUltimoID()
    {  
        return UltimoIDEntrada;
    }

    public static int AgregarCliente(Cliente cliente)
    {
        DicClientes.Add(UltimoIDEntrada, cliente);
        UltimoIDEntrada ++;

        return UltimoIDEntrada;
    }

    public static Cliente BuscarCliente(int IDEntradaIngresado)
    {
        Cliente clienteEncontrado;

        if(DicClientes.ContainsKey(IDEntradaIngresado))
        {
            clienteEncontrado = DicClientes[IDEntradaIngresado];
        }
        else
        {
            clienteEncontrado = null;
        }
        return clienteEncontrado;
    }
    
    public static bool CambiarEntrada(int IDEntradaIngresado, int tipoEntradaNuevo)
    {
        bool puedeCambiar = false;
        int tipoEntradaVieja;
        tipoEntradaVieja = DicClientes[IDEntradaIngresado].TipoEntrada;
        int importeNuevo;
        int importeViejo;

        importeNuevo = CalcularImporte(tipoEntradaNuevo);
        importeViejo = CalcularImporte(tipoEntradaVieja);

        if(importeNuevo > importeViejo)
        {
            puedeCambiar = true;
        }
        return puedeCambiar;
    }

    public static List<string> EstadisticasTicketera()
    {
        int cantInscripcion;
        int porcentajeEntradas;
        int tipo1 = 0;
        int tipo2 = 0;
        int tipo3 = 0;
        int tipo4 = 0;
        int recaudacionTotal;

        cantInscripcion = DicClientes.Count();


        foreach(Cliente clave in DicClientes.Values)
        {
            if(clave.TipoEntrada == 1)
            {
                tipo1 += 15000;
            }
            else if(clave.TipoEntrada == 2)
            {
                tipo2 += 30000;
            }
            else if(clave.TipoEntrada == 3)
            {
                dia3 += 10000;
            }
            else
            {
                dia4 += 40000;
            }  
        }

        recaudacionTotal = dia1 + dia2 + dia3 + dia4;

        
    }

    public static int CalcularImporte(int tipoEntrada)
    {
        int importe;
        if(tipoEntrada == 1)
        {
            importe = 15000;
        }
        else if(tipoEntrada == 2)
        {
            importe = 30000;
        }
        else if(tipoEntrada == 3)
        {
            importe = 10000;
        }
        else
        {
            importe = 40000;
        }
        return importe;
    }



}
