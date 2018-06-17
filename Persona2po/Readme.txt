Persona2Po - 1.0
********************************************
ESPAÑOL
********************************************
Este programa sirve para generar archivos Po desde los txt generados por el programa PersonaEditor hecho por Meloman19.

USO:
1º Debes de bajarte la última versión de PersonaEditor desde aquí
https://github.com/Meloman19/PersonaEditor/releases/latest
2º Copia el cmd «Export all files to PTP.cmd» y lo ejecutas.
3º Una vez que haya generado todos los PTP necesarios, abre una ventana de la consola de comandos y ejecuta esta linea
for /r ./ %f in (*.PTP) do PersonaEditor.exe "%f" -exptext "PTP\txt\%~nf.txt" /map "%FN %MSGIND %STRIND %OLDNM %OLDSTR %NEWNM %NEWSTR"
y empezará a generar los archivos en txt funcionales para el programa.
4º Luego une todas los txt con estos 2 comandos
COPY *.txt NAMES
RENAME NAMES *.txt 
Y elimina la última linea o dará error el programa.
5º Abre el txt con el Persona2po con -generatenames para generar el diccionario de nombres (así traduce todos los nombres automaticamente).
6º Para dividir txt que has unido, usa la opción -split y te lo dividirá.
7º Para importar, usa Persona2po con -import y el po para que te lo importe.

CRÉDITOS
-Darkmet98 - Creador del programa.
-Pleonex - Por la ayuda y las librerías Yarhl usadas en el programa.
-Meloman19 - Creador de PersonaEditor.

********************************************
ENGLISH
********************************************
This program makes po files from the generated txt files with PersonaEditor.

USAGE:
1º Download the latest version of PersonaEditor here
https://github.com/Meloman19/PersonaEditor/releases/latest
2º Copy "Export all files to PTP.cmd" and execute.
3º When the program finishes to export all PTP, open a command prompt and execute this line
for /r ./ %f in (*.PTP) do PersonaEditor.exe "%f" -exptext "PTP\txt\%~nf.txt" /map "%FN %MSGIND %STRIND %OLDNM %OLDSTR %NEWNM %NEWSTR"
and start to export all PTP files to txt.
4º After this, combine all TXT for generate the name's dictionary with this commands
COPY *.txt NAMES
RENAME NAMES *.txt
And delete the latest line.
5º Export the generated txt with Persona2Po with the option -generatenames.
6º To import the po, use Persona2Po with the option -import to import the po to txt.
7º To split the txt files, use Persona2Po with the option -split.

CREDITS
-Darkmet98 - Creator of this program.
-Pleonex - Help and Yarhl libraries.
-Meloman19 - Creator of PersonaEditor.