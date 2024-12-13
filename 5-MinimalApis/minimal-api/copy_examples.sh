   #!/bin/bash

   # Diretório onde os arquivos .example estão localizados
   DIR="./"

   # Verifica se o diretório existe
   if [ -d "$DIR" ]; then
     # Itera sobre cada arquivo .example no diretório, incluindo aqueles que começam com um ponto
     for file in "$DIR"/* "$DIR"/.*; do
       # Verifica se o arquivo termina com .example e existe para evitar erros
       if [[ -f "$file" && "$file" == *.example ]]; then
         # Remove a parte .example do nome do arquivo
         newfile="${file%.example}"
         # Copia o arquivo para o novo nome
         cp "$file" "$newfile"
         echo "Copiado $file para $newfile"
       fi
     done
   fi