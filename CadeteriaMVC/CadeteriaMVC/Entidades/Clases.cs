using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaMVC.Entidades
{
    public enum Vehiculo
    {
        Bicicleta,
        Auto,
        Moto
    }

    public enum Estado
    {
        Entregado = 0,
        Entregando = 1, //Cuando se está llevando un pedido
        Preparando = 2,
        NoDisponible = 3,
    }
    public enum TipoPedido
    {
        Ecologico,
        Delicado,
        Express
    }

    public abstract class Persona
    {
        private string nombre;
        private string direccion;
        private long telefono;
        private List<Pedido> listaPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Persona(string nombre, string direccion, long telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.ListaPedidos = new List<Pedido>();
        }
        public Persona()
        {
            this.Nombre = "";
            this.Direccion = "";
            //this.telefono;
            ListaPedidos = new List<Pedido>();
        }

        //public abstract int ContarPedidos();
    }

    public class Cliente : Persona
    {
        private int id;

        public int Id { get => id; set => id = value; }

        public Cliente(string nombre, string direccion, long telefono) : base(nombre, direccion, telefono)
        {
        }

        public Cliente()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Direccion = "";
            this.Telefono = 1234;
        }

        /*public override int ContarPedidos()
        {
            return this.listaPedidos.Count;
        }

        public void Pedir(Pedido ped)
        {
            this.listaPedidos.Add(ped);
        }*/
    }

    public class Pedido
    {
        //public int contador;
        private int id;
        private string observacion;
        private int cliente;
        private int cadete;
        private Estado estado;
        private TipoPedido tipoPedido;
        private bool tieneCupon;
        private double costoPedido;

        public int Id { get => id; set => id = value; }
        public bool TieneCupon { get => tieneCupon; set => tieneCupon = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Cliente { get => cliente; set => cliente = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public TipoPedido TipoPedido { get => tipoPedido; set => tipoPedido = value; }
        public double CostoPedido { get => costoPedido; set => costoPedido = value; }
        public int Cadete { get => cadete; set => cadete = value; }

        public Pedido(string obs, int client, int cad, Estado est, TipoPedido tipoPedido, bool tieneCupon)
        {
            //this.Id = contador;
            //contador++;
            this.Observacion = obs;
            this.Cliente = client;
            this.Cadete = cad;
            Estado = est;
            this.TipoPedido = tipoPedido;
            this.TieneCupon = tieneCupon;
            this.CostoPedido = 0;
        }

        public Pedido()
        {
            //this.Id = contador;
            //contador++;
            this.Observacion = "";
            Estado = Estado.NoDisponible;
            this.TipoPedido = TipoPedido.Express;
            this.TieneCupon = false;
            this.CostoPedido = 0;
        }

        /*public enum Estado
        {
            Entregado = 0,
            Entregando = 1, //Cuando se está llevando un pedido
            Preparando = 2,
            NoDisponible = 3,
        }
        public enum TipoPedido
        {
            Express,
            Delicado,
            Ecologico,
        }
        public void CambiarEstado(int num)
        {
            switch (num)
            {
                case 0:
                    this.Estado1 = Estado.Entregado;
                    break;
                case 1:
                    this.Estado1 = Estado.Entregando;
                    break;
                case 2:
                    this.Estado1 = Estado.Preparando;
                    break;
                case 3:
                    this.Estado1 = Estado.NoDisponible;
                    break;
                default:
                    break;
            }
        }
        public double CostoPedido()
        {
            double costoBase = 150;

            switch (this.TipoPedido1)
            {
                case TipoPedido.Express:
                    costoBase += costoBase * 0.25;
                    break;
                case TipoPedido.Delicado:
                    costoBase += costoBase * 0.30;
                    break;
                default:
                    break;
            }

            if (this.TieneCupon == true)
            {
                costoBase -= costoBase * 0.10;
            }
            return costoBase;
        }
        public void MostrarPedido()
        {
            Console.WriteLine("ID del pedido: " + this.Id);
            Console.WriteLine("Observación: " + this.Observacion);
            Console.WriteLine("Nombre del cliente: " + this.Cliente.Nombre);
            Console.WriteLine("Tipo de pedido: " + this.TipoPedido1.ToString());
            Console.WriteLine("¿Cupón?: " + this.TieneCupon.ToString());
            Console.WriteLine("Costo del pedido: " + this.CostoPedido());
            Console.WriteLine("Estado: " + this.Estado1.ToString());
            Console.WriteLine("");
        }*/
    }


    public class Cadete : Persona
    {
        private int id;
        private Vehiculo tipoVehiculo;
        private double jornal;
        public int Id { get => id; set => id = value; }
        public Vehiculo TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
        public double Jornal { get => jornal; set => jornal = value; }

        public Cadete() : base()
        {
            this.TipoVehiculo = Vehiculo.Moto;
        }
        public Cadete(string nombre, string direccion, long telefono, Vehiculo tipoVehiculo) : base(nombre, direccion, telefono)
        {
            this.TipoVehiculo = tipoVehiculo;
        }

        /*public void AsignarPedido(Pedido ped)
        {
            switch (ped.TipoPedido1)
            {
                case Pedido.TipoPedido.Express:
                    if (this.TipoVehiculo == Vehiculo.Moto)
                    {
                        //TipoVehiculo = Vehiculo.;
                        ped.CostoPedido1 += ped.CostoPedido1 * 0.20;
                        this.listaPedidos.Add(ped);
                    }
                    break;
                case Pedido.TipoPedido.Delicado:
                    if (this.TipoVehiculo == Vehiculo.Auto)
                    {
                        //vehiculo = "Auto";
                        ped.CostoPedido1 += ped.CostoPedido1 * 0.25;
                        this.listaPedidos.Add(ped);
                    }
                    break;
                case Pedido.TipoPedido.Ecologico:
                    if (this.TipoVehiculo == Vehiculo.Bicicleta)
                    {
                        //vehiculo = "Bicicleta";
                        ped.CostoPedido1 += ped.CostoPedido1 * 0.05;
                        this.listaPedidos.Add(ped);
                    }
                    break;
                default:
                    break;
            }
        }

        public void ReasignarPedido(Pedido ped, Cadete cad)
        {
            cad.listaPedidos.Add(ped);
            this.listaPedidos.Remove(ped);
        }

        public int CantidadEntregados()
        {
            int pedidosEntregados = 0;

            foreach (Pedido pedido in ListaPedidos)
            {
                if (pedido.Estado1 == Pedido.Estado.Entregado)
                {
                    pedidosEntregados++;
                }
            }
            return pedidosEntregados;
        }

        public double CalcularJornal()
        {
            return CantidadEntregados() * 100;
        }

        public int ID()
        {
            return Id;
        }

        public void MostrarDatos()
        {
            Console.WriteLine("ID del cadete: " + ID());
            Console.WriteLine("Nombre del cadete: " + this.Nombre);
            //Console.WriteLine("Tipo de vehículo: " + this.vehiculo);
            Console.WriteLine("Cantidad de pedidos entregados: " + this.CantidadEntregados());
            Console.WriteLine("Jornal a cobrar: " + this.CalcularJornal());
            Console.WriteLine("");
        }

        public override int ContarPedidos()
        {
            return this.listaPedidos.Count;
        }

        public enum Vehiculo
        {
            Bicicleta,
            Auto,
            Moto
        }

        public List<Vehiculo> GetVehiculos()
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            listaVehiculos.Add(Vehiculo.Auto);
            listaVehiculos.Add(Vehiculo.Bicicleta);
            listaVehiculos.Add(Vehiculo.Moto);

            return listaVehiculos;
        }
    }*/

        public class Cadeteria
        {
            public string nombre;
            public List<Cadete> listadoCadetes;


            public Cadeteria(string nombre)
            {
                this.nombre = nombre;
                listadoCadetes = new List<Cadete>();
            }

            /*public void InformeEntregas()
            {
                foreach (Cadete cadete in listadoCadetes)
                {

                    cadete.MostrarDatos();
                    /*Console.WriteLine("Nombre del cadete: " + cadete.nombre);
                    Console.WriteLine("Cantidad de pedidos entregados: " + cadete.CantidadEntregados());
                    Console.WriteLine("Jornal a cobrar: $" + cadete.CalcularJornal());
                    Console.WriteLine("");
                }
            }

            public Cadete InformeEntregados()
            {
                int pedidosEntregados = 0;
                Cadete retorno = new Cadete();
                foreach (Cadete cadete in listadoCadetes)
                {
                    if (cadete.CantidadEntregados() > pedidosEntregados)
                    {
                        pedidosEntregados = cadete.CantidadEntregados();
                        retorno = cadete;
                    }
                }
                return retorno;
            }
            public int InformePromedio()
            {
                int pedidosEntregados = 0;
                foreach (Cadete cadete in listadoCadetes)
                {
                    pedidosEntregados = pedidosEntregados + cadete.CantidadEntregados();
                }
                return pedidosEntregados / listadoCadetes.Count;
            }*/
        }

        /*public static class Helper
        {
            static Random rand = new Random();
            public static string[] nombres = { "Miguel", "Pablo", "José", "Pedro", "Macarena", "Sofía", "Carlos", "Florencia" };
            public static string[] apellidos = { "Rodriguez", "Cardozo", "Colombres", "Giménez", "Díaz", "Fernández", "López", "Vanetta" };
            public static string[] observaciones = { "Con condimentos", "Sin sal", "Con sal extra", "Sin condimentos", "Con Picante", "Sin Picante" };

            public static string NombreAleatorio()
            {
                return nombres[rand.Next(nombres.Length)] + " " + apellidos[rand.Next(apellidos.Length)];
            }

            /*public static List<Pedido> GenerarPedidos(int numPedidos)
            {
                List<Pedido> listaPedidos = new List<Pedido>();
                Random rand = new Random();
                try
                {
                    while (numPedidos > 0)
                    {
                        Cliente client = new Cliente(NombreAleatorio(), "Calle Al Azar " + rand.Next(99999).ToString(), rand.Next(987654321));
                        Pedido ped = new Pedido(observaciones[rand.Next(observaciones.Length)], client, Pedido.Estado.Preparando, (Pedido.TipoPedido)rand.Next(Enum.GetNames(typeof(Pedido.TipoPedido)).Length), Convert.ToBoolean(rand.Next(2)));
                        listaPedidos.Add(ped);
                        client.Pedir(ped);
                        numPedidos = numPedidos - 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al generar pedidos: " + ex.Message);
                }
                return listaPedidos;
            }

            public static List<Cadete> GenerarCadetes(int numCadetes, Cadeteria cadeteria)
            {
                List<Cadete> listaCadetes = new List<Cadete>();

                try
                {
                    while (numCadetes > 0)
                    {
                        Cadete cad = new Cadete(NombreAleatorio(), "Calle Al Azar 456", 123456, (Cadete.Vehiculo)rand.Next(Enum.GetNames(typeof(Cadete.Vehiculo)).Length));
                        cadeteria.listadoCadetes.Add(cad);
                        numCadetes = numCadetes - 1;
                    }
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Error al generar cadetes: " + ex2.Message);
                }

                return listaCadetes;
            }
        }*/
    }
}
