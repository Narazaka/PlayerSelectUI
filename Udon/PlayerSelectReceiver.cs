using System;
using UdonSharp;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace Narazaka.VRChat.PlayerSelectUI
{
    public abstract class PlayerSelectReceiver : UdonSharpBehaviour
    {
        [NonSerialized]
        public VRCPlayerApi _selectedPlayer;
        public abstract void _OnSelectPlayer();
        [NonSerialized]
        public IUdonEventReceiver _selectChangeReceiver;
        public abstract void _AddSelectChangeListener();
        // receiver emits _OnSelectedPlayerChanged after _selectedPlayer is changed.
    }
}
