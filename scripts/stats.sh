#!/bin/bash

# Project types and extensions
CS_EXT="cs"
BLAZOR_EXT="razor"
FRONTEND_EXTS=("ts" "js" "tsx" "jsx" "vue")

echo "====================================================="
echo "   CODE ANALYZER - ASPIRE .NET 10"
echo "====================================================="

total_lines_global=0

# Finding all .csproj files
projects=$(find . -name "*.csproj")

for proj in $projects; do
    proj_dir=$(dirname "$proj")
    proj_name=$(basename "$proj")
    
    # Improved line counting: 
    # 1. find files 
    # 2. grep -v matches lines that DON'T start with / or * (basic comment filtering)
    # 3. grep . ensures the line is not empty
    proj_lines=$(find "$proj_dir" -name "*.$CS_EXT" \
        -not -path "*/obj/*" \
        -not -path "*/bin/*" \
        -exec grep -E -v '^[[:space:]]*//|/|^\*' {} + | grep . | wc -l)
    
    # Blazor check
    blazor_lines=$(find "$proj_dir" -name "*.$BLAZOR_EXT" -not -path "*/obj/*" | wc -l)
    
    echo "pRJECT: $proj_name"
    echo "  - Code lines C# (pure logics): $proj_lines"
    
    if [ "$blazor_lines" -gt 0 ]; then
        echo "  - Code lines Blazor/Razor: $blazor_lines"
    fi

    # Frontend Framework Detection
    for ext in "${FRONTEND_EXTS[@]}"; do
        fe_files=$(find "$proj_dir" -name "*.$ext" -not -path "*/node_modules/*" -not -path "*/dist/*" | wc -l)
        if [ "$fe_files" -gt 0 ]; then
            if [ -f "$proj_dir/package.json" ]; then
                # Identify framework by looking into package.json
                framework=$(grep -iE "angular|react|vue|svelte|next|nuxt" "$proj_dir/package.json" | head -1 | cut -d: -f1 | tr -d '" ,')
                echo "  - Frontend: ${framework:-Custom JS/TS} ($fe_files archivos .$ext)"
            fi
        fi
    done
    
    echo "-----------------------------------------------------"
    total_lines_global=$((total_lines_global + proj_lines))
done

echo "FINAL RESUME:"
echo "Projects detected: $(echo "$projects" | wc -l)"
echo "Total resume C# (Net10): $total_lines_global"
echo "====================================================="