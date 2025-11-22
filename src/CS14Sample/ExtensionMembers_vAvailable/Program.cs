Console.WriteLine("Hello, World!".IsEmpty);
Console.WriteLine("".IsEmpty);
Console.WriteLine(string.Combine("saitama", "saiko"));
Console.WriteLine("Hello, World!".ToArray().IsEmpty);
Console.WriteLine("".ToArray().IsEmpty);
Console.WriteLine(IEnumerable<int>.Combine(new int[] { }, new int[] { }));

Console.WriteLine(SampleOldExtension.IsEmpty(0));
Console.WriteLine(SampleOldExtension.IsEmpty(1));

// 参考
// 昔ながらの拡張メソッド
public static class SampleOldExtension
{
    // 第一引数に this を付けることで拡張メソッドとして定義
    public static bool IsEmpty(this int i) => i == 0;
}


// 拡張メンバー定義
// 一つのクラスに複数定義可能
public static class SampleExtension
{
    // string に対する拡張メンバー
    // 引数に this  は必要ない
    extension(string s)
    {
        // メンバーのシグニチャに this の引数は不要
        // 一つの extension ブロックの中に複数定義可能
        public bool IsEmpty => (s?.Length ?? 0) == 0;
        public bool IsEmpty_2 => (s?.Length ?? 0) == 0;

        // メソッドも定義可能
        public bool Empty() => (s?.Length ?? 0) == 0;
    }

    // 静的メンバーも定義可能
    extension(string)
    {
        // 静的メソッド
        public static string Combine(string first, string second) => first + second;
        // 静的プロパティ
        public static string Empty_2 => string.Empty;
    }

    // ジェネリクス型に対する拡張メンバー
    extension<TSource>(IEnumerable<TSource> source)
    {
        public bool IsEmpty => !source.Any();
    }

    // ジェネリクス型に対する拡張メンバー
    extension<TSource>(IEnumerable<TSource>)
    {
        public static IEnumerable<TSource> Combine(IEnumerable<TSource> first, IEnumerable<TSource> second) => Enumerable.Empty<TSource>();
        public static IEnumerable<TSource> Identity => Enumerable.Empty<TSource>();
    }
}