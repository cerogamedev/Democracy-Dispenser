using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
    public class InputHandler : MonoSingleton<InputHandler>
    {
        private PlayerInputs playerInputs;
        void Awake()
        {
            playerInputs = new PlayerInputs();
            playerInputs.Player.Enable();
        }
        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = playerInputs.Player.Movement.ReadValue<Vector2>();
            return inputVector;
        }
    }
}
