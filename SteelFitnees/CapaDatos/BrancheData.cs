﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
namespace CapaDatos
{
    public class BrancheData
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private string cadCon;
        public BrancheData()
        {
            cadCon = ConfigurationManager.ConnectionStrings["steelFitness"].ConnectionString;
            Conexion = new SqlConnection(cadCon);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }
        public int add(Branche branche)
        {
            int idRecuperado = 0;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_proAddBranches";
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar,50));
                Comando.Parameters["@nombre"].Value = branche.nombre;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text));
                Comando.Parameters["@descripcion"].Value = branche.descripcion;
                Comando.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.Text));
                Comando.Parameters["@ubicacion"].Value = branche.ubicacion;
                Conexion.Open();
                idRecuperado = (int)Comando.ExecuteScalar();
            }
            catch (SqlException e)
            {                
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return idRecuperado;

        }
        public bool update(Branche branche)
        {
            bool ban;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_updateBranche";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = branche.idSucursal;
                Comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50));
                Comando.Parameters["@nombre"].Value = branche.nombre;
                Comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text));
                Comando.Parameters["@descripcion"].Value = branche.descripcion;
                Comando.Parameters.Add(new SqlParameter("@ubicacion", SqlDbType.Text));
                Comando.Parameters["@ubicacion"].Value = branche.ubicacion;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {

                ban = false;
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return ban;

        }
        public List<Branche> listBranches()
        {
            List<Branche> branches = new List<Branche>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_listBranches";
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    branches.Add(new Branche(renglon));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();

            }
            return branches;
        }
        public DataTable tableBranches()
        {
            DataTable schedules = new DataTable();
            SqlDataReader renglon;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_tableBranches";
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                schedules.Load(renglon);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return schedules;
        }
        public List<Image> dataImageByFkSucursal(int idSucursal)
        {
            List<Image> images = new List<Image>();
            try
            {
                SqlDataReader renglon;
                Conexion.Open();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_dataImageByFkSucursal";
                Comando.Parameters.Add(new SqlParameter("@idSucursal",SqlDbType.Int));
                Comando.Parameters["@idSucursal"].Value = idSucursal;
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    images.Add(new Image(renglon));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();

            }
            return images;
        }

        public bool delete(string strIds)
        {
            bool ban;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = "pro_deleteBranches";
            try
            {
                Comando.Parameters.Add(new SqlParameter("@ids", SqlDbType.VarChar));
                Comando.Parameters["@ids"].Value = strIds;
                Conexion.Open();
                Comando.ExecuteNonQuery();
                ban = true;
            }
            catch (SqlException e)
            {
                ban = false;
                throw new Exception(e.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return ban;
        }
        public Branche dataBrancheByIdBranche(int idBranche)
        {
            SqlDataReader renglon;
            Branche branche = null;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = "pro_dataBrancheByIdBranche";
                Comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                Comando.Parameters["@id"].Value = idBranche;
                Conexion.Open();
                renglon = Comando.ExecuteReader();
                while (renglon.Read())
                {
                    branche = new Branche(renglon);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                Comando.Parameters.Clear();
            }
            return branche;
        }

    }
}
