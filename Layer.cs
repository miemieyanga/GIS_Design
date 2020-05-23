using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    class Layer
    {
        #region 字段

        public string Name;
        public string Descript;
        public FeatureTypeConstant FeatureType;
        public bool Visible;
        public bool Selectable;

        /// <summary>
        /// 渲染器
        /// </summary>
        public Renderer MRenderer;

        /// <summary>
        /// 标注渲染器
        /// </summary>
        // public LabelRenderer MLabelRender;

        /// <summary>
        /// 地理数据集
        /// </summary>
        public GeoRecordset MRecords;

        /// <summary>
        /// 数据输入输出模块
        /// </summary>
        public GeoDataIO MGeoDataIO;

        private double _MinX,_MinY,_MaxX,_MaxY;
        #endregion

        #region 属性

        public double MinX
        {
            get { return _MinX;}
        }
        public double MinY
        {
            get { return _MinY; }
        }
        public double MaxX
        {
            get { return _MaxX; }
        }
        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion

        #region 方法

        public Layer(string name, string descript = "")
        {
            Name = name;
            Descript = descript;
            Visible = true;
            Selectable = false;
            MRecords = new GeoRecordset();
            MGeoDataIO = new GeoDataIO();
        }

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        public Rectangle GetExtent()
        {
            return new Rectangle();
        }

        #endregion
    }
}
