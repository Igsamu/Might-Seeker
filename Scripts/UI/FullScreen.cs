using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resDrop;
    Resolution[] resolutions; //Recoge las resoluciones disponibles en el ordenador
    private void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.enabled = true;
        }
        else
        {
            toggle.enabled = false;
        }

        RevRes();
    }

    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void RevRes()
    {
        resolutions = Screen.resolutions; //Asigna las resoluciones
        resDrop.ClearOptions(); //Limpia las opciones del dropdown
        List<string> options = new List<string>();
        int resAct = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                resAct = i;
            }
        }

        resDrop.AddOptions(options);
        resDrop.value = resAct;
        resDrop.RefreshShownValue();
    }

    public void ChangeResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
