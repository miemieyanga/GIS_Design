﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    public abstract class Projection
    {
        abstract public PointD LngLatToXY(PointD coordinate);
        abstract public PointF LngLatToXY(PointF coordinate);
        abstract public PointD XYToLngLat(PointD coordinate);
        abstract public PointF XYToLngLat(PointF coordinate);
    }

    /// <summary>
    /// 等距切圆柱投影
    /// </summary>
    public class ProjectionETC:Projection
    {
        const double a = 6378137, b = 6356752;
        const double alpha = a;
        const double e2 = (a * a - b * b) / (a * a);
        const double center = 110;
        static double e = Math.Sqrt(e2);

        /// <summary>
        /// 经纬度坐标转XY坐标
        /// </summary>
        public override PointD LngLatToXY(PointD coordinate)
        {
            double x = LongitudeToX(coordinate.X);
            double y = LatitudeToY(coordinate.Y);
            return new PointD(x, y);
        }

        /// <summary>
        /// 经纬度坐标转XY坐标
        /// </summary>
        public override PointF LngLatToXY(PointF coordinate)
        {
            float x = (float)LongitudeToX(coordinate.X);
            float y = (float)LatitudeToY(coordinate.Y);
            return new PointF(x, y);
        }

        /// <summary>
        /// XY坐标转经纬度坐标
        /// </summary>
        public override PointD XYToLngLat(PointD coordinate)
        {
            double lng = XToLongitude(coordinate.X);
            double lat = YToLatitude(coordinate.Y);
            return new PointD(lng, lat);
        }

        /// <summary>
        /// XY坐标转经纬度坐标
        /// </summary>
        public override PointF XYToLngLat(PointF coordinate)
        {
            float lng = (float)XToLongitude(coordinate.X);
            float lat = (float)YToLatitude(coordinate.Y);
            return new PointF(lng, lat);
        }

        public static double LatitudeToY(double latitude)
        {
            double laRad = DegToRad(latitude);
            double y = 0.5 * a * (1 - e2) / e
                   * (e * Math.Sin(laRad) / (1 - e2 * Math.Sin(laRad) * Math.Sin(laRad))
                   + Math.Log((1 + e * Math.Sin(laRad)) / Math.Sqrt(1 - e2 * Math.Sin(laRad) * Math.Sin(laRad)), Math.E));
            return y;
        }

        public static double LongitudeToX(double longitude)
        {
            double lamda = DegToRad(longitude - center);
            double x = alpha * lamda;
            return x;
        }

        public static double YToLatitude(double y)
        {
            double laRad = Division(y, 10e-7);
            double latitude = RadToDeg(laRad);
            return latitude;
        }

        public static double XToLongitude(double x)
        {
            double longitude = RadToDeg(x / alpha) + center;
            return longitude;
        }

        /// <summary>
        /// 角度制转弧度制
        /// </summary>
        static double DegToRad(double degree)
        {
            return degree / 180 * Math.PI;
        }

        /// <summary>
        /// 弧度制转角度
        /// </summary>
        static double RadToDeg(double radian)
        {
            return radian * 180 / Math.PI;
        }

        /// <summary>
        /// 二分法
        /// </summary>
        static double Division(double y0, double error)
        {
            double lower = 0;
            double upper = Math.PI / 2;
            double mid = -1;

            while ((upper - lower) > error)
            {
                mid = (lower + upper) / 2;
                if (F(mid, y0) * F(lower, y0) < 0)
                    upper = mid;
                else if (F(mid, y0) * F(upper, y0) < 0)
                    lower = mid;
                else
                    return mid;
            }
            return mid;
        }

        static double F(double x)
        {
            double y = 0.5 * a * (1 - e2) / e
                   * (e * Math.Sin(x) / (1 - e2 * Math.Sin(x) * Math.Sin(x))
                   + Math.Log((1 + e * Math.Sin(x)) / Math.Sqrt(1 - e2 * Math.Sin(x) * Math.Sin(x)), Math.E));
            return y;
        }

        static double F(double x, double y0)
        {
            double phi = 0.5 * a * (1 - e2) / e
                   * (e * Math.Sin(x) / (1 - e2 * Math.Sin(x) * Math.Sin(x))
                   + Math.Log((1 + e * Math.Sin(x)) / Math.Sqrt(1 - e2 * Math.Sin(x) * Math.Sin(x)), Math.E)) - y0;
            return phi;
        }
    }
}