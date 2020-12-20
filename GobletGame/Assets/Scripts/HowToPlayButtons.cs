using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButtons : MonoBehaviour {

    private HTPImages images;

    private void Start() {
        images = GameObject.Find("HowToPlayImages").GetComponent<HTPImages>();
    }

    public void Back() {
        Debug.Log(images.counter);
        switch (images.counter) {
            case 1:
                images.Image1.SetActive(false);
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
            case 2:
                images.Image2.SetActive(false);
                images.Image1.SetActive(true);
                images.TutorialText.SetText(images.Text1);
                images.counter -= 1;
                break;
            case 3:
                images.Image3.SetActive(false);
                images.Image2.SetActive(true);
                images.TutorialText.SetText(images.Text2);
                images.counter -= 1;
                break;
            case 4:
                images.Image4.SetActive(false);
                images.Image3.SetActive(true);
                images.TutorialText.SetText(images.Text3);
                images.counter -= 1;
                break;
            case 5:
                images.Image5.SetActive(false);
                images.Image4.SetActive(true);
                images.TutorialText.SetText(images.Text4);
                images.counter -= 1;
                break;
        }
    }

    public void Next() {
        Debug.Log(images.counter);
        switch (images.counter) {
            case 1:
                images.Image1.SetActive(false);
                images.Image2.SetActive(true);
                images.TutorialText.SetText(images.Text2);
                images.counter += 1;
                break;
            case 2:
                images.Image2.SetActive(false);
                images.Image3.SetActive(true);
                images.TutorialText.SetText(images.Text3);
                images.counter += 1;
                break;
            case 3:
                images.Image3.SetActive(false);
                images.Image4.SetActive(true);
                images.TutorialText.SetText(images.Text4);
                images.counter += 1;
                break;
            case 4:
                images.Image4.SetActive(false);
                images.Image5.SetActive(true);
                images.TutorialText.SetText(images.Text5);
                images.counter += 1;
                break;
            case 5:
                images.Image5.SetActive(false);
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
        }
    }
}
