# SharedLibrary

## Descripción

- Definir lógica de negocio, modelos, utilidades o servicios que son comunes a varias aplicaciones.
- Ayuda a mantener una arquitectura limpia y organizada, separando el código común del código específico. Esto sigue el principio de separación de preocupaciones (SoC).
- Al centralizar el código compartido en una biblioteca, cualquier modificación o corrección de errores solo se tiene que realizar en un solo lugar.
- Fomenta la modularización del código, lo que hace que las aplicaciones sean más fáciles de desarrollar y mantener.


## Uso comunes 

- Modelos y entidades: Las clases que representan modelos de datos o entidades.
- Componentes de acceso a datos: El acceso a bases de datos, repositorios, o clases que gestionan la persistencia de datos.
- Constantes y configuraciones: Valores constantes o configuraciones que deben ser accesibles en múltiples proyectos.
- Servicios utilitarios: Funcionalidades como la validación, criptografía, logging  o servicios de utilidades que pueden ser centralizadas en una biblioteca compartida, en lugar de duplicar la lógica en cada proyecto.