using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ennemy : Character
{
    Object characterprefab = Resources.Load("ennemy");

    public Ennemy()
    {
        health = 30;
        characterobject = (GameObject)Instantiate(characterprefab);
        characterobject.AddComponent<EnnemyMov1>(); // Script de movement, on peut en ajouter d'autres et tout pour gerer les diffrentes IA
    }


}

