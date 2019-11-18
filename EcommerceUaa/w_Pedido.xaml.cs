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
    /// Lógica de interacción para w_Pedido.xaml
    /// </summary>
    public partial class w_Pedido : Window
    {
        UAAEcommerce db = new UAAEcommerce();
        public w_Pedido()
        {
            InitializeComponent();
        }

        private void WindoLoaded(object sender, RoutedEventArgs e)
        {
            cboCliente.ItemsSource = db.Cliente.ToList();
            cboProducto.ItemsSource = db.Producto.ToList();
            cboProducto.SelectedItem = null;
            cboCliente.SelectedItem = null;

        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            PedidoDetalle pedidoDetalle = new PedidoDetalle();
            pedidoDetalle.Producto = (Producto)cboProducto.SelectedItem;
            
        }
    }
}
