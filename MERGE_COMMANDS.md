# 🔀 Comandos para Hacer Merge con el Origen (Main)

Esta guía proporciona los comandos necesarios para fusionar la rama `copilot/create-ping-app` con la rama principal `main`.

## 📋 Antes de Empezar

### Verificar Estado Actual

```bash
# Ver en qué rama estás
git branch

# Ver el estado de tu repositorio
git status

# Ver las ramas remotas disponibles
git branch -r
```

## 🔄 Opción 1: Merge Local y Push (Recomendado)

Esta es la forma más común y segura de hacer merge.

### Paso 1: Asegurarse de Estar en la Rama Correcta

```bash
# Cambiar a la rama copilot/create-ping-app
git checkout copilot/create-ping-app

# Asegurarse de tener los últimos cambios
git pull origin copilot/create-ping-app
```

### Paso 2: Obtener la Rama Main

```bash
# Obtener información de main desde el origen
git fetch origin main

# Crear/actualizar rama main local
git checkout -b main origin/main
```

Si ya tienes main localmente:

```bash
# Cambiar a main
git checkout main

# Actualizar main
git pull origin main
```

### Paso 3: Hacer Merge

```bash
# Estando en la rama main, hacer merge de copilot/create-ping-app
git merge copilot/create-ping-app

# Si hay conflictos, resuélvelos y luego:
# git add .
# git commit -m "Resolve merge conflicts"
```

### Paso 4: Subir los Cambios

```bash
# Subir main actualizada al origen
git push origin main
```

## 🚀 Opción 2: Pull Request (GitHub Web Interface)

Esta es la forma recomendada para proyectos colaborativos.

### Paso 1: Crear Pull Request

1. Ve a: https://github.com/xtremevice/pingCkeck_IA/compare
2. Selecciona:
   - Base: `main`
   - Compare: `copilot/create-ping-app`
3. Haz clic en "Create Pull Request"
4. Agrega título y descripción
5. Haz clic en "Create Pull Request"

### Paso 2: Revisar y Merge

1. Revisa los cambios
2. Espera la aprobación (si es necesario)
3. Haz clic en "Merge Pull Request"
4. Confirma el merge

## 📝 Opción 3: Merge con Squash (Commits Limpios)

Si quieres combinar todos los commits en uno solo:

```bash
# Estando en main
git checkout main
git pull origin main

# Hacer merge con squash
git merge --squash copilot/create-ping-app

# Hacer commit de todos los cambios
git commit -m "Merge copilot/create-ping-app: Add ping monitor application

- Complete Avalonia UI application
- Scatter plot and line graphs
- CSV/TXT report generation
- Cross-platform support (Windows, Linux, macOS)
- Comprehensive documentation
"

# Subir a main
git push origin main
```

## 🔍 Opción 4: Rebase (Historial Lineal)

Para mantener un historial más limpio:

```bash
# Cambiar a copilot/create-ping-app
git checkout copilot/create-ping-app

# Hacer rebase sobre main
git rebase main

# Si hay conflictos, resuélvelos y continúa:
# git add .
# git rebase --continue

# Una vez completado, hacer fast-forward merge
git checkout main
git merge copilot/create-ping-app

# Subir a main
git push origin main
```

## 🛡️ Comandos de Seguridad (Por Si Algo Sale Mal)

### Ver el Estado Antes de Merge

```bash
# Ver diferencias entre las ramas
git diff main..copilot/create-ping-app

# Ver lista de commits que se van a fusionar
git log main..copilot/create-ping-app --oneline

# Ver archivos que cambiarán
git diff --name-status main..copilot/create-ping-app
```

### Cancelar un Merge en Progreso

```bash
# Si algo sale mal durante el merge
git merge --abort
```

### Deshacer un Merge Completado

```bash
# Ver el historial de commits
git log --oneline

# Deshacer el último commit (el merge)
git reset --hard HEAD~1

# O volver a un commit específico
git reset --hard <commit-hash>
```

### Crear Respaldo Antes de Merge

```bash
# Crear una rama de respaldo
git branch backup-before-merge

# Si algo sale mal, puedes volver
git checkout backup-before-merge
```

## 📊 Comando Todo-en-Uno

Si estás seguro y quieres hacer todo de una vez:

```bash
git checkout copilot/create-ping-app && \
git pull origin copilot/create-ping-app && \
git checkout main && \
git pull origin main && \
git merge copilot/create-ping-app && \
git push origin main
```

**⚠️ Advertencia**: Usa esto solo si estás seguro de que no habrá conflictos.

## 🔧 Resolver Conflictos

Si hay conflictos durante el merge:

### Paso 1: Ver los Archivos en Conflicto

```bash
git status
```

### Paso 2: Resolver Cada Conflicto

Abre cada archivo en conflicto y busca las marcas:

```
<<<<<<< HEAD
(código de main)
=======
(código de copilot/create-ping-app)
>>>>>>> copilot/create-ping-app
```

Edita el archivo para resolver el conflicto.

### Paso 3: Marcar como Resuelto

```bash
# Después de resolver cada archivo
git add <archivo-resuelto>

# Cuando todos estén resueltos
git commit -m "Resolve merge conflicts"

# Continuar con el push
git push origin main
```

## ✅ Verificación Post-Merge

Después del merge, verifica:

```bash
# Ver que estás en main
git branch

# Ver el último commit
git log -1

# Verificar que todo se fusionó correctamente
git log --graph --oneline --all --decorate -10

# Verificar archivos
ls -la
```

## 🎯 Flujo Recomendado Completo

```bash
# 1. Preparación
cd /home/runner/work/pingCkeck_IA/pingCkeck_IA
git checkout copilot/create-ping-app
git pull origin copilot/create-ping-app

# 2. Obtener main
git fetch origin main
git checkout main
git pull origin main

# 3. Hacer merge
git merge copilot/create-ping-app -m "Merge copilot/create-ping-app into main

This merge includes:
- Complete Ping Monitor application with Avalonia UI
- Real-time ping monitoring with graphs
- Scatter plot (last 10 pings) and line graph (last 50 pings)
- CSV and TXT report generation
- Cross-platform support (Windows, Linux, macOS)
- Comprehensive Spanish documentation
- Update commands for all platforms
"

# 4. Subir cambios
git push origin main

# 5. Verificar
git log --oneline -5
```

## 📱 Notificación de Cambios

Después del merge, considera:

1. **Crear un Release/Tag**:
   ```bash
   git tag -a v1.0.0 -m "First stable release"
   git push origin v1.0.0
   ```

2. **Actualizar README** en main si es necesario

3. **Notificar a colaboradores** sobre los cambios

## 🔗 Enlaces Útiles

- Repositorio: https://github.com/xtremevice/pingCkeck_IA
- Documentación Git Merge: https://git-scm.com/docs/git-merge
- GitHub Pull Requests: https://docs.github.com/en/pull-requests

---

**Fecha de creación**: 2026-02-16
**Última actualización**: 2026-02-16
