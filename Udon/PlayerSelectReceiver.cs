using System;
using UdonSharp;
using VRC.SDKBase;

namespace Narazaka.VRChat.PlayerSelectUI
{
    public abstract class PlayerSelectReceiver : UdonSharpBehaviour
    {
        [NonSerialized]
        public VRCPlayerApi _selectedPlayer;
        public abstract void _OnSelectPlayer();
    }
}
