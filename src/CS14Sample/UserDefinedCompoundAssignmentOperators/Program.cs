{ C c = new() { Value = 32 }; Console.WriteLine(++c); }                         // 33 = 32 + 1
{ C c = new() { Value = 32 }; Console.WriteLine(--c); }                         // 31 = 32 - 1
{ C c = new() { Value = 32 }; Console.WriteLine(c += new C() { Value = 2 }); }  // 34 = 32 + 2
{ C c = new() { Value = 32 }; Console.WriteLine(c -= new C() { Value = 2 }); }  // 30 = 32 - 2
{ C c = new() { Value = 32 }; Console.WriteLine(c *= new C() { Value = 2 }); }  // 64 = 32 * 2
{ C c = new() { Value = 32 }; Console.WriteLine(c /= new C() { Value = 2 }); }  // 16 = 32 / 2
{ C c = new() { Value = 32 }; Console.WriteLine(c %= new C() { Value = 3 }); }  //  2 = 32 % 3
{ C c = new() { Value = 39 }; Console.WriteLine(c &= new C() { Value = 7 }); }  //  7 = 0b100111 & 0b111
{ C c = new() { Value = 32 }; Console.WriteLine(c |= new C() { Value = 2 }); }  // 34 = 0b100000 | 0b10
{ C c = new() { Value = 33 }; Console.WriteLine(c ^= new C() { Value = 3 }); }  // 34 = 0b100001 ^ 0b11
{ C c = new() { Value = 32 }; Console.WriteLine(c <<= 1); }                     // 64 = 32 << 1
{ C c = new() { Value = 32 }; Console.WriteLine(c >>= 1); }                     // 16 = 32 >> 1

// ユーザー定義の演算子を持つクラス
class C
{
    public int? Value { get; set; }
    public override string? ToString() => Value?.ToString();

    ///
    // これらは以前から書けた
    ///
    public static C operator +(C c1, C c2) => new C() { Value = c1?.Value + c2?.Value };
    public static C operator -(C c1, C c2) => new C() { Value = c1?.Value - c2?.Value };
    public static C operator *(C c1, C c2) => new C() { Value = c1?.Value * c2?.Value };
    public static C operator /(C c1, C c2) => new C() { Value = c1?.Value / c2?.Value };
    public static C operator %(C c1, C c2) => new C() { Value = c1?.Value % c2?.Value };
    public static C operator &(C c1, C c2) => new C() { Value = c1?.Value & c2?.Value };
    public static C operator |(C c1, C c2) => new C() { Value = c1?.Value | c2?.Value };
    public static C operator ^(C c1, C c2) => new C() { Value = c1?.Value ^ c2?.Value };
    public static C operator <<(C c, int shift) => new C() { Value = c?.Value << shift };
    public static C operator >>(C c, int shift) => new C() { Value = c?.Value >> shift };
    public static C operator ++(C c) => new C() { Value = c?.Value + 1 };
    public static C operator --(C c) => new C() { Value = c?.Value - 1 };

    ///
    // これらが書けるようになった
    ///
    // 現時点で Visual Studio でビルドできず、コマンドラインでのビルド (Visual Studio ではエラーになる)
    // > dotnet build
    public void operator ++() { Value += 1; }
    public void operator --() { Value -= 1; }
    public void operator +=(C c) { Value += c?.Value; }
    public void operator -=(C c) { Value -= c?.Value; }
    public void operator *=(C c) { Value *= c?.Value; }
    public void operator /=(C c) { Value /= c?.Value; }
    public void operator %=(C c) { Value %= c?.Value; }
    public void operator &=(C c) { Value &= c?.Value; }
    public void operator |=(C c) { Value |= c?.Value; }
    public void operator ^=(C c) { Value ^= c?.Value; }
    public void operator <<=(int shift) { Value <<= shift; }
    public void operator >>=(int shift) { Value >>= shift; }
}