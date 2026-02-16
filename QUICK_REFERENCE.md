# 📋 Referencia Rápida - Comandos Esenciales

Esta es una guía de referencia rápida para los comandos más comunes.

## 🔀 Merge con Main

```bash
# Comando completo (todo-en-uno)
git checkout copilot/create-ping-app && \
git pull origin copilot/create-ping-app && \
git checkout main && \
git pull origin main && \
git merge copilot/create-ping-app && \
git push origin main
```

Ver guía completa: [MERGE_COMMANDS.md](MERGE_COMMANDS.md)

## 📚 Subir al Wiki

```bash
# Clonar wiki
git clone https://github.com/xtremevice/pingCkeck_IA.wiki.git
cd pingCkeck_IA.wiki

# Copiar documentación (desde el repo principal)
cp /home/runner/work/pingCkeck_IA/pingCkeck_IA/*.md .
mv INDEX.md Home.md

# Subir
git add .
git commit -m "Upload documentation to wiki"
git push origin master
```

Ver guía completa: [WIKI_UPLOAD.md](WIKI_UPLOAD.md)

## 🔄 Actualizar Aplicación

```bash
# Mac Silicon
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && \
dotnet publish -c Release -r osx-arm64 --self-contained && \
cd bin/Release/net8.0/osx-arm64/publish/ && \
chmod +x PingMonitor && ./PingMonitor

# Windows
cd %USERPROFILE%\Desktop\pingCkeck_IA && git pull && cd PingMonitor && \
dotnet publish -c Release -r win-x64 --self-contained && \
cd bin\Release\net8.0\win-x64\publish\ && PingMonitor.exe

# Linux
cd ~/Desktop/pingCkeck_IA && git pull && cd PingMonitor && \
dotnet publish -c Release -r linux-x64 --self-contained && \
cd bin/Release/net8.0/linux-x64/publish/ && \
chmod +x PingMonitor && ./PingMonitor
```

Ver guía completa: [ACTUALIZAR.md](ACTUALIZAR.md)

## 🆕 Primera Instalación

```bash
# Mac Silicon
cd ~/Desktop && \
git clone -b copilot/create-ping-app https://github.com/xtremevice/pingCkeck_IA.git && \
cd pingCkeck_IA/PingMonitor && \
dotnet publish -c Release -r osx-arm64 --self-contained && \
cd bin/Release/net8.0/osx-arm64/publish/ && \
chmod +x PingMonitor && ./PingMonitor
```

Ver guía completa: [COMANDO_MAC_SILICON.md](COMANDO_MAC_SILICON.md)

## 🔍 Ver Estado

```bash
# Ver rama actual
git branch

# Ver estado del repositorio
git status

# Ver últimos commits
git log --oneline -5

# Ver diferencias
git diff
```

## 🛡️ Comandos de Seguridad

```bash
# Crear backup
git branch backup-$(date +%Y%m%d)

# Cancelar merge en progreso
git merge --abort

# Deshacer último commit (conservar cambios)
git reset --soft HEAD~1

# Deshacer último commit (descartar cambios)
git reset --hard HEAD~1
```

## 📁 Estructura de Documentación

```
/
├── ACTUALIZAR.md           - Comandos de actualización
├── MERGE_COMMANDS.md       - Comandos de merge
├── WIKI_UPLOAD.md          - Subir al wiki
├── COMANDO_MAC_SILICON.md  - Instalación Mac Silicon
├── README.md               - Documentación principal
├── INDEX.md                - Índice completo
└── ...
```

## 🔗 Enlaces Rápidos

- **Repositorio**: https://github.com/xtremevice/pingCkeck_IA
- **Wiki**: https://github.com/xtremevice/pingCkeck_IA/wiki
- **Rama principal**: `copilot/create-ping-app`

## ⚠️ Notas Importantes

1. La aplicación está en la rama `copilot/create-ping-app`, no en `main`
2. El wiki usa la rama `master` (no `main`)
3. Siempre hacer `git pull` antes de hacer cambios
4. Crear backup antes de operaciones importantes

---

**Última actualización**: 2026-02-16
