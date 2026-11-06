using fvelezS5Maui1.Models;

namespace fvelezS5Maui1.Views
{
    public partial class vPersona : ContentPage
    {
        public vPersona()
        {
            InitializeComponent();
        }
        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            App.personRepo.AddNewPerson(txtNombre.Text);
            statusMessage.Text = App.personRepo.StatusMessage;
            txtNombre.Text = string.Empty;
        }
        private void btnListar_Clicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            List<Persona> people = App.personRepo.GetAllPeople();
            listaPersona.ItemsSource = people;
        }
    }
}
