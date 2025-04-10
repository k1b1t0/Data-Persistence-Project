using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;
    public string Name;
    public string NameMax;
    public int ScoreMax;

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int point;
    }

    public void SaveMax(int point)
    {
        SaveData data = new SaveData();
        data.name = Name;
        data.point = point;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadMax()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NameMax = data.name;
            ScoreMax = data.point;
        }
        else
        {
            NameMax = "none";
            ScoreMax = 0;
        }
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ReadInput(string s)
    {
        Name = s;
        Debug.Log(s);
        SceneManager.LoadScene("main");
    }
}
