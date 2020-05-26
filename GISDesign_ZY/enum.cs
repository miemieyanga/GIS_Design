using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISDesign_ZY
{
    public enum SymbolType
    {
        SimpleMarkerSymbol, SimpleLineSymbol,
        SimpleFillSymbol, HatchFillSymbol
    }

    public enum MarkerStyleConstant
    {
        MCircle, MSolidCircle, MRectengle,
        MSolidRectengle, MTriangle, MSolidTriangle,
        MDotCircle, MDoubleCircle
    }

    public enum LineStyleConstant
    {
        LSolid, LDash, LDot, LDashDot, LDashDotDash
    }

    public enum FillStyleConstant
    {
        FColor, FTransparent
    }

    public enum HatchStyleConstant
    {
        HLine, HDot, HCrossLine
    }

    public enum RendererType
    {
        SimpleRenderer, UniqueValueRenderer,
        ClassBreaksRenderer
    }

    public enum FeatureTypeConstant
    {
        PointD, Polyline, Polygon, MultiPolygon, MultiPolyline
    }

    public enum ProjectionType
    {
        ETC,None
    }

    public enum CoordinateType
    {
        WGS84,None
    }
}
