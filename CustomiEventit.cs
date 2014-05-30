using UnityEngine;
using System.Collections;
using System;


//namespace KustomiEventit
//{

    public class CustomiEventit : MonoBehaviour
    {
        KustomiEventit.Car biili;

        void Start()
        {
            // Luo uusi olio
            KustomiEventit.Car biili = new KustomiEventit.Car();

            // Adds an event handler to the OwnerChanged event
            // biili.OwnerChanged += new EventHandler(biili_OwnerChanged);




            //adds an event handler to the OwnerChanged event
			// EI TOIMI		
            //biili.OwnerChanged += new OwnerChangedEventHandler(biili_OwnerChanged);




            // biili.OwnerChanged += new OwnerChangedEventHandler(biili_OwnerChanged);
            //OwnerChangedEventHandler(biili_OwnerChanged);       // Fire an event !

            biili.CarOwner = "Kentsu";

        }

        void OnClick()
        {
            Debug.Log("Painettu nappulaa !");

        }

        void biili_OwnerChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("Tulta : +" + i + " !\n");
            }
        }
    }
//}