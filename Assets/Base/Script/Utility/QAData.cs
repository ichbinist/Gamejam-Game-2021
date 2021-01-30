using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QAData", menuName = "ScriptableObjects/QAData", order = 1)]
public class QAData : ScriptableObject
{
    public string Question;

    public List<string> Answers = new List<string>();
}
