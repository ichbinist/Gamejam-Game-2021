using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : Singleton<CombatManager>
{
    public UnityEvent OnDeath = new UnityEvent();
}
