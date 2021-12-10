using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_V
    {
        public static Schedule[] Scheduled(Schedule[] arr)
        {            
            var rs = new List<Schedule>(arr.Length);
            int currentStart = 0;
            foreach (var item in arr)
            {
                if (item.Start >= currentStart)
                {
                    rs.Add(item);
                    currentStart = item.End;
                }
            }
            return rs.ToArray();
        }

        public static void TestScheduled()
        {
            int n = 10;
            List<Schedule> list = new(n);
            Random rd = new Random();
            string data = "";
            for (int i = 0; i < n; i++)
            {
                var temp = new Schedule(rd.Next(5, 10));
                data += temp + "\t";
            }
            Console.WriteLine(data);
            Common.WriteToFile(data.Trim('\t'));
            string[] a = Common.ReadFormFile().Split('\t');
            list = a.Select(s => Schedule.Parse(s)).ToList();
            Console.Write("Đầu vào : ");
            list.Print();
            list.Sort(new Schedule.Comparer());
            Console.Write("Sắp xếp : ");
            list.Print();
            Common.Monitoring(() =>
            {
                Console.Write("Kết quả : ");
                Scheduled(list.ToArray()).Print();
            });
        }

        public static Item[] GetItem(Item[] arr, int maxWeight)
        {
            List<Item> list = new(arr.Length);
            int currentWeight = 0;
            foreach (var item in arr)
            {
                if (currentWeight + item.Weight <= maxWeight)
                {
                    list.Add(item);
                    currentWeight += item.Weight;
                }
            }
            return list.ToArray();
        }

        public static void TestBalo()
        {
            int n = 10;
            int maxWeight = 10;
            string data = "";
            for (int i = 0; i < n; i++)
            {
                data += new Item(maxWeight, 10) + "\t";
            }
            data = data.Trim('\t');
            data += "\n" + maxWeight;
            Common.WriteToFile(data);
            data = Common.ReadFormFile();
            var sd = data.Split('\n');
            maxWeight = int.Parse(sd[1]);
            var itemsData = sd[0].Split('\t');
            List<Item> l = itemsData.Select(i => Item.Parse(i)).ToList();
            Console.Write("Đầu vào : ");
            l.Print();
            Console.Write("Sắp xếp : ");
            l.Sort(new Item.Comparer());
            l.Print();
            Common.Monitoring(() =>
            {
                Console.Write("Kết quả : ");
                GetItem(l.ToArray(), maxWeight).Print();
            });
        }
        public static string RutTien(int SoTien, int[] MenhGia, int i = 0)
        {
            if (i >= MenhGia.Length)
            {
                return "";
            }
            var rs = (SoTien / MenhGia[i] == 0 ? "" : $"Số tờ {MenhGia[i]}:{SoTien / MenhGia[i]};\n")
                + (!(SoTien % MenhGia[i] == 0) ? RutTien(SoTien % MenhGia[i], MenhGia, ++i) : "");
            return string.IsNullOrWhiteSpace(rs) ? "Không có mệnh giá phù hợp" : rs;
        }

        public static void TestRutTien()
        {
            Dictionary<int, int> MG = new();
            
            int[] MenhGia = new int[] { 20000, 50000, 100000, 200000, 500000 };
            //int soDu = 10000000;
            //int soTienRut = 5850000;
            //Common.WriteToFile(soDu + "\n" + soTienRut);
            string[] input = Common.ReadFormFile().Split('\n');
            input.Print();
            var soDu = int.Parse(input[0]);
            var soTienRut = int.Parse(input[1]);
            var mg = MenhGia.ToList();
            mg.Reverse();
            MenhGia = mg.ToArray();
            if (soDu - soTienRut >= 50000)
            {
                Console.WriteLine(RutTien(soTienRut, MenhGia));
            }
        }

        public static void TestSumArray()
        {
            int[] a = Common.RandomArray(1000, -1000, 1000);
            StreamWriter input = new StreamWriter("input.txt", false);
            for (int i = 0; i < a.Length; i++)
            {
                input.Write(a[i] + "#");
            }
            input.Close();
            StreamReader inputReader = new StreamReader("input.txt");
            int[] arr = inputReader.ReadToEnd().Trim('#').Split('#').Select(s => int.Parse(s)).ToArray();
            inputReader.Close();
            StreamWriter outputWriter = new StreamWriter("ontput.txt", false);
            outputWriter.Write(arr.Sum());
            outputWriter.Close();
        }
    }
    public class Schedule
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Schedule(int max)
        {
            Random rd = new Random();
            this.Start = rd.Next(0, max);
            this.End = rd.Next(this.Start, this.Start + max);
        }
        public Schedule(int S, int E)
        {
            Start = S;
            End = E;
        }
        public static Schedule Parse(string input)
        {
            var Match = Regex.Match(input, "([0-9]+;[0-9]+)");
            if (Match.Success)
            {
                var rs = Match.Value.Split(";");
                return new Schedule(int.Parse(rs[0]), int.Parse(rs[1]));
            }
            else
            {
                throw new Exception("Không đúng định dạng");
            }
        }
        public class Comparer : IComparer<Schedule>
        {
            public int Compare(Schedule x, Schedule y)
            {
                if (x.End == y.End)
                {
                    return x.Start - y.Start;
                }
                else
                {
                    return x.End - y.End;
                }
            }
        }
        public override string ToString()
        {
            return $"({Start};{End})";
        }
    }

    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
        public double AVG { get => Weight * 1.0 / Value; }
        public Item(int maxWeight, int maxValue)
        {
            Random rd = new();
            Weight = rd.Next(1, maxWeight);
            Value = rd.Next(1, maxValue);
        }
        public Item() { }
        public class Comparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                return x.AVG.CompareTo(y.AVG);
            }
        }
        public static Item Parse(string input)
        {
            var Match = Regex.Match(input, "([0-9]+;[0-9]+)");
            if (Match.Success)
            {
                var rs = Match.Value.Split(";");
                return new Item{ Weight = int.Parse(rs[0]), Value = int.Parse(rs[1]) };
            }
            else
            {
                throw new Exception("Không đúng định dạng");
            }
        }
        public override string ToString()
        {
            return $"({Weight};{Value})";
        }
    }
}
