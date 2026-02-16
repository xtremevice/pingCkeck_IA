#!/bin/bash
# Script para subir documentación al Wiki de GitHub
# Execution: bash upload-wiki.sh

set -e  # Exit on error

echo "🚀 Iniciando subida de documentación al Wiki..."

# Variables
REPO_DIR="/home/runner/work/pingCkeck_IA/pingCkeck_IA"
WIKI_URL="https://github.com/xtremevice/pingCkeck_IA.wiki.git"
TEMP_DIR="/tmp/pingCkeck_IA_wiki"

# Limpiar directorio temporal si existe
if [ -d "$TEMP_DIR" ]; then
    echo "🧹 Limpiando directorio temporal..."
    rm -rf "$TEMP_DIR"
fi

# Clonar el wiki
echo "📥 Clonando el wiki..."
git clone "$WIKI_URL" "$TEMP_DIR"

# Copiar archivos de documentación
echo "📄 Copiando archivos de documentación..."
cd "$REPO_DIR"

# Lista de archivos a copiar
FILES=(
    "ACTUALIZAR.md"
    "ARCHITECTURE.md"
    "COMANDO_MAC_SILICON.md"
    "DESCARGAR_APLICACION.md"
    "FEATURES_SCATTER_REPORT.md"
    "FIXES_GRAFICA_REPORTE.md"
    "MAC_SILICON_ES.md"
    "MERGE_COMMANDS.md"
    "PUBLISHING.md"
    "QUICKSTART_MAC_ES.md"
    "QUICK_REFERENCE.md"
    "README.md"
    "UI_LAYOUT.md"
    "WIKI_UPLOAD.md"
)

# Copiar cada archivo
for file in "${FILES[@]}"; do
    if [ -f "$file" ]; then
        echo "  ✓ Copiando $file"
        cp "$file" "$TEMP_DIR/"
    else
        echo "  ⚠ Archivo no encontrado: $file"
    fi
done

# Copiar INDEX.md como Home.md (página principal del wiki)
if [ -f "INDEX.md" ]; then
    echo "  ✓ Copiando INDEX.md -> Home.md"
    cp "INDEX.md" "$TEMP_DIR/Home.md"
fi

# Ir al directorio del wiki y hacer commit
cd "$TEMP_DIR"

# Configurar git si es necesario
git config user.name "GitHub Actions" || git config user.name "PingCheck Bot"
git config user.email "actions@github.com" || git config user.email "bot@pingcheck.local"

# Agregar todos los archivos
echo "📦 Agregando archivos al git..."
git add .

# Verificar si hay cambios
if git diff --staged --quiet; then
    echo "ℹ️  No hay cambios para subir. El wiki ya está actualizado."
else
    # Hacer commit
    echo "💾 Haciendo commit..."
    git commit -m "Actualizar documentación - $(date '+%Y-%m-%d %H:%M:%S')"
    
    # Push al wiki
    echo "⬆️  Subiendo al wiki..."
    git push origin master
    
    echo "✅ ¡Documentación subida exitosamente al wiki!"
fi

# Limpiar
cd /
rm -rf "$TEMP_DIR"

echo ""
echo "📚 Wiki URL: https://github.com/xtremevice/pingCkeck_IA/wiki"
echo "✨ Proceso completado!"
