using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Text;
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
    /// Lógica de interacción para w_Login.xaml
    /// </summary>
    public partial class w_Login : Window
    {
        public w_Login()
        {
            InitializeComponent();
        }

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            /*
           if (txtMail.Text.Trim() != "" && txtClave.Password.ToString() != null)
           {
                Usuario usuario = new Usuario();
                usuario.password = txtClave.Password.ToString().Trim();
                usuario.email = txtMail.Text.Trim();
                try
                {
                    if (await Usuario.VerificarLogin(usuario))
                    {*/
                        menu menu = new menu();
                        Hide();
                        menu.ShowDialog();
                        Close();
                    /*}
                    else
                    {
                        MessageBox.Show("Verifique el usuario y la contraseña", "Iniciar Sesion", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Error al conectar con servidor!\n" + ex.Message, "Iniciar Sesion", MessageBoxButton.OK, MessageBoxImage.Error);
                }catch (Exception ex)
                {
                    MessageBox.Show("Error!\n" + ex.Message, "Iniciar Sesion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
           }*/
        
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
    }
}
