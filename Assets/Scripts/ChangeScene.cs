using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public string ButtonName = "Fire1";
    public string NextScene = "Flappy_0";

	// Update is called once per frame
	void Update () {
        bool isPressed = Input.GetButtonDown(ButtonName);

        if(isPressed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(NextScene);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
