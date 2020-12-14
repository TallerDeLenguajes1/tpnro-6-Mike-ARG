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
				C.Cliente = Convert.ToInt32(reader["idCliente"]);
				C.Cadete = Convert.ToInt32(reader["idCadete"]);
				C.Observacion = reader["observacion"].ToString();
				C.Estado = (CadeteriaMVC.Entidades.Estado)Convert.ToInt32(reader["estado"]);
				C.TipoPedido = (CadeteriaMVC.Entidades.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				C.CostoPedido = Convert.ToDouble(reader["costoPedido"]);
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
			string instruccion = "insert into pedidos(observacion, idCliente, estado, tipo, cupon, costoPedido) values (@Observacion, @IdCliente, @Estado, @Tipo, @Cupon, @CostoPedido);";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Observacion", C.Observacion);
			command.Parameters.AddWithValue("@IdCliente", C.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.Cadete.Id);
			command.Parameters.AddWithValue("@Estado", C.Estado);
			command.Parameters.AddWithValue("@Tipo", C.TipoPedido);
			command.Parameters.AddWithValue("@Cupon", C.TieneCupon);

			C.CostoPedido = 150;

			if (C.TieneCupon)
            {
				C.CostoPedido = C.CostoPedido - C.CostoPedido * 0.10; //Le descuenta un 10% al costo base del pedido si tiene cupón
            }

			switch (C.TipoPedido)
            {
				case Entidades.TipoPedido.Express:
					C.CostoPedido += C.CostoPedido * 0.25;
					break;
				case Entidades.TipoPedido.Delicado:
					C.CostoPedido += C.CostoPedido * 0.30;
					break;
				case Entidades.TipoPedido.Ecologico:
					break;
            }

			command.Parameters.AddWithValue("@CostoPedido", C.CostoPedido);

			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Update(CadeteriaMVC.Entidades.Pedido C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			
			var command = conection.CreateCommand();
			string instruccion = "update pedidos set observacion = @Observacion, idCliente = @IdCliente, estado = @Estado, tipo = @Tipo, cupon = @Cupon, costoPedido = @CostoPedido where idPedido = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@Id", C.Id);
			command.Parameters.AddWithValue("@Observacion", C.Observacion);
			command.Parameters.AddWithValue("@IdCliente", C.Id);
			//command.Parameters.AddWithValue("@IdCadete", C.Cadete.Id);
			command.Parameters.AddWithValue("@Estado", C.Estado);
			command.Parameters.AddWithValue("@Tipo", C.TipoPedido);
			command.Parameters.AddWithValue("@Cupon", C.TieneCupon);

			C.CostoPedido = 150;

			if (C.TieneCupon)
			{
				C.CostoPedido = C.CostoPedido - C.CostoPedido * 0.10; //Le descuenta un 10% al costo base del pedido si tiene cupón
			}

			switch (C.TipoPedido)
			{
				case Entidades.TipoPedido.Express:
					C.CostoPedido += C.CostoPedido * 0.25;
					break;
				case Entidades.TipoPedido.Delicado:
					C.CostoPedido += C.CostoPedido * 0.30;
					break;
				case Entidades.TipoPedido.Ecologico:
					break;
			}

			command.Parameters.AddWithValue("@CostoPedido", C.CostoPedido);

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
				C.Cliente = Convert.ToInt32(reader["idCliente"]);
				C.Cadete = Convert.ToInt32(reader["idCadete"]);
				C.Observacion = reader["observacion"].ToString();
				C.Estado = (CadeteriaMVC.Entidades.Estado)Convert.ToInt32(reader["estado"]);
				C.TipoPedido = (CadeteriaMVC.Entidades.TipoPedido)Convert.ToInt32(reader["tipo"]);
				C.TieneCupon = Convert.ToBoolean(reader["cupon"]);
				C.CostoPedido = Convert.ToDouble(reader["costoPedido"]);
			}

			conection.Close();
			return C;
		}
	}
}
