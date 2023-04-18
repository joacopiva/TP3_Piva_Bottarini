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
