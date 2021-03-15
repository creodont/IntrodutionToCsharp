// Decompiled with JetBrains decompiler
// Type: lesson7.Program
// Assembly: lesson7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 258CE09E-0BB9-4E90-BCDF-966199BE2E8F
// Assembly location: D:\Projects\PRJ_LessonsGB\IntrodutionToCsharp\lesson7\bin\Release\lesson7.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson7
{
  internal class Program
  {
    private static void Do()
    {
      int linqCounter = 0;
      IEnumerable<byte> source = new List<byte>()
      {
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 0
      }.Where<byte>((Func<byte, bool>) (x =>
      {
        ++linqCounter;
        return x > (byte) 0;
      }));
      if ((int) source.First<byte>() == (int) source.Last<byte>())
        Console.WriteLine(--linqCounter);
      else
        Console.WriteLine(linqCounter++);
    }

    private static void Main(string[] args)
    {
      Program.Do();
      Console.ReadLine();
    }
  }
}
