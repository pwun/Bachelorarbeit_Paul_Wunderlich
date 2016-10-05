using UnityEngine;
using System.Collections;

public class User_Data_Loader : MonoBehaviour {

    public string[] items;
    public string user;
    // Use this for initialization
    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/wizard_academy/user.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split(';');
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length + 2);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

    public string getUser(int user_id)
    {
        for(int i = 0; i < items.Length - 1;i++)
        {
            if(GetDataValue(items[i], "user_id").Equals(user_id))
            {
                user = items[i];
                Debug.Log("Found User: " + user);
                return user;
            }
        }
        return "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
