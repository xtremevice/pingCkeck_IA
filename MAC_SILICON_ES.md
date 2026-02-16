# Guía de Instalación para Mac Silicon (Apple Silicon)

Esta guía te ayudará a descargar, compilar y ejecutar la aplicación Ping Monitor en Mac con procesador Apple Silicon (M1, M2, M3, etc.).

## ⚠️ IMPORTANTE: Descargar la Rama Correcta

**La aplicación completa está en la rama `copilot/create-ping-app`**, no en la rama principal (main).

Si solo ves el archivo README, consulta: [DESCARGAR_APLICACION.md](DESCARGAR_APLICACION.md)

## Requisitos Previos

1. **Instalar .NET 8 SDK**

Primero, necesitas instalar .NET 8 SDK. Abre la Terminal y ejecuta:

```bash
# Descargar e instalar .NET 8 SDK para macOS ARM64
curl -L https://dotnet.microsoft.com/download/dotnet/8.0 -o /tmp/dotnet.html
```

O descárgalo directamente desde: https://dotnet.microsoft.com/download/dotnet/8.0

Selecciona la versión **macOS ARM64** (para Apple Silicon).

2. **Verificar la instalación de .NET**

```bash
dotnet --version
```

Deberías ver algo como `8.0.xxx` o superior.

## Paso 1: Clonar el Repositorio

Abre la Terminal y ejecuta los siguientes comandos:

```bash
# Navegar a tu carpeta de proyectos (o donde prefieras)
cd ~/Desktop

# ⚠️ IMPORTANTE: Clonar la rama correcta con la aplicación
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git

# Entrar al directorio del proyecto
cd pingCkeck_IA
```

**Alternativa si ya clonaste sin la rama:**
```bash
cd ~/Desktop/pingCkeck_IA
git checkout copilot/create-ping-app
```

## Paso 2: Compilar la Aplicación

### Opción A: Compilación Simple para Desarrollo

```bash
# Navegar a la carpeta del proyecto
cd PingMonitor

# Compilar el proyecto
dotnet build

# Ejecutar la aplicación
dotnet run
```

### Opción B: Publicar una Versión Independiente (Recomendado)

Esta opción crea un ejecutable que no requiere tener .NET instalado:

```bash
# Navegar a la carpeta del proyecto
cd PingMonitor

# Publicar para Mac Silicon (ARM64)
dotnet publish -c Release -r osx-arm64 --self-contained

# La aplicación compilada estará en:
# bin/Release/net8.0/osx-arm64/publish/
```

### Opción C: Publicación Dependiente del Framework (Más Pequeña)

Si ya tienes .NET 8 instalado y quieres un ejecutable más pequeño:

```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64
```

## Paso 3: Ejecutar la Aplicación

### Si usaste la Opción A (dotnet run):

La aplicación ya debería estar ejecutándose.

### Si usaste la Opción B o C (publish):

```bash
# Navegar a la carpeta de publicación
cd bin/Release/net8.0/osx-arm64/publish/

# Dar permisos de ejecución
chmod +x PingMonitor

# Ejecutar la aplicación
./PingMonitor
```

## Paso 4: Usar la Aplicación

Una vez que la aplicación se abra:

1. **Agregar un sitio**: Escribe una URL (ej: `google.com`) o dirección IP (ej: `8.8.8.8`) y haz clic en "Add Site"

2. **Ajustar el intervalo**: Cambia el valor del intervalo (en milisegundos) y haz clic en "Update Interval"

3. **Monitorear**: Observa las estadísticas en tiempo real:
   - **Last**: Tiempo de respuesta del último ping
   - **Avg (50)**: Promedio de los últimos 50 pings
   - **Max**: Tiempo máximo registrado
   - **Graph**: Gráfica visual del historial de pings

4. **Eliminar sitios**: Haz clic en "Remove" junto a cualquier sitio

## Sitios de Ejemplo para Probar

```bash
google.com
8.8.8.8
1.1.1.1
github.com
cloudflare.com
```

## Comandos Completos (Copia y Pega)

```bash
# 1. Clonar repositorio (⚠️ IMPORTANTE: con la rama correcta)
cd ~/Desktop
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA

# 2. Navegar al proyecto
cd PingMonitor

# 3. Publicar para Mac Silicon
dotnet publish -c Release -r osx-arm64 --self-contained

# 4. Navegar a la carpeta de publicación
cd bin/Release/net8.0/osx-arm64/publish/

# 5. Dar permisos y ejecutar
chmod +x PingMonitor
./PingMonitor
```

## Solución de Problemas

### Error: "command not found: dotnet"

Significa que .NET SDK no está instalado o no está en el PATH. 
- Descarga e instala .NET 8 SDK desde: https://dotnet.microsoft.com/download/dotnet/8.0
- Reinicia la Terminal después de la instalación

### Error: "Cannot open because the developer cannot be verified"

macOS bloquea aplicaciones de desarrolladores no verificados:

```bash
# Permitir la ejecución de la aplicación
xattr -d com.apple.quarantine PingMonitor
```

O ve a **Preferencias del Sistema > Seguridad y Privacidad** y permite la aplicación.

### La aplicación no inicia

Verifica que estés en la carpeta correcta y que el archivo tenga permisos de ejecución:

```bash
# Verificar ubicación
pwd

# Dar permisos
chmod +x PingMonitor

# Ver archivos
ls -la
```

### Error: "No such file or directory"

Asegúrate de estar en la carpeta de publicación correcta:

```bash
cd ~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/
```

## Crear un Alias para Facilitar la Ejecución

Puedes crear un alias en tu `.zshrc` o `.bash_profile`:

```bash
# Agregar al archivo ~/.zshrc
echo 'alias pingmonitor="~/Desktop/pingCkeck_IA/PingMonitor/bin/Release/net8.0/osx-arm64/publish/PingMonitor"' >> ~/.zshrc

# Recargar configuración
source ~/.zshrc

# Ahora puedes ejecutar desde cualquier lugar
pingmonitor
```

## Desinstalar

Para desinstalar, simplemente elimina la carpeta del proyecto:

```bash
rm -rf ~/Desktop/pingCkeck_IA
```

## Más Información

- [README.md](README.md) - Documentación principal
- [PUBLISHING.md](PUBLISHING.md) - Instrucciones de publicación para todas las plataformas
- [ARCHITECTURE.md](ARCHITECTURE.md) - Detalles técnicos de la arquitectura

## Soporte

Si tienes problemas, verifica:
1. Que .NET 8 SDK esté correctamente instalado
2. Que estés usando la versión ARM64 (Apple Silicon)
3. Que tengas permisos de ejecución en el archivo
4. Que no haya firewall bloqueando la aplicación
