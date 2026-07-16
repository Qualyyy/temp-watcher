using System.Text.Json;

namespace Temp_Watcher
{
    internal class PCStats
    {
        public float CPUTemperature { get; set; }
        public float GPUTemperature { get; set; }


        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
