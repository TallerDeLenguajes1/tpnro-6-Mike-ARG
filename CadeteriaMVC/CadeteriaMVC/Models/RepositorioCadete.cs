using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace CadeteriaMVC.Models
{
    public class RepositorioCadete
    {
		public List<CadeteriaMVC.Entidades.Cadete> GetAll()
		{
			List<CadeteriaMVC.Entidades.Cadete> ListaCadetes = new List<CadeteriaMVC.Entidades.Cadete>();

			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "select * from cadetes inner join vehiculos using(idVehiculo)";
			command.CommandText = instruccion;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				CadeteriaMVC.Entidades.Cadete C = new CadeteriaMVC.Entidades.Cadete();

				C.id = Convert.ToInt32(reader["idCadete"]);
				C.nombre = reader["nombre"].ToString();
				C.direccion = reader["direccion"].ToString();
				C.telefono = (long)reader["telefono"];
				C.vehiculo = reader["vehiculo"].ToString();
				ListaCadetes.Add(C);
			}

			conection.Close();
			return ListaCadetes;
		}

		public void Alta(CadeteriaMVC.Entidades.Cadete C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			//busco el id del vehiculo para insertarlo en la tabla
			var command = conection.CreateCommand();
			string instruccion = "select idVehiculo from vehiculos where vehiculo LIKE @vehiculo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@vehiculo", C.TipoVehiculo);

			int idVehiculo = 0;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				idVehiculo = Convert.ToInt32(reader["idVehiculo"]);
			}

			//ahora si inserto el cadete
			command = conection.CreateCommand();
			instruccion = "insert into cadetes(nombre, direccion, telefono, idVehiculo) values (@Nombre, @Direccion, @Telefono, @IdVehiculo);";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@nombre", C.nombre);
			command.Parameters.AddWithValue("@direccion", C.direccion);
			command.Parameters.AddWithValue("@telefono", C.telefono);
			command.Parameters.AddWithValue("@idVehiculo", idVehiculo);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Update(CadeteriaMVC.Entidades.Cadete C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			//busco el id del vehiculo para insertarlo en la tabla
			var command = conection.CreateCommand();
			string instruccion = "select idVehiculo from vehiculos where vehiculo LIKE @Vehiculo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@vehiculo", C.TipoVehiculo);

			int idVehiculo = 0;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				idVehiculo = Convert.ToInt32(reader["idVehiculo"]);
			}

			//ahora si inserto el cadete
			command = conection.CreateCommand();
			instruccion = "update cadetes SET nombre = @Nombre, direccion = @Direccion, telefono = @Telefono, idVehiculo = @IdVehiculo where idCadete = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@id", C.id);
			command.Parameters.AddWithValue("@nombre", C.nombre);
			command.Parameters.AddWithValue("@direccion", C.direccion);
			command.Parameters.AddWithValue("@telefono", C.telefono);
			command.Parameters.AddWithValue("@idVehiculo", idVehiculo);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Baja(int id)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "delete from cadetes where idCadete = @id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@id", id);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public CadeteriaMVC.Entidades.Cadete Buscar(int id)
		{
			CadeteriaMVC.Entidades.Cadete C = new CadeteriaMVC.Entidades.Cadete();

			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "select * from cadetes inner join vehiculos using(idVehiculo) where idCadete = @id";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@id", id);

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				C.id = Convert.ToInt32(reader["idCadete"]);
				C.nombre = reader["nombre"].ToString();
				C.direccion = reader["direccion"].ToString();
				C.telefono = (long)reader["telefono"];
				C.vehiculo = reader["vehiculo"].ToString();
				//C.RecargaV = Convert.ToDouble(reader["aumento"]);
			}

			conection.Close();
			return C;
		}

		public List<Pedido> GetPedidos(Cadete C)
		{
			List<Pedido> ListaPedidos = new List<Pedido>();

			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\cadeteria.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "select * from pedidos inner join estados using(idEstado) inner join tipospedido using(idTipo) where idCadete = @Id";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", C.Id);

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				CadeteriaMVC.Entidades.Pedido P = new CadeteriaMVC.Entidades.Pedido();

				P.Id = Convert.ToInt32(reader["idPedido"]);
				P.IdCliente = Convert.ToInt32(reader["idCliente"]);
				P.IdCadete = Convert.ToInt32(reader["idCadete"]);
				P.Observacion = reader["observacion"].ToString();
				P.Estado = reader["estado"].ToString();
				P.Tipo = reader["tipo"].ToString();
				P.Cupon = Convert.ToBoolean(reader["cupon"]);
				P.Aumento = Convert.ToDouble(reader["aumento"]);
				ListaPedidos.Add(P);
			}

			conection.Close();
			return ListaPedidos;
		}
	}
}
