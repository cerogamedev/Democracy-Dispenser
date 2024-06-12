using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DemocracyDispenser
{
public abstract class IPlayerState
{
    public abstract void EnterState(PlayerController player);
    public abstract void UpdateState(PlayerController player);
    public abstract void ExitState(PlayerController player);

}
}