C c = new();
c.P3 = 1;
Console.WriteLine(c.P3); // 3
Console.WriteLine(c.P3); // 4

// -- Field-backed properties --
class C
{
    // これは以前からできた
    int p1;                     // バッキングフィールド
    public int P1
    {
        get => p1;              // バッキングフィールドの値を返却
        set => p1 = (value > 0) // バッキングフィールドに値を設定
            ? value + 1
            : -1;
    }

    // これができるようになった
    public int P2
    {
        get;                        // デフォルト実装の書き方
        set => field = (value > 0)  // field キーワード
            ? value + 1
            : -1;
        // Preview バージョンを指定していない場合のエラー
        // 機能 'field キーワード' は現在、プレビュー段階であり、*サポートされていません*。プレビュー機能を使用するには、'preview' 言語バージョンを使用してください。
    }

    // こんなこともできる
    public int P3
    {
        get => ++field;             // getter で field キーワードを使用。field の値の変更も
        set => field = value + 1;
    }
}