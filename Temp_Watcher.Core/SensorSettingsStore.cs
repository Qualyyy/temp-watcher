using System.Text.Json;

namespace Temp_Watcher.Core
{
    public class SensorSettingsStore
    {
        private readonly string settingsPath;

        public SensorSettingsStore()
        {
            string appData = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);

            settingsPath = Path.Combine(
                appData,
                "TempWatcher",
                "settings.json");
        }

        public SensorSettings? Load()
        {
            if (!File.Exists(settingsPath))
                return null;

            string json = File.ReadAllText(settingsPath);

            return JsonSerializer.Deserialize<SensorSettings>(json);
        }

        public void Save(SensorSettings settings)
        {
            string? directory = Path.GetDirectoryName(settingsPath);

            if (directory != null)
                Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(settingsPath, json);
        }
    }
}