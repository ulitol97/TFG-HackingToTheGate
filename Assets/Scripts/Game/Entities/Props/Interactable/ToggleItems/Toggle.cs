﻿using Game.Audio;
using Game.Entities.Props.Interactable.Obstacles;
using UnityEngine;

namespace Game.Entities.Props.Interactable.ToggleItems
{
    /// <summary>
    /// The class Toggle represents any game object that acts as an ON-OFF mechanism. It is capable
    /// of communication with any Actionable, which will be opened by interaction with the Toggle object.
    /// </summary>
    public class Toggle : AbstractInteractable
    {
        /// <summary>
        /// Identifier of the switch, used for multi-switch doors that may require a specific order.
        /// </summary>
        public int id;
        
        /// <summary>
        /// Sprite attached to the switch when active.
        /// </summary>
        public Sprite activeSprite;
        
        /// <summary>
        /// Sprite attached to the switch when not active.
        /// </summary>
        public Sprite inactiveSprite;

        /// <summary>
        /// Reference to the sprite renderer in charge of rendering the sprite in game.
        /// </summary>
        protected SpriteRenderer SpriteRenderer;

        /// <summary>
        /// The Actionable elements the switch is linked to.
        /// A switch may send an "open" signal to the linked obstacles when activated.
        /// </summary>
        public Obstacle[] linkedObstacles;
        
        /// <summary>
        /// Function called when the Toggle is inserted into the game.
        /// Sets up references for changing the sprite of the toggle mechanism later on.
        /// </summary>
        protected virtual void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer.sprite = inactiveSprite;
        }

        /// <summary>
        /// Mark the toggle mechanism active, change its appearance and send an open signal to the
        /// obstacle attached.
        /// </summary>
        protected virtual void ActivateSwitch()
        {
            SpriteRenderer.sprite = activeSprite;

            foreach (var obstacle in linkedObstacles)
            {
                if (obstacle != null)
                    obstacle.OnActionReceived(id);
            }
            AudioManager.Instance.PlayEffectClip(AudioManager.ToggleSwitch);
        }
        
        /// <summary>
        /// Mark the toggle mechanism inactive and change its appearance.
        /// </summary>
        private void DeactivateSwitch()
        {
            SpriteRenderer.sprite = inactiveSprite;
            AudioManager.Instance.PlayEffectClip(AudioManager.ToggleSwitch);
        }

        /// <summary>
        /// Activate the toggle mechanism if entered by a player.
        /// </summary>
        /// <param name="other">Object colliding with the switch</param>
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
                ActivateSwitch();
        }
        
        /// <summary>
        /// Deactivate the toggle mechanism if a player exits the trigger zone.
        /// </summary>
        /// <param name="other"></param>
        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
                DeactivateSwitch();
        }
    }
}
