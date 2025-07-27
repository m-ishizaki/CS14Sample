// これは以前からできた
Console.WriteLine($"名前は {nameof(List<int>)} です");   // 名前は List です

// これができるようになった
Console.WriteLine($"名前は {nameof(List<>)} です");   // 名前は List です
// Preview バージョンを指定していない場合のエラー
// 機能 'nameof 演算子でバインドされていないジェネリック型' は現在、プレビュー段階であり、*サポートされていません*。プレビュー機能を使用するには、'preview' 言語バージョンを使用してください。


// 余談
// ジェネリクス型 Type
Console.WriteLine($"Type は {typeof(List<int>).FullName} です");   // Type は  System.Collections.Generic.List`1[[System.Int32, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e] です
Console.WriteLine($"Type は {typeof(List<>).FullName} です");   // Type は System.Collections.Generic.List`1 です
