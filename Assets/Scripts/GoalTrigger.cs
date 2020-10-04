using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public int Index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RoundManager.Current.GoalTriggerEnter(Index);
    }
}
