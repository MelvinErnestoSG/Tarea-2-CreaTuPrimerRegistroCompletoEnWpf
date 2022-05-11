using System;
using System.Windows;
using Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.BLL;
using Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.Entidades;

namespace Tarea_2_CreaTuPrimerRegistroCompletoEnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Roles roll = new Roles();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = roll;
        }

        private void Limpiar()
        {
            this.roll = new Roles();
            this.DataContext = roll;
        }

        private bool Validar()
        {
            bool esValido = true;

            string MensajeValidacion = "Validación";

            if (RollIdTextBox.Text == "0")
            {
                MessageBox.Show("El Campo ID No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (DescripcionRolesComboBox.Text == "Administrador")
            {
                MessageBox.Show("No Pueden Haber Más De 2 Roles De Administrador.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (AliasTextBox.Text.Length == 0)
            {
                MessageBox.Show("El Campo Alias No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (NombreTextBox.Text.Length == 0)
            {
                MessageBox.Show("El Campo Nombre No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ClavePasswordBox.Password.Length == 0)
            {
                MessageBox.Show("El Campo Clave No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ConfirmarClavePasswordBox.Password.Length == 0)
            {
                MessageBox.Show("El Campo Confirmar No Puede Estar Clave Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ClavePasswordBox.Password != ConfirmarClavePasswordBox.Password)
            {
                MessageBox.Show("Las Contraseñas No Coinciden.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (EmailTextBox.Text.Length == 0)
            {
                MessageBox.Show("El Campo Email No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Encontrado = RolesBLL.Buscar(Utilidades.ToInt(RollIdTextBox.Text));

            if (Encontrado != null)
            {
                this.roll = Encontrado;
                MessageBox.Show("EL Rol Fue Creado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("El Rol No Esta Creado.", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
                this.roll = new Roles();
            }
            this.DataContext = this.roll;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            FechaIngresoDataPicker.SelectedDate = DateTime.Now;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            bool Guardo = RolesBLL.Guardar(roll);

            if (Guardo)
            {
                Limpiar();
                MessageBox.Show("Transacción Exitosa!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transacción Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(RollIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Regitro Eliminado!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Eliminación Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
