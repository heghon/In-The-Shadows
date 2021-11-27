using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public bool[] boolTabToSave;

    public LevelLockManager levelLockManager;

    public GameObject SavePanel;
    public Animator SavePanelAnimator;

    private void Awake()
    {
        boolTabToSave = new bool[] { false, false, false, false, false };
        levelLockManager = FindObjectOfType<LevelLockManager>();
    }

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (boolTabToSave[0] == false && levelLockManager.elephantOneStarHandler.victoryBool)
            boolTabToSave[0] = true;
        if (boolTabToSave[1] == false && levelLockManager.elephantTwoStarHandler.victoryBool)
            boolTabToSave[1] = true;
        if (boolTabToSave[2] == false && levelLockManager.teaPotOneStarHandler.victoryBool)
            boolTabToSave[2] = true;
        if (boolTabToSave[3] == false && levelLockManager.teaPotTwoStarHandler.victoryBool)
            boolTabToSave[3] = true;
        if (boolTabToSave[4] == false && levelLockManager.logoHandler.victoryBool)
            boolTabToSave[4] = true;
    }

    public void SaveGame()
    {
        if (levelLockManager.normalPlayMode)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
            SaveData data = new SaveData();
            data.savedBoolTab = boolTabToSave;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game Data Saved");
            SavePanelAnimator.Play("SavePanelAppearance");
        }
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            boolTabToSave = data.savedBoolTab;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no saved data!");
    }
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            boolTabToSave = new bool[] { false, false, false, false, false };
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public void SavePanelAppearance()
    {
        if (levelLockManager.normalPlayMode)
            SavePanelAnimator.Play("SavePanelAppearance");
    }
}

[Serializable]
class SaveData
{
    public bool[] savedBoolTab = new bool[5];
}

