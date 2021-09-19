using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WaveRunnerV2.Models
{
    public class ConfigModel
    {
        public List<AudioFile> AudioClips { get; set; }
        public List<MusicFile> Music { get; set; }
        public int FadeOutTimer { get; set; }

        public void SaveChanges(string configPath)
        {
            File.WriteAllText(configPath, JsonConvert.SerializeObject(this));
        }
    }

    public class AudioFile
    {
        public string FileName { get; set; }
        public string NickName { get; set; }
        public int SortOrder { get; set; }
    }

    public class MusicFile
    {
        public string FileName { get; set; }
        public int SortOrder { get; set; }
    }

    
}
