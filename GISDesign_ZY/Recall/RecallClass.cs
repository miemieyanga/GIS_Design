using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GISDesign_ZY
{
    /// <summary>
    /// 用于实现撤销功能
    /// </summary>
    public class RecallClass
    {
        /// <summary>
        /// 默认临时文件存储路径
        /// </summary>
        public string tempFilePath;
        /// <summary>
        /// 当前的状态ID
        /// </summary>
        public static int StateID = -1;

        public RecallClass(string path = "./temp")
        {
            tempFilePath = path;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                foreach (string d in Directory.GetFileSystemEntries(path))
                {
                    if (File.Exists(d))
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);//直接删除其中的文件 
                    }
                }
            }
        }

        /// <summary>
        /// 注册一个地图
        /// </summary>
        /// <param name="map"></param>
        public void Regist(MapManager map)
        {
            StateID += 1;
            string objString = ObjToString.ObjectToString(map);
            using(StreamWriter sw = new StreamWriter(tempFilePath+"/"+StateID.ToString()+".atp"))
            {
                sw.Write(objString);
            }

            //删除10次操作前的文件
            if (StateID > 10)
            {
                for (int i = 0; i < StateID - 10; i++)
                {
                    string curPath = tempFilePath + "/" + i.ToString() + ".atp";
                    File.Delete(curPath);//直接删除其中的文件 
                }
            }
        }

        /// <summary>
        /// 返回上一状态
        /// </summary>
        /// <returns></returns>
        public MapManager ReturnToLastState()
        {
            if (StateID <= 0)
                throw new Exception("没有上一状态");

            //返回上一状态
            StateID -= 1;
            MapManager map = new MapManager();
            using (StreamReader sr = new StreamReader(tempFilePath + "/" + StateID.ToString() + ".atp"))
            {
                string objString = sr.ReadToEnd();
                map = ObjToString.StringToObject<MapManager>(objString);
            }
            return map;
        }

        public int GetCurStateID()
        {
            return StateID;
        }

        public bool IsValid()
        {
            string curPath = tempFilePath + "/" + (StateID-1).ToString() + ".atp";
            return File.Exists(curPath);
        }
    }
}
