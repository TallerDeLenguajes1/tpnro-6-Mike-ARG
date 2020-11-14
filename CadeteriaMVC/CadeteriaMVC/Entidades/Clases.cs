﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaMVC.Entidades
{
    public abstract class Persona
    {
        public static int contador = 1;
        public int id;
        public string nombre;
        public string direccion;
        public long telefono;
        public List<Pedido> listaPedidos;

        public Persona(string nombre, string direccion, long telefono)
        {
            id = contador;
            contador++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listaPedidos = new List<Pedido>();
        }
        public Persona()
        {
            this.id = contador;
            contador++;
            this.nombre = "";
            this.direccion = "";
            this.telefono = -1;
            listaPedidos = new List<Pedido>();
        }

        public abstract int ContarPedidos();
    }

    public class Cliente : Persona
    {
        public Cliente(string nombre, string direccion, long telefono) : base(nombre, direccion, telefono)
        {

        }

        public override int ContarPedidos()
        {
            return this.listaPedidos.Count;
        }

        public void Pedir(Pedido ped)
        {
            this.listaPedidos.Add(ped);
        }
    }

    public class Pedido
    {
        public static int contador = 0;
        public int id;
        public string observacion;
        public Cliente cliente;
        public Estado estado;
        public TipoPedido tipoPedido;
        public bool tieneCupon;
        public double costoPedido;

        public Pedido(string obs, Cliente client, Estado est, TipoPedido tipoPedido, bool tieneCupon)
        {
            this.id = contador;
            contador++;
            this.observacion = obs;
            this.cliente = client;
            estado = est;
            this.tipoPedido = tipoPedido;
            this.tieneCupon = tieneCupon;
            this.costoPedido = CostoPedido();
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
            Express,
            Delicado,
            Ecologico,
        }
        public void CambiarEstado(int num)
        {
            switch (num)
            {
                case 0:
                    this.estado = Estado.Entregado;
                    break;
                case 1:
                    this.estado = Estado.Entregando;
                    break;
                case 2:
                    this.estado = Estado.Preparando;
                    break;
                case 3:
                    this.estado = Estado.NoDisponible;
                    break;
                default:
                    break;
            }
        }
        public double CostoPedido()
        {
            double costoBase = 150;

            switch (this.tipoPedido)
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

            if (this.tieneCupon == true)
            {
                costoBase -= costoBase * 0.10;
            }
            return costoBase;
        }
        public void MostrarPedido()
        {
            Console.WriteLine("ID del pedido: " + this.id);
            Console.WriteLine("Observación: " + this.observacion);
            Console.WriteLine("Nombre del cliente: " + this.cliente.nombre);
            Console.WriteLine("Tipo de pedido: " + this.tipoPedido.ToString());
            Console.WriteLine("¿Cupón?: " + this.tieneCupon.ToString());
            Console.WriteLine("Costo del pedido: " + this.CostoPedido());
            Console.WriteLine("Estado: " + this.estado.ToString());
            Console.WriteLine("");
        }
    }


    public class Cadete : Persona
    {

        public Vehiculo TipoVehiculo { get; set; }

        public Cadete() : base()
        {
            this.TipoVehiculo = Vehiculo.Moto;
        }
        public Cadete(string nombre, string direccion, long telefono, Vehiculo tipoVehiculo) : base(nombre, direccion, telefono)
        {
            this.TipoVehiculo = tipoVehiculo;
        }

        public void AsignarPedido(Pedido ped)
        {
            switch (ped.tipoPedido)
            {
                case Pedido.TipoPedido.Express:
                    if (this.TipoVehiculo == Vehiculo.Moto)
                    {
                        ped.costoPedido += ped.costoPedido * 0.20;
                        this.listaPedidos.Add(ped);
                    }
                    break;
                case Pedido.TipoPedido.Delicado:
                    if (this.TipoVehiculo == Vehiculo.Auto)
                    {
                        ped.costoPedido += ped.costoPedido * 0.25;
                        this.listaPedidos.Add(ped);
                    }
                    break;
                case Pedido.TipoPedido.Ecologico:
                    if (this.TipoVehiculo == Vehiculo.Bicicleta)
                    {
                        ped.costoPedido += ped.costoPedido * 0.05;
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

            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.estado == Pedido.Estado.Entregado)
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
            return id;
        }

        public void MostrarDatos()
        {
            Console.WriteLine("ID del cadete: " + ID());
            Console.WriteLine("Nombre del cadete: " + this.nombre);
            Console.WriteLine("Tipo de vehículo: " + this.TipoVehiculo);
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
    }

    public class Cadeteria
    {
        public string nombre;
        public List<Cadete> listadoCadetes;


        public Cadeteria(string nombre)
        {
            this.nombre = nombre;
            listadoCadetes = new List<Cadete>();
        }

        public void InformeEntregas()
        {
            foreach (Cadete cadete in listadoCadetes)
            {

                cadete.MostrarDatos();
                /*Console.WriteLine("Nombre del cadete: " + cadete.nombre);
                Console.WriteLine("Cantidad de pedidos entregados: " + cadete.CantidadEntregados());
                Console.WriteLine("Jornal a cobrar: $" + cadete.CalcularJornal());
                Console.WriteLine("");*/
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
        }
    }

    public static class Helper
    {
        static Random rand = new Random();
        public static string[] nombres = { "Miguel", "Pablo", "José", "Pedro", "Macarena", "Sofía", "Carlos", "Florencia" };
        public static string[] apellidos = { "Rodriguez", "Cardozo", "Colombres", "Giménez", "Díaz", "Fernández", "López", "Vanetta" };
        public static string[] observaciones = { "Con condimentos", "Sin sal", "Con sal extra", "Sin condimentos", "Con Picante", "Sin Picante" };

        public static string NombreAleatorio()
        {
            return nombres[rand.Next(nombres.Length)] + " " + apellidos[rand.Next(apellidos.Length)];
        }

        public static List<Pedido> GenerarPedidos(int numPedidos)
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
    }
}
