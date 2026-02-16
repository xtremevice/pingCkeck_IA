# 🔄 Actualizar a la Última Versión

Esta guía te muestra cómo actualizar y ejecutar la última versión de Ping Monitor.

## 📥 Si Ya Tienes la Aplicación Instalada

### Actualizar y Ejecutar - Comando Rápido

```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

### Paso a Paso

#### 1. Actualizar el Código

```bash
# Ir a la carpeta del proyecto
cd ~/Desktop/pingCkeck_IA

# Obtener la última versión
git pull
```

#### 2. Recompilar

```bash
# Ir a la carpeta del proyecto
cd PingMonitor

# Compilar la última versión para tu sistema
dotnet publish -c Release -r osx-arm64 --self-contained
```

#### 3. Ejecutar

```bash
# Ir a la carpeta de la aplicación compilada
cd bin/Release/net8.0/osx-arm64/publish/

# Dar permisos de ejecución (solo primera vez después de actualizar)
chmod +x PingMonitor

# Ejecutar
./PingMonitor
```

## 💻 Comandos por Sistema Operativo

### macOS (Apple Silicon - M1/M2/M3)

**Actualizar y ejecutar:**
```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

**Solo ejecutar (sin actualizar):**
```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/ && ./PingMonitor
```

### macOS (Intel)

**Actualizar y ejecutar:**
```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-x64 --self-contained && cd bin/Release/net8.0/osx-x64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

**Solo ejecutar (sin actualizar):**
```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-x64/publish/ && ./PingMonitor
```

### Windows

**Actualizar y ejecutar:**
```cmd
cd %USERPROFILE%\Desktop\pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r win-x64 --self-contained && cd bin\Release\net8.0\win-x64\publish\ && PingMonitor.exe
```

**Solo ejecutar (sin actualizar):**
```cmd
cd %USERPROFILE%\Desktop\pingCkeck_IA\PingMonitor\bin\Release\net8.0\win-x64\publish\ && PingMonitor.exe
```

### Linux

**Actualizar y ejecutar:**
```bash
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r linux-x64 --self-contained && cd bin/Release/net8.0/linux-x64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

**Solo ejecutar (sin actualizar):**
```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/linux-x64/publish/ && ./PingMonitor
```

## 🆕 Primera Instalación

Si aún no tienes la aplicación instalada, usa estos comandos:

### Mac Silicon (M1/M2/M3)
```bash
cd ~/Desktop && git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA/PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

Ver más detalles: [COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md)

### Mac Intel
```bash
cd ~/Desktop && git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA/PingMonitor && dotnet publish -c Release -r osx-x64 --self-contained && cd bin/Release/net8.0/osx-x64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

### Windows
```cmd
cd %USERPROFILE%\Desktop && git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA\PingMonitor && dotnet publish -c Release -r win-x64 --self-contained && cd bin\Release\net8.0\win-x64\publish\ && PingMonitor.exe
```

### Linux
```bash
cd ~/Desktop && git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA/PingMonitor && dotnet publish -c Release -r linux-x64 --self-contained && cd bin/Release/net8.0/linux-x64/publish/ && chmod +x PingMonitor && ./PingMonitor
```

## ⚙️ Requisitos

**Debes tener instalado .NET 8 SDK**

Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0

### Verificar Instalación

```bash
dotnet --version
```

Debe mostrar `8.0.xxx` o superior.

## 📋 ¿Qué Incluye la Última Versión?

✅ Monitor de ping en tiempo real  
✅ Gráfica de línea (últimos 50 pings)  
✅ Gráfica de dispersión visible (últimos 10 pings)  
✅ Botón para generar reportes (últimos 100 pings)  
✅ Reportes en formato TXT y CSV  
✅ Confirmación visual cuando se genera el reporte  
✅ Compatible con Windows, Linux y macOS  

## 🔧 Solución de Problemas

### Error: "Your branch is behind"

Si ves este mensaje al hacer `git pull`:

```bash
cd ~/Desktop/pingCkeck_IA
git fetch origin
git reset --hard origin/copilot/create-ping-app
```

### Error: "command not found: dotnet"

Instala .NET 8 SDK y reinicia la terminal.

### Error: "developer cannot be verified" (macOS)

```bash
xattr -d com.apple.quarantine ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/PingMonitor
```

### La aplicación no arranca

Asegúrate de estar en la carpeta correcta y de tener permisos:

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

## 🚀 Crear Alias para Ejecución Rápida

### macOS/Linux

Agrega a tu `~/.zshrc` o `~/.bashrc`:

```bash
# Para actualizar y ejecutar
alias ping-update='cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && dotnet publish -c Release -r osx-arm64 --self-contained && cd bin/Release/net8.0/osx-arm64/publish/ && chmod +x PingMonitor && ./PingMonitor'

# Para solo ejecutar
alias ping-run='cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/ && ./PingMonitor'
```

Luego recarga:
```bash
source ~/.zshrc  # o source ~/.bashrc
```

Ahora puedes usar:
```bash
ping-update  # Para actualizar y ejecutar
ping-run     # Para solo ejecutar
```

### Windows (PowerShell)

Agrega a tu perfil de PowerShell (`$PROFILE`):

```powershell
function Ping-Update {
    cd $env:USERPROFILE\Desktop\pingCkeck_IA
    git pull
    cd PingMonitor
    dotnet publish -c Release -r win-x64 --self-contained
    cd bin\Release\net8.0\win-x64\publish\
    .\PingMonitor.exe
}

function Ping-Run {
    cd $env:USERPROFILE\Desktop\pingCkeck_IA\PingMonitor\bin\Release\net8.0\win-x64\publish\
    .\PingMonitor.exe
}
```

Ahora puedes usar:
```powershell
Ping-Update  # Para actualizar y ejecutar
Ping-Run     # Para solo ejecutar
```

## 📚 Documentación Adicional

- [COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md) - Instalación inicial Mac Silicon
- [MAC_SILICON_ES.md](MAC_SILICON_ES.md) - Guía detallada Mac Silicon
- [QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md) - Comandos rápidos Mac
- [FIXES_GRAFICA_REPORTE.md](FIXES_GRAFICA_REPORTE.md) - Correcciones recientes
- [FEATURES_SCATTER_REPORT.md](FEATURES_SCATTER_REPORT.md) - Nuevas características

## 🆘 Necesitas Ayuda?

Si tienes problemas:
1. Verifica que .NET 8 SDK esté instalado
2. Asegúrate de estar en la rama correcta (`copilot/create-ping-app`)
3. Intenta eliminar la carpeta y clonar nuevamente
4. Revisa la documentación completa en [INDEX.md](INDEX.md)

---

**Última actualización**: 2026-02-16  
**Versión actual**: Incluye gráficas visibles, reportes CSV/TXT y feedback de usuario
