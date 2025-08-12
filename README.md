# sunset-ct-comment

## 概要

* ギルドSunSetのために作ったCT係コメント用ツールです
* Windows環境で使えます
  * x64で動くはず。動かなかったらSunSet鯖で連絡ください。
  * 他の環境で動かす場合もSunSet鯖で連絡ください。

## ダウンロード

* ユーザー環境に応じて選んでください

| No. | ダウンロードリンク | 説明                               |
| :-- | :----------------- | :--------------------------------- |
| 1   | [Link](https://github.com/simon-mog/sunset-ct-comment/raw/main/downloads/SunSetCTComment_dotNET%E6%A7%8B%E7%AF%89%E6%B8%88%E3%81%BF%E7%92%B0%E5%A2%83%E5%90%91%E3%81%91.zip) | ・.NET8.0環境が入っているユーザー向け<br>・アプリの最小限の構成のみ |
| 2   | [Link](https://github.com/simon-mog/sunset-ct-comment/raw/main/downloads/SunSetCTComment_dotNET%E8%BE%BC%E3%81%BF.zip) | ・.NET環境が入っていないユーザー向け<br>・アプリの中に必要な動作要件を含むためサイズが大きい |

## 使い方

* SunSetCTコメントコピー.exeを実行してください
  * .NET環境が入っていないユーザー向けの方のexe単体を別フォルダに移動すると実行できないはずです。ショートカットを活用してください。
* 実行すると下図ウィンドウが開きます

  <img width="326" height="443" alt="image" src="https://github.com/user-attachments/assets/787b7be3-db82-4a4e-86ff-d2627d40de06" />

* グループのプルダウンからグループの番号を選択してください
* コピーのボタンを押すとクリップボードにCT係のコメントがコピーされます
  * グループを選択してから押してください
  * 最後にコピーが成功したボタンは薄黄色になります
  * コピーした文字列は、下部の「コピーした文字列 (上が最新)」の領域に表示されます
* クリップボードにコピーされている文字列を確認するためのテキストボックスを用意していますので、コピー内容の確認に使ってください
  * フォーカスが外れると空になります
* 簡易表示のチェックボックスにチェックを入れると、ウィンドウが小さくなります

  <img width="326" height="180" alt="image" src="https://github.com/user-attachments/assets/a9e71121-78aa-4ce4-bd8f-486f712bd033" />

  * 「コピーした文字列確認用」「コピーした文字列 (上が最新)」は隠れます
  * 大体の部分をドラッグ&ドロップするとウィンドウを移動できます
    * ボタン、プルダウン、チェックボックスは反応しません
  * チェックを外すと元のウィンドウに戻ります

## Lisence


* [LICENSE](https://github.com/simon-mog/sunset-ct-comment/blob/main/LICENSE)を参照
