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
    /// Lógica de interacción para w_TipoCliente.xaml
    /// </summary>
    public partial class w_TipoCliente : Window
    {
        DataContext db = new DataContext();
        string modo = null;
        public w_TipoCliente()
        {
            InitializeComponent();
        }

        private void BloquearFormulario()
        {
            btnGuardar.IsEnabled = false;
            txtId.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
        }
        private void DesbloquearFormulario()
        {
            
            btnGuardar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            txtDescripcion.IsEnabled = true;
        }

        private void LimpiarFormulario()
        {
            txtId.Text = null;
            txtDescripcion.Text = null;
        }

        private void ActualizarDgv()
        {
            dgvTipoCliente.ItemsSource = null;
            dgvTipoCliente.ItemsSource = db.TipoCliente.ToList();
            dgvTipoCliente.Columns[0].Header = "Id";
            dgvTipoCliente.Columns[1].Header = "Descripcion";
            dgvTipoCliente.Columns[2].Visibility = Visibility.Collapsed;
            dgvTipoCliente.CanUserAddRows = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BloquearFormulario();
            ActualizarDgv();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
            DesbloquearFormulario();
            modo = "A";
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (modo.Equals("A"))
            {
                TipoCliente tipoCliente = new TipoCliente();
                tipoCliente.tipcli_descripcion = txtDescripcion.Text.Trim();

                db.TipoCliente.Add(tipoCliente);
                db.SaveChanges();
            }
            else if (modo.Equals("E"))
            {
                if (dgvTipoCliente.SelectedItem != null)
                {
                    TipoCliente tipoCliente = (TipoCliente)dgvTipoCliente.SelectedItem;
                    tipoCliente.tipcli_descripcion = txtDescripcion.Text.Trim();

                    db.Entry(tipoCliente).State = System.Data.Entity.EntityState.Modified;
                }
            }
            LimpiarFormulario();
            ActualizarDgv();
            BloquearFormulario();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            modo = "E";
            DesbloquearFormulario();           
            
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirma la eliminación del registro?","Eliminacion de registro",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (dgvTipoCliente.SelectedItem != null)
                {
                    TipoCliente tipoCliente = (TipoCliente)dgvTipoCliente.SelectedItem;
                    db.TipoCliente.Remove(tipoCliente);
                    db.SaveChanges();
                    LimpiarFormulario();
                    ActualizarDgv();
                }
            }
        }

        private void DgvTipoCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;

            if (dgvTipoCliente.SelectedItem != null)
            {
                TipoCliente tipoCliente = (TipoCliente)dgvTipoCliente.SelectedItem;
                txtDescripcion.Text = tipoCliente.tipcli_descripcion;
                txtId.Text = tipoCliente.idTipoCliente.ToString();

            }

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
