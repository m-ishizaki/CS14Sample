using System.Diagnostics.CodeAnalysis;

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

///
// += 演算子をユーザー定義している場合としていない場合の動作
///

{   // ユーザー定義の += を定義している場合
    C c = new() { Value = 32 }; C c2 = c;
    Console.WriteLine(c == c2);                     // ture (c と c2 は同じインスタンス)
    Console.WriteLine(c += new C() { Value = 2 });  // 34
    Console.WriteLine(c2);                          // 34 ( += でインスタンスの値が変わっている )
    Console.WriteLine(c == c2);                     // ture
}  // 34 = 32 + 2
{   // ユーザー定義の += を定義していない場合
    C2 c = new() { Value = 32 }; C2 c2 = c;
    Console.WriteLine(c == c2);                     // ture (c と c2 は同じインスタンス)
    Console.WriteLine(c += new C2() { Value = 2 }); // 34
    Console.WriteLine(c2);                          // 32 ( += で新しいインスタンスが作られ。インスタンスの値は変わらない)
    Console.WriteLine(c == c2);                     // false (c と c2 は別のインスタンスになっている)
}

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
    public static C operator ++(C c) => new C() { Value = c?.Value + 100 }; // 下の ++() があるとこちらは使われない
    public static C operator --(C c) => new C() { Value = c?.Value - 100 }; // 下の --() があるとこちらは使われない

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

    // Preview バージョンを指定していない場合のエラー
    // 機能 'user-defined compound assignment operators' は現在、プレビュー段階であり、*サポートされていません*。プレビュー機能を使用するには、'preview' 言語バージョンを使用してください。
}

// ユーザー定義の複合代入演算子を持たないクラス
class C2
{
    public int? Value { get; set; }
    public override string? ToString() => Value?.ToString();
    public static C2 operator +(C2 c1, C2 c2) => new C2() { Value = c1?.Value + c2?.Value };
}