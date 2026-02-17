# Generación de Ejecutables para Múltiples Plataformas

Este documento explica cómo generar ejecutables de la aplicación PingMonitor para diferentes plataformas y sistemas operativos.

## ⚠️ IMPORTANTE: Ubicación de los Scripts

Los scripts de compilación automatizados (`build-all-platforms.sh` y `build-all-platforms.bat`) están ubicados en la rama **`copilot/discuss-executable-creation`**, NO en la rama `main`.

**Si obtienes el error "no such file or directory":**
1. Verifica tu rama actual: `git branch`
2. Cambia a la rama correcta: `git checkout copilot/discuss-executable-creation`
3. O clona directamente esta rama: `git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git`

---

## 📋 Tabla de Contenidos

- [¿Qué son los Ejecutables?](#qué-son-los-ejecutables)
- [Plataformas Soportadas](#plataformas-soportadas)
- [Métodos de Generación](#métodos-de-generación)
- [Guía de Uso](#guía-de-uso)
- [Distribución de Ejecutables](#distribución-de-ejecutables)
- [Preguntas Frecuentes](#preguntas-frecuentes)

---

## 🎯 ¿Qué son los Ejecutables?

Los **ejecutables** son archivos binarios que se pueden ejecutar directamente en un sistema operativo sin necesidad de instalar el SDK de .NET. Son versiones "auto-contenidas" (self-contained) de la aplicación que incluyen:

- El código compilado de la aplicación
- El runtime de .NET necesario
- Todas las bibliotecas y dependencias requeridas

**Ventajas:**
- ✅ No requieren instalación de .NET en el equipo destino
- ✅ Ejecutables independientes y portátiles
- ✅ Fácil distribución a usuarios finales
- ✅ Compatibilidad garantizada con la versión específica de .NET

**Desventajas:**
- ⚠️ Tamaño de archivo más grande (incluyen el runtime de .NET)
- ⚠️ Ejecutable específico para cada plataforma y arquitectura

---

## 💻 Plataformas Soportadas

La aplicación PingMonitor puede generar ejecutables para las siguientes plataformas:

| Plataforma | Runtime ID | Sistema Operativo | Arquitectura |
|------------|-----------|-------------------|--------------|
| **Windows** | `win-x64` | Windows 7+ | x64 (64-bit) |
| **Linux** | `linux-x64` | Distribuciones Linux modernas | x64 (64-bit) |
| **macOS Intel** | `osx-x64` | macOS 10.12+ | Intel x64 |
| **macOS Apple Silicon** | `osx-arm64` | macOS 11.0+ | Apple M1/M2/M3 |

---

## 🛠️ Métodos de Generación

### Método 1: Script Automatizado (Recomendado)

#### En Windows:
```cmd
build-all-platforms.bat
```

#### En Linux/macOS:
```bash
./build-all-platforms.sh
```

Este script compilará automáticamente ejecutables para **todas las plataformas** y los colocará en:
- `PingMonitor/bin/Release/net8.0/win-x64/publish/`
- `PingMonitor/bin/Release/net8.0/linux-x64/publish/`
- `PingMonitor/bin/Release/net8.0/osx-x64/publish/`
- `PingMonitor/bin/Release/net8.0/osx-arm64/publish/`

### Método 2: Compilación Manual

#### Windows (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

#### Linux (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true
```

#### macOS Intel (x64):
```bash
cd PingMonitor
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true
```

#### macOS Apple Silicon (ARM64):
```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
```

### Método 3: GitHub Actions (Automatización CI/CD)

Los ejecutables se generan automáticamente cuando:

1. **Se crea una etiqueta de versión** (por ejemplo: `v1.0.0`):
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

2. **Se ejecuta manualmente el workflow** desde GitHub Actions:
   - Ve a la pestaña "Actions" en GitHub
   - Selecciona "Build Multi-Platform Executables"
   - Haz clic en "Run workflow"

El workflow creará automáticamente:
- Archivos comprimidos para cada plataforma
- Un release en GitHub con todos los ejecutables
- Artefactos descargables para 30 días

---

## 📖 Guía de Uso

### Requisitos Previos

1. **.NET 8.0 SDK** instalado:
   ```bash
   dotnet --version
   # Debe mostrar 8.0.x o superior
   ```

2. **Acceso de lectura/escritura** en el directorio del proyecto

### Generar Ejecutables Localmente

1. **Clona el repositorio** (si aún no lo has hecho):
   ```bash
   git clone https://github.com/xtremevice/pingCkeck_IA.git
   cd pingCkeck_IA
   ```

2. **Ejecuta el script de compilación**:
   
   En Windows:
   ```cmd
   build-all-platforms.bat
   ```
   
   En Linux/macOS:
   ```bash
   ./build-all-platforms.sh
   ```

3. **Encuentra los ejecutables** en:
   ```
   PingMonitor/bin/Release/net8.0/{runtime-id}/publish/
   ```

### Ejecutar un Ejecutable

#### Windows:
```cmd
PingMonitor\bin\Release\net8.0\win-x64\publish\PingMonitor.exe
```

#### Linux:
```bash
cd PingMonitor/bin/Release/net8.0/linux-x64/publish/
chmod +x PingMonitor
./PingMonitor
```

#### macOS:
```bash
cd PingMonitor/bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

---

## 📦 Distribución de Ejecutables

### Opción 1: Releases de GitHub (Recomendado)

1. Crea una etiqueta de versión:
   ```bash
   git tag -a v1.0.0 -m "Release version 1.0.0"
   git push origin v1.0.0
   ```

2. GitHub Actions creará automáticamente un release con:
   - `PingMonitor-windows-x64.zip`
   - `PingMonitor-linux-x64.tar.gz`
   - `PingMonitor-macos-intel.tar.gz`
   - `PingMonitor-macos-arm64.tar.gz`

3. Los usuarios pueden descargar el archivo correspondiente a su plataforma desde la sección "Releases"

### Opción 2: Distribución Manual

1. Genera los ejecutables usando el script
2. Comprime la carpeta `publish/` correspondiente:
   - Windows: Crear archivo `.zip`
   - Linux/macOS: Crear archivo `.tar.gz`
3. Distribuye los archivos comprimidos a los usuarios

### Opción 3: Instaladores Nativos (Avanzado)

Para crear instaladores nativos más profesionales:

- **Windows**: Usa [WiX Toolset](https://wixtoolset.org/) o [Inno Setup](https://jrsoftware.org/isinfo.php)
- **macOS**: Crea un `.app` bundle o usa [create-dmg](https://github.com/create-dmg/create-dmg)
- **Linux**: Genera paquetes `.deb`, `.rpm`, o [AppImage](https://appimage.org/)

---

## ❓ Preguntas Frecuentes

### ¿Por qué los ejecutables son tan grandes?

Los ejecutables auto-contenidos incluyen el runtime completo de .NET (~50-70 MB por plataforma). Si el tamaño es un problema, puedes:

1. **Usar compilación dependiente del framework** (framework-dependent):
   ```bash
   dotnet publish -c Release -r win-x64
   ```
   Esto requiere que .NET esté instalado en el equipo destino pero reduce el tamaño considerablemente.

2. **Habilitar el recorte (trimming)** para reducir el tamaño:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained -p:PublishTrimmed=true
   ```
   ⚠️ Advertencia: El recorte puede causar problemas en algunas aplicaciones.

### ¿Puedo compilar para una plataforma desde otra?

Sí, .NET permite **compilación cruzada** (cross-compilation). Por ejemplo, puedes compilar ejecutables de macOS desde Windows:

```bash
dotnet publish -c Release -r osx-arm64 --self-contained
```

Sin embargo, **no podrás probar** el ejecutable en una plataforma diferente.

### ¿Qué significa "self-contained"?

"Self-contained" (auto-contenido) significa que el ejecutable incluye:
- El código de la aplicación
- El runtime de .NET
- Todas las bibliotecas necesarias

El usuario no necesita tener .NET instalado.

### ¿Cómo actualizo un ejecutable distribuido?

1. **Método manual**: Los usuarios descargan la nueva versión y reemplazan el ejecutable viejo
2. **Actualización automática**: Implementa un sistema de auto-actualización en la aplicación (requiere desarrollo adicional)
3. **Releases de GitHub**: Los usuarios pueden verificar y descargar nuevas versiones desde la página de Releases

### ¿Los ejecutables son seguros?

Los ejecutables generados son tan seguros como el código fuente. Sin embargo:

- ✅ Los ejecutables oficiales de GitHub Actions están verificados
- ⚠️ Los usuarios deben descargar solo de fuentes confiables
- 💡 Considera firmar digitalmente los ejecutables para distribución empresarial

---

## 🔧 Solución de Problemas

### Error: ".NET SDK no está instalado"

**Solución**: Instala .NET 8.0 SDK desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

### Error: "Permission denied" en Linux/macOS

**Solución**: Da permisos de ejecución:
```bash
chmod +x PingMonitor
```

### El ejecutable no se abre en macOS

**Solución**: macOS puede bloquear aplicaciones no firmadas. Ejecuta:
```bash
xattr -cr PingMonitor
```

O ve a "Configuración del Sistema" > "Privacidad y Seguridad" y permite la aplicación.

---

## 📚 Recursos Adicionales

- [Documentación oficial de .NET Publishing](https://docs.microsoft.com/en-us/dotnet/core/deploying/)
- [Runtime Identifiers (RID) Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)
- [PUBLISHING.md](PUBLISHING.md) - Instrucciones básicas de publicación
- [GitHub Actions Workflow](.github/workflows/build-release.yml) - Configuración de CI/CD

---

## 💡 Próximos Pasos

Una vez que tengas los ejecutables generados:

1. **Prueba** cada ejecutable en su plataforma correspondiente
2. **Documenta** cualquier requisito especial (permisos, dependencias del sistema)
3. **Crea un Release** en GitHub para distribución pública
4. **Actualiza el README** con instrucciones de descarga para usuarios finales

---

¿Tienes más preguntas? Abre un [Issue en GitHub](https://github.com/xtremevice/pingCkeck_IA/issues) para obtener ayuda.
