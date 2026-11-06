using fvelezS5Maui1.Models;

namespace fvelezS5Maui1.Views
{
    public partial class vPersona : ContentPage
    {
        private Persona? _seleccionada;

        public vPersona()
        {
            InitializeComponent();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            App.personRepo.AddNewPerson(txtNombre.Text);
            MostrarEstado();

            if (App.personRepo.LastOperationSucceeded)
            {
                txtNombre.Text = string.Empty;
                CargarLista();
            }
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            CargarLista();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            if (_seleccionada is null)
                return;

            bool confirmar = await DisplayAlert(
                "Eliminar persona",
                $"¿Desea eliminar a '{_seleccionada.Nombre}' (Id {_seleccionada.Id})?",
                "Sí, eliminar", "Cancelar");

            if (!confirmar)
                return;

            App.personRepo.DeletePerson(_seleccionada.Id);
            MostrarEstado();
            CargarLista();
        }

        private void listaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _seleccionada = e.CurrentSelection.FirstOrDefault() as Persona;
            btnEliminar.IsEnabled = _seleccionada is not null;

            lblSeleccion.Text = _seleccionada is not null
                ? $"Seleccionado: Id {_seleccionada.Id} - {_seleccionada.Nombre}"
                : "Toque una persona de la lista para eliminarla";
        }

        private void CargarLista()
        {
            listaPersona.SelectedItem = null;
            listaPersona.ItemsSource = App.personRepo.GetAllPeople();
        }

        private void MostrarEstado()
        {
            statusMessage.Text = App.personRepo.StatusMessage;
            statusMessage.TextColor = App.personRepo.LastOperationSucceeded
                ? (Color)Application.Current!.Resources["Success"]
                : (Color)Application.Current!.Resources["Danger"];
        }
    }
}
