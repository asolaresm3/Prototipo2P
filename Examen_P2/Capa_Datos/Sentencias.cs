﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
   public class Sentencias
    {
        Conexion cn = new Conexion();
        OdbcCommand comm;
        //--------------------------------------------------------------------Metodo General--------------------------------------------------------------------//
        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT MAX(" + campo + "+1) FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                OdbcCommand command = new OdbcCommand(sql, cn.conexionbd());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();
                //Console.WriteLine("El resultado es: " + camporesultante);
                if (String.IsNullOrEmpty(camporesultante))
                    camporesultante = "1";
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            return camporesultante;
        }

        public OdbcDataReader Insertar(string[] datos)
        {
            string query = "";
            for (int i = 1; i < datos.Length; i++)
            {
                query += "'";
                query += datos[i];
                if (i == datos.Length - 1)
                    query += "'";
                else
                    query += "',";
            }
            try
            {
                cn.conexionbd();
                string consulta = "insert into " + datos[0] + " values(" + query + ");";
                Console.WriteLine(consulta);
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public OdbcDataReader Eliminar(string[] datos)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE " + datos[0] + " set estado='0' where " + datos[2] + " = '" + datos[1] + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public OdbcDataReader Modificar(string[] datos, string[] campos)
        {
            string query = "";
            int n = 1;
            query += " set ";
            for (int i = 2; i < datos.Length; i++)
            {
                query += campos[n];
                query += " = '";
                query += datos[i];
                if (i == datos.Length - 1)
                    query += "'";
                else
                    query += "',";
                n++;
            }

            try
            {
                cn.conexionbd();
                string consulta = "UPDATE " + datos[0] + query + " where " + campos[0] + " = '" + datos[1] + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public OdbcDataReader consultaPuesto()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM puesto WHERE estado = 1 ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        public OdbcDataReader consultaConcepto()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM concepto WHERE estado = 1 ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        public OdbcDataReader consultaDepartamento()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM departamento WHERE estado = 1 ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }
    }
}
