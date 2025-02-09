using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DemocracyDispenser
{
    public class PlayerWalk : IPlayerState
    {
        public Vector2 Direction;
        public PlayerStats movementScript;
        public override void EnterState(PlayerController player)
        {
            movementScript = player.GetComponent<PlayerStats>();
            player.anim.Play("walk");

        }

        public override void ExitState(PlayerController player)
        {
        }

        public override void UpdateState(PlayerController player)
        {
            Direction = InputHandler.Instance.GetMovementVector();
            player.rb.AddForce(Direction * movementScript.MovementSpeed * Time.deltaTime, ForceMode2D.Impulse);

            Vector2 viewPos;
            viewPos.x = Math.Clamp(player.transform.position.x, player.XBoundary.position.x*-1, player.XBoundary.position.x);
            viewPos.y = Math.Clamp(player.transform.position.y, player.YBoundary.position.y*-1, player.YBoundary.position.y);
            player.transform.position = viewPos;

            if (InputHandler.Instance.GetMovementVector().x<0){player.sr.flipX = true;}
            else {player.sr.flipX = false;}

            if (InputHandler.Instance.GetMovementVector() == Vector2.zero)
            {
                player.ChangeState(new PlayerIdle());
            }
        }
    }
}
