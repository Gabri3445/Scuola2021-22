costo: NOP
sconto: NOP
LDA #10
STA [sconto]

INP
STA [costo]
LDB [sconto]
MUL
LDB #100
DIV
STA 100
STB 101
LDA 101
LDB 100
SUB
OUT
HLT
