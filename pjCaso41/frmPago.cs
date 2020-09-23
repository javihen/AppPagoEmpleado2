using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjCaso41
{
    public partial class frmPago : Form
    {
        double sueldo = 0;
        public frmPago()
        {
            InitializeComponent();
        }

        private void frmPago_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los valores 
            string empleado = txtEmpleado.Text;
            string categoria = cboCategoria.Text;

            //Realizando calculos
            double descuento=0;
            if (sueldo > 2000) descuento = sueldo * (12.5/100);

            double neto = sueldo - descuento;

            //Imprimiendo los resultados en la lista
            ListViewItem fila = new ListViewItem(empleado);
            fila.SubItems.Add(categoria);
            fila.SubItems.Add(sueldo.ToString("C"));
            fila.SubItems.Add(descuento.ToString("C"));
            fila.SubItems.Add(neto.ToString("C"));
            lvPagos.Items.Add(fila);

            //Limpiando los controles
            btnCancelar_Click(sender, e);
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturando la categoria seleccionada
            string categoria=cboCategoria.Text;

            //Asignando el sueldo segun la categoria
            if (categoria == "Jefe") sueldo = 3500;
            if (categoria == "Administrativo") sueldo = 2500;
            if (categoria == "Tecnico") sueldo = 1700;
            if (categoria == "Operario") sueldo = 1000;

            //Enviando el sueldo obtenido a la impresion 
            lblSueldo.Text = sueldo.ToString("C");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboCategoria.Text = "(Seleccione)";
            txtEmpleado.Clear();
            txtEmpleado.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir?","Pago",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
