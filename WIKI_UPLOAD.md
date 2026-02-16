# 📚 Subir Documentación al Wiki de GitHub

Esta guía explica cómo subir toda la documentación del repositorio al Wiki de GitHub.

## 🔍 Sobre el Wiki de GitHub

El Wiki de GitHub es un sistema separado del repositorio principal. Cada wiki es en realidad un repositorio Git independiente.

## 📋 Pasos para Subir Documentación al Wiki

### Opción 1: Usando la Interfaz Web (Recomendado para Documentos Individuales)

1. **Ir al Wiki del Repositorio**
   ```
   https://github.com/xtremevice/pingCkeck_IA/wiki
   ```

2. **Crear o Editar Páginas**
   - Haz clic en "New Page" o "Edit"
   - Copia el contenido de los archivos .md
   - Guarda cada página

3. **Organizar Páginas**
   - Usa la sidebar para crear un índice
   - Agrupa páginas relacionadas

### Opción 2: Usando Git (Recomendado para Múltiples Documentos)

#### Paso 1: Clonar el Wiki

```bash
# Clonar el wiki del repositorio
git clone https://github.com/xtremevice/pingCkeck_IA.wiki.git

# Entrar al directorio del wiki
cd pingCkeck_IA.wiki
```

#### Paso 2: Copiar Documentación

```bash
# Volver al directorio del repositorio principal
cd /home/runner/work/pingCkeck_IA/pingCkeck_IA

# Copiar todos los archivos markdown al wiki
cp ACTUALIZAR.md ../pingCkeck_IA.wiki/
cp ARCHITECTURE.md ../pingCkeck_IA.wiki/
cp COMANDO_MAC_SILICON.md ../pingCkeck_IA.wiki/
cp DESCARGAR_APLICACION.md ../pingCkeck_IA.wiki/
cp FEATURES_SCATTER_REPORT.md ../pingCkeck_IA.wiki/
cp FIXES_GRAFICA_REPORTE.md ../pingCkeck_IA.wiki/
cp INDEX.md ../pingCkeck_IA.wiki/Home.md
cp MAC_SILICON_ES.md ../pingCkeck_IA.wiki/
cp PUBLISHING.md ../pingCkeck_IA.wiki/
cp QUICKSTART_MAC_ES.md ../pingCkeck_IA.wiki/
cp README.md ../pingCkeck_IA.wiki/
cp UI_LAYOUT.md ../pingCkeck_IA.wiki/
```

**Nota**: `INDEX.md` se renombra a `Home.md` para que sea la página principal del wiki.

#### Paso 3: Subir al Wiki

```bash
# Entrar al directorio del wiki
cd ../pingCkeck_IA.wiki

# Agregar todos los archivos
git add .

# Hacer commit
git commit -m "Upload complete documentation to wiki"

# Subir al wiki
git push origin master
```

### Opción 3: Script Automatizado

Puedes crear un script para automatizar el proceso:

```bash
#!/bin/bash

# Script para subir documentación al wiki
REPO_DIR="/home/runner/work/pingCkeck_IA/pingCkeck_IA"
WIKI_DIR="/home/runner/work/pingCkeck_IA/pingCkeck_IA.wiki"

# Clonar wiki si no existe
if [ ! -d "$WIKI_DIR" ]; then
    cd /home/runner/work/pingCkeck_IA
    git clone https://github.com/xtremevice/pingCkeck_IA.wiki.git
fi

# Copiar archivos
cd "$REPO_DIR"
cp *.md "$WIKI_DIR/"

# Renombrar INDEX.md a Home.md
mv "$WIKI_DIR/INDEX.md" "$WIKI_DIR/Home.md"

# Subir al wiki
cd "$WIKI_DIR"
git add .
git commit -m "Update wiki documentation - $(date '+%Y-%m-%d %H:%M:%S')"
git push origin master

echo "✅ Documentación subida al wiki exitosamente!"
```

Guarda este script como `upload-to-wiki.sh` y ejecútalo:

```bash
chmod +x upload-to-wiki.sh
./upload-to-wiki.sh
```

## 📝 Estructura Recomendada del Wiki

Organiza el wiki de la siguiente manera:

### Página Principal (Home.md)
- Índice general con enlaces a todas las secciones
- Información importante sobre la rama correcta

### Secciones

1. **Inicio Rápido**
   - COMANDO_MAC_SILICON.md
   - QUICKSTART_MAC_ES.md
   - ACTUALIZAR.md

2. **Instalación Detallada**
   - DESCARGAR_APLICACION.md
   - MAC_SILICON_ES.md
   - PUBLISHING.md

3. **Características**
   - FEATURES_SCATTER_REPORT.md
   - FIXES_GRAFICA_REPORTE.md

4. **Técnico**
   - ARCHITECTURE.md
   - UI_LAYOUT.md
   - README.md

## 🔄 Mantener el Wiki Actualizado

### Sincronización Manual

Cada vez que actualices la documentación en el repositorio:

```bash
# En el directorio del repositorio
cd /home/runner/work/pingCkeck_IA/pingCkeck_IA

# Copiar archivos actualizados al wiki
cp *.md ../pingCkeck_IA.wiki/

# Renombrar INDEX.md a Home.md
mv ../pingCkeck_IA.wiki/INDEX.md ../pingCkeck_IA.wiki/Home.md

# Subir cambios
cd ../pingCkeck_IA.wiki
git add .
git commit -m "Update wiki documentation"
git push origin master
```

### Usando GitHub Actions (Automatización)

Puedes crear un workflow que sincronice automáticamente:

```yaml
# .github/workflows/sync-wiki.yml
name: Sync Wiki

on:
  push:
    branches:
      - copilot/create-ping-app
    paths:
      - '**.md'

jobs:
  sync:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout repo
        uses: actions/checkout@v3
        
      - name: Checkout wiki
        uses: actions/checkout@v3
        with:
          repository: ${{github.repository}}.wiki
          path: wiki
          
      - name: Copy files
        run: |
          cp *.md wiki/
          mv wiki/INDEX.md wiki/Home.md
          
      - name: Push to wiki
        run: |
          cd wiki
          git config user.name "GitHub Actions"
          git config user.email "actions@github.com"
          git add .
          git commit -m "Auto-sync from main repo" || exit 0
          git push
```

## ⚠️ Consideraciones Importantes

1. **Permisos**: Asegúrate de tener permisos de escritura en el wiki
2. **Rama**: El wiki usa la rama `master` (no `main`)
3. **Conflictos**: Si hay conflictos, usa `git pull` antes de `git push`
4. **Imágenes**: Las imágenes deben subirse por separado o usar URLs absolutas

## 🔗 Enlaces Útiles

- Wiki URL: https://github.com/xtremevice/pingCkeck_IA/wiki
- Documentación GitHub Wiki: https://docs.github.com/en/communities/documenting-your-project-with-wikis

## ✅ Verificación

Después de subir, verifica:
1. Todas las páginas son accesibles
2. Los enlaces internos funcionan
3. El formato Markdown se muestra correctamente
4. La página Home.md es la página principal

---

**Fecha de creación**: 2026-02-16
**Última actualización**: 2026-02-16
