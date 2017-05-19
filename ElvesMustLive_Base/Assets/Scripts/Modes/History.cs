using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : GameMode {

    public int Map;
    public int waveRemaining;

    Queue<KeyValuePair<string, float>> queue;

    public override bool HasNextLevel()
    {
        return waveRemaining != 0;
    }

    public override Queue<KeyValuePair<string, float>> LoadNextLevel()
    {
        queue = new Queue<KeyValuePair<string, float>>();
        //level++;
        switch (Map)
        {
            case 1:
                /////////////////////////////////////////// MAP 1
                switch (waveRemaining)
                {
                    case 5:
                        Add("Ennemy0", 5f); // Vague 1
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave1");
                        break;
                    case 4:
                        Add("Ennemy0", 5f); // Vague 2
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f); // Vague 2
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave2");
                        break;

                    case 3:
                        Add("Ennemy0", 5f); // Vague 3
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f); // Vague 3
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // Vague 3
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave3");
                        break;
                    case 2:
                        Add("Ennemy0", 5f); // Vague 4
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f); // Vague 4
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // Vague 4
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave4");
                        break;

                    case 1:
                        Add("Ennemy0", 5f); // Vague 5
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // Vague 5
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f); // Vague 5
                        Add("Ennemy0", 0.1f); // String dans ressource et temps qui le sépare du mob précédent.
                        Add("Ennemy0", 0.1f);
                        Add("Boss1", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave5_1");
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map1_wave5_2");
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                ////////////////////////////////////////////// MAP 2
                switch (waveRemaining)
                {
                    case 5:
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);// Vague 1
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave1");
                        break;
                    case 4:
                        Add("Ennemy0", 5f); // Vague 2
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave2");
                        break;
                    case 3:
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 3f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave3");
                        break;

                    case 2:
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 3f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave4");
                        break;

                    case 1:
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Boss1", 2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Boss1", 2f);
                        Add("MOB_Sapeur", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 3f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss2", 2f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave5_1");
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map2_wave5_2");
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                //////////////////////////////////////////// MAP 3
                switch (waveRemaining)
                {
                    case 4:
                        Add("Ennemy0", 5f); // Vague 1
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map3_wave1");
                        break;
                    case 3:
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Assassin", 5f); // Vague 2
                        Add("Assassin", 0.1f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss1", 5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Assassin", 5f); // Vague 2
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss1", 5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map3_wave2");


                        break;
                    case 2:
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss1", 5f);
                        Add("Ennemy0", 1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss1", 5f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss2", 5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map3_wave3");
                        break;
                    case 1:
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Assassin", 0.1f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss3", 5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map3_wave4_1");
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map3_wave4_2");
                        break;
                    default:
                        break;
                }
                break;
            case 4:

                //////////////////////////////////////////// MAP 4
                switch (waveRemaining)
                {
                    case 5://Vague 1
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss1", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave1");

                        break;
                    case 4://Vague 2
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("MOB_Sapeur", 1f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss2", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave2");
                        break;
                    case 3://Vague 3
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Assassin", 1f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 10f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Ennemy0", 0.2f);
                        Add("Boss2", 0.2f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave3");
                        break;
                    case 2://Vague 4
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Boss3", 0.5f);
                        Add("Ennemy0", 7.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Boss3", 0.5f);
                        Add("Ennemy0", 7.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Assassin", 1f);
                        Add("Assassin", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 1f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Boss3", 1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave4");

                        break;
                    case 1://vague 5
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Boss3", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Assassin", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("MOB_Sapeur", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Ennemy0", 0.5f);
                        Add("Boss3", 0.5f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        Add("Ennemy0", 0.1f);
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave5_1");
                        wave.game.masterClient.photonView.RPC("ShowHistory", PhotonTargets.All, "map4_wave5_2");
                        break;

                    default:
                        break;
                }
                break;
            default:
                break;
        }
        waveRemaining -= 1;
        Debug.Log(waveRemaining);
        return queue;
    }

    // Use this for initialization
    void Start () {
        Map = PlayerPrefs.GetInt("Histoire");
        switch (Map)
        {
            case 1:
                //Map1
                waveRemaining = 5;
                break;
            case 2:
                //Map2
                waveRemaining = 5;
                break;
            case 3:
                //Map3
                waveRemaining = 4;
                break;
            case 4:
                //Map3
                waveRemaining = 5;
                break;
            default:
                break;
        }
        level = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(string ennemy, float waitTime)
    {
        queue.Enqueue(new KeyValuePair<string, float>(ennemy, waitTime));
    }
}
