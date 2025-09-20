using System.IO;
using UnityEngine;

public class UserExperience : MonoBehaviour
{
    public static UserExperience Instance;

    public string userName;
    public string bestUserName;
    public int bestUserScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestUser();
        //ClearData();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestUserName;
        public int bestUserScore;
    }

    public void SaveBestUser()
    {
        SaveData data = new SaveData();
        data.bestUserName = bestUserName;
        data.bestUserScore = bestUserScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestUser()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestUserName = data.bestUserName;
            bestUserScore = data.bestUserScore;
        }
    }

    void ClearData(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Archivo de guardado eliminado.");
        }
        else
        {
            Debug.Log("No se encontró el archivo para eliminar.");
        }
    }
    
}
