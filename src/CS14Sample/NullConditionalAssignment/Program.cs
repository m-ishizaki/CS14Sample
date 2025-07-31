C c = new() { P = "saitama" };
Console.WriteLine(c.P); // saitama

///
// これは以前からできた Null 条件演算子
///
// c?.P と書くと、c が null でも例外にならない (null が返る)
c = null;
try { Console.WriteLine(c.P); } catch (NullReferenceException) { Console.WriteLine("NullReferenceException caught!"); } // NullReferenceException caught!
Console.WriteLine(c?.P);    // null


// これは例外になる
try { c.P = "saitama"; } catch (NullReferenceException) { Console.WriteLine("NullReferenceException caught!"); } // NullReferenceException caught!

///
// そこで、これができるようになった null 条件付き割り当て
///
c?.P = "saitama";
Console.WriteLine(c?.P);    // null

// null でなければ普通に値を設定できる
c = new();
c?.P = "saitama";
Console.WriteLine(c?.P);    // saitama


// Preview バージョンを指定していない場合のエラー
// 機能 'null conditional assignment' は現在、プレビュー段階であり、*サポートされていません*。プレビュー機能を使用するには、'preview' 言語バージョンを使用してください。




// 
class C
{
    public string? P { get; set; }
}