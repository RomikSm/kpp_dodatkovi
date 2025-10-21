.386
.model flat, stdcall
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO, :DWORD
MessageBoxA PROTO, :DWORD, :DWORD, :DWORD, :DWORD 

.data
Caption db "Power Result", 0               ; Заголовок MessageBox
Result db 0                                ; Для зберігання результату

.const
baseNum = 5                                ; Основа (база)
expNum = 3                               ; Показник степеня

.code

WindowMessage PROC

    ; Виклик процедури CalculatePower для обчислення степеня
    call Power

    ; Завершення процесу
    push 0
    call ExitProcess

WindowMessage ENDP

Power PROC
    mov eax, baseNum                        ; Завантажуємо основу в регістр eax
    mov ecx, expNum                         ; Завантажуємо показник степеня в регістр ecx
    dec ecx                                 ; Зменшуємо показник на 1 (бо перше множення не потрібно)

power_loop:
    imul eax, baseNum                       ; Множимо основу на саму себе
    loop power_loop                         ; Цикл для піднесення до степеня (показник раз)

    ; Перетворення результату на рядок
    mov ebx, eax                            ; Зберігаємо результат у ebx
    mov ecx, 10                             ; Основу для поділу (10)

    ; Перетворення результату на рядок
    xor edi, edi                            ; Очищення edi для використання як індекс
convert_loop:
    xor edx, edx                            ; Очищаємо edx
    div ecx                                 ; Ділимо ebx на 10
    add dl, '0'                             ; Перетворюємо залишок на ASCII
    push dx                                 ; Записуємо символ у стек
    inc edi                                 ; Збільшуємо лічильник
    test eax, eax                           ; Перевіряємо, чи досягли 0
    jnz convert_loop                        ; Якщо ні, повторюємо

    ; Виведення MessageBox з результатом
    mov eax, 0                              ; Очищаємо eax для виведення
    mov ecx, edi                            ; Кількість символів у результаті
    lea esi, Result                         ; Вказівник на Result

pop_loop:
    pop dx                                  ; Витягуємо символ з стека
    mov [esi], dl                           ; Записуємо символ у Result
    inc esi                                 ; Переміщуємо вліво в Result
    dec ecx                                 ; Зменшуємо лічильник
    jnz pop_loop                            ; Якщо ще є символи, повторюємо

    mov byte ptr [esi], 0                   ; Завершення рядка

    ; Виведення MessageBox
    push 0                                  ; Значення для кнопки
    push offset Caption                     ; Заголовок
    push offset Result                      ; Результат
    push 0                                  ; Значення для батьківського вікна
    call MessageBoxA                        ; Виклик MessageBox

    ret

Power ENDP

END WindowMessage
