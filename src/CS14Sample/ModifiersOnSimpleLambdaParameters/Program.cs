
// これは以前からできた
Func0 func0 = (s) => s + s;                                                 // ref や in、out などがつかない場合は、型を省略できる
Func1 func2 = (ref string s1, in string s2, out string s3) => s3 = s1 + s2; // 型を省略できない

// これができるようになった
Func1 func3 = (ref s1, in s2, out s3) => s3 = s1 + s2;  // 型を省略できるようになった
// Preview バージョンを指定していない場合のエラー
// 機能 'simple lambda parameter modifiers' は現在、プレビュー段階であり、*サポートされていません*。プレビュー機能を使用するには、'preview' 言語バージョンを使用してください。


// delegate 定義
public delegate string Func0(string arg1);
public delegate string Func1(ref string arg1, in string arg2, out string arg3);
