using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DailyTracker2
{
    public class ConfigHandler : GSMemory
    {
        public RSTaskList Dailies = new RSTaskList {  };
        public RSTaskList Weeklies = new RSTaskList();
        public RSTaskList Monthlies = new RSTaskList();
        public event EventHandler ListsUpdated;

        Form1 form;

        public ConfigHandler()
        {
            
        }

        public RSTask GetTaskByName(string Name)
        {
            return Dailies.Concat(Weeklies).Concat(Monthlies).Where(x => x.Name == Name).FirstOrDefault();
        }

        public void Init(Form1 form)
        {
            Console.Write("Starting ConfigHandler Init...");
            this.form = form;
            CheckLists();
            Console.WriteLine(" Done!");
        }

        public void CheckLists()
        {
            List<string>[] Lists = GetWholeFiles("dailies.txt", "weeklies.txt", "monthlies.txt");
            UpdateList(ref Dailies, Lists[0]);
            UpdateList(ref Weeklies, Lists[1]);
            UpdateList(ref Monthlies, Lists[2]);
            ListsUpdated?.Invoke(this, null);
        }

        void UpdateList(ref RSTaskList list, List<string> file)
        {
            if(list.Count != file.Count)
            {
                file.Except(list.Select(x => x.Name));
                foreach(string a in file)
                {
                    list.Add(new RSTask { Name = a });
                }
            }
            WeighList(ref list);
        }

        void WeighList(ref RSTaskList list)
        {
            list.OrderBy(x => x.Name);
            for(int i = 0; i < list.Count; i++)
            {
                list[i].Weight = i;
            }
        }

        List<string>[] GetWholeFiles(params string[] filename)
        {
            List<string>[] ret = new List<string>[filename.Length];
            for(int i = 0; i < filename.Length; i++)
            {
                if (File.Exists(filename[i]))
                {
                    ret[i] = File.ReadAllLines(filename[i]).ToList();
                }
                else 
                {
                    ret[i] = new List<string>(); 
                }
            }
            return ret;
        }
    }

    public class RSTaskList : List<RSTask>
    {
        public TaskType TaskType { get { return taskType; } set { taskType = value; } }
        TaskType taskType;
        Task taskThread = null;
        public event EventHandler ListUpdated;

        public void RunThread()
        {
            if(taskThread != null && taskThread.Status != TaskStatus.Running)
            {
                taskThread = new Task(() =>
                {
                    DateTime Reset = TimeHelper.GetResetDate(taskType).AddMinutes(TimeHelper.GetOffset());
                    bool update = false;
                    ForEach(x =>
                    {
                        if (DateTime.Compare(x.ResetTime, DateTime.Now) < 1)
                        {
                            x.Complete(false);
                            update = true;
                        }
                    });
                    if (update) ListUpdated?.Invoke(this, null);
                    while (true)
                    {
                        TimeSpan ts = Reset - DateTime.Now;
                        Thread.Sleep((int)-ts.TotalMilliseconds);
                        ForEach(x => x.Complete(false));
                        ListUpdated?.Invoke(this, null);
                        Reset = TimeHelper.GetResetDate(taskType).AddMinutes(TimeHelper.GetOffset());
                    }
                });
            }
        }

        
    }

    public class RSTask
    {
        public string Name;
        public bool isCompleted;
        public bool isEnabled = true;
        public DateTime ResetTime;
        public int Weight;
        public TaskType taskType;

        public void Complete(bool isComplete)
        {
            if (!isComplete)
            {
                ResetTime = DateTime.MinValue;
            }
            else
            {
                ResetTime = TimeHelper.GetResetDate(taskType);
            }
            isCompleted = isComplete;
        }

        

    }

    public static class TimeHelper
    {
        public static DateTime GetResetDate(TaskType taskType)
        {

            DateTime now = DateTime.Now.AddMinutes(-TimeHelper.GetOffset());
            switch (taskType)
            {
                case TaskType.Daily:
                    return new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1);

                case TaskType.Weekly:
                    if ((int)now.DayOfWeek < 3)
                    {
                        return new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(DayOfWeek.Wednesday - now.DayOfWeek);
                    }
                    else
                    {
                        return new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(10 - (int)now.DayOfWeek);
                    }

                case TaskType.Monthly:
                    return new DateTime(now.Year, now.Month, 1, 0, 0, 0).AddMonths(1);
            }
            return DateTime.Now;
        }

        public static double GetOffset()
        {
            return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalMinutes;
        }
    }

    public enum TaskType
    {
        Daily = 0,
        Weekly = 1,
        Monthly = 2,
    }

    public class GSMemory
    {
        public void SaveMemory(string FileToSave)
        {
            XmlSerializer Save = new XmlSerializer(this.GetType());

            FileStream Fi = File.Create(FileToSave);
            Save.Serialize(Fi, this);
            Fi.Close();
        }

        public void SaveMemory(string FileToSave, XmlAttributeOverrides Ignores)
        {
            XmlSerializer Save = new XmlSerializer(this.GetType(), Ignores);

            FileStream Fi = File.Create(FileToSave);
            Save.Serialize(Fi, this);
            Fi.Close();
        }
    }

    public static class GSMemoryLoader
    {
        public static GSMemory LoadMemory(string FileToRead, Type MemoryType)
        {
            if (File.Exists(FileToRead))
            {

                XmlSerializer MemoryRead = new XmlSerializer(MemoryType);
                StreamReader MemoryReader = new StreamReader(FileToRead);
                StringReader StringMemory = new StringReader(MemoryReader.ReadToEnd());
                MemoryReader.Close();
                object Memory = MemoryRead.Deserialize(StringMemory);
                return (GSMemory)Memory;
            }
            else
            {
                return (GSMemory)Activator.CreateInstance(MemoryType);
            }
        }
    }
}
