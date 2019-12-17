using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveRunner.Models;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WaveRunner.Database
{
    public static class Interact
    {
        public static void Init()
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;

            if (!File.Exists(dbPath))
            {
                var newContext = new Models.WaveRunnerContext().ToJson();
                File.WriteAllText(dbPath, newContext);
            }

        }

        public static List<AudioFile> GetFiles()
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<AudioFile>();
            }
            else
            {
                var wrContext = Models.WaveRunnerContext.FromJson(json);

                if (wrContext.AudioFiles == null)
                    wrContext.AudioFiles = new List<AudioFile>();

                return wrContext.AudioFiles;
            }

        }

        public static List<Category> GetCategories()
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Category>();
            }
            else
            {
                var wrContext = Models.WaveRunnerContext.FromJson(json);

                if (wrContext.Categories == null)
                    wrContext.Categories = new List<Category>();


                return wrContext.Categories;
            }
        }

        public static void RemoveCategory(string category)
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);
            var wrContext = Models.WaveRunnerContext.FromJson(json);

            if (wrContext == null)
                wrContext = new WaveRunnerContext();

            if (wrContext.Categories == null)
                wrContext.Categories = new List<Category>();

            var catToRemove = wrContext.Categories.FirstOrDefault(d => d.CategoryName == category);
            wrContext.Categories.Remove(catToRemove);

            if (wrContext.AudioFiles != null && wrContext.AudioFiles.Any())
            {
                var allFiles = wrContext.AudioFiles.Where(d => d.Category == category);

                foreach (var file in allFiles)
                    file.Category = "";
            }
            var newjson = wrContext.ToJson();

            File.WriteAllText(dbPath, newjson);
        }

        public static void RemoveFile(string filename)
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);
            var wrContext = Models.WaveRunnerContext.FromJson(json);

            if (wrContext == null)
                wrContext = new WaveRunnerContext();

            if (wrContext.AudioFiles == null)
                wrContext.AudioFiles = new List<AudioFile>();

            var catToRemove = wrContext.AudioFiles.FirstOrDefault(d => d.Title == filename);
            wrContext.AudioFiles.Remove(catToRemove);

            var newjson = wrContext.ToJson();

            File.WriteAllText(dbPath, newjson);
        }


        public static void SaveNewCategory(Category category)
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);
            var wrContext = Models.WaveRunnerContext.FromJson(json);

            if (wrContext == null)
                wrContext = new WaveRunnerContext();

            if (wrContext.Categories == null)
                wrContext.Categories = new List<Category>();

            wrContext.Categories.Add(category);
            var newjson = wrContext.ToJson();

            File.WriteAllText(dbPath, newjson);
        }

        public static void SaveNewFile(AudioFile audioFile)
        {
            var dbPath = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
            var json = File.ReadAllText(dbPath);
            var wrContext = Models.WaveRunnerContext.FromJson(json);

            if (wrContext == null)
                wrContext = new WaveRunnerContext();

            if (wrContext.AudioFiles == null)
                wrContext.AudioFiles = new List<AudioFile>();

            wrContext.AudioFiles.Add(audioFile);
            var newjson = wrContext.ToJson();

            File.WriteAllText(dbPath, newjson);
        }
    }
}
