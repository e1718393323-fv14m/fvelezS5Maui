using SQLite;

namespace fvelezS5Maui1.Models
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection? conn;

        public string StatusMessage { get; set; } = string.Empty;

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string? nombre)
        {
            int result = 0;
            try
            {
                Init();

                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("Nombre requerido");

                nombre = nombre.Trim();

                Persona person = new() { Nombre = nombre };
                result = conn!.Insert(person);

                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn!.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Persona>();
        }
    }
}
