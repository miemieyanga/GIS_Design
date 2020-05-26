using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    public class Layer
    {
        #region 字段

        public string Name;
        public string Descript;
        public FeatureTypeConstant FeatureType;
        public string FeatureTypeString;
        public string DataSource;
        public bool Visible;
        public bool Selectable;

        /// <summary>
        /// 渲染器
        /// </summary>
        public Renderer MRenderer;

        /// <summary>
        /// 标注渲染器
        /// </summary>
        public LabelRenderer MLabelRender;

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

        public Layer(string name, string descript = "",string dataSource = "")
        {
            Name = name;
            Descript = descript;
            DataSource = dataSource;
            Visible = true;
            Selectable = false;
            MRenderer = new SimpleRenderer();
            MRecords = new GeoRecordset();
            MGeoDataIO = new GeoDataIO();
            MLabelRender = new LabelRenderer();
            _MinX = _MinY = _MaxX = _MaxY = 0;
        }

        /// <summary>
        /// 设置外包多边形
        /// </summary>
        internal void SetExtent(double minX,double minY,double maxX, double maxY)
        {
            _MinX = minX;
            _MinY = minY;
            _MaxX = maxX;
            _MaxY = maxY;
        }

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        public RectangleF GetExtent()
        {
            
            return new RectangleF((float)_MinX, (float)_MinY,
                (float)(_MaxX-_MinX), (float)(_MaxY-MinY));
        }

        /// <summary>
        /// 获取点要素的注记位置,接收的是屏幕坐标
        /// </summary>
        private PointF GetLabelPositionOfPointD(PointF pointOfScreen, string labelString)
        {
            double xBias = - labelString.Length * MLabelRender.MTextSymbol.FontSize / 2;
            double yBisa = - MLabelRender.MTextSymbol.FontSize / 2;
            return new PointF((float)(pointOfScreen.X + MLabelRender.MTextSymbol.OffsetX +xBias), 
                (float)(pointOfScreen.Y + MLabelRender.MTextSymbol.OffsetY + yBisa));
        }

        /// <summary>
        /// 获取线要素的注记位置数组，每个点定位一个字符
        /// </summary>
        private PointF[] GetLabelPositionOfPolyline(PointF[] pointsOfScreen, string labelString)
        {
            int lenOfString = labelString.Length;
            List<double> totalDis = new List<double>();  //累计距离
            double sum = 0;
            for(int i=0;i< pointsOfScreen.Length-1;i++)
            {
                float x1 = pointsOfScreen[i].X;
                float y1 = pointsOfScreen[i].Y;
                float x2 = pointsOfScreen[i + 1].X;
                float y2 = pointsOfScreen[i + 1].Y;
                double curRes = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
                sum += curRes;
                totalDis.Add(sum);
            }
            //掐头去尾，剩下的区域均匀分布
            double wordDis = totalDis[totalDis.Count - 1] / lenOfString + 2;  //每个字之间的距离

            List<PointF> res = new List<PointF>();  //结果
            //计算每个字的位置
            double curTotalDis = 0;  //当前字累加的距离
            int tempIndex = 0;
            for(int i = 0; i < lenOfString; i++)
            {
                if (i == 0)
                {
                    while (totalDis[tempIndex] < wordDis)
                    {
                        tempIndex += 1;
                    }
                }

                while (curTotalDis < wordDis)
                {
                    tempIndex += 1;
                    curTotalDis = totalDis[tempIndex] - wordDis * (i + 1);
                }

                //计算位置
                float X = pointsOfScreen[tempIndex].X + pointsOfScreen[tempIndex + 1].X / 2;
                float Y = pointsOfScreen[tempIndex].Y + pointsOfScreen[tempIndex + 1].Y / 2;

                res.Add(new PointF(X, Y));
                curTotalDis = 0;
            }
            return res.ToArray();
        }

        /// <summary>
        /// 获取多边形要素的注记位置数组
        /// </summary>
        private PointF GetLabelPositionOfPolygon(PointF[] polygonOfScreen, string labelString)
        {
            /*
            //先判断几何中心是不是在多边形内，如果不在就旋转多边形，直到找到位置
            double aph = 0;
            PointF geoCenter = GetGeoCenter(polygonOfScreen);
            PointF labelLocation = GetCenterOfMBR(polygonOfScreen);  //标注位置
            PointF[] polygonRotated = polygonOfScreen;
            while (!IsInPolygon(polygonRotated, labelLocation))
            {
                polygonRotated = RotateAndCreateNewPolygon(polygonOfScreen,geoCenter,aph);
                labelLocation = GetCenterOfMBR(polygonRotated);

                aph += 5;
                if (aph == 360)
                {
                    aph += 5;
                    break;
                }
            }
            aph -= 5;
            MLabelRender.MTextSymbol.Angle = -aph;
            */
            PointF point = GetGeoCenter(polygonOfScreen);
            point.X -= labelString.Length * MLabelRender.MTextSymbol.FontSize / 2;
            point.Y += MLabelRender.MTextSymbol.FontSize / 2;
            return point;
        }
        
        //获取多边形外包矩形中心
        private PointF GetCenterOfMBR(PointF[] polygon)
        {
            float minX = polygon[0].X, minY = polygon[0].Y, 
                maxX = polygon[0].X, maxY = polygon[0].Y;
            foreach(PointF point in polygon)
            {
                if (point.X < minX)
                    minX = point.X;
                if (point.X > maxX)
                    maxX = point.X;
                if (point.Y < minY)
                    minY = point.Y;
                if (point.Y > maxY)
                    maxY = point.Y;
            }
            return new PointF((maxX - minX) / 2, (maxY - minY) / 2);
        }

        //顺时针旋转多边形
        private PointF[] RotateAndCreateNewPolygon(PointF[] polygon, PointF center, double aph)
        {
            List<PointF> res = new List<PointF>();
            foreach(PointF point in polygon)
            {
                res.Add(RotatePointF(point, center, aph));
            }
            return res.ToArray();
        }

        // 求多边形几何中心
        private PointF GetGeoCenter(PointF[] points)
        {
            float sumX = 0;
            float sumY = 0;
            int cnt = points.Length;
            foreach(PointF p in points)
            {
                sumX += p.X;
                sumY += p.Y;
            }
            return new PointF(sumX/cnt,sumY/cnt);
        }

        //围绕一个中心顺时针旋转一个点
        private PointF RotatePointF(PointF point, PointF center, double aph)
        {
            PointF res = new PointF();

            res.X =(float)((point.X - center.X) * Math.Cos(-aph/180*Math.PI) - 
                (point.Y - center.Y) * Math.Sin(-aph / 180 * Math.PI) + center.X);

            res.Y =(float)((point.X - center.X) * Math.Sin(-aph / 180 * Math.PI) + 
                (point.Y - center.Y) * Math.Cos(-aph / 180 * Math.PI) + center.Y);
            return res;
        }

        //判断点是否在多边形内
        private bool IsInPolygon(PointF[] points, PointF point)
        {
            bool result = false;

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (IsIntersect(point, points[i], points[i + 1]) == true)
                    result = !result;
            }
            if (IsIntersect(point, points[points.Length - 1], points[0]) == true)
                result = !result;
            return result;
        }

        // 判断指定点向右射线与指定线段是否相交
        private static bool IsIntersect(PointF target, PointF p1, PointF p2)
        {
            double x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
            if (target.Y > Math.Max(y1, y2) || target.Y < Math.Min(y1, y2))
                return false;
            if (y1 == y2)
                return false;
            double k = (x2 - x1) / (y2 - y1);
            double x = k * (target.Y - y1) + x1;
            if (x < target.X)  //交点在射线左边
                return false;
            if (x < Math.Min(x1, x2) || x > Math.Max(x1, x2))
                return false;
            return true;
        }
        #endregion
    }
}
