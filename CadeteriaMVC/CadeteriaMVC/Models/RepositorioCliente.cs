using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using CadeteriaMVC.Entidades;

namespace CadeteriaMVC.Models
{
    public class RepositorioCliente
    {
        public List<CadeteriaMVC.Entidades.Cliente> GetAll()
        {
            List<CadeteriaMVC.Entidades.Cliente> ListaClientes = new List<CadeteriaMVC.Entidades.Cliente>();

            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "select * from clientes";
            command.CommandText = instruccion;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                CadeteriaMVC.Entidades.Cliente C = new CadeteriaMVC.Entidades.Cliente();

                C.Id = Convert.ToInt32(reader["idCliente"]);
                C.Nombre = reader["nombre"].ToString();
                C.Direccion = reader["direccion"].ToString();
                C.Telefono = (long)Convert.ToDouble(reader["telefono"]);
                ListaClientes.Add(C);
            }

            conection.Close();
            return ListaClientes;
        }

        public void Alta(CadeteriaMVC.Entidades.Cliente C)
        {
            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "insert into clientes(nombre, direccion, telefono) values (@nombre, @direccion, @telefono);";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", C.Id);
            command.Parameters.AddWithValue("@nombre", C.Nombre);
            command.Parameters.AddWithValue("@direccion", C.Direccion);
            command.Parameters.AddWithValue("@telefono", C.Telefono);
            command.ExecuteNonQuery();

            conection.Close();
        }

        public void Update(Cliente C)
        {
            try
            {
                string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
                var conection = new SQLiteConnection(path);
                conection.Open();

                var command = conection.CreateCommand();
                command.CommandText = "update clientes SET nombre = @nombre, direccion = @direccion, telefono = @telefono where idCliente = @id;";
                command.Parameters.AddWithValue("@id", C.Id);
                command.Parameters.AddWithValue("@nombre", C.Nombre);
                command.Parameters.AddWithValue("@direccion", C.Direccion);
                command.Parameters.AddWithValue("@telefono", C.Telefono);
                command.ExecuteNonQuery();

                conection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void Baja(int id)
        {
            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "delete from clientes where idCliente = @idCliente;";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@idCliente", id);
            command.ExecuteNonQuery();

            conection.Close();
        }

        public CadeteriaMVC.Entidades.Cliente Buscar(int id)
        {
            CadeteriaMVC.Entidades.Cliente C = new CadeteriaMVC.Entidades.Cliente("", "", 1234);

            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "select * from clientes where idCliente = @id";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                C.Id = Convert.ToInt32(reader["idCliente"]);
                C.Nombre = reader["nombre"].ToString();
                C.Direccion = reader["direccion"].ToString();
                C.Telefono = (long)Convert.ToDouble(reader["telefono"]);
            }

            conection.Close();
            return C;
        }

        public List<Pedido> PedidosCliente(int id)
        {
            List<Pedido> ListaPed = new List<Pedido>();
            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "SELECT idPedido, idCliente, idCadete, observacion, cupon, estado, tipo, costoPedido FROM pedidos " +
                                 "INNER JOIN (clientes) USING (idCliente) where idCliente = @id";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pedido P = new Pedido();
                P.Id = Convert.ToInt32(reader["idPedido"]);
                P.Cliente = Convert.ToInt32(reader["idCliente"]);
                P.Cadete = Convert.ToInt32(reader["idCadete"]);
                P.Observacion = reader["observacion"].ToString();
                P.TieneCupon = Convert.ToBoolean(reader["cupon"]);
                P.Estado = (Estado)reader["estado"];
                P.TipoPedido = (TipoPedido)reader["tipo"];
                P.CostoPedido = Convert.ToDouble(reader["costoPedido"]);

                ListaPed.Add(P);
            }

            conection.Close();
            return ListaPed;
        }
    }
}
