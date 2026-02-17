# Comandos Rápidos - Mac Silicon

## 💡 ¿Quieres Compilar para TODAS las Plataformas?

Si necesitas generar ejecutables para **Windows, Linux, macOS Intel Y macOS Apple Silicon** desde tu Mac, ve a:

**👉 [MAC_SILICON_BUILD_ALL.md](MAC_SILICON_BUILD_ALL.md)**

**Comando rápido para compilar todas las plataformas:**
```bash
cd ~/Desktop/pingCkeck_IA && git pull && ./build-all-platforms.sh
```

---

## ⚠️ ¿Solo ves el archivo README?

Si solo descargaste el README, necesitas clonar la rama correcta. Ver: [DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md)

## Instalación Rápida (Copia y Pega)

```bash
# 1. Clonar el repositorio (RAMA CORRECTA!)
cd ~/Desktop
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA/PingMonitor

# 2. Publicar para Mac Silicon
dotnet publish -c Release -r osx-arm64 --self-contained

# 3. Ir a la carpeta de publicación y ejecutar
cd bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

## Ejecución Rápida (si ya está instalado)

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
./PingMonitor
```

## Requisito

Instala .NET 8 SDK primero: https://dotnet.microsoft.com/download/dotnet/8.0 (macOS ARM64)

## Verificar Instalación

```bash
dotnet --version  # Debe mostrar 8.0.xxx
```

## Solución Rápida de Problemas

### Si obtienes "no such file or directory: ./build-all-platforms.sh":
```bash
# Verifica dónde está el repositorio
ls ~/Desktop/pingCkeck_IA/build-all-platforms.sh

# Si no está ahí, búscalo
find ~ -name "build-all-platforms.sh" 2>/dev/null

# Navega al directorio correcto antes de ejecutar
cd ~/Desktop/pingCkeck_IA
./build-all-platforms.sh
```

Ver solución completa en: [MAC_SILICON_BUILD_ALL.md](MAC_SILICON_BUILD_ALL.md#-solución-de-problemas)

### Si dice "developer cannot be verified":
```bash
xattr -d com.apple.quarantine PingMonitor
```

### Si no encuentra dotnet:
Instala .NET 8 SDK y reinicia la Terminal

---

Para la guía completa, ver: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)
