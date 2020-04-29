using Capa_Diseño.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Diseño
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        bool ventanaPuesto = false;
        Frm_Mantenimiento_Puesto puesto = new Frm_Mantenimiento_Puesto();
        private void ConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantenimiento_Puesto);
            if (ventanaPuesto == false || frmC == null)
            {
                if (frmC == null)
                {
                    puesto = new Frm_Mantenimiento_Puesto();
                }

                puesto.MdiParent = this;
                puesto.Show();
                Application.DoEvents();
                ventanaPuesto = true;
            }
            else
            {
                puesto.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }

        }

        bool ventanaConcepto = false;
        Frm_Mantenimiento_Concepto concep = new Frm_Mantenimiento_Concepto();
        private void ConceptoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantenimiento_Concepto);
            if (ventanaConcepto == false || frmC == null)
            {
                if (frmC == null)
                {
                    concep = new Frm_Mantenimiento_Concepto();
                }

                concep.MdiParent = this;
                concep.Show();
                Application.DoEvents();
                ventanaConcepto = true;
            }
            else
            {
                concep.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaDepto = false;
        Frm_Mantenimientos_Departamento depto = new Frm_Mantenimientos_Departamento();
        private void DepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantenimientos_Departamento);
            if (ventanaDepto == false || frmC == null)
            {
                if (frmC == null)
                {
                    depto = new Frm_Mantenimientos_Departamento();
                }

                depto.MdiParent = this;
                depto.Show();
                Application.DoEvents();
                ventanaDepto = true;
            }
            else
            {
                depto.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaEmp = false;
        Frm_Mantenimiento_Empleado Emp = new Frm_Mantenimiento_Empleado();
        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Mantenimiento_Empleado);
            if (ventanaEmp == false || frmC == null)
            {
                if (frmC == null)
                {
                    Emp = new Frm_Mantenimiento_Empleado();
                }

                Emp.MdiParent = this;
                Emp.Show();
                Application.DoEvents();
                ventanaEmp = true;
            }
            else
            {
                Emp.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
