using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EcommerceUaa
{
    /// <summary>
    /// Lógica de interacción para w_Cliente.xaml
    /// </summary>
    public partial class w_Cliente : Window
    {
        UAAEcommerce datos;
        string modo = null;

        public w_Cliente()
        {
            InitializeComponent();
            datos = new UAAEcommerce();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgvClientes.ItemsSource = datos.Cliente.ToList();
                dgvClientes.Columns[1].Visibility = Visibility.Collapsed;
                dgvClientes.Columns[2].Visibility = Visibility.Collapsed;
                dgvClientes.Columns[8].Visibility = Visibility.Collapsed;
                dgvClientes.Columns[9].Visibility = Visibility.Collapsed;
                dgvClientes.Columns[10].Visibility = Visibility.Collapsed;
                dgvClientes.Columns[0].Header = "Id";
                dgvClientes.Columns[3].Header = "RUC";
                dgvClientes.Columns[4].Header = "Razon Social";
                dgvClientes.Columns[5].Header = "Direccion";
                dgvClientes.Columns[6].Header = "Email";
                dgvClientes.Columns[7].Header = "Telefono";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgvClientes_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CargarCombos()
        {
            cmbCiudad.ItemsSource = datos.Ciudad.ToList();
            cmbCiudad.DisplayMemberPath = "ciu_descripcion";
            cmbCiudad.SelectedValuePath = "idCiudad";

            cmbTipoCliente.ItemsSource = datos.TipoCliente.ToList();
            cmbTipoCliente.DisplayMemberPath = "tipcli_descripcion";
            cmbTipoCliente.SelectedValuePath = "idTipoCliente";
        }

        private void BloquearFormulario()
        {
            txtRuc.IsEnabled = false;
            txtRazonSocial.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtMail.IsEnabled = false;
            cmbCiudad.IsEnabled = false;
            cmbTipoCliente.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;

        }

        private void DesbloquearFormulario()
        {
            txtRazonSocial.IsEnabled = true;
            txtRuc.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtMail.IsEnabled = true;
            cmbCiudad.IsEnabled = true;
            cmbTipoCliente.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnAgregar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
            CargarCombos();
            BloquearFormulario();
            dgvClientes.SelectionMode = DataGridSelectionMode.Single;
            dgvClientes.SelectionUnit = DataGridSelectionUnit.FullRow;
            

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            DesbloquearFormulario();
            LimpiarFormulario();
            modo = "A";
        }

        private void LimpiarFormulario()
        {
            txtRuc.Text = null;
            txtRazonSocial.Text = null;
            txtDireccion.Text = null;
            txtTelefono.Text = null;
            txtMail.Text = null;
            cmbCiudad.SelectedItem = null;
            cmbTipoCliente.SelectedItem = null;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modo.Equals("A"))
                {
                    Cliente cli = new Cliente();
                    cli.idCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
                    cli.idTipoCliente = Convert.ToInt32(cmbTipoCliente.SelectedValue);
                    cli.cli_razonsocial = txtRazonSocial.Text;
                    cli.cli_ruc = txtRuc.Text;
                    cli.cli_direccion = txtDireccion.Text;
                    cli.cli_telefono = txtTelefono.Text;
                    cli.cli_email = txtTelefono.Text;

                    datos.Cliente.Add(cli);
                    datos.SaveChanges();
                    CargarDatosGrilla();
                    LimpiarFormulario();
                    BloquearFormulario();
                }
                else if (modo.Equals("E"))
                {
                    Cliente cli = (Cliente)dgvClientes.SelectedItem;
                    cli.idCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
                    cli.idTipoCliente = Convert.ToInt32(cmbTipoCliente.SelectedValue);
                    cli.cli_razonsocial = txtRazonSocial.Text;
                    cli.cli_ruc = txtRuc.Text;
                    cli.cli_direccion = txtDireccion.Text;
                    cli.cli_telefono = txtTelefono.Text;
                    cli.cli_email = txtTelefono.Text;

                    datos.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                    datos.SaveChanges();

                    LimpiarFormulario();
                    BloquearFormulario();
                    CargarDatosGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente cliente = (Cliente)dgvClientes.SelectedItem;
            if (cliente != null)
            {
                txtRuc.Text = cliente.cli_ruc;
                txtRazonSocial.Text = cliente.cli_razonsocial;
                txtDireccion.Text = cliente.cli_direccion;
                txtTelefono.Text = cliente.cli_telefono;
                txtMail.Text = cliente.cli_email;
                cmbCiudad.SelectedItem = cliente.Ciudad;
                cmbTipoCliente.SelectedItem = cliente.TipoCliente;

                
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            modo = "E";
            if (dgvClientes.SelectedItem != null) DesbloquearFormulario();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminacion de registro", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (dgvClientes.SelectedItem != null)
                {
                    Cliente cliente = (Cliente)dgvClientes.SelectedItem;
                    datos.Cliente.Remove(cliente);
                    datos.SaveChanges();
                    CargarDatosGrilla();
                    LimpiarFormulario();
                    BloquearFormulario();
                }
                else
                {
                    MessageBox.Show("Seleccione un item para eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
