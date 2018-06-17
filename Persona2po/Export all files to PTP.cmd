@Echo OFF
CHCP 65001 1>NUL
echo Exporting PTP...
for /r data %%X in (*.PM1) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.bf) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.bmd) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.bin) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.pac) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.pak) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.P00) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.tbl) do PersonaEditor.exe "%%X" -expptp /sub
for /r data %%X in (*.bvp) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.PM1) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.bf) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.bmd) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.bin) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.pac) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.pak) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.P00) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.tbl) do PersonaEditor.exe "%%X" -expptp /sub
for /r btl %%X in (*.bvp) do PersonaEditor.exe "%%X" -expptp /sub
xcopy "*.PTP" "..\PTP" /s /e /i
pause
cd data
del *.PTP /S
cd ..
cd btl
del *.PTP /S
move "..\PTP" "PTP"
echo End