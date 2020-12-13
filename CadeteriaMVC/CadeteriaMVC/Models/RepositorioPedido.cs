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
				C.Cliente.Id = Convert.ToInt32(reader["idCliente"]);
				//C.Cadete.Id = Convert.ToInt32(reader["idCadete"]);
				C.Observacion = reader["observacion"].ToString();
				C.Estado1 = (CadeteriaMVC.Entidades.Pedido.Estado)Convert.ToInt32(reader["estado"]);
				C.TipoPedido1 = (CadeteriaMVC.Entidades.Pedido.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				//C.CostoPedido1 = Convert.ToDouble(reader["costoPedido"]);
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

			var command = conection.CreateCommand();
			string instruccion = "insert into pedidos(observacion, idCliente, estado, tipo, cupon) values (@Observacion, @IdCliente, @Estado, @Tipo, @Cupon);";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Observacion", C.Observacion);
			command.Parameters.AddWithValue("@IdCliente", C.Cliente.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.Cadete.Id);
			command.Parameters.AddWithValue("@Estado", C.Estado1);
			command.Parameters.AddWithValue("@Tipo", C.TipoPedido1);
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
			/*var command = conection.CreateCommand();
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
			*/
			//update de la tabla
			var command = conection.CreateCommand();
			string instruccion = "update pedidos set observacion = @Observacion, idCliente = @IdCliente, estado = @Estado, tipo = @Tipo, cupon = @Cupon where idPedido = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", C.Id);
			command.Parameters.AddWithValue("@Observacion", C.Observacion);
			command.Parameters.AddWithValue("@IdCliente", C.Cliente.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.Cadete.Id);
			command.Parameters.AddWithValue("@Estado", C.Estado1);
			command.Parameters.AddWithValue("@Tipo", C.TipoPedido1);
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
				C.Cliente.Id = Convert.ToInt32(reader["idCliente"]);
				//C.IdCadete = Convert.ToInt32(reader["idCadete"]);
				C.Observacion = reader["observacion"].ToString();
				C.Estado1 = (CadeteriaMVC.Entidades.Pedido.Estado)Convert.ToInt32(reader["estado"]);
				C.TipoPedido1 = (CadeteriaMVC.Entidades.Pedido.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				//C.Aumento = Convert.ToDouble(reader["aumento"]);
			}

			conection.Close();
			return C;
		}
	}
}
