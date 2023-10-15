using System.Text.RegularExpressions;

namespace AppEmpleados
{
    public partial class MainPage : ContentPage
    {
        private List<Empleado> empleados = new List<Empleado>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void GuardarEmpleado(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            DateTime fechaNacimiento = dpFechaNacimiento.Date;
            string correo = txtCorreo.Text;

            string patronCorreo = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            Regex regexCorreo = new Regex(patronCorreo);

            bool correoValido = regexCorreo.IsMatch(correo);


            if (!string.IsNullOrEmpty(nombres) && !string.IsNullOrEmpty(apellidos) && correoValido)
            {
                Empleado nuevoEmpleado = new Empleado
                {
                    nombres = nombres,
                    apellidos = apellidos,
                    fechaNacimiento = fechaNacimiento,
                    correo = correo
                };

                empleados.Add(nuevoEmpleado);

                lblConfirmacion.Text = "Empleado registrado con éxito.";

                txtNombres.Text = "";
                txtApellidos.Text = "";
                dpFechaNacimiento.Date = DateTime.Now;
                txtCorreo.Text = "";
            }
            else
            {
                lblConfirmacion.Text = "Por favor, complete todos los campos correctamente.";
            }
        }

        private void VerEmpleado(object sender, EventArgs e)
        {
            if (empleados.Count > 0) 
            {
                Navigation.PushAsync(new EmpleadosPage(empleados)); 
            }
            else
            {
                lblConfirmacion.Text = "Primero registra al menos un empleado antes de ver la lista.";
            }
        }


    }
}