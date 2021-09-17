using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.Dialog;
using MRTK.Tutorials.MultiUserCapabilities;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;

public class MenùButton : MonoBehaviour
{
    public GameObject DocumentationDialog;
    public GameObject Model;
    private int counterLoad = 0;
    private int counterFollow = 0;
    private int x = 0;


    public void SeeDocument()
    {
        DocumentationDialog.SetActive(true);
    }

    public void LoadModel()
    {
        if (counterLoad == 0)
        {
            Model.GetComponent<PhotonRoom>().CreateInteractableObjects();
            //GameObject.Find("Elettromandrino_Complete_Variant").SetActive(true);
            counterLoad++;
        }
        else
            GameObject.Find("GameManager").GetComponent<Microsoft.MixedReality.Toolkit.Examples.Experimental.DialogTest.DialogExampleController>().OpenLoadModelError();
    }

    public void FollowMe()
    {
        if (counterFollow == 0)
        {
            GameObject.Find("SharedPlayground").GetComponent<FollowMeToggle>().enabled = true;
            GameObject.Find("SharedPlayground").GetComponent<RadialView>().enabled = true;
            GameObject.Find("SharedPlayground").GetComponent<SolverHandler>().enabled = true;

            GameObject.Find("CallButtons").GetComponent<FollowMeToggle>().enabled = true;
            GameObject.Find("CallButtons").GetComponent<RadialView>().enabled = true;
            GameObject.Find("CallButtons").GetComponent<SolverHandler>().enabled = true;

            GameObject.Find("LocalMedia").GetComponent<FollowMeToggle>().enabled = true;
            GameObject.Find("LocalMedia").GetComponent<RadialView>().enabled = true;
            GameObject.Find("LocalMedia").GetComponent<SolverHandler>().enabled = true;

            GameObject.Find("RemoteMedia").GetComponent<FollowMeToggle>().enabled = true;
            GameObject.Find("RemoteMedia").GetComponent<RadialView>().enabled = true;
            GameObject.Find("RemoteMedia").GetComponent<SolverHandler>().enabled = true;

            counterFollow++;
        }
        else
        {
            GameObject.Find("SharedPlayground").GetComponent<FollowMeToggle>().enabled = false;
            GameObject.Find("SharedPlayground").GetComponent<RadialView>().enabled = false;
            GameObject.Find("SharedPlayground").GetComponent<SolverHandler>().enabled = false;

            GameObject.Find("CallButtons").GetComponent<FollowMeToggle>().enabled = false;
            GameObject.Find("CallButtons").GetComponent<RadialView>().enabled = false;
            GameObject.Find("CallButtons").GetComponent<SolverHandler>().enabled = false;

            /*GameObject.Find("LocalMedia").GetComponent<FollowMeToggle>().enabled = false;
            GameObject.Find("LocalMedia").GetComponent<RadialView>().enabled = false;
            GameObject.Find("LocalMedia").GetComponent<SolverHandler>().enabled = false;

            GameObject.Find("RemoteMedia").GetComponent<FollowMeToggle>().enabled = false;
            GameObject.Find("RemoteMedia").GetComponent<RadialView>().enabled = false;
            GameObject.Find("RemoteMedia").GetComponent<SolverHandler>().enabled = false;
            */
            counterFollow--;
        }

    }

    /*public void ExplodedView()
    {
        if (x == 0)
        {
            GameObject.Find("Elettromandrino_model").SetActive(false);    
            GameObject.Find("Elettromandrino_Exploded").SetActive(true);
            x++;
        }
        else
        {
            GameObject.Find("Elettromandrino_Exploded").SetActive(false);
            GameObject.Find("Elettromandrino_model").SetActive(true);
            x--;
        }
    
    }
    */
}
