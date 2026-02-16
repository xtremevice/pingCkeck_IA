# 🚀 Comando Rápido para Mac Silicon - Última Versión

## 🔄 Actualizar a la Última Versión (Si Ya Tienes la App)

**¿Ya instalaste la aplicación antes?** Usa este comando para actualizar:

```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

Ver más opciones en: **[ACTUALIZAR.md](ACTUALIZAR.md)**

---

## 🆕 Primera Instalación - Comando Todo-en-Uno

Copia y pega este comando completo en tu Terminal:

```bash
cd ~/Desktop && git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA/PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

## ¿Qué hace este comando?

1. Va a tu Escritorio
2. Descarga la última versión (rama `copilot/create-ping-app`)
3. Entra a la carpeta del proyecto
4. Compila la aplicación para Mac Silicon (ARM64)
5. Le da permisos de ejecución
6. Ejecuta la aplicación

## Requisito Previo

**Debes tener instalado .NET 8 SDK**

Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0

Selecciona: **macOS ARM64** (para Apple Silicon)

## Verificar si tienes .NET instalado

```bash
dotnet --version
```

Debe mostrar `8.0.xxx` o superior.

## Características de esta Versión

✅ Monitor de ping en tiempo real  
✅ Gráfica de línea (últimos 50 pings)  
✅ **NUEVO:** Gráfica de dispersión visible (últimos 10 pings)  
✅ **NUEVO:** Botón para generar reportes (últimos 100 pings)  
✅ **NUEVO:** Reportes en formato TXT y CSV  
✅ **NUEVO:** Confirmación visual al generar reportes  
✅ Estadísticas: Último, Promedio, Máximo  
✅ Compatible con Mac Silicon (M1, M2, M3)  

## Ejecutar Nuevamente (después de primera instalación)

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
./PingMonitor
```

## Problemas Comunes

### "developer cannot be verified"
```bash
xattr -d com.apple.quarantine ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/PingMonitor
```

### "command not found: dotnet"
Instala .NET 8 SDK y reinicia la Terminal.

## Documentación Completa

- **[ACTUALIZAR.md](ACTUALIZAR.md)** - 🔄 Comandos para actualizar y ejecutar
- **Guía detallada**: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)
- **Comandos rápidos**: [QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)
- **Nuevas características**: [FEATURES_SCATTER_REPORT.md](FEATURES_SCATTER_REPORT.md)
- **Correcciones recientes**: [FIXES_GRAFICA_REPORTE.md](FIXES_GRAFICA_REPORTE.md)

---

**Última actualización**: 2026-02-16  
**Versión**: Incluye gráficas visibles, reportes CSV/TXT y feedback de usuario
