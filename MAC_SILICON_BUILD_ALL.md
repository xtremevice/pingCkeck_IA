# 🚀 Mac Silicon: Obtener Última Versión y Generar Ejecutables para Todas las Plataformas

Esta guía te muestra cómo **obtener la última versión** del código y **generar ejecutables para todas las plataformas** (Windows, Linux, macOS Intel y macOS Apple Silicon) desde tu Mac Silicon (Apple M1/M2/M3).

---

## 📋 Tabla de Contenidos

- [Requisitos Previos](#requisitos-previos)
- [Comando Completo (Todo en Uno)](#comando-completo-todo-en-uno)
- [Comandos Paso a Paso](#comandos-paso-a-paso)
- [Ubicación de los Ejecutables](#ubicación-de-los-ejecutables)
- [Actualizar y Regenerar](#actualizar-y-regenerar)
- [Solución de Problemas](#solución-de-problemas)

---

## 🔧 Requisitos Previos

Antes de comenzar, asegúrate de tener:

### 1. .NET 8 SDK Instalado

```bash
# Verificar si está instalado
dotnet --version
```

Debe mostrar `8.0.xxx` o superior.

**Si no está instalado:**
- Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0
- Selecciona: **macOS ARM64** (para Apple Silicon)

### 2. Git Instalado

```bash
# Verificar si está instalado
git --version
```

Si no está instalado, se instalará automáticamente al intentar usarlo por primera vez en macOS.

### 3. Repositorio Clonado EN LA RAMA CORRECTA ⚠️

**MUY IMPORTANTE:** El script `build-all-platforms.sh` está en la rama `copilot/discuss-executable-creation`, NO en la rama `main`.

Si aún no has clonado el repositorio, **clona la rama correcta**:

```bash
cd ~/Desktop
# IMPORTANTE: Clonar la rama con los scripts de compilación
git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA
```

**Si ya clonaste desde main y obtienes "no such file or directory":**

```bash
cd ~/Desktop/pingCkeck_IA
# Cambiar a la rama correcta
git fetch origin copilot/discuss-executable-creation
git checkout copilot/discuss-executable-creation
# Ahora el script existe
ls build-all-platforms.sh
```

---

## ⚡ Comando Completo (Todo en Uno)

### ⚠️ Antes de Empezar - Verifica tu Ubicación

Si obtienes un error como `no such file or directory`, es porque no estás en el directorio correcto. Primero verifica:

```bash
# ¿Dónde está el repositorio?
find ~ -name "pingCkeck_IA" -type d 2>/dev/null | head -1

# O si sabes que está en el Desktop
ls ~/Desktop/pingCkeck_IA/build-all-platforms.sh
```

Si el comando anterior muestra la ruta del script, usa esa ubicación en los comandos siguientes.

### Si Ya Tienes el Repositorio Clonado:

**Opción A - Si está en el Desktop Y en la rama correcta:**
```bash
cd ~/Desktop/pingCkeck_IA && git checkout copilot/discuss-executable-creation && git pull && ./build-all-platforms.sh
```

**Opción B - Si clonaste en otra ubicación:**
```bash
# Reemplaza /tu/ruta con la ubicación real del repositorio
cd /tu/ruta/pingCkeck_IA && git checkout copilot/discuss-executable-creation && git pull && ./build-all-platforms.sh
```

**Opción C - Si no sabes dónde está:**
```bash
# Este comando encuentra y entra al repositorio automáticamente
cd $(find ~ -name "pingCkeck_IA" -type d 2>/dev/null | head -1) && git checkout copilot/discuss-executable-creation && git pull && ./build-all-platforms.sh
```

### Si Es tu Primera Vez:

**⚠️ IMPORTANTE: Debes clonar la rama correcta que contiene los scripts de compilación:**

```bash
cd ~/Desktop && git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git && cd pingCkeck_IA && ./build-all-platforms.sh
```

**Nota:** El comando incluye `-b copilot/discuss-executable-creation` para clonar la rama que contiene `build-all-platforms.sh`.

**¡Eso es todo!** El script generará ejecutables para:
- ✅ Windows (x64)
- ✅ Linux (x64)
- ✅ macOS Intel (x64)
- ✅ macOS Apple Silicon (ARM64)

---

## 📝 Comandos Paso a Paso

Si prefieres ejecutar los comandos uno por uno para entender el proceso:

### 0. Verificar que Tienes el Repositorio (Importante ⚠️)

**Antes de continuar, verifica que el repositorio existe:**

```bash
# Verificar si el repositorio está en el Desktop
ls ~/Desktop/pingCkeck_IA

# O buscar el repositorio en todo el sistema
find ~ -name "pingCkeck_IA" -type d 2>/dev/null
```

Si no existe, primero **clónalo**:
```bash
cd ~/Desktop
git clone https://github.com/xtremevice/pingCkeck_IA.git
```

### 1. Navegar al Directorio del Repositorio

```bash
cd ~/Desktop/pingCkeck_IA
```

**Verificar que estás en el lugar correcto:**
```bash
# Este comando debe mostrar el script
ls build-all-platforms.sh

# Si ves "build-all-platforms.sh", estás en el lugar correcto ✅
```

### 2. Obtener la Última Versión

```bash
git pull
```

Este comando descarga todos los cambios más recientes del repositorio.

**Salida esperada:**
```
Already up to date.
```
O mostrará los archivos actualizados si hay cambios.

### 3. Generar Ejecutables para Todas las Plataformas

```bash
./build-all-platforms.sh
```

**Si obtienes "no such file or directory"**, significa que no estás en el directorio correcto. Vuelve al paso 0 y 1.

**¿Qué hace este script?**
1. Verifica que .NET SDK esté instalado
2. Limpia compilaciones anteriores
3. Compila para Windows (x64)
4. Compila para Linux (x64)
5. Compila para macOS Intel (x64)
6. Compila para macOS Apple Silicon (ARM64)
7. Configura permisos de ejecución para sistemas Unix
8. Muestra la ubicación de cada ejecutable

**Tiempo estimado:** 5-10 minutos dependiendo de tu Mac.

---

## 📦 Ubicación de los Ejecutables

Después de ejecutar el script, los ejecutables estarán en:

```
PingMonitor/bin/Release/net8.0/
├── win-x64/publish/
│   └── PingMonitor.exe          ← Windows (70-85 MB)
├── linux-x64/publish/
│   └── PingMonitor              ← Linux (70-85 MB)
├── osx-x64/publish/
│   └── PingMonitor              ← macOS Intel (70-85 MB)
└── osx-arm64/publish/
    └── PingMonitor              ← macOS Apple Silicon (70-85 MB)
```

### Acceso Rápido a los Ejecutables:

```bash
# Windows
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/win-x64/publish/

# Linux
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/linux-x64/publish/

# macOS Intel
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-x64/publish/

# macOS Apple Silicon (tu plataforma)
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
```

### Ejecutar en tu Mac Silicon:

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
./PingMonitor
```

---

## 🔄 Actualizar y Regenerar

Cuando quieras obtener la última versión y regenerar los ejecutables:

### Comando Rápido:

```bash
cd ~/Desktop/pingCkeck_IA && git pull && ./build-all-platforms.sh
```

### Desglosado:

```bash
# 1. Ir al directorio
cd ~/Desktop/pingCkeck_IA

# 2. Obtener últimos cambios
git pull

# 3. Regenerar todos los ejecutables
./build-all-platforms.sh
```

**Nota:** Si hubo cambios en el código, el script tardará unos minutos en recompilar todo.

---

## 🔍 Verificar que Todo Está Actualizado

Antes de generar ejecutables, puedes verificar el estado:

```bash
cd ~/Desktop/pingCkeck_IA

# Ver rama actual
git branch

# Ver últimos commits
git log --oneline -5

# Ver si hay cambios remotos
git fetch
git status
```

---

## 🎯 Solo Actualizar Sin Compilar

Si solo quieres obtener la última versión sin compilar:

```bash
cd ~/Desktop/pingCkeck_IA
git pull
```

---

## 📊 Salida del Script

Cuando ejecutes `./build-all-platforms.sh`, verás:

```
=========================================
PingMonitor - Multi-Platform Build Script
=========================================

Using .NET version:
8.0.xxx

Cleaning previous builds...

Building for all platforms...

[1/4] Building for Windows (x64)...
✓ Build complete: bin/Release/net8.0/win-x64/publish/

[2/4] Building for Linux (x64)...
✓ Build complete: bin/Release/net8.0/linux-x64/publish/

[3/4] Building for macOS Intel (x64)...
✓ Build complete: bin/Release/net8.0/osx-x64/publish/

[4/4] Building for macOS Apple Silicon (ARM64)...
✓ Build complete: bin/Release/net8.0/osx-arm64/publish/

=========================================
All builds completed successfully!
=========================================
```

---

## ❓ Solución de Problemas

### Error: "no such file or directory: ./build-all-platforms.sh"

**🚨 CAUSA MÁS COMÚN:** Clonaste desde la rama `main` que NO contiene los scripts de compilación.

**Solución 0 - Verificar y cambiar a la rama correcta (MÁS COMÚN):**
```bash
# Verificar en qué rama estás
git branch

# Si ves "* main" o no ves "copilot/discuss-executable-creation", necesitas cambiar:
git fetch origin copilot/discuss-executable-creation
git checkout copilot/discuss-executable-creation

# Ahora verifica que el script existe
ls -la build-all-platforms.sh

# Si lo ves, ejecuta
./build-all-platforms.sh
```

**Causa alternativa:** Estás en el directorio incorrecto o el repositorio no está clonado.

**Solución 1 - Verificar ubicación del repositorio:**
```bash
# Buscar el repositorio en tu sistema
find ~ -name "build-all-platforms.sh" -type f 2>/dev/null

# O buscar la carpeta del repositorio
find ~ -name "pingCkeck_IA" -type d 2>/dev/null
```

**Solución 2 - Navegar al directorio correcto:**
```bash
# Si clonaste en el Desktop (ubicación recomendada)
cd ~/Desktop/pingCkeck_IA

# Verificar que estás en el lugar correcto
ls -la build-all-platforms.sh

# Si el archivo existe, ahora puedes ejecutar
./build-all-platforms.sh
```

**Solución 3 - Si clonaste en otra ubicación:**
```bash
# Reemplaza /ruta/a/tu con la ruta real donde clonaste
cd /ruta/a/tu/pingCkeck_IA
./build-all-platforms.sh
```

**Solución 4 - Si el repositorio no está clonado o clonaste la rama incorrecta:**
```bash
# Clonar la rama correcta con los scripts de compilación
cd ~/Desktop
git clone -b copilot/discuss-executable-creation https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA
ls build-all-platforms.sh  # Verificar que existe
./build-all-platforms.sh
```

**Verificación rápida - ¿Estás en la rama correcta?**
```bash
# Ver rama actual (debe mostrar "copilot/discuss-executable-creation")
git branch

# Este comando debe mostrar el script
ls -la build-all-platforms.sh

# Este comando debe mostrar "pingCkeck_IA"
basename $(pwd)
```

### Error: "Permission denied" al ejecutar el script

**Solución:**
```bash
chmod +x build-all-platforms.sh
./build-all-platforms.sh
```

### Error: "dotnet: command not found"

**Causa:** .NET SDK no está instalado o no está en el PATH.

**Solución:**
1. Instala .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0
2. Reinicia la Terminal
3. Verifica: `dotnet --version`

### Error: "git: command not found"

**Solución:**
```bash
xcode-select --install
```

### Error al ejecutar: "developer cannot be verified"

**Causa:** macOS bloquea aplicaciones no firmadas.

**Solución:**
```bash
# Para el ejecutable de Mac Silicon
xattr -cr ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/PingMonitor

# O si estás en el directorio del ejecutable
xattr -cr PingMonitor
```

Luego intenta ejecutar de nuevo.

### Error: "fatal: not a git repository"

**Causa:** No estás en el directorio correcto del repositorio.

**Solución:**
```bash
cd ~/Desktop/pingCkeck_IA
git status
```

Si no existe, clona de nuevo:
```bash
cd ~/Desktop
git clone https://github.com/xtremevice/pingCkeck_IA.git
```

### El script tarda mucho tiempo

**Es normal.** La compilación para 4 plataformas puede tardar 5-10 minutos en un Mac Silicon, dependiendo del modelo (M1/M2/M3) y otros procesos en ejecución.

**Salida esperada:**
- Windows: ~2-3 minutos
- Linux: ~2-3 minutos  
- macOS Intel: ~2-3 minutos
- macOS Apple Silicon: ~1-2 minutos

### Solo quiero compilar para Mac Silicon

Si no necesitas los ejecutables de Windows y Linux:

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
cd bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

Ver: [COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md) para más opciones solo de Mac.

---

## 🎓 Comandos de Referencia Rápida

### ⚠️ Nota Importante
Estos comandos asumen que el repositorio está en `~/Desktop/pingCkeck_IA`. Si lo clonaste en otra ubicación, reemplaza `~/Desktop/pingCkeck_IA` con tu ruta real.

**Encontrar tu repositorio:**
```bash
# Buscar el repositorio
find ~ -name "pingCkeck_IA" -type d 2>/dev/null | head -1

# Guardar la ruta en una variable para uso fácil
REPO_PATH=$(find ~ -name "pingCkeck_IA" -type d 2>/dev/null | head -1)
cd "$REPO_PATH"
```

### Actualizar y Compilar Todo
```bash
cd ~/Desktop/pingCkeck_IA && git pull && ./build-all-platforms.sh
```

### Solo Actualizar
```bash
cd ~/Desktop/pingCkeck_IA && git pull
```

### Solo Compilar (sin actualizar)
```bash
cd ~/Desktop/pingCkeck_IA && ./build-all-platforms.sh
```

### Ejecutar la App (Mac Silicon)
```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/ && ./PingMonitor
```

### Ver Estado del Repositorio
```bash
cd ~/Desktop/pingCkeck_IA && git status
```

### Ver Últimos Cambios
```bash
cd ~/Desktop/pingCkeck_IA && git log --oneline -10
```

### Verificar que Estás en el Directorio Correcto
```bash
# Debe mostrar "pingCkeck_IA"
basename $(pwd)

# Debe mostrar el script
ls build-all-platforms.sh
```

---

## 📚 Documentación Relacionada

- **[GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)** - Guía completa sobre generación de ejecutables
- **[COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md)** - Comandos específicos solo para Mac Silicon
- **[QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)** - Inicio rápido para Mac
- **[MAC_SILICON_ES.md](MAC_SILICON_ES.md)** - Guía detallada para Mac Silicon
- **[ACTUALIZAR.md](ACTUALIZAR.md)** - Comandos de actualización para todas las plataformas
- **[README.md](README.md)** - Documentación principal

---

## 💡 Casos de Uso Comunes

### 1. Primera Instalación y Compilación

```bash
cd ~/Desktop && \
git clone https://github.com/xtremevice/pingCkeck_IA.git && \
cd pingCkeck_IA && \
./build-all-platforms.sh
```

### 2. Actualización Diaria

```bash
cd ~/Desktop/pingCkeck_IA && git pull && ./build-all-platforms.sh
```

### 3. Solo Verificar Actualizaciones

```bash
cd ~/Desktop/pingCkeck_IA && git fetch && git status
```

### 4. Actualizar sin Recompilar

```bash
cd ~/Desktop/pingCkeck_IA && git pull
```

### 5. Recompilar sin Actualizar

```bash
cd ~/Desktop/pingCkeck_IA && ./build-all-platforms.sh
```

---

## 🚀 Siguiente Paso: Distribuir Ejecutables

Una vez que hayas generado los ejecutables, puedes:

1. **Copiar a USB/Disco Externo** para distribuir a otros usuarios
2. **Compartir por Correo/Cloud** (comprimir primero)
3. **Crear Release en GitHub** usando GitHub Actions (ver [GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md))

### Comprimir Ejecutables:

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0

# Windows
zip -r PingMonitor-Windows.zip win-x64/publish/

# Linux
tar -czf PingMonitor-Linux.tar.gz linux-x64/publish/

# macOS Intel
tar -czf PingMonitor-macOS-Intel.tar.gz osx-x64/publish/

# macOS Apple Silicon
tar -czf PingMonitor-macOS-ARM64.tar.gz osx-arm64/publish/
```

---

## ✅ Checklist de Verificación

Después de ejecutar los comandos, verifica:

- [ ] .NET SDK instalado (`dotnet --version`)
- [ ] Repositorio clonado en `~/Desktop/pingCkeck_IA`
- [ ] `git pull` ejecutado sin errores
- [ ] `./build-all-platforms.sh` ejecutado exitosamente
- [ ] 4 carpetas de publicación creadas en `PingMonitor/bin/Release/net8.0/`
- [ ] Ejecutables presentes en cada carpeta `publish/`
- [ ] Ejecutable de Mac Silicon funciona: `./PingMonitor`

---

## 📞 ¿Necesitas Ayuda?

Si encuentras algún problema:

1. **Revisa la sección de Solución de Problemas** arriba
2. **Consulta la documentación completa** en [GENERAR_EJECUTABLES.md](GENERAR_EJECUTABLES.md)
3. **Abre un Issue** en GitHub: https://github.com/xtremevice/pingCkeck_IA/issues

---

**Última actualización:** 2026-02-17  
**Compatible con:** Mac Silicon (M1, M2, M3), macOS 11.0+, .NET 8.0+
