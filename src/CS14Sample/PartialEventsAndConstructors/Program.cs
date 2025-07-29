
Console.WriteLine();

partial class C
{
    // 宣言パート
    // イベントの宣言のみ
    partial event EventHandler Ev1;

    // コンストラクターの宣言のみ
    partial C(int i);
    partial C(int i1, int i2);

    // これは書けない
    // partial C(int i1,int i2) : base();
    // エラー
    // 'C.C(int, int)': only the implementing declaration of a partial constructor can have an initializer

    // Preview バージョンを指定していない場合のエラー
    // C# 13.0 では、修飾子 'partial' はこの項目に対して有効ではありません。'preview' 以上の言語バージョンをご使用ください。


    // 実装パート
    // イベントの実装
    EventHandler? eh;
    partial event EventHandler Ev1 { add => eh += value; remove => eh -= value; }

    // コンストラクタの実装。実装では this() や base() が書ける
    partial C(int i) : this() { }
    partial C(int i1,int i2) : base() { }

    // this() 用のコンストラクタ
    C() { }
}