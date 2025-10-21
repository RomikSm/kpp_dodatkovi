ExitProcess PROTO
wsprintfA PROTO
MessageBoxA PROTO

.data
fmtStr      db "%d", 0
buffer      db 64 dup(0)
caption     db "Result", 0

.const
number      dq 5        

.code
main PROC
    sub rsp, 28h          

    mov rax, number       
    mov rcx, rax          
    mov rbx, 1            

factorial_loop:
    test rcx, rcx
    jz factorial_done
    imul rbx, rcx
    dec rcx
    jmp factorial_loop

factorial_done:
    lea rcx, buffer       
    lea rdx, fmtStr       
    mov r8, rbx           
    call wsprintfA

    mov rcx, 0
    lea rdx, buffer
    lea r8, caption
    mov r9, 0
    call MessageBoxA

    xor ecx, ecx
    call ExitProcess
main endp
END
