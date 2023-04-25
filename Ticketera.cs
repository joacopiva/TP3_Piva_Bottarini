using System;
using System.Collections.Generic;
class Ticketera
{ 
    private static Dictionary<int,Cliente> DicClientes = new Dictionary<int, Cliente>();



    private static  int UltimoIDEntrada = 0;

    
    public static int DevolverUltimoID()
    {  
        return UltimoIDEntrada;
    }

    public static int AgregarCliente(Cliente cliente)
    {
        UltimoIDEntrada ++;
        DicClientes.Add(UltimoIDEntrada, cliente);
        

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
        int importeNuevo;
        int importeViejo;
        if(DicClientes.ContainsKey(IDEntradaIngresado))
        {
            tipoEntradaVieja = DicClientes[IDEntradaIngresado].TipoEntrada;
            importeNuevo = CalcularImporte(tipoEntradaNuevo);
            importeViejo = CalcularImporte(tipoEntradaVieja);

            if(importeNuevo > importeViejo)
            {
                puedeCambiar = true;
            }
        }
        return puedeCambiar;
    }

    public static List<string> EstadisticasTicketera()
    {
        List <string> ListaEstadisticas = new List <string>();
        int cantInscripcion = 0;
        int recaudacionTotal = 0;

        cantInscripcion = DicClientes.Count();

        if(cantInscripcion == 0)
        {
            return null;
        }
        else
        {
            int[] vecRecaudacionTipos = new int[4];
            int[] vecCantPorTipo = new int[4];
            int[] vecRecaudacionPorcentaje = new int[4];

            foreach(Cliente clave in DicClientes.Values)
            {
                if(clave.TipoEntrada == 1)
            {
                vecRecaudacionTipos[0] += 15000;
                vecCantPorTipo[0] += 1;
            }
                else if(clave.TipoEntrada == 2)
            {
                vecRecaudacionTipos[1] += 30000;
                vecCantPorTipo[1] += 1;
            }
                else if(clave.TipoEntrada == 3)
            {
                vecRecaudacionTipos[2] += 10000;
                vecCantPorTipo[2] += 1;
            }
                else
            {
                vecRecaudacionTipos[3] += 40000;
                vecCantPorTipo[3] += 1;
            }  

            }
            for(int i = 0; i < 4; i++)
            {
                recaudacionTotal += vecRecaudacionTipos[i];
            }
            

            for(int x = 0; x < 4; x++)
            {
                vecRecaudacionPorcentaje[x] = (vecCantPorTipo[x] * 100) / cantInscripcion;
            }

            ListaEstadisticas.Add(Convert.ToString("La cantidad de cliente inscriptos fueron: " + cantInscripcion));

            for(int y = 1; y < 4; y++)
            {   
            ListaEstadisticas.Add(Convert.ToString("El porcentaje de cantidad de entradas vendias de la opcion opcion " + y + " fue del " + vecRecaudacionPorcentaje[y -1]) + " porciento");
            ListaEstadisticas.Add(Convert.ToString("La recaudacion de la opcion " + y  + " fue de " + vecRecaudacionTipos[y -1]));
            }
            ListaEstadisticas.Add(Convert.ToString("La recaudacion total fue de: " + recaudacionTotal));
            return ListaEstadisticas;
            }

        
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
