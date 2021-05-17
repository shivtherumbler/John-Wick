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

    public void ParkingLot()
    {
        Parking1.SetActive(true);
        Select.SetActive(false);
    }

    public void Roof()
    {
        Rooftop.SetActive(true);
        Select.SetActive(false);
    }

    public void NightStreet()
    {
        Street.SetActive(true);
        Select.SetActive(false);
    }

    public void Weaponry()
    {
        Armory.SetActive(true);
        Select.SetActive(false);
    }    

    public void Train()
    {
        Subway.SetActive(true);
        Select.SetActive(false);
    }

    public void Home()
    {
        House.SetActive(true);
        Select.SetActive(false);
    }

    public void ParkingLot2()
    {
        Parking2.SetActive(true);
        Select.SetActive(false);
    }

    public void Entrance()
    {
        EnterHome.SetActive(true);
        Select.SetActive(false);
    }    

    public void Theatre()
    {
        MovieHall.SetActive(true);
        Select.SetActive(false);
    }

    public void Roof2()
    {
        Rooftop2.SetActive(true);
        Select.SetActive(false);
    }

    public void Lift()
    {
        Lifts.SetActive(true);
        Select.SetActive(false);
    }

    public void CyberRoom()
    {
        CameraRoom.SetActive(true);
        Select.SetActive(false);
    }

    public void LightStreet()
    {
        Street2.SetActive(true);
        Select.SetActive(false);
    }

    public void Lift2()
    {
        Lifts2.SetActive(true);
        Select.SetActive(false);
    }

    public void Club()
    {
        NightClub.SetActive(true);
        Select.SetActive(false);
    }
}
