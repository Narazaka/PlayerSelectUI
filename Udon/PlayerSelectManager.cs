using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace Narazaka.VRChat.PlayerSelectUI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PlayerSelectManager : UdonSharpBehaviour
    {
        [SerializeField] UdonBehaviour receiver;
        [SerializeField] PlayerSelectButton playerSelectButtonSource;

        void OnEnable()
        {
            receiver.SetProgramVariable(nameof(PlayerSelectReceiver._selectChangeReceiver), (object)(IUdonEventReceiver)this);
            receiver.SendCustomEvent(nameof(PlayerSelectReceiver._AddSelectChangeListener));
        }

        public void _OnSelectedPlayerChanged()
        {
            var selectedPlayer = (VRCPlayerApi)receiver.GetProgramVariable(nameof(PlayerSelectReceiver._selectedPlayer));
            SetUI(selectedPlayer);
        }

        public void _OnPlayerSelectByButton(VRCPlayerApi player)
        {
            receiver.SetProgramVariable(nameof(PlayerSelectReceiver._selectedPlayer), (object)player);
            receiver.SendCustomEvent(nameof(PlayerSelectReceiver._OnSelectPlayer));
            SetUI(player);
        }

        void SetUI(VRCPlayerApi selectedPlayer)
        {
            var players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            VRCPlayerApi.GetPlayers(players);
            foreach (var p in players)
            {
                var btn = (PlayerSelectButton)Networking.FindComponentInPlayerObjects(p, playerSelectButtonSource);
                btn._SetSelected(p.playerId == selectedPlayer.playerId);
            }
        }
    }
}
