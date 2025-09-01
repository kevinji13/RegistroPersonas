# RegistroPersonas
Aplicación de escritorio en C# (Windows Forms) para registrar y gestionar personas, que pueden ser **Alumnos** o **Profesores**.

## Descripción

Esta aplicación permite:

- Agregar, modificar y visualizar personas en un **DataGridView**.
- Diferenciar entre **Alumno** y **Profesor**, mostrando atributos específicos (Carrera o Materia).
- Seleccionar una persona para ver sus datos detallados en un **Label** y en los **TextBox** del formulario.
- Validar los datos ingresados (campos vacíos y tipo de dato correcto para Edad).
- Aplicar **polimorfismo** mediante clases derivadas de `Persona` con métodos y propiedades sobrescritas.

## Tecnologías

- C# 11
- Windows Forms
- Visual Studio 2022

## Estructura del proyecto

- `Persona.cs` → Clase base con atributos comunes y métodos virtuales.  
- `Alumno.cs` → Clase derivada que agrega `Carrera` y sobrescribe métodos/properties.  
- `Profesor.cs` → Clase derivada que agrega `Materia` y sobrescribe métodos/properties.  
- `Form1.cs` → Formulario principal con lógica para agregar, modificar y mostrar personas.

## Polimorfismo

Se utiliza polimorfismo en:

- `MostrarDatos()` → cada tipo de persona devuelve su información específica.
- `InfoExtra` → propiedad sobrescrita para mostrar Carrera o Materia según corresponda.
- Esto permite manejar objetos de tipo `Persona` de forma uniforme, simplificando la gestión en el DataGridView y en los Labels.

## Uso

1. Abrir el proyecto en Visual Studio.  
2. Ejecutar la aplicación.  
3. Seleccionar el tipo de persona (Alumno/Profesor) en el ComboBox.  
4. Ingresar los datos y hacer clic en **Agregar**.  
5. Seleccionar una fila para modificar datos y usar **Modificar**.
