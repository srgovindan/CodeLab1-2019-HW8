using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePosition : MonoBehaviour
{
    string filePath;
    public int[] highScores;
    
    // Start is called before the first frame update
    void Start()
    {
        highScores = new[] {4, 5, 6, 7, 8, 8};
        string spString = JsonUtility.ToJson(this, true);
        print(spString);
        File.WriteAllText(Application.dataPath + "/spStr.json",spString);
        
       // JsonUtility.FromJsonOverwrite(Application.dataPath+"/spStr.json",this);
        
        
        filePath = Application.dataPath + "/pos.json";
        if (File.Exists(filePath))
        {
            string contents = File.ReadAllText(filePath);
            transform.position = JsonUtility.FromJson<Vector3>(contents);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = transform.position;
            string posStr = JsonUtility.ToJson(position, true);
            print(posStr);
            File.WriteAllText(filePath,posStr);
        }
    }
}
