.data
    multiplier_red real4 8 dup (77.0)
    multiplier_green real4 8 dup(151.0)    
    multiplier_blue real4 8 dup(28.0)

.code
ConvertToGrayscale proc      
    ;R:rcx, G:rdx, B:r8, size:r9, output back in R

    ;divide size by 8 we pass 8 pixels at a time)
    shr r9, 3

    ;move coefficients to registers
    vmovups ymm3, [multiplier_red]
    vmovups ymm4, [multiplier_green]
    vmovups ymm5, [multiplier_blue]

    jmp cond

loop_avx:
    ; Load 8 pixel value from the source image
    vmovups ymm0, ymmword ptr[rcx]
    vmovups ymm1, ymmword ptr[rdx]
    vmovups ymm2, ymmword ptr[r8]
    
    ; Multiply the pixel values by the color weights
    vmulps ymm0, ymm0, ymm3
    vmulps ymm1, ymm1, ymm4
    vmulps ymm2, ymm2, ymm5

    ; Add the results of the multiplications
    vaddps ymm0, ymm0, ymm1
    vaddps ymm0, ymm0, ymm2

    ; Divide the result by 256
    vpsrld ymm0, ymm0, 8
    ; Store the result in the destination image
    sub rcx, 32
    vmovups ymmword ptr[rcx], ymm0

    ; Increment the pointer to the next 8 pixels
    add rcx, 32
    add rdx, 32
    add r8, 32

    ; Decrement the remaining pixels counter
    sub r9, 8

cond:
    jnz loop_avx ; if r9 != 0
    leave
    ret

ConvertToGrayscale endp

;IsVisible
;*A:rcx, *LowBo:rdx, *UpBo:r8, size:r9, output back in A

IsVisible proc

;divide size by 8
shr r9, 3
jmp cond

loop_compare:
;load 8 values from Hue channel array to ymm6 register
vmovups ymm6, ymmword ptr[rcx]
;load Lower Boundary and Upper Boundary to ymm registers
vmovups ymm9, ymmword ptr[rdx]
vmovups ymm10, ymmword ptr[r8]
;check if values are in the range
;ymm7 <- 1 if more than lower boundary
vpcmpgtq ymm7, ymm6, ymm9
;ymm8 <- 1 if less than upper boundary
vpcmpgtq ymm8, ymm10, ymm6
;ymm6 <- combine ymm7 AND ymm8 (1 only if both are 1s)
vandps ymm6, ymm7, ymm8

;sub rcx, 64
vmovups ymmword ptr[rcx], ymm6
;move 8 pixels further
add rcx, 32
add rdx, 32
add r8, 32
;decrease size
sub r9, 1


cond:
jnz loop_compare
leave
ret

IsVisible endp

end