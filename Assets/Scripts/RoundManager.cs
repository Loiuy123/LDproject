using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Current;

    private void Awake()
    {
        Current = this;
        CurrentLap = 1;
        TimeTracker = new System.Diagnostics.Stopwatch();
        TimeTracker.Start();
    }

    public GameObject CopyPrefab;
    public MovementRecorder Player;
    public Rigidbody2D PlayerRigid;
    public TMPro.TMP_Text LapText;
    public TMPro.TMP_Text Speed;
    public TMPro.TMP_Text TimeText;

    public System.Diagnostics.Stopwatch TimeTracker;
    
    
    public enum Region
    {
        Goal,
        Check,
        Spawn
    }
    public Region CurrentPlayerPos = Region.Goal;


    public int LastCheckPointIndex = 0;
    public static int lastId = 0;



    public int RequiredLaps = 2;
    public int CurrentLap = 1;


    private void Update()
    {
        LapText.text = "Lap " + CurrentLap + "/" + RequiredLaps;
        if (PlayerRigid==null)
        {
            PlayerRigid = Player.GetComponent<Rigidbody2D>();
        }
        Speed.text = ""+PlayerRigid.velocity.magnitude;
        TimeText.text = TimeTracker.Elapsed.ToString(@"mm\:ss\:fff");
        //TimeText.text = TimeTracker.Elapsed.Minutes.ToString("") + ":" + TimeTracker.Elapsed.Seconds+":" + TimeTracker.Elapsed.Milliseconds;
    }




    public string NextLevel;

    public GameObject LevelCompleteScreen;

    public void CompleteLevel()
    {
        // we complete the level
        LevelCompleteScreen.SetActive(true);
        Time.timeScale = 0;
        TimeTracker.Stop();
    }

    public void ClickNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
    }

    public void SpawnNewCopy()
    {
        var copy = Instantiate(CopyPrefab);
        copy.GetComponent<MovementPlayback>().Data = Player.CurrentData;
        copy.GetComponent<MovementPlayback>().ID = lastId++;
    }


    internal void CheckEnter(int Index)
    {
        if (LastCheckPointIndex < Index || (LastCheckPointIndex > 1 && Index == 0))
        {
            CurrentPlayerPos = Region.Check;
            LastCheckPointIndex = Index;
        }
    }

    internal void PlayerSpawnTriggerEnter(int Index)
    {
        if (LastCheckPointIndex < Index || (LastCheckPointIndex > 1 && Index == 0))
        {
            // spawn new player
            SpawnNewCopy();

            CurrentPlayerPos = Region.Spawn;
            LastCheckPointIndex = Index;
        }
    }

    internal void GoalTriggerEnter(int Index)
    {
        if (LastCheckPointIndex < Index || (LastCheckPointIndex > 1 && Index == 0))
        {
            // we can make the player faster
            CurrentLap++;
            if (CurrentLap > RequiredLaps)
            {
                CompleteLevel();
            }
            Player.GetComponent<MovementController>().FrontForce *= 1.1f;

            CurrentPlayerPos = Region.Goal;
            LastCheckPointIndex = Index;
        }
        
    }



}
