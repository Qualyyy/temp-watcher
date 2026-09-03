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

            try
            {
                string json = File.ReadAllText(settingsPath);

                return JsonSerializer.Deserialize<SensorSettings>(json);
            }
            catch (JsonException)
            {
                return null;
            }
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

            string tempPath = settingsPath + ".tmp";

            File.WriteAllText(tempPath, json);
            File.Move(tempPath, settingsPath, true);
        }
    }
}