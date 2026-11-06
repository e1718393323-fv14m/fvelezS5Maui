using fvelezS5Maui1.Models;

namespace fvelezS5Maui1
{
    public partial class App : Application
    {
        public static PersonRepository personRepo { get; set; } = null!;

        public App(PersonRepository personRepository)
        {
            InitializeComponent();
            personRepo = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell()) { Title = "fvelezS5Maui1" };
        }
    }
}
