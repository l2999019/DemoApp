using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoApp.HTTPClientDemo
{
    public static class JsonToDictionary
    {
        /// <summary> 
        /// Json格式转换成键值对，键值对中的Key需要区分大小写 
        /// </summary> 
        /// <param name="JsonData">需要转换的Json文本数据</param> 
        /// <returns></returns> 
        public static Dictionary<string, string> ToDictionary(string JsonData)
        {
            object Data = null;
            Dictionary<string, string> Dic = new Dictionary<string, string>();
            if (JsonData.StartsWith("["))
            {
                //如果目标直接就为数组类型，则将会直接输出一个Key为List的List<Dictionary<string, object>>集合 
                //使用示例List<Dictionary<string, object>> ListDic = (List<Dictionary<string, object>>)Dic["List"]; 
                List<Dictionary<string, string>> List = new List<Dictionary<string, string>>();
                MatchCollection ListMatch = Regex.Matches(JsonData, @"{[\s\S]+?}");//使用正则表达式匹配出JSON数组 
                foreach (Match ListItem in ListMatch)
                {
                    List.Add(ToDictionary(ListItem.ToString()));//递归调用 
                }
                Data = List;
                Dic.Add("List", Data.ToString());
            }
            else
            {
                MatchCollection Match = Regex.Matches(JsonData, @"""(.+?)"": {0,1}(\[[\s\S]+?\]|null|"".+?""|-{0,1}\d*)");//使用正则表达式匹配出JSON数据中的键与值 
                foreach (Match item in Match)
                {
                    try
                    {
                        if (item.Groups[2].ToString().StartsWith("["))
                        {
                            //如果目标是数组，将会输出一个Key为当前Json的List<Dictionary<string, object>>集合 
                            //使用示例List<Dictionary<string, object>> ListDic = (List<Dictionary<string, object>>)Dic["Json中的Key"]; 
                            List<Dictionary<string, string>> List = new List<Dictionary<string, string>>();
                            MatchCollection ListMatch = Regex.Matches(item.Groups[2].ToString(), @"{[\s\S]+?}");//使用正则表达式匹配出JSON数组 
                            foreach (Match ListItem in ListMatch)
                            {
                                List.Add(ToDictionary(ListItem.ToString()));//递归调用 
                            }
                            Data = List;
                        }
                        else if (item.Groups[2].ToString().ToLower() == "null") Data = null;//如果数据为null(字符串类型),直接转换成null 
                        else Data = item.Groups[2].ToString(); //数据为数字、字符串中的一类，直接写入 
                        Dic.Add(item.Groups[1].ToString(), Data.ToString());
                    }
                    catch { }
                }
            }
            return Dic;
        }
    }
}
