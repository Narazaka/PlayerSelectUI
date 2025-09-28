# Player Select UI

インスタンス内Player選択ボタンを表示する簡易的なUI

## Install

### VCC用インストーラーunitypackageによる方法（おすすめ）

https://github.com/Narazaka/PlayerSelectUI/releases/latest から `net.narazaka.vrchat.player-select-ui-installer.zip` をダウンロードして解凍し、対象のプロジェクトにインポートする。

### VCCによる方法

1. https://vpm.narazaka.net/ から「Add to VCC」ボタンを押してリポジトリをVCCにインストールします。
2. VCCでSettings→Packages→Installed Repositoriesの一覧中で「Narazaka VPM Listing」にチェックが付いていることを確認します。
3. アバタープロジェクトの「Manage Project」から「Player Select UI」をインストールします。

## Usage

1. `Udon/PlayerSelectReceiver` を参考にカスタムスクリプトを実装する
  - ```
    public abstract class PlayerSelectReceiver : UdonSharpBehaviour
    {
        [NonSerialized]
        public VRCPlayerApi _selectedPlayer;
        public abstract void _OnSelectPlayer();
    }
    ```
2. `PlayerSelectUI` プレハブをシーンに配置し、 `PlayerSelectUI/Canvas/Panel/Scroll View/Viewport/Content/PlayerSelectButton` の `PlayerSelectButton` コンポーネントにある `Receiver` に設定する。

## Changelog

- v1.0.2: スクロールするように
- v1.0.1: UI改善
- v1.0.0: リリース

## License

[Zlib License](LICENSE.txt)
