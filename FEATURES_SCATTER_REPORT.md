# Características: Gráfica de Dispersión y Reporte

## 📊 Gráfica de Dispersión (Scatter Plot)

La aplicación ahora incluye una mini gráfica de dispersión que muestra los **últimos 10 pings** de cada sitio monitoreado.

### Ubicación
- Se encuentra entre la columna "Max" y el botón "Remove" en cada fila de sitio
- Tamaño: 90px de ancho x 60px de alto

### Características
- **Tipo de visualización**: Puntos (scatter plot), no líneas
- **Datos mostrados**: Últimos 10 pings realizados
- **Actualización**: En tiempo real con cada nuevo ping
- **Color**: Azul (DodgerBlue)
- **Escala**: Automática basada en los valores de ping

### Diferencia con la gráfica existente
- **Gráfica de línea** (columna central): Muestra todos los 50 pings históricos con línea continua
- **Gráfica de dispersión** (nueva): Muestra solo los últimos 10 pings como puntos discretos

## 📋 Generación de Reportes

### Botón "Generate Report"

Un nuevo botón ubicado junto al control de intervalo permite generar un reporte completo de todos los sitios monitoreados.

### Ubicación
- Barra superior de controles, a la derecha del botón "Update Interval"

### Contenido del Reporte

El reporte incluye para cada sitio:

1. **Información General**
   - URL del sitio
   - Estado actual (Online/Offline)
   - Último tiempo de ping
   - Promedio de los últimos 50 pings
   - Tiempo máximo registrado

2. **Historial Detallado**
   - **Últimos 100 pings** con:
     - Marca de tiempo (timestamp)
     - Tiempo de respuesta en milisegundos
     - Estado (Success/Failed)

### Formato del Reporte

- **Tipo**: Archivo de texto plano (.txt)
- **Nombre**: `PingReport_YYYYMMDD_HHmmss.txt`
  - Ejemplo: `PingReport_20260216_143045.txt`
- **Ubicación**: Escritorio del usuario
- **Codificación**: UTF-8

### Ejemplo de Reporte

```
Ping Monitor Report
Generated: 2026-02-16 14:30:45
================================================================================

Site: google.com
Current Status: Online
Last Ping: 23 ms
Average (50): 25.40 ms
Maximum: 45 ms

Last 100 Ping Results:
Timestamp                | Ping Time (ms) | Status
--------------------------------------------------------------------------------
2026-02-16 14:30:44 |             23 | Success
2026-02-16 14:30:43 |             24 | Success
2026-02-16 14:30:42 |             22 | Success
...

================================================================================

Site: github.com
Current Status: Online
Last Ping: 156 ms
Average (50): 148.70 ms
Maximum: 201 ms

Last 100 Ping Results:
Timestamp                | Ping Time (ms) | Status
--------------------------------------------------------------------------------
2026-02-16 14:30:44 |            156 | Success
2026-02-16 14:30:43 |            148 | Success
...
```

## 🎨 Cambios en la Interfaz

### Ventana Principal
- **Ancho anterior**: 1000px
- **Ancho nuevo**: 1200px (para acomodar la nueva gráfica)

### Distribución de Columnas

```
┌──────┬──────┬──────┬──────┬────────────┬──────────┬────────┐
│ URL  │ Last │ Avg  │ Max  │ Gráf.Línea │ Gráf.Pts │ Remove │
│ 200  │ 120  │ 120  │ 120  │     *      │   100    │   80   │
└──────┴──────┴──────┴──────┴────────────┴──────────┴────────┘
```

## 💻 Uso

### Visualizar Gráfica de Dispersión
1. Agrega uno o más sitios para monitorear
2. La gráfica de dispersión aparecerá automáticamente
3. Se actualizará en tiempo real con cada ping
4. Después de 10 pings, mostrará los 10 más recientes

### Generar Reporte
1. Asegúrate de tener al menos un sitio monitoreado
2. Haz clic en el botón **"Generate Report"**
3. El reporte se guardará en tu Escritorio
4. Abre el archivo `.txt` con cualquier editor de texto

## 🔧 Detalles Técnicos

### Archivos Nuevos
- `PingMonitor/Controls/MiniScatterGraph.cs` - Control personalizado para la gráfica de puntos

### Archivos Modificados
- `PingSiteModel.cs` - Almacenamiento de hasta 100 resultados con timestamps
- `PingSiteViewModel.cs` - Propiedad para últimos 10 pings y método para obtener historial
- `MainWindowViewModel.cs` - Comando para generar reportes
- `MainWindow.axaml` - UI actualizada con nueva gráfica y botón

### Estructura de Datos
```csharp
public class PingResult
{
    public DateTime Timestamp { get; set; }
    public long PingTimeMs { get; set; }
    public bool IsSuccess { get; set; }
}
```

## ⚠️ Notas

- El reporte se genera de forma asíncrona para no bloquear la UI
- Si no hay sitios monitoreados, el botón no genera ningún reporte
- Los reportes se acumulan en el Escritorio (no se borran automáticamente)
- La gráfica de dispersión solo es visible después de tener al menos 1 ping
- Los resultados offline también se registran en el historial de 100 pings

## 🌐 Compatibilidad

Estas características son compatibles con:
- Windows (7+)
- Linux (X11/Wayland)
- macOS (10.12+)
