using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    /// <summary>
    /// 渲染器工厂类
    /// </summary>
    static class RendererFactory
    {
        /// <summary>
        /// 生成一个简单渲染器
        /// </summary>
        /// <param name="symbol">图层符号样式</param>
        /// <returns></returns>
        static public SimpleRenderer CreateSimpleRenderer(Symbol symbol)
        {
            SimpleRenderer res = new SimpleRenderer();
            res.MSymbol = symbol;
            return res;
        }

        /// <summary>
        /// 生成一个唯一值渲染器
        /// </summary>
        /// <param name="recordset">地理数据集</param>
        /// <param name="mField">绑定字段名称</param>
        /// <param name="mSymbolType">渲染符号的类型</param>
        /// <returns></returns>
        static public UniqueValueRenderer CreateUniqueValueRenderer(GeoRecordset recordset, string mField, SymbolType mSymbolType)
        {
            UniqueValueRenderer res = new UniqueValueRenderer();
            res.Field = mField;
            Symbol cSymbol = SymbolFactory.CreateSymbol(mSymbolType);
            List<object>values = recordset.GetValuesByField(mField);
            foreach(var value in values)
            {
                res.AddValue(value.ToString(), cSymbol);
            }
            res.RandomColor(0, 0, 0, 255, 255, 255);
            res.DefaultSymbol = cSymbol;
            return res;
        }

        /// <summary>
        /// 生成一个分级渲染器
        /// </summary>
        /// <param name="recordset">地理数据集</param>
        /// <param name="mField">绑定字段名称,绑定字段需为浮点类型</param>
        /// <param name="mSymbolType">渲染符号的类型</param>
        /// <param name="count">分级数目</param>
        /// <returns></returns>
        static public ClassBreaksRenderer CreateClassBreaksRenderer(GeoRecordset recordset, string mField, SymbolType mSymbolType, int count)
        {
            ClassBreaksRenderer res = new ClassBreaksRenderer();
            res.Field = mField;
            Symbol cSymbol = SymbolFactory.CreateSymbol(mSymbolType);
            List<object> values = recordset.GetValuesByField(mField);
            double[] valuesInFields = new double[values.Count];
            for(int i=0;i<values.Count;i++)
            {
                valuesInFields[i] = (double)values[i];
            }
            double min = valuesInFields.Min();
            double max = valuesInFields.Max();
            for(double i = min-min/10; i < max; i += (max - min) / count)
            {
                res.AddBreak(i, cSymbol);
            }
            return res;
        }
    }
}
