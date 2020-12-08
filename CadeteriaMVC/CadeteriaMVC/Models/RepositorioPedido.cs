using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace CadeteriaMVC.Models
{
	public class RepositorioPedido
	{
		public static Random random = new Random(Environment.TickCount);

		public List<CadeteriaMVC.Entidades.Pedido> GetAll()
		{
			List<CadeteriaMVC.Entidades.Pedido> ListaPedidos = new List<CadeteriaMVC.Entidades.Pedido>();

			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "select * from pedidos";
			command.CommandText = instruccion;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				CadeteriaMVC.Entidades.Pedido C = new CadeteriaMVC.Entidades.Pedido();

				C.Id = Convert.ToInt32(reader["idPedido"]);
				C.cliente.Id = Convert.ToInt32(reader["idCliente"]);
				//C = Convert.ToInt32(reader["idCadete"]);
				C.observacion = reader["observacion"].ToString();
				C.estado = (CadeteriaMVC.Entidades.Pedido.Estado)Convert.ToInt32(reader["estado"]);
				C.tipoPedido = (CadeteriaMVC.Entidades.Pedido.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				//C. = Convert.ToDouble(reader["aumento"]);
				ListaPedidos.Add(C);
			}

			conection.Close();
			return ListaPedidos;
		}

		public void Alta(CadeteriaMVC.Entidades.Pedido C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			//consigo el id del tipo que tiene el pedido
			/*var command = conection.CreateCommand();
			string instruccion = "select idTipo from tipopedidos where tipo LIKE @Tipo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Tipo", C.tipoPedido);

			int idTipo = 0;
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				idTipo = Convert.ToInt32(reader["idTipo"]);
			}

			//consigo el id del estado que tiene el pedido
			command = conection.CreateCommand();
			instruccion = "select idEstado from estados where estado LIKE @Estado";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Estado", C.estado);

			int idEstado = 0;
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				idEstado = Convert.ToInt32(reader["idEstado"]);
			}*/

			var command = conection.CreateCommand();
			string instruccion = "insert into pedidos(observacion, idCliente, estado, tipo, cupon) values (@Observacion, @IdCliente, @Estado, @Tipo, @Cupon);";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Observacion", C.observacion);
			command.Parameters.AddWithValue("@IdCliente", C.cliente.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.IdCadete);
			command.Parameters.AddWithValue("@Estado", C.estado);
			command.Parameters.AddWithValue("@Tipo", C.tipoPedido);
			command.Parameters.AddWithValue("@Cupon", C.TieneCupon);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Update(CadeteriaMVC.Entidades.Pedido C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			//consigo el id del tipo que tiene el pedido
			var command = conection.CreateCommand();
			string instruccion = "select idTipo from tipospedido where tipo LIKE @Tipo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Tipo", C.tipoPedido);

			int idTipo = 0;
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				idTipo = Convert.ToInt32(reader["idTipo"]);
			}

			//consigo el id del estado que tiene el pedido
			command = conection.CreateCommand();
			instruccion = "select idEstado from estados where estado LIKE @Estado";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Estado", C.estado);

			int idEstado = 0;
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				idEstado = Convert.ToInt32(reader["idEstado"]);
			}

			//update de la tabla
			command = conection.CreateCommand();
			instruccion = "update pedidos set observacion = @Observacion, idCliente = @IdCliente, idCadete = @IdCadete, idEstado = @Estado, idTipo = @Tipo, cupon = @Cupon where idPedido = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", C.Id);
			command.Parameters.AddWithValue("@Observacion", C.observacion);
			command.Parameters.AddWithValue("@IdCliente", C.cliente.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.);
			command.Parameters.AddWithValue("@Estado", idEstado);
			command.Parameters.AddWithValue("@Tipo", idTipo);
			command.Parameters.AddWithValue("@Cupon", C.TieneCupon);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Baja(int id)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "delete from pedidos where idPedido = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", id);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public CadeteriaMVC.Entidades.Pedido Buscar(int id)
		{
			CadeteriaMVC.Entidades.Pedido C = new CadeteriaMVC.Entidades.Pedido();

			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "select * from pedidos where idPedido = @Id";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", id);

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				C.Id = Convert.ToInt32(reader["idPedido"]);
				C.cliente.Id = Convert.ToInt32(reader["idCliente"]);
				//C.IdCadete = Convert.ToInt32(reader["idCadete"]);
				C.observacion = reader["observacion"].ToString();
				C.estado = (CadeteriaMVC.Entidades.Pedido.Estado)Convert.ToInt32(reader["estado"]);
				C.tipoPedido = (CadeteriaMVC.Entidades.Pedido.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				//C.Aumento = Convert.ToDouble(reader["aumento"]);
			}

			conection.Close();
			return C;
		}

		/*public CadeteriaMVC.Entidades.Pedido AsignarCadete(CadeteriaMVC.Entidades.Pedido P)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\cadeteria.db");
			var conection = new SQLiteConnection(path);
			conection.Open();
			//consigo el id del tipo que tiene el pedido
			var command = conection.CreateCommand();
			string instruccion = "select idTipo from tipospedido where tipo LIKE @Tipo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Tipo", P.Tipo);
			int idTipo = 0;
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				idTipo = Convert.ToInt32(reader["idTipo"]);
			}
			//agarro todos los cadetes que pueden llevar ese pedido
			command = conection.CreateCommand();
			instruccion = "select idCadete from cadetes where idVehiculo = @IdTipo";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@IdTipo", idTipo);
			List<int> CadetesDisponibles = new List<int>();
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				CadetesDisponibles.Add(Convert.ToInt32(reader["idCadete"]));
			}
			//asigno el cadete de forma aleatoria
			try
			{
				P.IdCadete = CadetesDisponibles[random.Next(CadetesDisponibles.Count)];
			}
			catch (Exception)
			{
				P.IdCadete = 0;
			}
			return P;
		}*/
	}
}
