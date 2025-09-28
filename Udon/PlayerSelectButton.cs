using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace Narazaka.VRChat.PlayerSelectUI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PlayerSelectButton : UdonSharpBehaviour
    {
        [SerializeField] UdonBehaviour receiver;

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (Networking.IsOwner(player, gameObject))
            {
                SetTextAndActivate(player.displayName);
            }
        }

        void SetTextAndActivate(string name)
        {
            GetComponent<Button>().interactable = true;
            var child = transform.GetChild(0);
            var tmp = child.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.text = name;
                return;
            }
            var text = child.GetComponent<Text>();
            if (text != null)
            {
                text.text = name;
                return;
            }
        }

        public void _OnClick()
        {
            receiver.SetProgramVariable(nameof(PlayerSelectReceiver._selectedPlayer), (object)Networking.GetOwner(gameObject));
            receiver.SendCustomEvent(nameof(PlayerSelectReceiver._OnSelectPlayer));
        }
    }
}
