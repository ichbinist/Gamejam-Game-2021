﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }
}
