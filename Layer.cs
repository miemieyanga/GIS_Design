using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public Renderer MRender;

        // public LabelRenderer MLabelRender;
        // public GeoRecordSet MRecords;

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
