# ⚠️ IMPORTANTE: Cómo Descargar la Aplicación Completa

## Problema: Solo Veo el README

Si clonaste el repositorio y solo ves el archivo README, es porque estás en la rama `main` que aún no tiene la aplicación.

**El código completo de la aplicación está en la rama `copilot/create-ping-app`.**

## 🚀 Solución: Descargar la Rama Correcta

### Opción 1: Clonar la Rama con la Aplicación (RECOMENDADO)

```bash
# Clonar directamente la rama con la aplicación
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git
cd pingCkeck_IA
```

### Opción 2: Si Ya Clonaste el Repositorio

```bash
# Si ya clonaste el repositorio, cambia a la rama correcta
cd pingCkeck_IA
git checkout copilot/create-ping-app
```

### Opción 3: Descargar ZIP Directamente

1. Ve a: https://github.com/xtremevice/pingCkeck_IA/tree/copilot/create-ping-app
2. Haz clic en el botón verde **"Code"**
3. Selecciona **"Download ZIP"**
4. Descomprime el archivo

## ✅ Verificar que Tienes Todo

Después de seguir cualquiera de las opciones anteriores, deberías ver estos archivos y carpetas:

```
pingCkeck_IA/
├── .gitignore
├── README.md
├── INDEX.md
├── MAC_SILICON_ES.md          ← Guía para Mac Silicon
├── QUICKSTART_MAC_ES.md        ← Comandos rápidos
├── PUBLISHING.md
├── ARCHITECTURE.md
├── UI_LAYOUT.md
├── PingMonitor/                ← La aplicación!
│   ├── Program.cs
│   ├── PingMonitor.csproj
│   ├── Models/
│   ├── Services/
│   ├── ViewModels/
│   ├── Views/
│   └── ...
└── PingMonitor.Tests/          ← Tests
```

## 🎯 Después de Descargar Correctamente

### Para Mac Silicon:

```bash
cd PingMonitor
dotnet publish -c Release -r osx-arm64 --self-contained
cd bin/Release/net8.0/osx-arm64/publish/
chmod +x PingMonitor
./PingMonitor
```

Ver guía completa: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)

### Para Windows:

```bash
cd PingMonitor
dotnet publish -c Release -r win-x64 --self-contained
cd bin\Release\net8.0\win-x64\publish\
PingMonitor.exe
```

### Para Linux:

```bash
cd PingMonitor
dotnet publish -c Release -r linux-x64 --self-contained
cd bin/Release/net8.0/linux-x64/publish/
chmod +x PingMonitor
./PingMonitor
```

## 🔍 Comandos para Verificar en Qué Rama Estás

```bash
# Ver en qué rama estás actualmente
git branch

# Ver todas las ramas disponibles
git branch -a

# Cambiar a la rama con la aplicación
git checkout copilot/create-ping-app
```

## 📝 Nota para el Propietario del Repositorio

Para que los usuarios vean la aplicación al clonar sin especificar rama, necesitas:

1. Hacer merge de `copilot/create-ping-app` a `main`, o
2. Cambiar la rama por defecto del repositorio en GitHub a `copilot/create-ping-app`

**Cambiar rama por defecto en GitHub:**
1. Ve a: https://github.com/xtremevice/pingCkeck_IA/settings
2. En la sección "Default branch", cambia de `main` a `copilot/create-ping-app`
3. Confirma el cambio

## ❓ ¿Necesitas Ayuda?

- Ver documentación completa: [INDEX.md](INDEX.md)
- Guía rápida Mac Silicon: [QUICKSTART_MAC_ES.md](QUICKSTART_MAC_ES.md)
- Guía detallada Mac Silicon: [MAC_SILICON_ES.md](MAC_SILICON_ES.md)
