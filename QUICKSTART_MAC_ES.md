# Comandos Rápidos - Mac Silicon

## Instalación Rápida (Copia y Pega)

```bash
# 1. Clonar el repositorio
cd ~/Desktop
git clone https://github.com/xtremevice/pingCkeck_IA.git
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

### Si dice "developer cannot be verified":
```bash
xattr -d com.apple.quarantine PingMonitor
```

### Si no encuentra dotnet:
Instala .NET 8 SDK y reinicia la Terminal

---

Para la guía completa, ver: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)
