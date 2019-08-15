using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {
    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool fadeToBlack;
    private bool fadeToGame;



    // Start is called before the first frame update
    void Start() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {

          if(fadeToBlack) {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f) {
                fadeToBlack = false;
            }
          }

          if (fadeToGame) {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f) {
               fadeToGame = false;
            }
        }
    }

    public void FadeToBlack() {
        fadeToBlack = true;
        fadeToGame = false;
    }

    public void FadeToGame() {
        fadeToBlack = false;
        fadeToGame = true;
    }
}
