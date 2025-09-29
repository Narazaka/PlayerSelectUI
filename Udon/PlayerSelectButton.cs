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
        [SerializeField] PlayerSelectManager manager;
        [SerializeField] Image image;
        [SerializeField] Color selectedColor = Color.green;
        [SerializeField] Color baseColor = Color.white;

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
            manager._OnPlayerSelectByButton(Networking.GetOwner(gameObject));
        }

        public void _SetSelected(bool selected)
        {
            image.color = selected ? selectedColor : baseColor;
        }
    }
}
