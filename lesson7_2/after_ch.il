.method private hidebysig static void  Do() cil managed
{
  // Code size       131 (0x83)
  .maxstack  3
  .locals init ([0] class lesson7.Program/'<>c__DisplayClass0_0' 'CS$<>8__locals0',
           [1] class [mscorlib]System.Collections.Generic.IEnumerable`1<uint8> source,
           [2] int32 V_2)
  IL_0000:  newobj     instance void lesson7.Program/'<>c__DisplayClass0_0'::.ctor()
  IL_0005:  stloc.0
  IL_0006:  ldloc.0
  IL_0007:  ldc.i4.0
  IL_0008:  stfld      int32 lesson7.Program/'<>c__DisplayClass0_0'::linqCounter
  IL_000d:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::.ctor()
  IL_0012:  dup
  IL_0013:  ldc.i4.0
  IL_0014:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::Add(!0)
  IL_0019:  dup
  IL_001a:  ldc.i4.0
  IL_001b:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::Add(!0)
  IL_0020:  dup
  IL_0021:  ldc.i4.1
  IL_0022:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::Add(!0)
  IL_0027:  dup
  IL_0028:  ldc.i4.1
  IL_0029:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::Add(!0)
  IL_002e:  dup
  IL_002f:  ldc.i4.0
  IL_0030:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<uint8>::Add(!0)
  IL_0035:  ldloc.0
  IL_0036:  ldftn      instance bool lesson7.Program/'<>c__DisplayClass0_0'::'<Do>b__0'(uint8)
  IL_003c:  newobj     instance void class [mscorlib]System.Func`2<uint8,bool>::.ctor(object,
                                                                                      native int)
  IL_0041:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                                                                       class [mscorlib]System.Func`2<!!0,bool>)
  IL_0046:  stloc.1
  IL_0047:  ldloc.1
  IL_0048:  call       !!0 [System.Core]System.Linq.Enumerable::First<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
  IL_004d:  ldloc.1
  IL_004e:  call       !!0 [System.Core]System.Linq.Enumerable::Last<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
  IL_0053:  bne.un.s   IL_006c
  IL_0055:  ldloc.0
  IL_0056:  ldfld      int32 lesson7.Program/'<>c__DisplayClass0_0'::linqCounter
  IL_005b:  ldc.i4.1
  IL_005c:  sub
  IL_005d:  stloc.2
  IL_005e:  ldloc.0
  IL_005f:  ldloc.2
  IL_0060:  stfld      int32 lesson7.Program/'<>c__DisplayClass0_0'::linqCounter
  IL_0065:  ldloc.2
  IL_0066:  call       void [mscorlib]System.Console::WriteLine(int32)
  IL_006b:  ret
  IL_006c:  ldloc.0
  IL_006d:  ldfld      int32 lesson7.Program/'<>c__DisplayClass0_0'::linqCounter
  IL_0072:  stloc.2
  IL_0073:  ldloc.0
  IL_0074:  ldloc.2
  IL_0075:  ldc.i4.1
  IL_0076:  add
  IL_0077:  stfld      int32 lesson7.Program/'<>c__DisplayClass0_0'::linqCounter
  IL_007c:  ldloc.2
  IL_007d:  call       void [mscorlib]System.Console::WriteLine(int32)
  IL_0082:  ret
} // end of method Program::Do

