# fvelezS5Maui1 – SQLite en .NET MAUI (Semana 5, UISRAEL)

Ejercicio de clase: **Insertar** y **Seleccionar** personas en una base SQLite local (`personas.db3`) con `sqlite-net-pcl`.

## Ejecutar
1. Abrir `fvelezS5Maui1.sln` en Visual Studio 2022 (carga de trabajo .NET MAUI, SDK .NET 9).
2. Esperar la restauración de NuGet.
3. Elegir **Windows Machine** o un emulador Android y pulsar F5.

## Uso
- **Agregar Persona**: escribir un nombre y pulsar el botón.
- **Get All People**: listar todos los registros (Id y Nombre).

## Estructura
```
├── Models/
│   ├── Persona.cs            # Tabla "persona"
│   └── PersonRepository.cs   # Acceso a SQLite
├── Views/
│   └── vPersona.xaml(.cs)    # Vista para ingresar y listar personas
├── FileAccessHelper.cs       # Ruta del archivo personas.db3
├── MauiProgram.cs            # Registro del repositorio (DI)
├── App.xaml(.cs)             # Instancia estática App.personRepo
└── AppShell.xaml             # Navegación → Views/vPersona
```
