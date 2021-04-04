using System;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
namespace LqmToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            var outDir = args[1];
            if(Directory.Exists(outDir)){
                Directory.Delete(outDir, true);
                Directory.CreateDirectory(outDir);
            }

            var dir = args[0];
            var files = Directory.GetFiles(dir).Where(x => x.EndsWith("lqm")).ToList();
            var i = 0;
            foreach(var f in files){
                var lines =  File.ReadAllLines(f);
                foreach (var l in lines) { 
                    if(l.Contains("DescRaw")){
                        var line = l.Replace("\"DescRaw\": \"", string.Empty);
                        line = line.Replace("\",", string.Empty);
                        line = line.Trim();
                        line = Regex.Unescape(line);
                        //System.Console.WriteLine(line);

                        var newFileName = $@"{outDir}\Memo {++i}.txt";
                        System.Console.WriteLine(newFileName);
                        File.WriteAllText(newFileName, line);
                    }
                }
            }
        }
    }
}