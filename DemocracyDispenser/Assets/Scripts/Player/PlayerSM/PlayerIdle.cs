using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace DemocracyDispenser
{
    public class PlayerIdle : IPlayerState
    {
        private InputHandler handler;
        public override void EnterState(PlayerController player)
        {
            handler = InputHandler.Instance;
        }

        public override void ExitState(PlayerController player)
        {
        }

        public override void UpdateState(PlayerController player)
        {
            Vector2 viewPos;
            viewPos.x = Math.Clamp(player.transform.position.x, player.XBoundary.position.x*-1, player.XBoundary.position.x);
            viewPos.y = Math.Clamp(player.transform.position.y, player.YBoundary.position.y*-1, player.YBoundary.position.y);
            player.transform.position = viewPos;
            if (InputHandler.Instance.GetMovementVector() != Vector2.zero)
            {
                player.ChangeState(new PlayerWalk());
            }
        }
    }
}
