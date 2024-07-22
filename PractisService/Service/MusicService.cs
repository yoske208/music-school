using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool.Service
{
    internal class MusicService
    {
        /*public static Func<List<string>, bool>> AnyStartWitha = (list) =>
        list.Any(x => x.StartsWith("a"));*/
        public static Func<List<string>,bool> StartWith = (list) =>
        list.Any (x => x.Contains("a"));


        public static Func<List<string>, bool> IsEmpty = (list) =>
        list.Any(string.IsNullOrWhiteSpace);

        public static Func<List<string>, bool> AllContainca = (list) =>
        list.All(x => x.Contains("a"));
        
        public static Func<List<string>,List<string>> Uperr = (list) =>
        (from str  in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> Uperrs = (list) =>
        (from str in list where str.Length > 3 select str).ToList();

         


    }
}
