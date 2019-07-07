﻿using System.Text.RegularExpressions;
using UnityEngine;

namespace Game.Configuration
{
    /// <summary>
    /// The GameConfiguration class encapsulates all the configuration parameters the games need to run.
    /// Instances of this class can be loaded from a Json file.
    /// </summary>
    [System.Serializable]
    public class GameConfiguration
    {
        public VncConnectionInfo vncConnectionInfo;
        public SshConnectionInfo sshConnectionInfo;
        public int secondsBetweenConnectionAttempts;
        
        /// <summary>
        /// Class containing the user configuration for VNC connecting to the remote host.
        /// </summary>
        [System.Serializable]
        public class VncConnectionInfo
        {
            public string targetHost;
            public string vncServerPassword;
            public int port;
        }

        /// <summary>
        /// Class containing the user configuration for SSH connecting to the remote host.
        /// </summary>
        [System.Serializable]
        public class SshConnectionInfo
        {
            public string username;
            public string password;
            public int port;
            public PublicKeyAuth publicKeyAuth;
        }
        
        /// <summary>
        /// Class containing all the information regarding the use of a key pair to login into the remote server.
        /// </summary>
        [System.Serializable]
        public class PublicKeyAuth
        {
            public string path;
            public string passPhrase;
            public bool preferSshPublicKey;
        }

        /// <summary>
        /// Creates an instance of the GameConfiguration class from a JSON file with the correct format.
        /// </summary>
        /// <param name="jsonFilePath">Path where the json file is located.</param>
        /// <returns></returns>
        public static GameConfiguration CreateFromJson(string jsonFilePath)
        {
            return JsonUtility.FromJson<GameConfiguration>(jsonFilePath);
        }
        
        /// <summary>
        /// Represents the information held by the game configuration file in a text chain.
        /// </summary>
        /// <returns>String containing summary of the game configuration</returns>
        public override string ToString()
        {
            string ret = "";
            ret += "Target host: " + vncConnectionInfo.targetHost + "\n";
            ret += "VNC port: " + vncConnectionInfo.port + "\n";
            ret += "SSH login username: " + sshConnectionInfo.username + "\n";
            ret += "SSH login password: " + Regex.Replace(sshConnectionInfo.password, ".", "*") + "\n";
            ret += "SSH port: " + sshConnectionInfo.port + "\n";
            ret += "Prefer public key authentication: " + sshConnectionInfo.publicKeyAuth.preferSshPublicKey +"\n";
            return ret;
        }
    }
}
