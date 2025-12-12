using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace P1NGMU
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenualBack;
        public GameObject Menual;
        public GameObject Story;
        public void BtnManual()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMenual", 2f);
        }

        public void BtnStory()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenStory", 2f);
        }

        public void BtnBack(int num)
        {
            switch (num)
            {
                case 0: //Menual
                    Menual.GetComponent<Animator>().SetTrigger("Close");
                    Invoke("OpenMenuBack", 2f);
                    break;
                case 1: //Story
                    Story.GetComponent<Animator>().SetTrigger("Close");
                    Invoke("OpenMenuBack", 2f);
                    break;
            }
        }

        public void BtnStart()
        {
            SceneManager.LoadScene("stage01");
        }

        public void BtnExit()
        {
            Application.Quit();
        }

        void OpenMenual()
        {
            Menual.SetActive(true);
            Menual.GetComponent<Animator>().SetTrigger("Open");
        }

        void OpenMenuBack()
        {
            MenualBack.GetComponent<Animator>().SetTrigger("Open");
        }
        void OpenStory()
        {
            Story.SetActive(true);
            Story.GetComponent<Animator>().SetTrigger("Open");
        }
    }
}
