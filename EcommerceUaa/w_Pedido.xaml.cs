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
using UAAEcommerce.Services;

namespace EcommerceUaa
{
    /// <summary>
    /// Lógica de interacción para w_Pedido.xaml
    /// </summary>
    public partial class w_Pedido : Window
    {
        DataContext db = new DataContext();
        Pedido pedidoAEntregar = new Pedido();
        Recommender recommender = new Recommender();
        public w_Pedido()
        {
            InitializeComponent();
        }

        private void WindoLoaded(object sender, RoutedEventArgs e)
        {
            ActualizarDGV();
        }
        private void ActualizarDGV()
        {
            dgvOrdenes.ItemsSource = db.Entrega.ToList();
            dgvPedidos.ItemsSource = db.Pedido.ToList();
            dgvOrdenes.Columns[4].Visibility = Visibility.Collapsed;
            dgvPedidos.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (!(pedidoAEntregar == null))
            {
                var entrega = new Entrega(){
                    id_pedido = pedidoAEntregar.idPedido,
                    chofer = txtChofer.Text,
                    fecha = Convert.ToDateTime(dtpFecha.Text)
                };
                db.Entrega.Add(entrega);
                db.SaveChanges();
                ActualizarDGV();
            }
            
        }

        

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DgvPedidosChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPedidos.SelectedItems.Count < 1)
                return;
            var item = (Pedido)dgvPedidos.SelectedItem;
            pedidoAEntregar = item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recommender.TrainModel();
            MessageBox.Show("IA entrenada con exito.");
        }
    }
}
