
// これは以前からできた
new int[] { }.M1();

// これができるようになった
new int[] { }.M2();
new int[] { }.M3();
// Preview バージョンを指定していない場合のエラー
// 'int[]' に 'M2' の定義が含まれておらず、型 'int[]' の最初の引数を受け付けるアクセス可能な拡張メソッド 'M2' が見つかりませんでした。using ディレクティブまたはアセンブリ参照が不足していないことを確認してください


// これはできない
// List<object> list = new List<string>();
// Span<object> span1 = new Span<string>();
// 型 'System.Collections.Generic.List<string>' を 'System.Collections.Generic.List<object>' に暗黙的に変換できません
// 型 'System.Span<string>' を 'System.Span<object>' に暗黙的に変換できません

// これができるようになった
ReadOnlySpan<object> span2 = new ReadOnlySpan<string>();
// Preview バージョンを指定していない場合のエラー
// 型 'System.ReadOnlySpan<string>' を 'System.ReadOnlySpan<object>' に暗黙的に変換できません

// 拡張メソッドの定義
internal static class Ex
{
    public static void M1<T>(this IEnumerable<T> enu) {; }
    public static void M2<T>(this Span<T> span) {; }
    public static void M3<T>(this ReadOnlySpan<T> span) {; }
}
