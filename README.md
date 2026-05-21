# 🚉 Sistema de Control de Acceso - Metro (Equipo 4)

Este proyecto corresponde al **Sprint 1** del sistema de gestión y control de acceso peatonal para las estaciones del Sistema Metro. El objetivo es registrar el ingreso y salida de visitantes mediante una arquitectura robusta, portátil y segura.

## 👥 Integrantes del Equipo
* **Juan Diego** (@Juandiego666) — *Líder de Desarrollo / Base de Datos* - *Desarrollador Frontend*- *Documentación y QA*



## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C# (.NET Framework)
* **Interfaz Gráfica:** Windows Forms (WinForms)
* **Base de Datos:** SQLite (Base de datos embebida para alta portabilidad sin requerir instalaciones pesadas)
* **Control de Versiones:** Git & GitHub

## 📐 Arquitectura del Sistema
El sistema está siendo reestructurado bajo un patrón de **Arquitectura en 4 Capas** para garantizar la separación de responsabilidades exigida:
1. **Capa de Presentación:** Formularios e interfaz de usuario (`Form1`, `FrmMenu`).
2. **Capa de Negocio (CN):** Lógica de validación y reglas del sistema.
3. **Capa de Datos (CD):** Consultas parametrizadas seguras para prevenir inyección SQL.
4. **Capa de Entidades (CE):** Modelos y moldes de datos del sistema.

## 🚀 Novedades de la Última Versión

En esta actualización, consolidamos el core de negocio del **Sprint 1** y nos adelantamos implementando una funcionalidad clave planificada para el **Sprint 2**:

### 1. Refactorización de Interfaz (UX/UI Premium)
* **Diseño Limpio y Corporativo:** Implementación de la paleta de colores institucional del Metro (Verde esmeralda y naranja de alerta).
* **Tablero de Indicadores en Tiempo Real:** Tarjetas dinámicas que muestran el conteo de ingresos del día y las personas actualmente activas dentro de la estación.
* **Navegación por Pestañas (TabControl):** Separación visual inteligente entre las personas que están *Dentro de la Estación* y el *Historial General* completo.

### 2. 📊 Exportación Real de Reportes (Avance Sprint 2)
Ya no es un botón estático. Hemos programado la lógica física de descargas del sistema:
* **Generación de Archivos Físicos:** El sistema procesa los datos del `DataGridView` en tiempo real y compila un reporte estructurado en formato de texto plano delimitado.
* **Compatibilidad Nativa con Microsoft Excel:** El archivo se genera usando codificación **UTF-8**, lo que garantiza que las tildes, eñes y caracteres especiales se lean perfectamente al abrir el documento directamente en Excel.
* **Interacción con el Sistema Operativo:** Integra una ventana nativa de guardado (`SaveFileDialog`) para que el usuario elija la ruta de descarga en su computadora.

---

## 🛠️ Arquitectura del Código Modificado

Para lograr una integración limpia sin corromper el diseñador visual de Visual Studio, el proyecto divide la carga de la siguiente manera:

* **`FrmMenu.Designer.cs`**: Registra e inicializa de manera segura el botón `btnExportar` y mapea el evento del click hacia la lógica del controlador.
* **`FrmMenu.cs`**: 
    * `AplicarDiseñoPremiumUX()`: Modifica dinámicamente el aspecto visual, tamaño y coordenadas de los controles al iniciar la aplicación.
    * `btnExportar_Click()`: Contiene el algoritmo de limpieza de texto (escapado de comillas dobles y comas internas) y el flujo de escritura física de archivos (`System.IO`).

---

## 📋 Requisitos para Ejecución
* .NET Framework 4.7.2 o superior.
* Base de Datos SQL Server (con el procedimiento almacenado para estadísticas e historial activo).
* No requiere dependencias externas de NuGet para la exportación (Solución nativa ligera).
