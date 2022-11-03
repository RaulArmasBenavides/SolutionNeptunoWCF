using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio.Neptuno.AppWind.ProxyWCF;

namespace Servicio.Neptuno.AppWind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            listaEmpleados();
        }

        //instanciar objeto de la clase EmpleadoService
        EmpleadoServiceClient obj = new EmpleadoServiceClient();

        private void listaEmpleados()
        {
            dgvEmpleado.DataSource = obj.EmpleadoListar(); 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            adicionar();
        }

        Empleado emp;

        private void adicionar()
        {
            emp = new Empleado()
            {
                IdEmpleado=int.Parse(txtCodigo.Text),
                Nombre=txtNombre.Text,
                Apellidos=txtApellido.Text,
                Cargo=txtCargo.Text
            };
            try
            {
                obj.EmpleadoAdicionar(emp);
                MessageBox.Show("Empleado registrado con exito", "exito");
                listaEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error");
            }
           

        }
    }
}
