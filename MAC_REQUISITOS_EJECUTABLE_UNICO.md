# 🍎 Mac: Requisitos para Generar un Ejecutable de Un Solo Archivo

Esta guía explica **qué se necesita en Mac** para generar un ejecutable que sea **un solo archivo** (single-file executable) de la aplicación PingMonitor.

---

## 📋 Tabla de Contenidos

- [¿Qué es un Ejecutable de Un Solo Archivo?](#qué-es-un-ejecutable-de-un-solo-archivo)
- [Requisitos del Sistema Mac](#requisitos-del-sistema-mac)
- [Requisitos de Software](#requisitos-de-software)
- [Cómo Generar el Ejecutable](#cómo-generar-el-ejecutable)
- [Características del Ejecutable Generado](#características-del-ejecutable-generado)
- [Consideraciones Específicas de Mac](#consideraciones-específicas-de-mac)
- [Solución de Problemas](#solución-de-problemas)

---

## 🎯 ¿Qué es un Ejecutable de Un Solo Archivo?

Un **ejecutable de un solo archivo** (single-file executable) es:

- ✅ **Un único archivo binario** que contiene todo lo necesario para ejecutar la aplicación
- ✅ **Auto-contenido**: Incluye el runtime de .NET y todas las dependencias
- ✅ **No requiere instalación**: Solo copiar y ejecutar
- ✅ **Portátil**: Se puede mover a cualquier Mac compatible sin instalar nada más

**Ejemplo:** En lugar de tener múltiples archivos (DLLs, archivos de configuración, etc.), tienes solo:
```
PingMonitor  <-- Un solo archivo ejecutable
```

---

## 💻 Requisitos del Sistema Mac

### Para Mac con Apple Silicon (M1, M2, M3, M4):

| Requisito | Especificación |
|-----------|---------------|
| **Procesador** | Apple M1, M2, M3, M4 (ARM64) |
| **Sistema Operativo** | macOS 11.0 Big Sur o superior |
| **Arquitectura** | ARM64 (Apple Silicon) |
| **Espacio en Disco** | ~500 MB para compilación, ~80-90 MB para ejecutable final |
| **Memoria RAM** | Mínimo 4 GB (8 GB recomendado) |

### Para Mac con Procesador Intel:

| Requisito | Especificación |
|-----------|---------------|
| **Procesador** | Intel x64 (64-bit) |
| **Sistema Operativo** | macOS 10.12 Sierra o superior |
| **Arquitectura** | x64 (Intel) |
| **Espacio en Disco** | ~500 MB para compilación, ~80-90 MB para ejecutable final |
| **Memoria RAM** | Mínimo 4 GB (8 GB recomendado) |

---

## 🛠️ Requisitos de Software

### 1. .NET 8 SDK (OBLIGATORIO)

El SDK de .NET 8 es **absolutamente necesario** para generar ejecutables de un solo archivo.

#### Para Apple Silicon (M1/M2/M3/M4):
```bash
# Descargar desde:
# https://dotnet.microsoft.com/download/dotnet/8.0
# Seleccionar: "macOS ARM64 Installer"
```

#### Para Intel Mac:
```bash
# Descargar desde:
# https://dotnet.microsoft.com/download/dotnet/8.0
# Seleccionar: "macOS x64 Installer"
```

#### Verificar Instalación:
```bash
dotnet --version
```

**Salida esperada:** `8.0.xxx` o superior

**Si no está instalado:**
1. Ve a https://dotnet.microsoft.com/download/dotnet/8.0
2. Descarga el instalador apropiado para tu Mac
3. Ejecuta el instalador PKG
4. Reinicia la Terminal
5. Verifica con `dotnet --version`

### 2. Git (Opcional pero Recomendado)

Para clonar el repositorio:

```bash
# Verificar si está instalado
git --version
```

Si no está instalado, macOS te pedirá instalarlo automáticamente.

### 3. Terminal o Símbolo del Sistema

Usa la Terminal incluida en macOS:
- Aplicaciones → Utilidades → Terminal
- O presiona `Cmd + Espacio` y escribe "Terminal"

---

## 🚀 Cómo Generar el Ejecutable

### Método 1: Comando Manual (Recomendado para Aprender)

#### Para Mac con Apple Silicon:

```bash
# 1. Navegar al directorio del proyecto
cd /ruta/a/pingCkeck_IA/PingMonitor

# 2. Generar el ejecutable de un solo archivo
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true

# 3. El ejecutable estará en:
# bin/Release/net8.0/osx-arm64/publish/PingMonitor
```

#### Para Mac con Intel:

```bash
# 1. Navegar al directorio del proyecto
cd /ruta/a/pingCkeck_IA/PingMonitor

# 2. Generar el ejecutable de un solo archivo
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true

# 3. El ejecutable estará en:
# bin/Release/net8.0/osx-x64/publish/PingMonitor
```

### Método 2: Script Automatizado

El repositorio incluye un script que genera ejecutables para todas las plataformas:

```bash
# Desde el directorio raíz del repositorio
./build-all-platforms.sh
```

Este script automáticamente:
- ✅ Detecta tu versión de .NET
- ✅ Compila para todas las plataformas (Windows, Linux, macOS Intel, macOS Apple Silicon)
- ✅ Genera ejecutables de un solo archivo para cada plataforma
- ✅ Configura los permisos de ejecución correctamente

---

## 📊 Características del Ejecutable Generado

### Tamaño del Archivo

| Plataforma | Tamaño Aproximado |
|------------|-------------------|
| **macOS Apple Silicon** | 70-85 MB |
| **macOS Intel** | 70-85 MB |

**¿Por qué tan grande?**
- Incluye el runtime completo de .NET 8
- Incluye todas las bibliotecas de Avalonia UI
- Incluye todas las dependencias del proyecto
- Es **auto-contenido**: no necesita .NET instalado en la máquina destino

### Contenido del Ejecutable

El ejecutable de un solo archivo contiene:

```
PingMonitor (archivo único)
├─ Código compilado de la aplicación
├─ Runtime de .NET 8
├─ Bibliotecas de Avalonia UI
├─ Bibliotecas del sistema
└─ Recursos de la aplicación
```

### Ventajas

✅ **Un solo archivo**: Fácil de distribuir y mover
✅ **Auto-contenido**: No requiere .NET instalado en el equipo destino
✅ **Portátil**: Copiar y ejecutar en cualquier Mac compatible
✅ **Sin instalación**: No hay proceso de instalación
✅ **Versión específica**: El runtime de .NET está incluido y no cambiará

### Desventajas

⚠️ **Tamaño grande**: ~80 MB por la inclusión del runtime
⚠️ **Arranque inicial**: Ligeramente más lento en el primer inicio
⚠️ **Específico de plataforma**: Un ejecutable para Mac no funciona en Windows/Linux

---

## 🍎 Consideraciones Específicas de Mac

### 1. Permisos de Ejecución

Después de generar el ejecutable, debes darle permisos de ejecución:

```bash
chmod +x PingMonitor
```

**Nota:** El script `build-all-platforms.sh` hace esto automáticamente.

### 2. Gatekeeper y Firma de Código

macOS tiene un sistema de seguridad llamado **Gatekeeper** que puede bloquear aplicaciones no firmadas.

**Síntoma:** Al intentar ejecutar, ves:
```
"PingMonitor" no se puede abrir porque es de un desarrollador no identificado
```

**Solución 1 - Remover Quarantine (Recomendado):**
```bash
xattr -d com.apple.quarantine PingMonitor
```

**Solución 2 - Abrir desde Menú Contextual:**
1. Haz clic derecho en el archivo
2. Selecciona "Abrir"
3. Confirma que deseas abrir la aplicación

**Solución 3 - Permitir en Preferencias del Sistema:**
1. Intenta abrir la aplicación (recibirás el error)
2. Ve a Preferencias del Sistema → Seguridad y Privacidad
3. En la pestaña "General", haz clic en "Abrir de todos modos"

### 3. Eliminar Atributos de Cuarentena

Si descargaste el ejecutable de internet o lo copiaste desde un disco externo:

```bash
# Remover todos los atributos de cuarentena
xattr -cr PingMonitor

# O solo el atributo específico
xattr -d com.apple.quarantine PingMonitor
```

### 4. Firmar Código (Opcional para Distribución)

Si planeas distribuir la aplicación a otros usuarios:

```bash
# Requiere cuenta de desarrollador de Apple
codesign --force --deep --sign "Developer ID Application: Tu Nombre" PingMonitor
```

**Nota:** Para uso personal, no es necesario firmar el código.

### 5. Crear un App Bundle (.app) - Opcional

Puedes crear un paquete .app para que la aplicación se vea más "nativa":

```bash
# Crear estructura de app bundle
mkdir -p PingMonitor.app/Contents/MacOS
mkdir -p PingMonitor.app/Contents/Resources

# Copiar el ejecutable
cp PingMonitor PingMonitor.app/Contents/MacOS/

# Crear Info.plist
cat > PingMonitor.app/Contents/Info.plist << 'EOF'
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleExecutable</key>
    <string>PingMonitor</string>
    <key>CFBundleIdentifier</key>
    <string>com.pingmonitor.app</string>
    <key>CFBundleName</key>
    <string>PingMonitor</string>
    <key>CFBundleVersion</key>
    <string>1.0</string>
    <key>LSMinimumSystemVersion</key>
    <string>11.0</string>
</dict>
</plist>
EOF

# Ahora puedes abrir PingMonitor.app desde Finder
```

---

## ❓ Solución de Problemas

### Error: "dotnet: command not found"

**Causa:** .NET SDK no está instalado o no está en el PATH.

**Solución:**
```bash
# Verificar instalación
which dotnet

# Si no aparece nada, reinstala .NET 8 SDK
# Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0
```

Después de instalar, reinicia la Terminal.

### Error: "The framework 'Microsoft.NETCore.App' version '8.0.x' was not found"

**Causa:** Versión incorrecta o faltante de .NET.

**Solución:**
```bash
# Ver versiones instaladas
dotnet --list-sdks

# Debe aparecer una versión 8.0.x
# Si no, descarga e instala .NET 8 SDK
```

### Error: "Architecture mismatch" o el ejecutable no funciona

**Causa:** Compilaste para la arquitectura incorrecta.

**Solución:**
```bash
# Verificar tu arquitectura
uname -m

# Si ves "arm64" -> Usas Apple Silicon
# Si ves "x86_64" -> Usas Intel

# Compila para la arquitectura correcta:
# Apple Silicon: -r osx-arm64
# Intel: -r osx-x64
```

### El ejecutable es muy grande (>100 MB)

**Causa:** Esto es normal para ejecutables auto-contenidos.

**Opciones:**
1. **Aceptar el tamaño**: Es el costo de no requerir .NET instalado
2. **Usar PublishTrimmed**: Reduce tamaño pero puede causar problemas
   ```bash
   dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=true
   ```
3. **Distribución framework-dependent**: Requiere .NET instalado pero es más pequeña (~2-5 MB)
   ```bash
   dotnet publish -c Release -r osx-arm64 -p:PublishSingleFile=true
   # (sin --self-contained)
   ```

### El ejecutable no se abre en otro Mac

**Posibles causas:**
1. **Arquitectura incorrecta**: Mac Intel vs Apple Silicon
2. **Versión de macOS**: Verifica requisitos mínimos
3. **Atributos de cuarentena**: Usa `xattr -cr PingMonitor` en el otro Mac

**Verificación:**
```bash
# En el otro Mac, verificar arquitectura
file PingMonitor

# Debería decir:
# Para Apple Silicon: "Mach-O 64-bit executable arm64"
# Para Intel: "Mach-O 64-bit executable x86_64"
```

### Error: "Permission denied"

**Causa:** El archivo no tiene permisos de ejecución.

**Solución:**
```bash
chmod +x PingMonitor
./PingMonitor
```

### Error al compilar: "Project file does not exist"

**Causa:** No estás en el directorio correcto.

**Solución:**
```bash
# Navegar al directorio del proyecto
cd /ruta/a/pingCkeck_IA/PingMonitor

# Verificar que estás en el lugar correcto
ls PingMonitor.csproj
```

---

## 📚 Comparación: Single-File vs Framework-Dependent

### Ejecutable de Un Solo Archivo (Single-File, Self-Contained)

```bash
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
```

| Característica | Valor |
|---------------|-------|
| **Tamaño** | ~80 MB |
| **Requiere .NET instalado** | ❌ No |
| **Portabilidad** | ✅ Alta (copiar y ejecutar) |
| **Velocidad arranque** | ⚠️ Ligeramente más lento |
| **Actualizaciones .NET** | ❌ Manual (recompilar) |
| **Ideal para** | Distribución a usuarios finales |

### Framework-Dependent

```bash
dotnet publish -c Release -r osx-arm64 -p:PublishSingleFile=true
```

| Característica | Valor |
|---------------|-------|
| **Tamaño** | ~2-5 MB |
| **Requiere .NET instalado** | ✅ Sí (.NET 8) |
| **Portabilidad** | ⚠️ Media (necesita .NET) |
| **Velocidad arranque** | ✅ Más rápido |
| **Actualizaciones .NET** | ✅ Automáticas (del sistema) |
| **Ideal para** | Desarrollo y pruebas |

---

## 🎓 Comandos de Referencia Rápida

### Generar Ejecutable para Tu Mac

**Apple Silicon (M1/M2/M3/M4):**
```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
chmod +x bin/Release/net8.0/osx-arm64/publish/PingMonitor
```

**Intel Mac:**
```bash
cd PingMonitor
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true
chmod +x bin/Release/net8.0/osx-x64/publish/PingMonitor
```

### Ejecutar el Ejecutable

```bash
# Navegar a la ubicación
cd bin/Release/net8.0/osx-arm64/publish/  # o osx-x64

# Remover cuarentena si es necesario
xattr -d com.apple.quarantine PingMonitor

# Ejecutar
./PingMonitor
```

### Verificar Requisitos

```bash
# Verificar .NET
dotnet --version

# Verificar arquitectura del Mac
uname -m

# Verificar versión de macOS
sw_vers
```

---

## ✅ Checklist de Requisitos

Antes de generar el ejecutable, verifica:

- [ ] macOS 11.0+ (Apple Silicon) o 10.12+ (Intel)
- [ ] .NET 8 SDK instalado (`dotnet --version` muestra 8.0.x)
- [ ] Repositorio clonado en tu Mac
- [ ] Terminal abierta
- [ ] ~500 MB de espacio libre en disco
- [ ] Conoces tu arquitectura (Intel o Apple Silicon)

---

## 🔗 Documentación Relacionada

- **[GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)** - Guía completa de generación para todas las plataformas
- **[MAC_SILICON_BUILD_ALL.md](MAC_SILICON_BUILD_ALL.md)** - Guía para compilar todas las plataformas desde Mac
- **[QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)** - Inicio rápido para Mac
- **[EXECUTABLE_GENERATION.md](EXECUTABLE_GENERATION.md)** - Guía en inglés

---

**Última actualización:** 2026-02-17  
**Versión del documento:** 1.0  
**Compatible con:** .NET 8.0, macOS 10.12+, Apple Silicon (M1/M2/M3/M4)
