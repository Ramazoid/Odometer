using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW www = new WWW("http://www.metazoid.ru/watcher.set.php"))
        {
            yield return www;
            print("Done.");
        }
    }
}
