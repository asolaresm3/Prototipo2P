﻿using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño.Consultas
{
    public partial class Frm_Consult_Concepto : Form
    {
        Logica logic = new Logica();
        public Frm_Consult_Concepto()
        {
            InitializeComponent();
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        public void MostrarConsulta()
        {
            OdbcDataReader mostrar = logic.consultarConcepto();
            try
            {
                while (mostrar.Read())
                {
                    Dgv_consulta.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }



        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        private void Frm_Consult_Concepto_Load(object sender, EventArgs e)
        {
            Dgv_consulta.Rows.Clear();
            MostrarConsulta();
        }

        private void Btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (Dgv_consulta.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
