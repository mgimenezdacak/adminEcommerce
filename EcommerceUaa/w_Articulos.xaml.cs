using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para w_Articulos.xaml
    /// </summary>
    public partial class w_Articulos : Window
    {
        UAAEcommerce db = new UAAEcommerce();
        string modo = null;
        public w_Articulos()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            BloquearFormulario();
            chbTipoProducto.ItemsSource = db.TipoProducto.ToList();
            chbTipoProducto.DisplayMemberPath = "tipro_descripcion";
            chbTipoProducto.SelectedValuePath = "idTipoProducto";
            LimpiarFormulario();
            ActualizarDgv();
            dgvProductos.SelectionMode = DataGridSelectionMode.Single;
            dgvProductos.SelectionUnit = DataGridSelectionUnit.FullRow;
        }

        private void BloquearFormulario()
        {
            txtCodBarra.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            chbTipoProducto.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;

        }

        private void DesbloquearFormulario()
        {
            txtCodBarra.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            chbTipoProducto.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnAgregar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }

        private void LimpiarFormulario()
        {
            txtCodBarra.Text = null;
            txtDescripcion.Text = null;
            txtPrecio.Text = null;
            chbTipoProducto.SelectedItem = null;

        }

        private void ActualizarDgv()
        {
            dgvProductos.ItemsSource = null;
            /*var listaProductos = from p in db.Producto.ToList()
                                 join p1 in db.TipoProducto.ToList() on p.idTipoProducto equals p1.idTipoProducto
                                 select new { Id = p.idProducto ,CodigoBarra = p.pro_codigobarra, Producto = p.pro_descripcion, tipoProducto = p1.tipro_descripcion, Precio = p.pro_precio };

             
            dgvProductos.ItemsSource = listaProductos;*/

            dgvProductos.ItemsSource = db.Producto.ToList();
            dgvProductos.Columns[5].Visibility = Visibility.Collapsed;
            dgvProductos.Columns[6].Visibility = Visibility.Collapsed;
            dgvProductos.Columns[1].Visibility = Visibility.Collapsed;
            

        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            DesbloquearFormulario();
            LimpiarFormulario();
            modo = "A";

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (modo.Equals("A"))
            {
                Producto pro = new Producto();
                pro.idTipoProducto = Convert.ToInt32(chbTipoProducto.SelectedValue);
                pro.pro_descripcion = txtDescripcion.Text;
                pro.pro_precio = Convert.ToInt32(txtPrecio.Text);
                pro.pro_codigobarra = txtCodBarra.Text;

                db.Producto.Add(pro);
                db.SaveChanges();
                ActualizarDgv();
                LimpiarFormulario();
                BloquearFormulario();
            }
            else if (modo.Equals("E"))
            {
                Producto pro = (Producto)dgvProductos.SelectedItem;

                pro.idTipoProducto = Convert.ToInt32(chbTipoProducto.SelectedValue);
                pro.pro_descripcion = txtDescripcion.Text;
                pro.pro_precio = Convert.ToInt32(txtPrecio.Text);
                pro.pro_codigobarra = txtCodBarra.Text;

                db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
                LimpiarFormulario();
                BloquearFormulario();
                ActualizarDgv();
            }

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            modo = "E";
            if (dgvProductos.SelectedItem != null) DesbloquearFormulario();
        }


        private void DgvProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int id = Convert.ToInt32((dgvProductos.SelectedCells[0].Column.GetCellContent(dgvProductos.SelectedCells[0].Item) as TextBlock).Text);;
           
            Producto producto = (Producto)dgvProductos.SelectedItem;
                if (producto != null)
                {
                    txtCodBarra.Text = producto.pro_codigobarra;
                    txtDescripcion.Text = producto.pro_descripcion;
                    txtPrecio.Text = producto.pro_precio.ToString();
                    chbTipoProducto.SelectedItem = producto.TipoProducto;
                }
          
               
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminacion de registro", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (dgvProductos.SelectedItem != null)
                {
                    Producto producto = (Producto)dgvProductos.SelectedItem;
                    db.Producto.Remove(producto);
                    db.SaveChanges();
                    ActualizarDgv();
                    LimpiarFormulario();
                    BloquearFormulario();
                }
                else
                {
                    MessageBox.Show("Seleccione un item para eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void SoloNumero (object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        private void TxtCodBarra_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumero(sender, e);
        }

        private void TxtPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SoloNumero(sender, e);
        }
    }
}
