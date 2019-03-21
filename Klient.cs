using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Net.Sockets;


public class Client
{
    const int PORT_NO = 5000;
    const string SERVER_IP = "127.0.0.1";

    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Client");

        Data player = new Data();
        player.Id.player = "crowisover2";
        player.Id.ModelCharacter = "grunt1";
        player.Id.Senjata = "AK-56";
        player.XYplayer.X = 1;
        player.XYplayer.Y = 2;
        player.XYbullet.X = 1;
        player.XYbullet.Y = 2;
        player.Status_dead_alive = "dead";

        //---create a TCPClient object at the IP and port no.---
        TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
        NetworkStream nwStream = client.GetStream();
        byte[] bytesToSend = byteData.serializable(player);

        //---send the text---
        nwStream.Write(bytesToSend, 0, bytesToSend.Length);

        byte[] buffer = new byte[client.ReceiveBufferSize];
        int dataLength = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        //---convert the data received into a string---
        Data dataEnemy = (Data)byteData.Deserializable(buffer, dataLength);
        if (dataLength == null) Console.WriteLine("NULL");
        dataEnemy.Show();

        //---read back the text---
        /*            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));*/
        Console.ReadLine();
        client.Close();
    }
}