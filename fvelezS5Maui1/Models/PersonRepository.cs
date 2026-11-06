using SQLite;

namespace fvelezS5Maui1.Models
{
    /// <summary>
    /// Acciones de creación de la base de datos, inserción, consulta y eliminación de personas.
    /// </summary>
    public class PersonRepository
    {
        string _dbPath; 
        private SQLiteConnection? conn;

        public string StatusMessage { get; set; } = string.Empty;

        public bool LastOperationSucceeded { get; private set; }

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
                LastOperationSucceeded = true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
                LastOperationSucceeded = false;
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

        public void DeletePerson(int id)
        {
            try
            {
                Init();

                int result = conn!.Delete<Persona>(id);

                if (result == 0)
                    throw new Exception($"No existe la persona con Id {id}");

                StatusMessage = string.Format("{0} record(s) deleted (Id: {1})", result, id);
                LastOperationSucceeded = true;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete Id {0}. Error: {1}", id, ex.Message);
                LastOperationSucceeded = false;
            }
        }
    }
}
