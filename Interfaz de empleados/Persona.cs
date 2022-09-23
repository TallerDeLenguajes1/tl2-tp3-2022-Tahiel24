public abstract class Persona
{
    private int id;
    private string nombre;
    private string direccion;
    private string Telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }

}

class Cliente : Persona
{
    private string DatosReferenciaDireccion;

    public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }

    string[] nombresA = { "Agustin", "Leandro", "Jose", "Juan", "Pedro", "Fransisco" };
    string[] direccionA = { "Asuncion 320", "Corrientes 234", "Av. Peron 256", "Peru 1921", "25 de Mayo 452" };
    string[] TelefonoA = { "32427835", "87382242", "78263930", "32423545", "23546748" };
    string[] referencias = { "Porton negro y pino enfrente", "Paredon blanco", "Auto Negro estacionado dentro", "Plantas en macetas por el jardin", "Ligustrines" };

    Random r = new Random();
    public Cliente()
    {
        Id = r.Next(0, 1000);
        Nombre = nombresA[r.Next(0, 6)];
        Direccion = direccionA[r.Next(0, 5)];
        Telefono1 = TelefonoA[r.Next(0, 5)];
        DatosReferenciaDireccion1 = referencias[r.Next(0, 5)];
    }
}

class Cadete : Persona
{
    private List<Pedido> listadopedidos = new List<Pedido>();
    private List<Pedido> listadoEntregados = new List<Pedido>();

    public List<Pedido> ListadoPedidos { get => listadopedidos; set => listadopedidos = value; }
    public List<Pedido> ListadoEntregados { get => listadoEntregados; set => listadoEntregados = value; }

    string[] nombresA = { "Agustin", "Leandro", "Jose", "Juan", "Pedro", "Fransisco" };
    string[] direccionA = { "Asuncion 320", "Corrientes 234", "Av. Peron 256", "Peru 1921", "25 de Mayo 452" };
    string[] TelefonoA = { "32427835", "87382242", "78263930", "32423545", "23546748" };

    Random r = new Random();
    public Cadete()
    {
        Id = r.Next(0, 1000);
        Nombre = nombresA[r.Next(0, 6)];
        Direccion = direccionA[r.Next(0, 5)];
        Telefono1 = TelefonoA[r.Next(0, 5)];
    }

    public int JornalACobrar()
    {
        return (ListadoEntregados.Count) * 300;
    }
}

class Cadeteria
{
    private List<Cadete> listadoCadetes = new List<Cadete>();
    private string nombre;
    private string telefono;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    string[]nombres={"Pedidos ya", "Rappi"};
    string[]telefonos={"54325465", "32423562"};
    Random r = new Random();

    public Cadeteria(List<Cadete>lista){
        Nombre=nombres[r.Next(0,2)];
        Telefono=telefonos[r.Next(0,2)];
        listadoCadetes=lista;
    }

}

class Pedido
{
    private int nro;
    private string obs;
    private string cliente;
    private int estado;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public int Estado { get => estado; set => estado = value; }
    public string Cliente { get => cliente; set => cliente = value; }
}