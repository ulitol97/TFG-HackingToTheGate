﻿using UnityEngine;

namespace Game.ScriptableObjects
{
    /// <summary>
    /// The Inventory class acts a persistence object holding the player's inventory that can be managed across
    /// scenes.
    /// </summary>
    /// <remarks>This class does not inherit from Mono-Behavior
    /// so it can be left outside the scene so that it survives scene changes.
    /// </remarks>
    [CreateAssetMenu]
    public class Inventory : ScriptableObject
    {
        /// <summary>
        /// Current active item in the inventory.
        /// </summary>
        public Item currentItem;
        
        /// <summary>
        /// Runtime value representing the amount of keys present in the inventory
        /// during the game session.
        /// </summary>
        public FloatValue currentKeysValue;
        
        /// <summary>
        /// Maximum number of keys present in the players inventory at the same time.
        /// </summary>
        public FloatValue maxKeysValue;

        /// <summary>
        /// Represents whether the player has acquired a sword or not. A boolean value is used as a global variable.
        /// </summary>
        public BooleanValue hasSword;
        
        /// <summary>
        /// Represents whether the player has acquired the remote terminal or not.
        /// A boolean value is used as a global variable.
        /// </summary>
        public BooleanValue hasTerminal;
        
        /// <summary>
        /// Adds an item to the inventory after checking what type of item it is.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            if (item.isKey && currentKeysValue.runtimeValue < maxKeysValue.runtimeValue)
                currentKeysValue.runtimeValue++;
            else if (item.isSword)
                hasSword.runtimeValue = true;
            else if (item.isTerminal)
                hasTerminal.runtimeValue = true;
        }

        /// <summary>
        /// Subtract a key from player's inventory.
        /// </summary>
        public void SubtractKey()
        {
            currentKeysValue.runtimeValue = Mathf.Max(0, currentKeysValue.runtimeValue - 1);
        }
    }
}
