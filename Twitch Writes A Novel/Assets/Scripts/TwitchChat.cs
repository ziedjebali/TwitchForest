﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;

public class TwitchChat : MonoBehaviour
{
    public static string lastName;

    public GameObject GameManager;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private int index = 0;

    public string username, password, channelName; //Get the password from https://twitchapps.com/tmi

    public Text chatBox;
    public Rigidbody player;
    public int speed;

    void Start()
    {
        lastName = "Twitch User";

        
        Connect();
    }

    void Update()
    {
        if (!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
    }

    private void ReadChat()
    {
        if (twitchClient.Available > 0)
        {
            var message = reader.ReadLine(); //Read in the current message

            if (message.Contains("PRIVMSG"))
            {
                //Get the users name by splitting it from the string
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //Get the users message by splitting it from the string
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                //print(String.Format("{0}: {1}", chatName, message));
                chatBox.text = chatBox.text + "\n" + String.Format("{0}: {1}", chatName, message);

                lastName = chatName;


                //Run the instructions to control the game!
                GameInputs(message);
            }
        }
    }

    private void GameInputs(string ChatInputs)
    {
        if (ChatInputs.ToLower() == "spawn red")
        {
            GameManager.GetComponent<SkeletonSpawner>().SpawnSkeletonRed();
            Debug.Log("Spawned Skele Red");
        }

        if (ChatInputs.ToLower() == "spawn blue")
        {
            GameManager.GetComponent<SkeletonSpawner>().SpawnSkeletonBlue();
            Debug.Log("Spawned Skele Blue");
        }

        if (ChatInputs.ToLower() == "forward")
        {
            player.AddForce(Vector3.forward * (speed * 1000));
        }
    }
    
}
