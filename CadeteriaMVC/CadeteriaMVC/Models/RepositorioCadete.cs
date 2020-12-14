﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using CadeteriaMVC.Entidades;
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
			string instruccion = "select * from cadetes";
			command.CommandText = instruccion;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				CadeteriaMVC.Entidades.Cadete C = new CadeteriaMVC.Entidades.Cadete();

				C.Id = Convert.ToInt32(reader["idCadete"]);
				C.Nombre = reader["nombre"].ToString();
				C.Direccion = reader["direccion"].ToString();
				C.Telefono = (long)Convert.ToDouble(reader["telefono"]);
				C.TipoVehiculo = (Vehiculo)Convert.ToInt32(reader["vehiculo"]);
				ListaCadetes.Add(C);
			}

			conection.Close();
			return ListaCadetes;
		}

		public void Alta(Cadete C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();


			var command = conection.CreateCommand();
			string instruccion = "insert into cadetes(nombre, direccion, telefono, vehiculo) values (@Nombre, @Direccion, @Telefono, @vehiculo);";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@nombre", C.Nombre);
			command.Parameters.AddWithValue("@direccion", C.Direccion);
			command.Parameters.AddWithValue("@telefono", C.Telefono);
			command.Parameters.AddWithValue("@vehiculo", C.TipoVehiculo);
			command.ExecuteNonQuery();

			conection.Close();
		}

		public void Update(CadeteriaMVC.Entidades.Cadete C)
		{
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();


			var command = conection.CreateCommand();
			string instruccion = "update cadetes SET nombre = @Nombre, direccion = @Direccion, telefono = @Telefono, vehiculo = @vehiculo where idCadete = @Id;";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@id", C.Id);
			command.Parameters.AddWithValue("@nombre", C.Nombre);
			command.Parameters.AddWithValue("@direccion", C.Direccion);
			command.Parameters.AddWithValue("@telefono", C.Telefono);
			command.Parameters.AddWithValue("@vehiculo", C.TipoVehiculo);
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
			string instruccion = "select * from cadetes where idCadete = @id";
			command.CommandText = instruccion;
			command.Parameters.AddWithValue("@id", id);

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				C.Id = Convert.ToInt32(reader["idCadete"]);
				C.Nombre = reader["nombre"].ToString();
				C.Direccion = reader["direccion"].ToString();
				C.Telefono = (long)Convert.ToDouble(reader["telefono"]);
				C.TipoVehiculo = (Vehiculo)Convert.ToInt32(reader["vehiculo"]);
				//C.RecargaV = Convert.ToDouble(reader["aumento"]);
			}

			conection.Close();
			return C;
		}

		public List<Pedido> PedidosCadete(int id)
		{
			List<Pedido> ListaPed = new List<Pedido>();
			string path = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
			var conection = new SQLiteConnection(path);
			conection.Open();

			var command = conection.CreateCommand();
			string instruccion = "SELECT idPedido, idCliente, idCadete, observacion, cupon, estado, tipo, costoPedido FROM pedidos " +
								 "INNER JOIN (cadetes) USING (idCadete) where idCadete = @id";
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
