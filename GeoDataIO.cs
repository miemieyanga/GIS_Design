using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryIofly
{
    class GeoDataIO
    {
        public bool SaveToBitMap(string filename, GeoRecordset geoset)
        {
            return true;
        }

        public GeoRecordset OpenShapeFile(string filename)
        {
            return new GeoRecordset();
        }
    }
}
