﻿using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Entities.Props.PickUpItems
{
    /// <summary>
    /// The PickUpHeart class represents a life point that can be picked up from the floor
    /// by the player by passing through it.
    /// </summary>
    public class PickUpHeart : FloorObject
    {
        /// <summary>
        /// Float value containing the player's health ath the moment.
        /// </summary>
        public FloatValue playerHealth;
        
        /// <summary>
        /// Amount of health points healed by the heart pick up.
        /// </summary>
        public FloatValue healingFactor;

        /// <summary>
        /// Increases the player's health global value and notifies the UI about the change
        /// via signal observer.
        /// </summary>
        public override void PickUp()
        {
            // Update player health
            playerHealth.runtimeValue = Mathf.Min(playerHealth.initialValue,
                playerHealth.runtimeValue + healingFactor.runtimeValue);
            base.PickUp();
        }
    }
}
