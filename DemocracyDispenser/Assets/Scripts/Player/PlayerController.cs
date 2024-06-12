using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemocracyDispenser
{
public class PlayerController : MonoSingleton<PlayerController>
{
    private IPlayerState currentState;
    public Rigidbody2D rb;

    public PlayerStatsSO Stats;
    public Transform XBoundary, YBoundary;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        ChangeState(new PlayerIdle());
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void ChangeState(IPlayerState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
}