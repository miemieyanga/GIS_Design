using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    /// <summary>
    /// 标注类
    /// </summary>
    public class MapLabel
    {
        public Bitmap bitmap;
        private Graphics g;

        public MapLabel(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
        }

        public void DrawLabelOfLayer(Layer layer)
        {
            Font font = new Font("黑体", 9);
            g.DrawString(layer.Name, font, new SolidBrush(Color.Black),
                new PointF(bitmap.Width/2- layer.Name.Length*4.5f,0));
            RectangleF curBox = new RectangleF(0, 12 , bitmap.Width, bitmap.Height-12);
            switch (layer.MRenderer.Type)
            {
                case RendererType.SimpleRenderer:
                    AddSimpleRenderer((SimpleRenderer)layer.MRenderer, curBox);
                    break;
                case RendererType.UniqueValueRenderer:
                    AddUniqueValueRenderer((UniqueValueRenderer)layer.MRenderer, curBox);
                    break;
                case RendererType.ClassBreaksRenderer:
                    AddClassBreakRenderer((ClassBreaksRenderer)layer.MRenderer, curBox);
                    break;
            }
        }

        /// <summary>
        /// 添加分级设色渲染器标注
        /// </summary>
        public void AddClassBreakRenderer(ClassBreaksRenderer renderer, RectangleF rectangle)
        {
            renderer.colorRamp.DrawRamp(g, new Rectangle((int)rectangle.X+10, (int)rectangle.Y,
                (int)rectangle.Width-20, (int)rectangle.Height / 2));
            Font font = new Font("宋体", 9);
            g.DrawString(renderer.breaks[0].ToString(), font, new SolidBrush(Color.Black),
                new PointF(rectangle.X, rectangle.Y));
            g.DrawString(renderer.breaks[renderer.breaks.Count-1].ToString(), font, new SolidBrush(Color.Black),
                new PointF(rectangle.X + rectangle.Width-9, rectangle.Y));
            g.DrawString(renderer.Field, font, new SolidBrush(Color.Black),
                new PointF(rectangle.X + rectangle.Width / 2 - renderer.Field.Length * 4.5f, rectangle.Y + rectangle.Height / 2));
        }

        /// <summary>
        /// 添加简单渲染器标注
        /// </summary>
        /// <param name="renderer"></param>
        public void AddSimpleRenderer(SimpleRenderer renderer, RectangleF rectangle)
        {
            DrawSymbol.DrawAnySymbol(g, renderer.MSymbol,
                new RectangleF(rectangle.X, rectangle.Y, rectangle.Width / 2, rectangle.Height));
            Font font = new Font("宋体", 9);
            g.DrawString(renderer.fieldLabel,font,new SolidBrush(Color.Black),
                new PointF(rectangle.X + rectangle.Width / 2, rectangle.Y+rectangle.Height/2-4.5f));
        }

        /// <summary>
        /// 添加唯一值渲染器标注
        /// </summary>
        /// <param name="renderer"></param>
        public void AddUniqueValueRenderer(UniqueValueRenderer renderer, RectangleF rectangle)
        {

        }
    }
}
