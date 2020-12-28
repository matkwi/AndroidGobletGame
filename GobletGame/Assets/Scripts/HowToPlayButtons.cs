using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButtons : MonoBehaviour {

    private HTPImages _images;

    private void Start() {
        _images = GameObject.Find("HowToPlayImages").GetComponent<HTPImages>();
    }

    public void Back() {
        Debug.Log(_images.counter);
        switch (_images.counter) {
            case 1:
                _images.image1.SetActive(false);
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
            case 2:
                _images.image2.SetActive(false);
                _images.image1.SetActive(true);
                _images.tutorialText.SetText(_images.text1);
                _images.counter -= 1;
                break;
            case 3:
                _images.image3.SetActive(false);
                _images.image2.SetActive(true);
                _images.tutorialText.SetText(_images.text2);
                _images.counter -= 1;
                break;
            case 4:
                _images.image4.SetActive(false);
                _images.image3.SetActive(true);
                _images.tutorialText.SetText(_images.text3);
                _images.counter -= 1;
                break;
            case 5:
                _images.image5.SetActive(false);
                _images.image4.SetActive(true);
                _images.tutorialText.SetText(_images.text4);
                _images.counter -= 1;
                break;
        }
    }

    public void Next() {
        Debug.Log(_images.counter);
        switch (_images.counter) {
            case 1:
                _images.image1.SetActive(false);
                _images.image2.SetActive(true);
                _images.tutorialText.SetText(_images.text2);
                _images.counter += 1;
                break;
            case 2:
                _images.image2.SetActive(false);
                _images.image3.SetActive(true);
                _images.tutorialText.SetText(_images.text3);
                _images.counter += 1;
                break;
            case 3:
                _images.image3.SetActive(false);
                _images.image4.SetActive(true);
                _images.tutorialText.SetText(_images.text4);
                _images.counter += 1;
                break;
            case 4:
                _images.image4.SetActive(false);
                _images.image5.SetActive(true);
                _images.tutorialText.SetText(_images.text5);
                _images.counter += 1;
                break;
            case 5:
                _images.image5.SetActive(false);
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
        }
    }
}
