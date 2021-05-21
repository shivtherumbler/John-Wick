using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeLevel : MonoBehaviour
{
    public GameObject Select;
    public GameObject Parking1;
    public GameObject Rooftop;
    public GameObject Street;
    public GameObject Armory;
    public GameObject Subway;
    public GameObject House;
    public GameObject Parking2;
    public GameObject EnterHome;
    public GameObject MovieHall;
    public GameObject Rooftop2;
    public GameObject Lifts;
    public GameObject CameraRoom;
    public GameObject Street2;
    public GameObject Lifts2;
    public GameObject NightClub;
    public GameObject Pause;

    public void ParkingLot()
    {
        Parking1.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Roof()
    {
        Rooftop.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void NightStreet()
    {
        Street.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Weaponry()
    {
        Armory.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }    

    public void Train()
    {
        Subway.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Home()
    {
        House.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void ParkingLot2()
    {
        Parking2.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Entrance()
    {
        EnterHome.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }    

    public void Theatre()
    {
        MovieHall.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Roof2()
    {
        Rooftop2.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Lift()
    {
        Lifts.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void CyberRoom()
    {
        CameraRoom.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void LightStreet()
    {
        Street2.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Lift2()
    {
        Lifts2.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }

    public void Club()
    {
        NightClub.SetActive(true);
        Select.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Pause);
    }
}
