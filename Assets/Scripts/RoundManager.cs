using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Current;

    private void Awake()
    {
        Current = this;
    }

    public GameObject CopyPrefab;

    public MovementRecorder Player;

    public enum Region
    {
        Goal,
        Check,
        Spawn
    }
    public Region CurrentPlayerPos = Region.Goal;


    public int LastCheckPointIndex = 0;


    public static int lastId = 0;


    public void SpawnNewCopy()
    {
        var copy = Instantiate(CopyPrefab);
        copy.GetComponent<MovementPlayback>().Data = Player.CurrentData;
        copy.GetComponent<MovementPlayback>().ID = lastId++;
    }


    internal void CheckEnter(int Index)
    {
        CurrentPlayerPos = Region.Check;
        LastCheckPointIndex = Index;
    }

    internal void PlayerSpawnTriggerEnter(int Index)
    {
        if (CurrentPlayerPos == Region.Check && Index- LastCheckPointIndex <2)
        {
            // spawn new player
            SpawnNewCopy();
        }
        CurrentPlayerPos = Region.Spawn;
        LastCheckPointIndex = Index;
    }

    internal void GoalTriggerEnter(int Index)
    {
        if (CurrentPlayerPos == Region.Spawn && Index - LastCheckPointIndex < 2)
        {
            // we can make the player faster
            Player.GetComponent<MovementController>().FrontForce *= 1.1f;
            MovementPlayback.SpeedUp += 0.2f;
        }
        CurrentPlayerPos = Region.Goal;
        LastCheckPointIndex = Index;
    }



}
