namespace AppEmpleados;

public partial class EmpleadosPage : ContentPage
{
	public EmpleadosPage(List<Empleado> empleados)
	{
		InitializeComponent();
        lstEmpleados.ItemsSource = empleados;
    }
}