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
    /// Lógica de interacción para w_TipoProducto.xaml
    /// </summary>
    public partial class w_TipoProducto : Window
    {
        UAAEcommerce db = new UAAEcommerce();
        string modo;
        int idToEdit;
        public w_TipoProducto()
        {
            InitializeComponent();
        }

        private void ActualizarDgv()
        {
            dgvTipoProducto.ItemsSource = db.TipoProducto.ToList();
            dgvTipoProducto.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void WindoLoaded(object sender, RoutedEventArgs e)
        {
            ActualizarDgv();
            BloquearFormulario();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescripcion.Text.Length < 1)
            {
                MessageBox.Show("Ingrese una descripcion valida");
                return;
            }
            if (modo == "A")
            {
                var tipo = new TipoProducto() {
                    tipro_descripcion = txtDescripcion.Text
                };
                db.TipoProducto.Add(tipo);
                db.SaveChanges();
                ActualizarDgv();
                BloquearFormulario();
            }
            if (modo == "E")
            {
                var tipo = db.TipoProducto.Find(idToEdit);
                tipo.tipro_descripcion = txtDescripcion.Text;
                db.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ActualizarDgv();
                BloquearFormulario();
            }
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var tipo = (TipoProducto)dgvTipoProducto.SelectedValue;
            if (!(tipo is null))
            {
                db.TipoProducto.Remove(tipo);
                BloquearFormulario();
                db.SaveChanges();
                ActualizarDgv();
            }
        }


        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            modo = "E";
            if (dgvTipoProducto.SelectedItem != null) DesbloquearFormulario();
        }

        private void DesbloquearFormulario()
        {
            txtDescripcion.IsEnabled = true;
        }

        private void BloquearFormulario()
        {
            txtDescripcion.Text = "";
            txtDescripcion.IsEnabled = false;
        }

        private void ChangeDgvChanged(object sender, SelectionChangedEventArgs e)
        {
            var tipo = (TipoProducto)dgvTipoProducto.SelectedValue;
            if (!(tipo is null))
            {
                idToEdit = tipo.idTipoProducto;
                txtDescripcion.Text = tipo.tipro_descripcion;
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            txtDescripcion.Text = "";
            modo = "A";
            DesbloquearFormulario();
        }
    }
}
