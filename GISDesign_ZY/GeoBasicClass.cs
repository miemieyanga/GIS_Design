using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryIofly
{
    /// <summary>
    /// 点
    /// </summary>
    /// 
    [Serializable]
    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public bool isInBox(RectangleD rec)
        {
            if (X >= rec.MinX & X <= rec.MaxX & Y >= rec.MinY & Y <= rec.MaxY)
                return true;
            else
                return false;
        }

        public double Distance(PointD point)
        {
            double distance = Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
            return distance;
        }

        public bool isNearPoint(PointD point, double tolerance)
        {
            double distance = Distance(point);
            if (distance <= tolerance)
                return true;
            else return false;
        }


    }

    /// <summary>
    /// 圆
    /// </summary>
    /// 
    [Serializable]
    public class Circle
    {
        public PointD center { get; set; }
        public double R { get; set; }

        public Circle(PointD ct, double r)
        {
            center = ct;
            R = r;
        }
    }

    /// <summary>
    /// 矩形
    /// </summary>
    /// 
    [Serializable]
    public class RectangleD
    {
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double MaxX{ get; set; }
        public double MaxY{ get; set; }


        public RectangleD(double minX, double minY, double maxX, double maxY)
        {
            if (minX > maxX || minY > maxY)
            {
                throw new Exception("Invalid Rectangle");
            }
            else
            {
                MinX = minX;
                MinY = minY;
                MaxX = maxX;
                MaxY = maxY;
            }
        }

        public double Width
        {
            get { return MaxX - MinX; }
        }
        public double Height
        {
            get { return MaxY - MinY; }
        }
    }


    /// <summary>
    /// 多边形
    /// </summary>
    /// 
    [Serializable]
    public class Polygon
    {
        public PointD[] points
        {
            get
            {
                return _points.ToArray();
            }
            set
            {
                _points = value.ToList();
            }
        }
        private List<PointD> _points = new List<PointD>(); //顶点集合
        public double MinX, MinY, MaxX, MaxY;


        public Polygon() { }

        public Polygon(PointD[] pts)
        {
            _points.AddRange(pts);
            points = pts;
        }

        /// <summary>
        /// 获取顶点数目
        /// </summary>
        public Int32 PointCount
        {
            get { return _points.Count; }
        }

        /// <summary>
        /// 选择顶点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PointD GetPointD(int index)
        {
            return _points[index];
        }

        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(PointD point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// 返回外包矩形
        /// </summary>
        /// <returns></returns>
        public RectangleD GetEnvelope()
        {
            double tempMaxx = _points[0].X, tempMinx = _points[0].X;
            double tempMaxy = _points[0].Y, tempMiny = _points[0].Y;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X >= tempMaxx)
                {
                    tempMaxx = _points[i].X;
                }
                if (_points[i].X <= tempMinx)
                {
                    tempMinx = _points[i].X;
                }
                if (_points[i].Y >= tempMaxy)
                {
                    tempMaxy = _points[i].Y;
                }
                if (_points[i].Y <= tempMiny)
                {
                    tempMiny = _points[i].Y;
                }
            }
            RectangleD envelope = new RectangleD(tempMinx, tempMiny, tempMaxx, tempMaxy);
            return envelope;
        }

        /// <summary>
        /// 计算并返回面积
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double allArea = 0;
            double tempArea = 0;
            List<PointD> tempPts = new List<PointD>();
            int sPointCount = _points.Count;
            for (int i = 0; i < sPointCount; i++) //以第一个顶点作为原点，更新坐标系方便运算
            {
                PointD tempPt = new PointD(_points[i].X - _points[0].X, _points[i].Y - _points[0].Y);
                tempPts.Add(tempPt);
            }
            for (int i = 1; i < sPointCount - 1; i++) //向量叉乘算面积
            {
                tempArea = 0.5 * (tempPts[i].X * tempPts[i + 1].Y - tempPts[i + 1].X * tempPts[i].Y);
                allArea += tempArea;
            }
            allArea = Math.Abs(allArea);
            return allArea;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }


        /// <summary>
        /// 复制多边形
        /// </summary>
        /// <returns></returns>
        public Polygon Clone()
        {
            Polygon sPolygon = new Polygon();
            int sPointCount = _points.Count;
            for (int i = 0; i < sPointCount; i++)
            {
                PointD sPoint = new PointD(_points[i].X, _points[i].Y);
                sPolygon.AddPoint(sPoint);
            }

            return sPolygon;
        }

        /// <summary>
        /// 判断是否在指定矩形内
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool isInBox(RectangleD rec)
        {
            RectangleD envelope = GetEnvelope();
            if (envelope.MinX >= rec.MinX & envelope.MaxX <= rec.MaxX & envelope.MinY >= rec.MinY & envelope.MaxY <= rec.MaxY)
                return true;
            else return false;
        }

        /// <summary>
        /// 判断是否包含点
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public bool isContainPoint(PointD checkPoint)
        { 
            List<PointD> polygonPoints = _points;

            bool inside = false;
            int pointCount = polygonPoints.Count;
            PointD p1, p2;
            for (int i = 0, j = pointCount - 1; i < pointCount; j = i, i++)//第一个点和最后一个点作为第一条线，之后是第一个点和第二个点作为第二条线，之后是第二个点与第三个点，第三个点与第四个点...
            {
                p1 = polygonPoints[i];
                p2 = polygonPoints[j];
                if (checkPoint.Y < p2.Y)
                {//p2在射线之上
                    if (p1.Y <= checkPoint.Y)
                    {//p1正好在射线中或者射线下方
                        if ((checkPoint.Y - p1.Y) * (p2.X - p1.X) > (checkPoint.X - p1.X) * (p2.Y - p1.Y))//斜率判断,在P1和P2之间且在P1P2右侧
                        {
                            //射线与多边形交点为奇数时则在多边形之内，若为偶数个交点时则在多边形之外。
                            //由于inside初始值为false，即交点数为零。所以当有第一个交点时，则必为奇数，则在内部，此时为inside=(!inside)
                            //所以当有第二个交点时，则必为偶数，则在外部，此时为inside=(!inside)
                            inside = (!inside);
                        }
                    }
                }
                else if (checkPoint.Y < p1.Y)
                {
                    //p2正好在射线中或者在射线下方，p1在射线上
                    if ((checkPoint.Y - p1.Y) * (p2.X - p1.X) < (checkPoint.X - p1.X) * (p2.Y - p1.Y))//斜率判断,在P1和P2之间且在P1P2右侧
                    {
                        inside = (!inside);
                    }
                }
            }
            return inside;

        }

    }


    /// <summary>
    /// 多个多边形
    /// </summary>
    /// 
    [Serializable]
    public class MultiPolygon
    {
        public Polygon[] polygons { get; set; }
        private List<Polygon> _polygons = new List<Polygon>(); //多边形集合
        public double MinX, MinY, MaxX, MaxY;


        public MultiPolygon() { }

        public MultiPolygon(Polygon[] pgs)
        {
            _polygons.AddRange(pgs);
            polygons = pgs;
        }

        /// <summary>
        /// 返回多边形数目
        /// </summary>
        /// <returns></returns>
        public Int32 PolygonCount()
        {
            return _polygons.Count;
        }

        /// <summary>
        /// 选择多边形
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Polygon GetPolygon(int index)
        {
            return _polygons[index];
        }

        /// <summary>
        /// 添加多边形
        /// </summary>
        /// <param name="pg"></param>
        public void AddPolygon(Polygon pg)
        {
            _polygons.Add(pg);
        }


        /// <summary>
        /// 返回外包矩形
        /// </summary>
        /// <returns></returns>
        public RectangleD GetEnvelope()
        {
            int sPolygonCount = _polygons.Count;
            RectangleD envelope = _polygons[0].GetEnvelope();
            for (int i = 0; i < sPolygonCount; i++)
            {
                RectangleD tempRec = _polygons[i].GetEnvelope();
                if (tempRec.MaxX >= envelope.MaxX)
                    envelope.MaxX = tempRec.MaxX;
                if (tempRec.MinX <= envelope.MinX)
                    envelope.MinX = tempRec.MinX;
                if (tempRec.MaxY >= envelope.MaxY)
                    envelope.MaxY = tempRec.MaxY;
                if (tempRec.MinY <= envelope.MinY)
                    envelope.MinY = tempRec.MinY;
            }
            return envelope;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _polygons.Clear();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public MultiPolygon Clone()
        {
            MultiPolygon multiPolygon = new MultiPolygon();
            int sPolygonCount = _polygons.Count;
            for (int i = 0; i < sPolygonCount; i++)
            {
                Polygon sPolygon = _polygons[i].Clone();
                multiPolygon.AddPolygon(sPolygon);
            }
            return multiPolygon;
        }


        /// <summary>
        /// 判断是否在指定矩形内
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool isInBox(RectangleD rec)
        {
            RectangleD envelope = GetEnvelope();
            if (envelope.MinX >= rec.MinX & envelope.MaxX <= rec.MaxX & envelope.MinY >= rec.MinY & envelope.MaxY <= rec.MaxY)
                return true;
            else return false;
        }


        /// <summary>
        /// 判断是否包含点
        /// </summary>
        /// <param name="checkPoint"></param>
        /// <returns></returns>
        public bool isContainPoint(PointD checkPoint)
        {
            bool isContain = false;
            for(int i=0;i<_polygons.Count;i++)
            {
                if(_polygons[i].isContainPoint(checkPoint)==true)
                {
                    isContain = true;
                    return isContain;
                }
            }
            return isContain;
        }

    }


    /// <summary>
    /// 线
    /// </summary>
    /// 
    [Serializable]
    public class Polyline
    {
        public PointD[] points {
            get
            {
                return _points.ToArray();
            }
            set
            {
                _points = value.ToList();
            }
        }
        private List<PointD> _points = new List<PointD>(); //顶点集合
        public double MinX, MinY, MaxX, MaxY;

        public Polyline() { }

        public Polyline(PointD[] pts)
        {
            _points.AddRange(pts);
            points = pts;
        }

        /// <summary>
        /// 获取顶点数目
        /// </summary>
        public Int32 PointCount
        {
            get { return _points.Count; }
        }

        /// <summary>
        /// 选择顶点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PointD GetPointD(int index)
        {
            return _points[index];
        }

        /// <summary>
        /// 添加点
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(PointD point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// 返回外包矩形
        /// </summary>
        /// <returns></returns>
        public RectangleD GetEnvelope()
        {
            double tempMaxx = _points[0].X, tempMinx = _points[0].X;
            double tempMaxy = _points[0].Y, tempMiny = _points[0].Y;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X >= tempMaxx)
                {
                    tempMaxx = _points[i].X;
                }
                if (_points[i].X <= tempMinx)
                {
                    tempMinx = _points[i].X;
                }
                if (_points[i].Y >= tempMaxy)
                {
                    tempMaxy = _points[i].Y;
                }
                if (_points[i].Y <= tempMiny)
                {
                    tempMiny = _points[i].Y;
                }
            }
            RectangleD envelope = new RectangleD(tempMinx, tempMiny, tempMaxx, tempMaxy);
            return envelope;
        }

        /// <summary>
        /// 返回线的长度
        /// </summary>
        /// <returns></returns>
        public double GetLength()
        {
            int sPointCount = _points.Count;
            double tempLen = 0;
            double allLen = 0;
            for (int i = 0; i < sPointCount - 1; i++)
            {
                tempLen = (_points[i].X - points[i + 1].X) * (_points[i].X - points[i + 1].X) + (_points[i].Y - points[i + 1].Y) * (_points[i].Y - points[i + 1].Y);
                tempLen = Math.Sqrt(tempLen);
                allLen += tempLen;
            }
            return allLen;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }


        /// <summary>
        /// 复制线
        /// </summary>
        /// <returns></returns>
        public Polyline Clone()
        {
            Polyline sPolyline = new Polyline();
            int sPointCount = _points.Count;
            for (int i = 0; i < sPointCount; i++)
            {
                PointD sPoint = new PointD(_points[i].X, _points[i].Y);
                sPolyline.AddPoint(sPoint);
            }

            return sPolyline;
        }


        /// <summary>
        /// 判断是否在指定矩形内
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool isInBox(RectangleD rec)
        {
            RectangleD envelope = GetEnvelope();
            if (envelope.MinX >= rec.MinX & envelope.MaxX <= rec.MaxX & envelope.MinY >= rec.MinY & envelope.MaxY <= rec.MaxY)
                return true;
            else return false;
        }

        /// <summary>
        /// 判断是否邻近点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool isNearPoint(PointD point, double tolerance)
        {
            
            for(int i=0;i<_points.Count-1;i++)
            {
                double dis = 0;
                PointD p1 = _points[i];
                PointD p2 = _points[i + 1];
                PointD ac = new PointD(point.X - p1.X, point.Y - p1.Y);
                PointD ab = new PointD(p2.X - p1.X, p2.Y - p1.Y);
                double ab2 = p1.Distance(p2) * p1.Distance(p2);
                double f = (point.X - p1.X) * (p2.X - p1.X) + (point.Y - p1.Y) * (p2.Y - p1.Y);
                if(f<0)
                    dis = point.Distance(p1);
                else if(f>ab2)
                    dis = point.Distance(p2);
                else
                {
                    f = f / ab2;
                    PointD d = new PointD(p1.X + (f * ab.X), p1.Y + (f * ab.Y));
                    dis = point.Distance(d);
                }
                    
                if(dis<=tolerance)
                {
                    return true;
                }
            }
            return false;
        }

    }


    /// <summary>
    /// 多条线
    /// </summary>
    /// 
    [Serializable]
    public class MultiPolyline
    {
        public Polyline[] polylines { get; set; }
        private List<Polyline> _polylines = new List<Polyline>(); //多边形集合
        public double MinX, MinY, MaxX, MaxY;


        public MultiPolyline() { }

        public MultiPolyline(Polyline[] pls)
        {
            _polylines.AddRange(pls);
            polylines = pls;
        }

        /// <summary>
        /// 返回线的数目
        /// </summary>
        /// <returns></returns>
        public Int32 PolylineCount()
        {
            return _polylines.Count;
        }

        /// <summary>
        /// 选择线
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Polyline GetPolyline(int index)
        {
            return _polylines[index];
        }

        /// <summary>
        /// 添加线
        /// </summary>
        /// <param name="pl"></param>
        public void AddPolyline(Polyline pl)
        {
            _polylines.Add(pl);
        }


        /// <summary>
        /// 返回外包矩形
        /// </summary>
        /// <returns></returns>
        public RectangleD GetEnvelope()
        {
            int sPolylineCount = _polylines.Count;
            RectangleD envelope = _polylines[0].GetEnvelope();
            for (int i = 0; i < sPolylineCount; i++)
            {
                RectangleD tempRec = _polylines[i].GetEnvelope();
                if (tempRec.MaxX >= envelope.MaxX)
                    envelope.MaxX = tempRec.MaxX;
                if (tempRec.MinX <= envelope.MinX)
                    envelope.MinX = tempRec.MinX;
                if (tempRec.MaxY >= envelope.MaxY)
                    envelope.MaxY = tempRec.MaxY;
                if (tempRec.MinY <= envelope.MinY)
                    envelope.MinY = tempRec.MinY;
            }
            return envelope;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _polylines.Clear();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public MultiPolyline Clone()
        {
            MultiPolyline multiPolyline = new MultiPolyline();
            int sPolylineCount = _polylines.Count;
            for (int i = 0; i < sPolylineCount; i++)
            {
                Polyline sPolyline = _polylines[i].Clone();
                multiPolyline.AddPolyline(sPolyline);
            }
            return multiPolyline;
        }


        /// <summary>
        /// 判断是否在指定矩形内
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool isInBox(RectangleD rec)
        {
            RectangleD envelope = GetEnvelope();
            if (envelope.MinX >= rec.MinX & envelope.MaxX <= rec.MaxX & envelope.MinY >= rec.MinY & envelope.MaxY <= rec.MaxY)
                return true;
            else return false;
        }


        /// <summary>
        /// 判断是否邻近点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool isNearPoint(PointD point, double tolerance)
        {
            for(int i=0;i<_polylines.Count;i++)
            {
                if (_polylines[i].isNearPoint(point, tolerance) == true)
                    return true;
            }
            return false;
        }

    }

}
