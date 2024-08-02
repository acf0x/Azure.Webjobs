# Azure Webjobs

Este repositorio contiene tres aplicaciones: ConsoleApp1, ConsoleApp2 y WebUploadFiles. WebUploadFiles permite a los usuarios cargar archivos que luego serán procesados por ConsoleApp1 o ConsoleApp2. Ambas aplicaciones de consola mueven los archivos cargados por la aplicación web desde el directorio `upload` al directorio `process`.

  
## WebUploadFiles
WebUploadFiles es una aplicación web ASP.NET Core que permite cargar archivos a través de un formulario web. Los archivos cargados se almacenan localmente o en Azure Blob Storage, dependiendo del método utilizado. También proporciona una vista para listar y descargar los archivos procesados.

### Controladores y Métodos:
- **Index**: Muestra la página principal.
- **Ficheros**: Lista los archivos en el directorio `wwwroot/process` y los muestra en la vista.
- **UploadFile**: Permite a los usuarios cargar archivos al directorio `wwwroot/upload`.
- **UploadFile2**: Permite a los usuarios cargar archivos a un contenedor de Azure Blob Storage.
  
## ConsoleApp1
Aplicación de consola que se ejecuta periódicamente cada 30 segundos. Su principal función es mover archivos desde el directorio `C:\home\site\wwwroot\wwwroot\upload` al directorio `C:\home\site\wwwroot\wwwroot\process`.

### Funcionamiento:
- Inicia un temporizador que se activa cada 30 segundos.
- Cuando el temporizador se activa, busca archivos en el directorio `upload`.
- Mueve cada archivo encontrado al directorio `process`.
- Registra mensajes en la consola para cada paso del proceso, incluyendo errores si ocurren.

## ConsoleApp2
Aplicación de consola que se ejecuta una vez cuando se inicia. Al igual que ConsoleApp1, su función es mover archivos desde el directorio `D:\home\site\wwwroot\wwwroot\upload` al directorio `D:\home\site\wwwroot\wwwroot\process`.

### Funcionamiento:
- Al iniciarse, busca archivos en el directorio `upload`.
- Mueve cada archivo encontrado al directorio `process`.
- Registra mensajes en la consola para cada paso del proceso, incluyendo errores si ocurren.
