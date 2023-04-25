int menu;

bool salir = false;
while(!salir)
{
     menu = Funciones.IngresarEntero("1. Nueva Inscripcion  | 2. Obtener Estadisticas  | 3. Buscar Cliente | 4. Cambiar Entrada | 5. Salir"); 
        switch(menu)
    {
        case 1:
            NuevaInscripcion();
        break;

        case 2:
            ObtenerEstadisticas();
        break;

        case 3:
            BuscarCliente(); 
        break;

        case 4:
            CambiarEntrada();
        break;

        case 5:
            salir = true;
        break;
   
    }
}



void NuevaInscripcion()
{
    int dni = Funciones.IngresarEntero("Ingrese el DNI: ");
    string apellido = Funciones.IngresarTexto("Ingrese el apellido: ");
    string nombre = Funciones.IngresarTexto("Ingrese el nombre: ");
    DateTime fecha = DateTime.Today;
    int tipoentrada = Funciones.IngresarEntero("Ingrese el tipo de entrada: ");
    
    int totalabonado = Ticketera.CalcularImporte(tipoentrada);

    Cliente cliente = new Cliente(dni, apellido, nombre, fecha, tipoentrada, totalabonado);

    int IDnuevo = Ticketera.AgregarCliente(cliente);

    Console.WriteLine("Su compra a sido un exito, su ID es: " + IDnuevo);
}

void ObtenerEstadisticas()
{
    List <string> ListaEstadisticas = Ticketera.EstadisticasTicketera();

    foreach(string dato in ListaEstadisticas)
    {
        Console.WriteLine(dato);
    }
}

void BuscarCliente()
{
    Cliente clienteEncontrado;
    int idIngresado;
    idIngresado = Funciones.IngresarEntero("Ingrese el ID que quiere buscar: ");

    clienteEncontrado = Ticketera.BuscarCliente(idIngresado);

    Console.WriteLine(clienteEncontrado.DNI);
    Console.WriteLine(clienteEncontrado.Apellido);
    Console.WriteLine(clienteEncontrado.Nombre);
    Console.WriteLine(clienteEncontrado.FechaInscripcion);
    Console.WriteLine(clienteEncontrado.TipoEntrada);
    Console.WriteLine(clienteEncontrado.TotalAbonado);
}

void CambiarEntrada()
{
    int IDIngresado = Funciones.IngresarEntero("Ingrese su ID: ");
    int tipoEntrada = Funciones.IngresarEntero("Ingrese el nuevo tipo de entrada que quiere comprar: ");
    int importeNuevo;
    bool puedeCambiar = Ticketera.CambiarEntrada(IDIngresado, tipoEntrada);
    Cliente ClienteACambiar;

    if(!puedeCambiar)
    {
        Console.WriteLine("No se encontro su ID o el monto es menor al que ya habia comprado");
    }
    else
    {
        ClienteACambiar = Ticketera.BuscarCliente(IDIngresado);
        importeNuevo = Ticketera.CalcularImporte(tipoEntrada);

        ClienteACambiar.TipoEntrada = tipoEntrada;
        ClienteACambiar.TotalAbonado = importeNuevo;
        ClienteACambiar.FechaInscripcion = DateTime.Today;
    }
}