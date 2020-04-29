using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;

namespace Capa_Logica
{
    public class Logica
    {
        Sentencias sn = new Sentencias();
        /*-----------------------------------------------------------------------Metodos Generales------------------------------------------------------------*/
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }

        public OdbcDataReader Insertar(string[] datos)
        {
            return sn.Insertar(datos);
        }
        public OdbcDataReader Eliminar(string[] datos)
        {
            return sn.Eliminar(datos);
        }

        public OdbcDataReader Modificar(string[] datos, string[] campos)
        {
            return sn.Modificar(datos, campos);
        }

        public OdbcDataReader consultarPuesto()
        {
            return sn.consultaPuesto();
        }

        public OdbcDataReader consultarConcepto()
        {
            return sn.consultaConcepto();
        }

        public OdbcDataReader consultarDepartamento()
        {
            return sn.consultaDepartamento();
        }
    }
}
