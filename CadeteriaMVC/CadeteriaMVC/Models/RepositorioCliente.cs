using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace CadeteriaMVC.Models
{
    public class RepositorioCliente
    {
        public List<CadeteriaMVC.Entidades.Cliente> GetAll()
        {
            List<CadeteriaMVC.Entidades.Cliente> ListaClientes = new List<CadeteriaMVC.Entidades.Cliente>();

            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\cadeteria.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "select * from clientes";
            command.CommandText = instruccion;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                CadeteriaMVC.Entidades.Cliente C = new CadeteriaMVC.Entidades.Cliente("","",1234);

                C.id = Convert.ToInt32(reader["idCliente"]);
                C.nombre = reader["nombre"].ToString();
                C.direccion = reader["direccion"].ToString();
                C.telefono = (long)Convert.ToDouble(reader["telefono"]);
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
            command.Parameters.AddWithValue("@nombre", C.nombre);
            command.Parameters.AddWithValue("@direccion", C.direccion);
            command.Parameters.AddWithValue("@telefono", C.telefono);
            command.ExecuteNonQuery();

            conection.Close();
        }

        public void Update(CadeteriaMVC.Entidades.Cliente C)
        {
            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "update clientes SET nombre = @nombre, direccion = @direccion, telefono = @telefono where idCliente = @id;";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", C.id);
            command.Parameters.AddWithValue("@nombre", C.nombre);
            command.Parameters.AddWithValue("@direccion", C.direccion);
            command.Parameters.AddWithValue("@telefono", C.telefono);
            command.ExecuteNonQuery();

            conection.Close();
        }

        public void Baja(int id)
        {
            string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conection = new SQLiteConnection(path);
            conection.Open();

            var command = conection.CreateCommand();
            string instruccion = "delete from clientes where idCliente = @id;";
            command.CommandText = instruccion;
            command.Parameters.AddWithValue("@id", id);
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
                C.id = Convert.ToInt32(reader["idCliente"]);
                C.nombre = reader["nombre"].ToString();
                C.direccion = reader["direccion"].ToString();
                C.telefono = (long)Convert.ToDouble(reader["telefono"]);
            }

            conection.Close();
            return C;
        }

    }
}
