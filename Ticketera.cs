using System;
using System.Collections.Generic;
class Ticketera
{ 
    private Dictionary<int,Cliente> DicClientes;

    private int UltimoIDEntrada = 1;

    
    int DevolverUltimoID()
    {  
        return UltimoIDEntrada;
    }

    int AgregarCliente(Cliente cliente)
    {
        DicClientes.Add(UltimoIDEntrada, cliente);
        UltimoIDEntrada ++;

        return UltimoIDEntrada;
    }

    Cliente BuscarCliente(int UltimoIDEntrada)
    {
        foreach()
    }

}
