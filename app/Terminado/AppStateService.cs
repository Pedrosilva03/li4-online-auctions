using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace app.Terminado
{

    public class AppStateService
    {
        public static AppStateService _instance;
        public static readonly string filePath = "terminadoHandledMap.json";
        public Dictionary<int, bool> TerminadoHandledMap { get; set;} = new Dictionary<int, bool>();

        public AppStateService()
        {
            LoadState();
        }

        public static AppStateService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AppStateService();
            }
            return _instance;
        }

        public void SaveState()
        {
            string json = JsonSerializer.Serialize(TerminadoHandledMap);
            File.WriteAllText(filePath, json);
        }

        public void LoadState()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                TerminadoHandledMap = JsonSerializer.Deserialize<Dictionary<int, bool>>(json);
            }
        }

    }

}