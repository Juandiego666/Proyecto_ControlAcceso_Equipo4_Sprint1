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

## 🚀 Estado del Sprint 1
- [x] Repositorio de GitHub público y accesible.
- [x] Base de Datos SQLite configurada correctamente.
- [x] Módulo de Login funcional (`admin` / `123`).
- [x] Interfaz de Registro de Visitas conectada a la base de datos.
- [x] Controladores de estadísticas en tiempo real (Dashboard).
