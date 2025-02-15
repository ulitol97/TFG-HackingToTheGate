﻿using Game.Audio;

namespace Game.Entities.Props.Interactable.Door
{
    /// <summary>
    /// The NonKeyDoor class inherits from Door.
    /// Represents an in-game door the player can open if interacted with.
    /// </summary>
    public class NonKeyDoor : Door
    {
        public override void Open()
        {
            context.Notify();
            Parent.gameObject.SetActive(false);
            AudioManager.Instance.PlayEffectClip(AudioManager.OpenDoor);
        }
    }
}
