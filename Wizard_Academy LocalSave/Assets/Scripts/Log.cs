using UnityEngine;
using System.Collections;

public static class Log {

    static string LogURL = "http://wunderlich-paul.de/wizard/Log.php";

    public static int LogEntry(string action)
    {
        SaveLoad.Load();
        //Start Coroutine
        WWWForm form = new WWWForm();
        form.AddField("useridPost", Game.current.hero.id);
        string logString = "Aktion: " + action + ", ID: "+Game.current.hero.id+", N: " + Game.current.hero.Name + " ,C: " + Game.current.hero.ClassLevel + ", S: " + Game.current.hero.Subject + ", L: " + Game.current.hero.Level + ", XP: " + Game.current.hero.Xp + "/" + Game.current.hero.XpNeeded;
        Debug.Log("Logstring (" + logString.Length + "): " + logString);
        form.AddField("actionPost", logString);
        WWW www = new WWW(LogURL, form);
        while (!www.isDone) {
            //Wait
        }
        if (www.text.Contains("success"))
        {
            Debug.Log("Successfully Logged: " + action);
            return 1;
        }
        else {
            Debug.Log("Failed to Log: " + action);
            Debug.Log(www.text);
            return 0;
        }
        
    }
}
