using UnityEngine;
using System.Collections;

public class Data_Loader : MonoBehaviour {

    public string[] items;

	// Use this for initialization
	IEnumerator Start () {
        WWW itemsData = new WWW("http://localhost/wizard_academy/login.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        items = itemsDataString.Split(';');
	}

    string GetDataValue(string data, string index) {
        string value = data.Substring(data.IndexOf(index) + index.Length+2);
        if (value.Contains("|")){
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }
    
    public bool CheckLogin(string user, string password)
    {
        print("Checking " + user + ", " + password);
        for (int i = 0; i < items.Length-1; i++)
        {
            if (GetDataValue(items[i], "Name").Equals(user) && GetDataValue(items[i], "Password").Equals(password))
            {
                print("Success");
                return true;
            }
        }
        print("No Match");
        return false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
