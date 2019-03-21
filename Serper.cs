using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Server
{
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Server");

            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---nmb,jughf

            //---read incoming stream---
            using (NetworkStream nwStream = client.GetStream())
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int dataLength = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                Data dataEnemy = (Data)byteData.Deserializable(buffer, dataLength);
                if (dataLength == null) Console.WriteLine("NULL");
                dataEnemy.Show();

                byte[] bytesToSend = byteData.serializable(dataEnemy);

                //---send the text---
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            }
            //---write back the text to the client---

            // nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            listener.Stop();
            Console.ReadLine();
        }
    }
